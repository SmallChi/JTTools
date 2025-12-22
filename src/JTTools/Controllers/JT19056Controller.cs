using Microsoft.AspNetCore.Mvc;
using JTTools.Configs;
using JT809.Protocol.Enums;
using JTTools.Dtos;
using System.Reflection.Emit;
using JT808.Protocol;
using JT808.Protocol.Extensions;

namespace JTTools.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("jtt/[controller]")]
    public class JT19056Controller : ControllerBase
    {
        JT808CarDVRSerializer Serializer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public JT19056Controller(
                    IJT808Config config
            )
        {
            Serializer = config.GetCarDVRSerializer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JT19056AnalyzeResultDto> Analyze(JT19056AnalyzeDto request)
        {
            ResultDto<JT19056AnalyzeResultDto> result = new ResultDto<JT19056AnalyzeResultDto>();
            result.Result = new JT19056AnalyzeResultDto();
            try
            {
                var data = request.Hex.ToHexBytes();
                switch (request.ProtocolType)
                {
                    case "up":
                        result.Result.JsonValue = Serializer.UpAnalyze(data, options: JTJsonWriterOptions.Instance);
                        break;
                    case "down":
                        result.Result.JsonValue = Serializer.DownAnalyze(data, options: JTJsonWriterOptions.Instance);
                        break;
                    default:
                        result.Result.JsonValue = "";
                        break;
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }
    }
}
