using System;
using JT808.Protocol;
using JT808.Protocol.Extensions.JT1078;
using JT808.Protocol.Extensions.JTActiveSafety;
using JT809.Protocol;
using JT809.Protocol.Extensions.JT1078;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using JTTools.Configs;
using BlazorStrap;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;
using System.Net.Http;

namespace JTTools
{
    public class Program
    {
        public static async Task Main(string[] args)
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

            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddBootstrapCss();
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddJT808Configure();
            builder.Services.AddJT808Configure(new JT808_JTActiveSafety_Config())
                    .AddJTActiveSafetyConfigure();
            builder.Services.AddJT808Configure(new JT808_JT1078_Config())
                    .AddJT1078Configure();
            builder.Services.AddJT809Configure(new JT809_2011_Config())
                    .AddJT1078Configure();
            builder.Services.AddJT809Configure(new JT809_2019_Config())
                    .AddJT1078Configure();
            await builder.Build().RunAsync();
        }
    }
}
