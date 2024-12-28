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
        JT809Serializer serializer2011;
        JT809Serializer serializer2019;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config2011"></param>
        /// <param name="config2019"></param>
        public JT809Controller(
                    JT809_2011_Config config2011,
                    JT809_2019_Config config2019
            )
        {
            this.config2011 = config2011;
            this.config2019 = config2019;
            serializer2011 = config2011.GetSerializer();
            serializer2019 = config2019.GetSerializer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JT809AnalyzeResultDto> Analyze(JT809AnalyzeDto request)
        {
            ResultDto<JT809AnalyzeResultDto> result = new ResultDto<JT809AnalyzeResultDto>();
            result.Result = new JT809AnalyzeResultDto();



            return result;
        }

  
    }
}
