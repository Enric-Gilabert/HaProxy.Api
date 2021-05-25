using Clint.Network.HaProxy.Api;
using System;

namespace HaProxy.Client
{
    class Program
    {
        private int port = 9999;
        private string hostName = "172.16.12.225";

        static void Main(string[] args)
        {

            // https://github.com/clintnetwork/HaProxy.Api

            Console.WriteLine("Hello World!");

            using (var haproxy = new HaProxyClient("172.16.12.225", 9999))
            using (var instance = haproxy.GetInstance())
            {
                // Get the help message
                Console.WriteLine(instance.Help());
                
                string errors = instance.ShowErrors();
                Console.WriteLine(errors);

                // Get all the backends
                var backends = instance.ShowBackend();
                foreach (var backend in backends)
                {
                    Console.WriteLine(backend);
                }

                

                // Disable the "http-in" frontend
                instance.DisableFrontend("http-in");

                // Re-enable it
                instance.EnableFrontend("http-in");

               
            }

        }
    }
}
