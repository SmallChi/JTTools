using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using JT808.Protocol;
using JT808.Protocol.Extensions;
using JT808.Protocol.Exceptions;
using JTTools.Configs;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using JT808.Protocol.Interfaces;
using JTTools.Dtos;
using System.Reflection.Emit;
using JT809.Protocol;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using JT905.Protocol.SerialPort;
using JT808.Protocol.Enums;
using YamlDotNet.Serialization;
using JT808.Protocol.MessageBody;

namespace JTTools.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("jtt/[controller]")]
    public class JT808Controller : ControllerBase
    {
        IJT808Config config;
        JT808_JT1078_Config jT808_JT1078_Config;
        JT808_SuBiao_Config jT808_SuBiao_Config;
        JT808_Streamax_Config jT808_Streamax_Config;
        JT808_YueBiao_Config jT808_YueBiao_Config;
        JT808_GPS51_Config jT808_gps51_Config;
        JT808Serializer Serializer;
        JT808Serializer JTRM_Serializer;
        JT808Serializer JTSuBiao_Serializer;
        JT808Serializer JTYueBiao_Serializer;
        JT808Serializer JTGps51_Serializer;
        JT808Serializer JT1078Serializer;

 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="jT808_JT1078_Config"></param>
        /// <param name="jT808_SuBiao_Config"></param>
        /// <param name="jT808_Streamax_Config"></param>
        /// <param name="jT808_YueBiao_Config"></param>
        /// <param name="jT808_gps51_Config"></param>
        public JT808Controller(
                    IJT808Config config,
                    JT808_JT1078_Config jT808_JT1078_Config,
                    JT808_SuBiao_Config jT808_SuBiao_Config,
                    JT808_Streamax_Config jT808_Streamax_Config,
                    JT808_YueBiao_Config jT808_YueBiao_Config,
                    JT808_GPS51_Config jT808_gps51_Config
            )
        {
            this.config = config;
            this.jT808_JT1078_Config = jT808_JT1078_Config;
            this.jT808_SuBiao_Config = jT808_SuBiao_Config;
            this.jT808_Streamax_Config = jT808_Streamax_Config;
            this.jT808_YueBiao_Config = jT808_YueBiao_Config;
            this.jT808_gps51_Config = jT808_gps51_Config;
            this.config.SkipCRCCode = true;
            this.config.SkipCarDVRCRCCode = true;
            Serializer = config.GetSerializer();
            JT1078Serializer = jT808_JT1078_Config.GetSerializer();
            JTSuBiao_Serializer = jT808_SuBiao_Config.GetSerializer();
            JTRM_Serializer = jT808_Streamax_Config.GetSerializer();
            JTYueBiao_Serializer = jT808_YueBiao_Config.GetSerializer();
            JTGps51_Serializer = jT808_gps51_Config.GetSerializer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JT808AnalyzeResultDto> Analyze(JT808AnalyzeDto request)
        {
            ResultDto<JT808AnalyzeResultDto> result = new ResultDto<JT808AnalyzeResultDto>();
            result.Result = new JT808AnalyzeResultDto();
            if (string.IsNullOrEmpty(request.Hex)) 
            {
                result.Fail("hex数据不为空");
                return result;
            }
            if (string.IsNullOrEmpty(request.ProtocolType))
            {
                result.Fail("请选择对应的版本类型");
                return result;
            }
            SortedList<int, JT808HeaderPackage> sort = new SortedList<int, JT808HeaderPackage>();
            List<JT808HeaderPackage> headerPackages;
            var total = 0;
            try
            {
                string[] lines = request.Hex.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                foreach (var (i, item) in lines.Index())
                {
                    var data = item.ToHexBytes();
                    var headerPackage = Serializer.HeaderDeserialize(data);
                    var package = new JT808PackageInfoDto
                    {
                        Order = i+1,
                        MsgId = headerPackage.Header.MsgId.ToString("X2"),
                        ProtocolVersion = ((JT808.Protocol.Enums.JT808Version)headerPackage.Header.ProtocolVersion).ToString(),
                        DataLength = headerPackage.Header.MessageBodyProperty.DataLength,
                        TerminalPhoneNo = headerPackage.Header.TerminalPhoneNo,
                        Encrypt = headerPackage.Header.MessageBodyProperty.Encrypt != JT808.Protocol.Enums.JT808EncryptMethod.None,
                        MsgNum = headerPackage.Header.MsgNum
                    };
                    //处理分包
                    if (headerPackage.Header.MessageBodyProperty.IsPackage)
                    {
                        total = headerPackage.Header.PackgeCount;
                        sort.Add(headerPackage.Header.PackageIndex, headerPackage);
                        package.PackageIndex = headerPackage.Header.PackageIndex;
                        package.PackgeCount = headerPackage.Header.PackgeCount;
                        package.Body = headerPackage.Bodies.ToHexString();
                        if (package.PackageIndex == 1)
                        {
                            package.Body =$"首包数据体:\r\n{package.Body}\r\n{BodyAnalyze(headerPackage.Header.MsgId, headerPackage.Bodies)}\r\n" ;
                        }
                    }
                    else
                    {
                        switch (request.ProtocolType)
                        {
                            case "JT808":
                                package.JsonValue = Serializer.Analyze(data, options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_JT1078":
                                package.JsonValue = JT1078Serializer.Analyze(data, options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_SuBiao":
                                package.JsonValue = JTSuBiao_Serializer.Analyze(data, options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_YueBiao":
                                package.JsonValue = JTYueBiao_Serializer.Analyze(data, options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_JTRM":
                                package.JsonValue = JTRM_Serializer.Analyze(data, options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT2013Force":
                                package.JsonValue = Serializer.Analyze(data, JT808.Protocol.Enums.JT808Version.JTT2013Force, options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_GPS51":
                                package.JsonValue = JTGps51_Serializer.Analyze(data, options: JTJsonWriterOptions.Instance);
                                break;
                        }
                    }
                    result.Result.Packages.Add(package);
                }
                if (sort.Count > 0)
                {
                    List<byte> bodies = new List<byte>();
                    ushort msgid = 0;
                    foreach (var item in sort)
                    {
                        msgid = item.Value.Header.MsgId;
                        bodies = bodies.Concat(item.Value.Bodies).ToList();
                    }
                    headerPackages = sort.Select(s => s.Value).ToList();   
                    result.Result.IsSubpackage = sort.Count == total;
                    if (result.Result.IsSubpackage)
                    {
                        switch (request.ProtocolType)
                        {
                            case "JT808":
                                result.Result.JsonValue = Serializer.Analyze(msgid, bodies.ToArray(), options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_JT1078":
                                result.Result.JsonValue = JT1078Serializer.Analyze(msgid, bodies.ToArray(), options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_SuBiao":
                                result.Result.JsonValue = JTSuBiao_Serializer.Analyze(msgid, bodies.ToArray(), options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_YueBiao":
                                result.Result.JsonValue = JTYueBiao_Serializer.Analyze(msgid, bodies.ToArray(), options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_JTRM":
                                result.Result.JsonValue = JTRM_Serializer.Analyze(msgid, bodies.ToArray(), options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT2013Force":
                                result.Result.JsonValue = Serializer.Analyze(msgid, bodies.ToArray(), JT808.Protocol.Enums.JT808Version.JTT2013Force, options: JTJsonWriterOptions.Instance);
                                break;
                            case "JT808_GPS51":
                                result.Result.JsonValue = JTGps51_Serializer.Analyze(msgid, bodies.ToArray(), options: JTJsonWriterOptions.Instance);
                                break;
                        }
                    }
                    else
                    {
                        result.Result.JsonValue = "";
                    }  
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }

        string BodyAnalyze(ushort msgId, byte[] body)
        {
            switch (msgId)
            {
                case (ushort)JT808MsgId._0x0801:
                    return Serializer.Analyze<JT808_0x0801>(body, options: JTJsonWriterOptions.Instance);
                default:
                    return "";
            }
        }
    }
}
