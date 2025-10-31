using JT808.Protocol.MessageBody;
using JT808.Protocol.MessagePack;
using JT808.Protocol;
using JT809.Protocol;
using JT809.Protocol.Configs;
using JT809.Protocol.Extensions.JT1078;
using Microsoft.Extensions.DependencyInjection;

namespace JTTools.Utils
{
    public static class JT809ConfigFactory
    {

        public static JT809Serializer GetNewSerializer<T>(JT809EncryptOptions encryptOptions, Dictionary<ushort, JT808AnalyzeCallback> analyzeCallbacks = null) where T : IJT809Config, new()
        {
            T t = new T();
            t.EncryptOptions = encryptOptions;
            t.AnalyzeCallbacks = analyzeCallbacks;
            IServiceCollection serviceDescriptors1 = new ServiceCollection();
            serviceDescriptors1.AddJT809Configure(t)
                               .AddJT1078Configure();
            return serviceDescriptors1.BuildServiceProvider().GetRequiredService<T>().GetSerializer();
        }
    }
}
