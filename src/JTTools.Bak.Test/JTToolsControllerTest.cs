using JT808.Protocol;
using JT808.Protocol.Extensions.JT1078;
using JT809.Protocol;
using JT809.Protocol.Configs;
using JT809.Protocol.Enums;
using JT809.Protocol.Extensions.JT1078;
using JT809.Protocol.MessageBody;
using JTTools.Controllers;
using JTTools.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace JTTools.Test
{
    public class JTToolsControllerTest
    {
        IServiceCollection serviceDescriptors = new ServiceCollection();

        private readonly JTToolsController jTToolsController;

        public JTToolsControllerTest()
        {
            serviceDescriptors.AddJT808Configure();
                              //.AddJT1078Configure();
            serviceDescriptors.AddJT809Configure()
                              .AddJT1078Configure();
            serviceDescriptors.AddSingleton<JTToolsController>();
            IServiceProvider ServiceProvider = serviceDescriptors.BuildServiceProvider();
            jTToolsController = ServiceProvider.GetRequiredService<JTToolsController>();
        }

        [Fact]
        public void Parse809Test1()
        {
            var result=jTToolsController.Parse809(new JT809RequestDto()
            {
                 IsEncrypt=true,
                 EncryptOptions=new JT809EncryptOptions
                 {
                      IA1= 96135846,
                      IC1= 30000000,
                      M1 = 10000079
                 },
                 HexData= "5B 00 00 00 73 00 00 17 3B 12 00 02 A2 49 7F 01 02 0F 01 00 00 00 01 AC 84 2A 2C 11 20 47 CA 38 E1 DD 75 BE EE F8 03 D5 7A B8 17 C7 C0 43 3C D0 85 6D 94 EA E0 00 5A 01 23 68 A6 D6 DB A1 0B 49 F6 CB 74 C6 61 F6 D6 6A 80 C4 D2 B1 10 40 AE 48 7E 96 3A 8D 0F ED 7A 1B 2D 82 00 41 B9 BE 0A E7 8C D6 AB 7D B7 79 2E 8A 7F 17 AE B8 0A 9F AE AA A2 75 A4 5D"
            });
            JT809Package package = (JT809Package)result.Value.Data;
            JT809_0x1200 jT809_0X1200 = (JT809_0x1200)package.Bodies;
            Assert.Equal(44190079u, package.Header.MsgGNSSCENTERID);
            Assert.Equal(30116, package.CRCCode);
            Assert.Equal("ÔÁSEB408²â", jT809_0X1200.VehicleNo);
            Assert.Equal(JT809VehicleColorType.»ÆÉ«, jT809_0X1200.VehicleColor);
        }
        [Fact]
        public void Parse808Test1()
        {
            var result=jTToolsController.Parse808(new JT809RequestDto()
            {
                 IsEncrypt=true,
                 HexData= "7E 02 00 00 57 00 00 00 00 77 77 62 F7 00 08 00 00 00 04 00 03 01 66 53 A7 06 A2 55 F8 00 9E 00 00 00 00 20 03 31 07 00 35 01 04 00 00 00 00 03 02 00 00 21 08 00 00 00 A0 00 05 6F 67 25 04 00 00 00 00 2B 04 00 00 00 00 30 01 03 31 01 0C 16 04 00 00 0B FE 17 01 02 18 04 01 1D 00 00 14 04 00 00 00 02 8A 7E"
            });

        }
    }
}
