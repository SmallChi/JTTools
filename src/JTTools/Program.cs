using JT808.Protocol;
using JT808.Protocol.Extensions.JT1078;
using JT808.Protocol.Extensions.SuBiao;
using JT808.Protocol.Extensions.YueBiao;
using JT809.Protocol;
using JT809.Protocol.Extensions.JT1078;
using JT808.Protocol.Extensions.Streamax;
using System.Text.Json;
using JT808.Protocol.MessagePack;
using JT808.Protocol.MessageBody;
using JTTools.Configs;
using JT808.Protocol.Extensions.GPS51;
using YamlDotNet.Serialization;
using JT905.Protocol;


namespace JTTools
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddJT808Configure();
            builder.Services.AddJT808Configure(new JT808_SuBiao_Config())
                    .AddSuBiaoConfigure();
            builder.Services.AddJT808Configure(new JT808_YueBiao_Config())
                    .AddYueBiaoConfigure();
            builder.Services.AddJT808Configure(new JT808_JT1078_Config())
                    .AddJT1078Configure();
            builder.Services.AddJT809Configure(new JT809_2011_Config())
                    .AddJT1078Configure();
            IServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
            builder.Services.AddJT809Configure(new JT809_2019_Config())
                    .AddJT1078Configure()
                    .AddJT809_JT808AnalyzeCallback(0x0200, (bytes, writer, jT809Config) => {
                        IJT808Config jT808Config = serviceProvider.GetRequiredService<IJT808Config>();
                        JT808MessagePackReader jT808MessagePackReader = new JT808MessagePackReader(bytes);
                        JT808.Protocol.Extensions.JT808AnalyzeExtensions.Analyze(JT808.Protocol.JT808ConfigExtensions.GetMessagePackFormatter<JT808_0x0200>(jT808Config),
                            ref jT808MessagePackReader, writer, jT808Config);
                    });
            builder.Services.AddJT808Configure(new JT808_Streamax_Config())
                    .AddStreamaxConfigure();
            builder.Services.AddJT808Configure(new JT808_GPS51_Config())
                    .AddGPS51Configure();
            builder.Services.AddJT905Configure();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            builder.Services.AddOpenApiDocument();

            builder.Services.AddCors(options =>
             {
                 options.AddPolicy("AnyCors", builder=> builder.AllowAnyMethod()
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyHeader()
                    .AllowCredentials());
             });

            var app = builder.Build();

            app.UseCors("AnyCors");

            app.UseOpenApi(options =>
            {
               options.Path = "/jtt/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUi(options =>
            {
                options.DocumentPath = "/jtt/swagger/{documentName}/swagger.json";
                options.Path ="/jttui/swagger";
            });

            app.MapControllers();

            app.UseDefaultFiles();

            app.MapStaticAssets();

            app.UseStaticFiles();

            app.Run();
        }
    }
}
