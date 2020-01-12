using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using JT808.Protocol;
using JT809.Protocol;
using JT808.Protocol.Extensions.JT1078;
using JT808.Protocol.Extensions.JTActiveSafety;
using JT809.Protocol.Extensions.JT1078;
using Newtonsoft.Json.Serialization;
using System;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using JTTools.JsonConvert;

namespace JTTools
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostingContext, services) =>
                    {
                        services.AddControllers()
                                //Microsoft.AspNetCore.Mvc.NewtonsoftJson
                                .AddNewtonsoftJson(jsonOptions =>
                                {
                                    jsonOptions.SerializerSettings.Converters.Add(new ByteArrayHexConverter());
                                    jsonOptions.SerializerSettings.ContractResolver = new DefaultContractResolver();
                                    //jsonOptions.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                                })
                                //.AddJsonOptions(jsonOptions =>
                                //{
                                //    jsonOptions.JsonSerializerOptions.MaxDepth = 64;

                                //    jsonOptions.JsonSerializerOptions.Converters.Add(new ByteArrayHexTextJsonConverter());
                                //})
                                ;
                        services.AddCors(options =>
                                     options.AddPolicy("Domain", builder =>
                                     builder.WithOrigins(hostingContext.Configuration.GetSection("AllowedOrigins").Value.Split(","))
                                     .AllowAnyMethod()
                                     .AllowAnyHeader()
                                     .AllowAnyOrigin()));

                    })
                    .ConfigureKestrel(ksOptions =>
                    {
                        ksOptions.ListenAnyIP(18888);
                    })
                    .ConfigureLogging((context, logging) => {
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
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    })
                    .Configure(app => {
                        app.UseRouting();
                        app.UseCors("Domain");
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                })
                .ConfigureServices(services => 
                {
                    services.AddJT808Configure()
                            .AddJT1078Configure()
                            .AddJTActiveSafetyConfigure();
                    services.AddJT809Configure()
                            .AddJT1078Configure();
                })
                .Build()
                .Run();
        }
    }
}
