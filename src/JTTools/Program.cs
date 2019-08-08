using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using JT808.Protocol;
using JT809.Protocol;
using JT808.Protocol.Extensions.JT1078;
using JT809.Protocol.Extensions.JT1078;
using Newtonsoft.Json.Serialization;
using System;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace JTTools
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureKestrel(ksOptions=> 
                {
                    ksOptions.ListenAnyIP(18888);
                })
                .ConfigureLogging((context,logging) => {
                    //if (Environment.OSVersion.Platform == PlatformID.Unix)
                    //{
                    //    NLog.LogManager.LoadConfiguration("Configs/nlog.unix.config");
                    //}
                    //else
                    //{
                    //    NLog.LogManager.LoadConfiguration("Configs/nlog.win.config");
                    //}
                    //logging.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties = true });
                    //logging.SetMinimumLevel(LogLevel.Trace);
                })
                .ConfigureServices(services => 
                {
                    services.AddMvc()
                            .AddJsonOptions(jsonOptions =>
                            {
                                jsonOptions.SerializerSettings.Converters.Add(new ByteArrayHexConverter());
                                jsonOptions.SerializerSettings.ContractResolver = new DefaultContractResolver();
                            })
                            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                    services.AddCors(options => 
                        options.AddPolicy("Domain",builder => builder.WithOrigins("http://jttools.smallchi.cn")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowAnyOrigin()
                                .AllowCredentials()));
                    services.AddJT808Configure()
                            .AddJT1078Configure();
                    services.AddJT809Configure()
                            .AddJT1078Configure();
                })
                .Configure(app => {
                    app.UseCors("Domain");
                    app.UseMvc();
                })
                .Build()
                .Run();
        }
    }
}
