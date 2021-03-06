﻿using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Orchard.Hosting;

namespace Orchard.Cms.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder() 
               .AddCommandLine(args)
               .Build();

            var host = new WebHostBuilder()
                .UseIISIntegration()
                .UseKestrel()
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .Build();

            using (host)
            {
                using (var cts = new CancellationTokenSource())
                {
                    host.Run((services) =>
                    {
                        var orchardHost = new OrchardHost(
                            services,
                            System.Console.In,
                            System.Console.Out,
                            args);

                        orchardHost
                            .RunAsync()
                            .Wait();

                        cts.Cancel();

                    }, cts.Token, "Application started. Press Ctrl+C to shut down.");
                }
            }
        }
    }
}