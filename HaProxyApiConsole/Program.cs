using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using HaProxyApi;

namespace HaProxyApiConsole
{
    class Program
    {

        private static string ToString(IDictionary<string, object> info, string typeName = null)
        {
            typeName = string.IsNullOrWhiteSpace(typeName) ? null : typeName;
            StringBuilder stringBuilder = new StringBuilder();

            if ((info?.Count ?? 0) > 0)
                foreach (var item in info)
                    stringBuilder.Append($"{item.Key}:{item.Value} ");

            string instanceValue = stringBuilder.Length > 0 ? stringBuilder.ToString() : null;

            return $"{typeName ?? ""} [ {instanceValue ?? "Is Null"} ]";
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //
            //  https://gist.github.com/haproxytechblog/f41c32952df3baa6536e95d515e03a20
            //---------------------------------------------------------------------------------
            var haProxy = new HaProxyServiceBase("172.16.12.225", 9999);


            string backedName = "WEBAPI.NFCReader";
            
            var bk2 = haProxy.SetStateServerMantain(backedName, "API.5002");
            var bk03 = haProxy.SetStateServerMantain(backedName, "API.5003");
            var bk04 = haProxy.SetStateServerMantain(backedName, "API.5004");

            Thread.Sleep(5000);

            bk2 = haProxy.SetStateServerReady(backedName, "API.5002");
            bk03 = haProxy.SetStateServerReady(backedName, "API.5003");
            bk04 = haProxy.SetStateServerReady(backedName, "API.5004");

            string help = haProxy.Help();

            Console.WriteLine(help);

            var errors = haProxy.ShowErrors();

            var info = haProxy.ShowInfo();

            var status = haProxy.ShowStat();

            foreach (var stat in status)
            {
                Console.WriteLine(ToString(stat, "="));
            }


            foreach (var backend in haProxy.ShowBackends())
            {

                foreach (var backendServer in haProxy.ShowBackendServers(backend.Name))
                {
                    var backendServerResult = haProxy.DisableServer(backendServer.BackendName, backendServer.Name);

                }
            }

            Thread.Sleep(3000);

            foreach (var backend in haProxy.ShowBackends())
            {

                foreach (var backendServer in haProxy.ShowBackendServers(backend.Name))
                {
                    var backendServerResult = haProxy.EnableServer(backendServer.BackendName, backendServer.Name);

                }
            }



        



        }
    }
}
