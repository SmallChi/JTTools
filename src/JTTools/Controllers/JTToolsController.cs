using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JTTools.Dtos;
using Microsoft.AspNetCore.Mvc;
using JT1078.Protocol;
using JT808.Protocol;
using JT809.Protocol;
using JT809.Protocol.Exceptions;
using JT808.Protocol.Extensions;
using JT808.Protocol.Exceptions;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using JT808.Protocol.Interfaces;

namespace JTTools.Controllers
{
    [Route("api/JTTools")]
    [ApiController]
    [EnableCors("Domain")]
    public class JTToolsController : ControllerBase
    {
        private readonly IJT809Config jT809Config;
        private readonly IJT808Config jT808Config;
        private readonly JT808Serializer jT808Serializer;
        private readonly JT809Serializer jT809Serializer;

        public JTToolsController(
            IJT809Config jT809Config, 
            IJT808Config jT808Config)
        {
            this.jT809Config = jT809Config;
            this.jT808Config = jT808Config;
            jT808Serializer = jT808Config.GetSerializer();
            jT809Serializer = jT809Config.GetSerializer();
        }

        [Route("Parse808")]
        [HttpPost]
        public ActionResult<JTResultDto> Parse808([FromBody]JTRequestDto parameter)
        {
            JTResultDto jTResultDto = new JTResultDto();
            try
            {
                jTResultDto.Code = 200;
                jTResultDto.Data =jT808Serializer.Deserialize(parameter.HexData.ToHexBytes());
            }
            catch(JT808Exception ex)
            {
                jTResultDto.Code = 500;
                jTResultDto.Message = $"{ex.ErrorCode}-{ex.Message}";
            }
            catch (Exception ex)
            {
                jTResultDto.Code = 500;
                jTResultDto.Message = ex.Message;
            }
            return jTResultDto;
        }

        [Route("Parse809")]
        [HttpPost]
        public ActionResult<JTResultDto> Parse809([FromBody]JT809RequestDto parameter)
        {
            JTResultDto jTResultDto = new JTResultDto();
            try
            {
                if (parameter.IsEncrypt)
                {
                    IJT809Config jt809ConfigInternal = new JT809Config(Guid.NewGuid().ToString());
                    jt809ConfigInternal.EncryptOptions = parameter.EncryptOptions;
                    JT809Serializer jT809SerializerInternal = new JT809Serializer(jt809ConfigInternal);
                    jTResultDto.Data = jT809SerializerInternal.Deserialize(parameter.HexData.ToHexBytes());
                }
                else
                {
                    jTResultDto.Data = jT809Serializer.Deserialize(parameter.HexData.ToHexBytes());
                }
                jTResultDto.Code = 200;

            }
            catch (JT809Exception ex)
            {
                jTResultDto.Code = 500;
                jTResultDto.Message = $"{ex.ErrorCode}-{ex.Message}";
            }
            catch (Exception ex)
            {
                jTResultDto.Code = 500;
                jTResultDto.Message = ex.Message;
            }
            return jTResultDto;
        }

        [Route("Parse1078")]
        [HttpPost]
        public ActionResult<JTResultDto> Parse1078([FromBody]JTRequestDto parameter)
        {
            JTResultDto jTResultDto = new JTResultDto();
            try
            {
                jTResultDto.Code = 200;
                jTResultDto.Data = JT1078Serializer.Deserialize(parameter.HexData.ToHexBytes());
            }
            catch (Exception ex)
            {
                jTResultDto.Code = 500;
                jTResultDto.Message = ex.Message;
            }
            return jTResultDto;
        }
    }

    class JT809Config : JT809.Protocol.Interfaces.GlobalConfigBase
    {
        public JT809Config(string configId)
        {
            ConfigId = configId;
        }

        public override string ConfigId { get; }
    }
}
