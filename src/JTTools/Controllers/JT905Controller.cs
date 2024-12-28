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
    
        public JT905Controller(IJT905Config config)
        {
            this.config = config;
            this.serializer =  new JT905Serializer(config);
        }

        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JT905AnalyzeResultDto> Analyze(JT905AnalyzeDto request)
        {
            ResultDto<JT905AnalyzeResultDto> result = new ResultDto<JT905AnalyzeResultDto>();
            result.Result = new JT905AnalyzeResultDto();



            return result;
        }
    }
}
