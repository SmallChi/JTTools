using System;
using JT808.Protocol;
using JT808.Protocol.Extensions.JT1078;
using JT808.Protocol.Extensions.SuBiao;
using JT808.Protocol.Extensions.YueBiao;
using JT809.Protocol;
using JT809.Protocol.Extensions.JT1078;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using JTTools.Configs;
using Newtonsoft.Json;
using JT808.Protocol.Extensions.Streamax;
using System.Text.Json;
using JT808.Protocol.MessagePack;
using JT808.Protocol.MessageBody;

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
                        services.AddAntDesign();
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
                        app.UseStaticFiles();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapBlazorHub();
                            endpoints.MapFallbackToPage("/_Host");
                        });
                    });
                })
                .ConfigureServices(services =>
                {
                    services.AddJT808Configure();
                    services.AddJT808Configure(new JT808_SuBiao_Config())
                            .AddSuBiaoConfigure();
                    services.AddJT808Configure(new JT808_YueBiao_Config())
                            .AddYueBiaoConfigure();
                    services.AddJT808Configure(new JT808_JT1078_Config())
                            .AddJT1078Configure();
                    services.AddJT809Configure(new JT809_2011_Config())
                            .AddJT1078Configure();
                    IServiceProvider serviceProvider = services.BuildServiceProvider();
                    services.AddJT809Configure(new JT809_2019_Config())
                            .AddJT1078Configure()
                            .AddJT809_JT808AnalyzeCallback(0x0200,(bytes, writer, jT809Config)=> {
                                IJT808Config jT808Config = serviceProvider.GetRequiredService<IJT808Config>();
                                JT808MessagePackReader jT808MessagePackReader = new JT808MessagePackReader(bytes);
                                JT808.Protocol.Extensions.JT808AnalyzeExtensions.Analyze(JT808.Protocol.JT808ConfigExtensions.GetMessagePackFormatter<JT808_0x0200>(jT808Config),
                                    ref jT808MessagePackReader, writer, jT808Config);
                            });
                    services.AddJT808Configure(new JT808_Streamax_Config())
                            .AddStreamaxConfigure();
                })
                .Build()
                .Run();
        }
    }
}
