using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Clint.Network.HaProxy.Api
{
    internal class StreamHelper : IDisposable
    {
        private const int bufferLength = 1024;

        private readonly IPEndPoint _endpoint;
        private NetworkStream _stream;

        public  int Port
        {
            get => _endpoint.Port;
            set => _endpoint.Port = value;
        }

        public IPAddress Address
        {
            get => _endpoint.Address;
            set=> _endpoint.Address = value;
        }

        public string HostName => $"{Address}";

        public StreamHelper(IPEndPoint endpoint)
        {
            _endpoint = endpoint;
        }

        internal void Connect()
        {

            // La direccion solicitada no es valida en este contexto.
            // _stream = new TcpClient(_endpoint).GetStream();
            
            // Este si que funciona.
            _stream = new TcpClient(this.HostName, this.Port).GetStream();
            
        }

        public void Send(string data)
        {
            var byteData = Encoding.UTF8.GetBytes(data + Environment.NewLine);
            _stream.Write(byteData, 0, byteData.Length);
        }

        public string Receive()
        {
            var buffer = new byte[bufferLength];
            _stream.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        public void Dispose()
        {
            _stream?.Close();
            _stream?.Dispose();
        }
    }
}
