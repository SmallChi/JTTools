using Microsoft.AspNetCore.Mvc;
using JTTools.Configs;
using JTTools.Dtos;
using JTActiveSafety.Protocol;
using JTActiveSafety.Protocol.Extensions;

namespace JTTools.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("jtt/[controller]")]
    public class JTActiveSafetyController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">"30 31 63 64 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 61 6C 61 72 6D 2E 78 6C 73 78 00 00 00 01 00 00 00 05 01 02 03 04 05"</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JTActiveSafetyAnalyzeResultDto> Analyze(JTActiveSafetyAnalyzeDto request)
        {
            ResultDto<JTActiveSafetyAnalyzeResultDto> result = new ResultDto<JTActiveSafetyAnalyzeResultDto>();
            result.Result = new JTActiveSafetyAnalyzeResultDto();
            try
            {
                var data = request.Hex.ToHexBytes();
                result.Result.JsonValue = JTActiveSafetySerializer.Analyze(data, options: JTJsonWriterOptions.Instance);
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }
    }
}
