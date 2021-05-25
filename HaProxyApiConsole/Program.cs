using System;
using System.Threading;
using HaProxyApi;

namespace HaProxyApiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var haProxy = new HaProxyServiceBase("172.16.12.225", 9999);

            string help = haProxy.Help();

            Console.WriteLine(help);

            string backedName = "WEBAPI.01";
            var bk01 = haProxy.SetStateServerMantain(backedName, "API.5001");

            var bk2 = haProxy.SetStateServerMantain(backedName, "API.5002");

            var bk03 = haProxy.SetStateServerMantain(backedName, "API.5003");

            var bk04 = haProxy.SetStateServerMantain(backedName, "API.5004");


            Thread.Sleep(5000);



            bk01 = haProxy.SetStateServerReady(backedName, "API.5001");

            bk2 = haProxy.SetStateServerReady(backedName, "API.5002");

            bk03 = haProxy.SetStateServerReady(backedName, "API.5003");

            bk04 = haProxy.SetStateServerReady(backedName, "API.5004");




        }
    }
}
