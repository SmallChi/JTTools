using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using JTTools.Configs;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using JT808.Protocol.Interfaces;
using JTTools.Dtos;
using System.Reflection.Emit;
using JT905.Protocol;
using JT808.Protocol.Extensions;


namespace JTTools.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("jtt/[controller]")]
    public class JT905Controller : ControllerBase
    {
        IJT905Config config;
        JT905Serializer serializer;
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public JT905Controller(IJT905Config config)
        {
            this.config = config;
            this.serializer =  new JT905Serializer(config);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">7E02000023103456789012007D02000000010000000200BA7F0E07E4F11C003C002110152110100104000000640202007D01347E</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JT905AnalyzeResultDto> Analyze(JT905AnalyzeDto request)
        {
            ResultDto<JT905AnalyzeResultDto> result = new ResultDto<JT905AnalyzeResultDto>();
            result.Result = new JT905AnalyzeResultDto();
            try
            {
                var data = request.Hex.ToHexBytes();
                result.Result.JsonValue = serializer.Analyze(data, options: JTJsonWriterOptions.Instance);
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }
    }
}
