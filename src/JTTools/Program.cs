using System;
using JT808.Protocol;
using JT808.Protocol.Extensions.JT1078;
using JT808.Protocol.Extensions.JTActiveSafety;
using JT809.Protocol;
using JT809.Protocol.Extensions.JT1078;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using JTTools.Configs;
using BlazorStrap;
using Newtonsoft.Json;

namespace JTTools
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Newtonsoft.Json.JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
                //日期类型默认格式化处理
                settings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                //空值处理
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                settings.Converters.Add(new ByteArrayHexConverter());
                return settings;
            });
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((hostingContext, services) =>
                    {
                        services.AddRazorPages();
                        services.AddServerSideBlazor();
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
                        services.AddBootstrapCss();
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
                        app.UseStaticFiles();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                            endpoints.MapBlazorHub();
                            endpoints.MapFallbackToPage("/_Host");
                        });
                    });
                })
                .ConfigureServices(services =>
                {
                    services.AddJT808Configure();
                    services.AddJT808Configure(new JT808_JTActiveSafety_Config())
                            .AddJTActiveSafetyConfigure();
                    services.AddJT808Configure(new JT808_JT1078_Config())
                            .AddJT1078Configure();
                    services.AddJT809Configure(new JT809_2011_Config())
                            .AddJT1078Configure();
                    services.AddJT809Configure(new JT809_2019_Config())
                            .AddJT1078Configure();
                })
                .Build()
                .Run();
        }
    }
}
