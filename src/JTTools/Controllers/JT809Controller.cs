using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using Newtonsoft.Json;
using JT809.Protocol.Configs;
using JT809.Protocol.Interfaces;
using JT809.Protocol.Exceptions;
using JTTools.Configs;
using JT809.Protocol.Enums;
using JTTools.Dtos;
using System.Reflection.Emit;
using JT808.Protocol;
using System.Security.Cryptography.Xml;
using JT808.Protocol.MessagePack;
using JT808.Protocol.MessageBody;

namespace JTTools.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("jtt/[controller]")]
    public class JT809Controller : ControllerBase
    {
        JT809_2011_Config config2011;
        JT809_2019_Config config2019;
        IJT808Config jt808Config;
        JT809Serializer serializer2011;
        JT809Serializer serializer2019;

        int MAX_BUFFER_SIZE = 1024 * 1024 * 1; //10M

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jt808Config"></param>
        /// <param name="config2011"></param>
        /// <param name="config2019"></param>
        public JT809Controller(
                    IJT808Config jt808Config,
                    JT809_2011_Config config2011,
                    JT809_2019_Config config2019
            )
        {
            this.config2011 = config2011;
            this.config2019 = config2019;
            this.jt808Config = jt808Config;
            serializer2011 = config2011.GetSerializer();
            serializer2019 = config2019.GetSerializer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">
        /// HexData2011 "5B 00 00 00 92 00 00 06 82 94 00 01 33 EF B8 01 00 00 00 00 00 27 0F D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 94 01 00 00 00 5C 01 00 02 00 00 00 00 5A 01 AC 3F 40 12 3F FA A1 00 00 00 00 5A 01 AC 4D 50 03 73 6D 61 6C 6C 63 68 69 00 00 00 00 00 00 00 00 31 32 33 34 35 36 37 38 39 30 31 00 00 00 00 00 00 00 00 00 31 32 33 34 35 36 40 71 71 2E 63 6F 6D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BA D8 5D"
        /// HexData2019 "5B 00 00 00 C9 00 00 06 82 17 00 01 34 15 F4 01 00 00 00 00 00 27 0F 00 00 00 00 5E 02 A5 07 B8 D4 C1 41 31 32 33 34 35 00 00 00 00 00 00 00 00 00 00 00 00 00 02 17 01 00 00 00 8B 01 02 03 04 05 06 07 08 09 10 11 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 E7 D3 5D"
        /// </param>
        /// <returns></returns>
        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JT809AnalyzeResultDto> Analyze(JT809AnalyzeDto request)
        {
            ResultDto<JT809AnalyzeResultDto> result = new ResultDto<JT809AnalyzeResultDto>();
            result.Result = new JT809AnalyzeResultDto();
            try
            {
                var data = request.Hex.ToHexBytes();
                var encryptOptions = new JT809EncryptOptions();
                encryptOptions.M1 = (uint)request.M1;
                encryptOptions.IC1 = (uint)request.IC1;
                encryptOptions.IA1 = (uint)request.IA1;
                switch (request.ProtocolType)
                {
                    case "2011":
                        if (request.IsEncrypt)
                        {
                            result.Result.JsonValue = serializer2011.Analyze(data, JTJsonWriterOptions.Instance, MAX_BUFFER_SIZE);
                        }
                        else
                        {
                            IJT809Config jt809ConfigInternal = new JT809Config2011(Guid.NewGuid().ToString());
                            jt809ConfigInternal.EncryptOptions = encryptOptions;
                            jt809ConfigInternal.AnalyzeCallbacks.Add(0x0200, (bytes, writer, jT809Config) => {       
                                JT808MessagePackReader jT808MessagePackReader = new JT808MessagePackReader(bytes);
                                JT808.Protocol.Extensions.JT808AnalyzeExtensions.Analyze(JT808.Protocol.JT808ConfigExtensions.GetMessagePackFormatter<JT808_0x0200>(jt808Config),
                                    ref jT808MessagePackReader, writer, jt808Config);
                            });
                            JT809Serializer jT809SerializerInternal = new JT809Serializer(jt809ConfigInternal);
                            result.Result.JsonValue = jT809SerializerInternal.Analyze(data, JTJsonWriterOptions.Instance, MAX_BUFFER_SIZE);
                        }
                        break;
                    case "2019":
                        if (request.IsEncrypt)
                        {
                            result.Result.JsonValue = serializer2019.Analyze(data, JTJsonWriterOptions.Instance, MAX_BUFFER_SIZE);
                        }
                        else
                        {
                            IJT809Config jt809ConfigInternal = new JT809Config2019(Guid.NewGuid().ToString());
                            jt809ConfigInternal.EncryptOptions = encryptOptions;
                            jt809ConfigInternal.AnalyzeCallbacks.Add(0x0200, (bytes, writer, jT809Config) => {
                                JT808MessagePackReader jT808MessagePackReader = new JT808MessagePackReader(bytes);
                                JT808.Protocol.Extensions.JT808AnalyzeExtensions.Analyze(JT808.Protocol.JT808ConfigExtensions.GetMessagePackFormatter<JT808_0x0200>(jt808Config),
                                    ref jT808MessagePackReader, writer, jt808Config);
                            });
                            JT809Serializer jT809SerializerInternal = new JT809Serializer(jt809ConfigInternal);
                            result.Result.JsonValue = jT809SerializerInternal.Analyze(data, JTJsonWriterOptions.Instance, MAX_BUFFER_SIZE);
                        }
                        break;
                    default:
                        result.Error(" ‰»Î∞Ê±æ∫≈”–Œ");
                        result.Result.JsonValue = "";
                        break;
                }
            }
            catch (JT809Exception ex)
            {
                result.Result.JsonValue = "";
                result.Error(ex);
            }
            catch (Exception ex)
            {
                result.Result.JsonValue = "";
                result.Error(ex);
            }
            return result;
        }
  
        class JT809Config2011 : JT809GlobalConfigBase
        {
            public JT809Config2011(string configId)
            {
                ConfigId = configId;
            }

            public override string ConfigId { get; }
        }

        class JT809Config2019 : JT809GlobalConfigBase
        {
            public JT809Config2019(string configId)
            {
                ConfigId = configId;
                Version = JT809Version.JTT2019;
            }

            public override string ConfigId { get; }
        }
    }
}
