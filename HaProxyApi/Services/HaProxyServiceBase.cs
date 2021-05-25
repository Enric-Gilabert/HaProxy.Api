﻿using HaProxyApi.Models;
using HaProxyApi.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using HaProxyApi.Services;

namespace HaProxyApi
{
    /// <summary>
    /// HaProxyServiceBase
    /// </summary>
    public class HaProxyServiceBase
    {

        protected IPEndPoint Endpoint = null;

        public IPAddress Address => Endpoint?.Address;

        public string HostName => Address == null ? "" : $"{Address}";
        
        public int Port => Endpoint?.Port ?? 0;
        
        #region .ctr
        /// <summary>
        /// .ctr 
        /// </summary>
        /// <param name="endpoint"></param>
        public HaProxyServiceBase(IPEndPoint endpoint)
        {
            string hostNameOrIp = endpoint?.Address == null ? null : $"{endpoint.Address}";
            int port = endpoint?.Port ?? 0;

            OnSettingIPEndpoint(hostNameOrIp,port);
        }
        /// <summary>
        /// .ctr
        /// </summary>
        /// <param name="hostNameOrIp"></param>
        /// <param name="port"></param>
        public HaProxyServiceBase(string hostNameOrIp, int port)
        {
            OnSettingIPEndpoint(hostNameOrIp, port);
        }

        #region OnSettingIPEndpoints(...)
        /// <summary>
        /// OnSettingIPEndpoint
        /// </summary>
        /// <param name="hostNameOrIp"></param>
        /// <param name="port"></param>
        protected void OnSettingIPEndpoint(string hostNameOrIp, int port)
        {
            var addresses = Dns.GetHostAddresses(hostNameOrIp);

            if (addresses.Length == 0)
            {
                throw new Exception("Unable to get the associated IP address.");
            }

            Endpoint = new IPEndPoint(addresses[0], port);
        } 
        #endregion  OnSettingIPEndpoints(...)

        #endregion  .ctr
        
        #region Send Command
        /// <summary>
        /// Sends the command a HAProxy
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="readAnswer">if set to <c>true</c> [read answer].</param>
        /// <returns></returns>
        /// <autogeneratedoc />
        public virtual string SendCommand(string command, bool readAnswer = true)
        {
            using (var client = new TcpClient(HostName, Port))
            using (var stream = client.GetStream())
            {
                var bytes = (Encoding.ASCII.GetBytes(command + "\n"));
                stream.Write(bytes, 0, bytes.Length);

                stream.ReadTimeout = 250;
                string result = null;
                if (readAnswer)
                {
                    byte[] data = new byte[1024];
                    using (var ms = new MemoryStream())
                    {
                        int numBytesRead;
                        while ((numBytesRead = stream.Read(data, 0, data.Length)) > 0)
                        {
                            ms.Write(data, 0, numBytesRead);
                        }
                        result = Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);
                    }
                }
                return result;
            }
        }
        #endregion  Send Command

        #region Help
        /// <summary>
        /// Lanza el comando help
        /// </summary>
        /// <returns></returns>
        public string Help() => SendCommand("help", true); 
        #endregion  Help

        #region Show Info
        /// <summary>
        /// Shows the information raw.
        /// </summary>
        /// <returns></returns>
        /// <autogeneratedoc />
        public string ShowInfoRaw() => SendCommand("show info", true);
        

        /// <summary>
        /// Shows the information.
        /// </summary>
        /// <returns></returns>
        /// <autogeneratedoc />
        public IShowInfoResponse ShowInfo() => new ShowInfoParser().Parse(ShowInfoRaw());

        #endregion  Show Info

        #region Show Errors 
        /// <summary>
        /// Shows the errors raw.
        /// </summary>
        /// <returns></returns>
        private string ShowErrorsRaw() =>  SendCommand("show errors", true);
        
        /// <summary>
        /// Shows the errors.
        /// </summary>
        /// <returns></returns>
        /// <autogeneratedoc />
        public IShowErrorResponse ShowErrors() => new ShowErrorParser().Parse(ShowErrorsRaw());

        #endregion  Show Errors

        #region Show Stat
        /// <summary>
        /// Shows the stat raw.
        /// </summary>
        /// <returns></returns>
        /// <autogeneratedoc />
        public string ShowStatRaw() => SendCommand("show stat", true);
        #endregion  Show Stat
        
        #region Show backed

        /// <summary>
        /// Shows the backends. Command: "show backend"
        /// </summary>
        /// <returns>Lista de Backend configurados</returns>
        public IEnumerable<Backend> ShowBackends() => SendCommand("show backend").ParseResponse<Backend>();
        #endregion  Show backed
        
        #region Show servers state [backend]
        /// <summary>
        /// Shows the backend servers.
        /// </summary>
        /// <param name="backend">The backend name. Ejemplos: show servers state </param>        
        /// <returns></returns>
        public IEnumerable<BackendServer> ShowBackendServers(string backend = null)
            => SendCommand($"show servers state  {backend}").ParseResponse<BackendServer>();
        #endregion  Show servers state [backend]


        #region Show Servers State and gets first who's name is equals to serverName
        /// <summary>
        /// Shows the backend server.
        /// </summary>
        /// <param name="backend">The backend name. Ejemplos: WEB_SERVER_TIER, WEB_SERVER_DEV_TIER </param>
        /// <param name="serverName">The server name. Ejemplos: ORQ1.5002, ORQ2.5002, ORQ1.5003, ORQ2.5003, etc </param>
        /// <returns></returns>
        public BackendServer ShowBackendServer(string backendName, string serverName)
            => ShowBackendServers(backendName)
                .FirstOrDefault(
                    (backendServer) =>
                        string.Equals(backendName, backendServer.BackendName, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(backendServer.Name, serverName, StringComparison.OrdinalIgnoreCase)
                        );


        #endregion  Show Servers State and gets first who's name is equals to serverName
        
        #region Show servers state and gest first who's name is equals to serverName
        /// <summary>
        /// Enables the server.
        /// </summary>
        /// <param name="backend">The backend name. Ejemplos: WEB_SERVER_TIER, WEB_SERVER_DEV_TIER </param>
        /// <param name="server">The server name. Ejemplos: ORQ1.5002, ORQ2.5002, ORQ1.5003, ORQ2.5003, etc </param>
        /// <returns></returns>
        /// <autogeneratedoc />
        public BackendServer EnableServer(string backendName, string serverName)
        {
            SendCommand($"enable server {backendName}/{serverName}");
            return ShowBackendServer(backendName, serverName);
        } 
        #endregion  Show servers state and gest first who's name is equals to serverName

        /// <summary>
        /// Disables the server.
        /// </summary>
        /// <param name="backend">The backend name </param>
        /// <param name="server">The server name </param>
        /// <returns></returns>
        public BackendServer DisableServer(string backend, string server)
        {
            SendCommand($"disable server {backend}/{server}");
            return ShowBackendServer(backend, server);
        }

        
        public BackendServer SetStateServerMantain(string backendName, string serverName)
        {
            SendCommand($"set server {backendName}/{serverName} state maint");
            return ShowBackendServer(backendName, serverName);

        }

        public BackendServer SetStateServerReady(string backendName, string serverName)
        {
            SendCommand($"set server {backendName}/{serverName} state ready");
            return ShowBackendServer(backendName, serverName);

        }


    }
}
