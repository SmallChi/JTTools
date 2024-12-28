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
        JT808Serializer JTPrivateSerializer;
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
        /// 序列化字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDict")]
        public ResultDto<List<JTTDictDto>> GetDict()
        {
            return new ResultDto<List<JTTDictDto>>
            {
                 Result=new List<JTTDictDto>{
                   { new JTTDictDto{Label = "国标(通过包自动识别版本号)" ,Value = "JT808"}},
                   { new JTTDictDto{Label = "国标扩展JT1078", Value = "JT808_JT1078"}},
                   { new JTTDictDto{Label = "国标扩展主动安全(苏标)", Value = "JT808_SuBiao"}},
                   { new JTTDictDto{Label = "国标扩展主动安全(粤标)" ,Value = "JT808_YueBiao"}},
                   { new JTTDictDto{Label = "公交扩展协议(锐明)", Value = "JT808_JTRM"}},
                   { new JTTDictDto{Label = "国标(强制使用2013版本解析)" ,Value = "JT2013Force"}},
                   { new JTTDictDto{Label = "国标扩展私有协议", Value = "JTPrivate"} },
                   { new JTTDictDto{Label = "国标扩展私有协议(GPS51)", Value = "JT808_GPS51"} }
                }
            };
        }

        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JT808AnalyzeResultDto> Analyze(JT808AnalyzeDto request)
        {
            ResultDto<JT808AnalyzeResultDto> result = new ResultDto<JT808AnalyzeResultDto>();
            result.Result = new JT808AnalyzeResultDto();



            return result;
        }
    }
}
