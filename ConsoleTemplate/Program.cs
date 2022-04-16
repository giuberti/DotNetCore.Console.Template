using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using BusinessLibrary;

namespace ConsoleTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            Setup.BuildConfig(builder);
   
            Log.Logger = Setup.SetupLogger(builder);

            Log.Logger.Information("Console starting...");
           
            IHost host = Setup.SetupHost();

            var svc = ActivatorUtilities.CreateInstance<BusinessClass>(host.Services);
            svc.RunBusiness();

            Log.Logger.Warning("Console finished.");
        }
    }
}
