using System;
using Microsoft.Owin.Hosting;

namespace PoC.Microservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string baseAddress = $"http://localhost:{args[0]}/";

            using (WebApp.Start<Startup>(url: baseAddress)) 
            {
                Console.WriteLine("Started");
                Console.ReadLine();
                Console.WriteLine("Stopped");
            } 
        }
    }
}