using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using JTTools.Configs;
using JTTools.Dtos;
using System.Reflection.Emit;
using JT1078.Protocol;

namespace JTTools.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("jtt/[controller]")]
    public class JT1078Controller : ControllerBase
    {
        JT1078Serializer serializer;

        /// <summary>
        /// 
        /// </summary>
        public JT1078Controller()
        {
            serializer = new JT1078Serializer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JT1078AnalyzeResultDto> Analyze(JT1078AnalyzeDto request)
        {
            ResultDto<JT1078AnalyzeResultDto> result = new ResultDto<JT1078AnalyzeResultDto>();
            result.Result = new JT1078AnalyzeResultDto();



            return result;
        }
    }
}
