namespace WebApiDemo
{
    using System;
    using System.Configuration;

    using Microsoft.Owin.Hosting;

    using WebApiDemo.Infrastructure;

    public class Program
    {
        static void Main(string[] args)
        {
            int port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            string baseUri = ConfigurationManager.AppSettings["BaseHostUri"];

            string baseAddress = $"http://{baseUri}:{port}/";

            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Started...");
                Console.ReadLine();
            }
        }
    }
}
