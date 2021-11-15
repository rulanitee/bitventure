using System;
using System.IO;
using BitVenture.Application;
using BitVenture.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BitVenture
{
    class Program
    {
        static void Main(string[] args)
        {

            using IHost host = CreateHostBuilder(args).Build();

            string path = InputPath();

            host.Services.GetService<IJsonFileProcessor>().Process(path);

            Console.ReadLine();
        }

        static string InputPath()
        {
            Console.WriteLine("Provide the path and the file name to read from: ");

            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine($"Provided path: {path} does not exist.");
                path = InputPath();
            }

            return path;
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services
            .AddScoped<IJsonFileProcessor, JsonFileProcessor>()
            .AddScoped<IEndPointCallService, EndPointCallService>()
            .AddScoped<IResponseProcessorService, ResponseProcessorService>()
            .AddScoped<IResponseHandler, XmlResponseHandler>()
            .AddScoped<IResponseHandler, JsonResponseHandler>()

            );

    }

}
