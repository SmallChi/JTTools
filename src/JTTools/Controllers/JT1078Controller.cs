using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using JTTools.Configs;
using JTTools.Dtos;
using System.Reflection.Emit;
using JT1078.Protocol;
using JT1078.Protocol.Extensions;
using JT808.Protocol;
using JT808.Protocol.Extensions.JT1078.MessageBody;

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

        JT808Serializer jt1078_serializer;

        /// <summary>
        /// 
        /// </summary>
        public JT1078Controller(JT808_JT1078_Config jT808_JT1078_Config)
        {
            serializer = new JT1078Serializer();
            jt1078_serializer = jT808_JT1078_Config.GetSerializer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">"30 31 63 64 81 E2 10 88 01 12 34 56 78 10 01 10 00 00 01 6B B3 92 CA 7C 02 80 00 28 00 2E 00 00 00 01 61 E1 A2 BF 00 98 CF C0 EE 1E 17 28 34 07 78 8E 39 A4 03 FD DB D1 D5 46 BF B0 63 01 3F 59 AC 34 C9 7A 02 1A B9 6A 28 A4 2C 08"</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Analyze")]
        public ResultDto<JT1078AnalyzeResultDto> Analyze(JT1078AnalyzeDto request)
        {
            ResultDto<JT1078AnalyzeResultDto> result = new ResultDto<JT1078AnalyzeResultDto>();
            result.Result = new JT1078AnalyzeResultDto();
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Packet_0x9101")]
        public ResultDto<JT1078PacketResultDto> Packet_0x9101(JT1078_0x9101_Dto request)
        {
            ResultDto<JT1078PacketResultDto> result = new ResultDto<JT1078PacketResultDto>();
            result.Result = new JT1078PacketResultDto();
            JT808Package jT808Package = new JT808Package();
            JT808Header header = new JT808Header();
            try
            {
                header.MsgId = 0x9101;
                header.ManualMsgNum = (ushort)request.SN;
                header.TerminalPhoneNo = request.Sim;
                jT808Package.Header = header;
                JT808_0x9101 jT808_0X9101 = new JT808_0x9101();
                jT808_0X9101.ServerIp = request.IPAddress;
                jT808_0X9101.TcpPort = (ushort)request.TcpPort;
                jT808_0X9101.UdpPort = (ushort)request.UdpPort;
                jT808_0X9101.ChannelNo = request.LogicalChannelNo;
                jT808_0X9101.DataType = (byte)(request.DataType);
                jT808_0X9101.StreamType = (byte)(request.StreamType);
                jT808Package.Bodies = jT808_0X9101;
                result.Result.Hex = jt1078_serializer.Serialize(jT808Package).ToHexString();
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Packet_0x9102")]
        public ResultDto<JT1078PacketResultDto> Packet_0x9102(JT1078_0x9102_Dto request)
        {
            ResultDto<JT1078PacketResultDto> result = new ResultDto<JT1078PacketResultDto>();
            result.Result = new JT1078PacketResultDto();
            JT808Package jT808Package = new JT808Package();
            JT808Header header = new JT808Header();
            try
            {
                header.MsgId = 0x9102;
                header.ManualMsgNum = (ushort)request.SN;
                header.TerminalPhoneNo = request.Sim;
                jT808Package.Header = header;
                JT808_0x9102 jT808_0X9102 = new JT808_0x9102();
                jT808_0X9102.ChannelNo = request.LogicalChannelNo;
                jT808_0X9102.ControlCmd = byte.Parse(request.ControlCmd);
                jT808_0X9102.CloseAVData = byte.Parse(request.CloseAVData);
                jT808_0X9102.StreamType = byte.Parse(request.SwitchStreamType);
                jT808Package.Bodies = jT808_0X9102;
                result.Result.Hex = jt1078_serializer.Serialize(jT808Package).ToHexString();
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Packet_0x9205")]
        public ResultDto<JT1078PacketResultDto> Packet_0x9205(JT1078_0x9205_Dto request)
        {
            ResultDto<JT1078PacketResultDto> result = new ResultDto<JT1078PacketResultDto>();
            result.Result = new JT1078PacketResultDto();
            JT808Package jT808Package = new JT808Package();
            JT808Header header = new JT808Header();
            try
            {
                header.MsgId = 0x9205;
                header.ManualMsgNum = (ushort)request.SN;
                header.TerminalPhoneNo = request.Sim;
                jT808Package.Header = header;
                JT808.Protocol.MessageBody.JT808_0x0200 jT808_0X0200 = new JT808.Protocol.MessageBody.JT808_0x0200();
                jT808_0X0200.AlarmFlag = (uint)JT808.Protocol.Enums.JT808Alarm.gnss_ant_not_connected;
                JT808_0x9205 jT808_0X9205 = new JT808_0x9205();
                jT808_0X9205.ChannelNo = request.LogicalChannelNo;
                jT808_0X9205.BeginTime = request.BeginTime;
                jT808_0X9205.EndTime = request.EndTime;
                jT808_0X9205.AlarmFlag = ulong.Parse(request.AlarmFlag);
                jT808_0X9205.MediaType = byte.Parse(request.MediaType);
                jT808_0X9205.StreamType = byte.Parse(request.MemoryType);
                jT808_0X9205.MemoryType = byte.Parse(request.MemoryType);
                jT808Package.Bodies = jT808_0X9205;
                result.Result.Hex = jt1078_serializer.Serialize(jT808Package).ToHexString();
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Packet_0x9206")]
        public ResultDto<JT1078PacketResultDto> Packet_0x9206(JT1078_0x9206_Dto request)
        {
            ResultDto<JT1078PacketResultDto> result = new ResultDto<JT1078PacketResultDto>();
            result.Result = new JT1078PacketResultDto();
            JT808Package jT808Package = new JT808Package();
            JT808Header header = new JT808Header();
            try
            {
                header.MsgId = 0x9206;
                header.ManualMsgNum = (ushort)request.SN;
                header.TerminalPhoneNo = request.Sim;
                jT808Package.Header = header;
                JT808_0x9206 jT808_0X9206 = new JT808_0x9206();
                jT808_0X9206.ServerIpLength = byte.Parse(request.ServerIP.Length.ToString());
                jT808_0X9206.ServerIp = request.ServerIP;
                jT808_0X9206.Port = ushort.Parse(request.Port);
                jT808_0X9206.UserName = request.UserName;
                jT808_0X9206.Password = request.Password;
                jT808_0X9206.FileUploadPath = request.FileUploadPath ?? "";
                jT808_0X9206.BeginTime = request.BeginTime;
                jT808_0X9206.EndTime = request.EndTime;
                jT808_0X9206.AlarmFlag = ulong.Parse(request.AlarmFlag);
                jT808_0X9206.MediaType = byte.Parse(request.MediaType);
                jT808_0X9206.StreamType = byte.Parse(request.MemoryType);
                jT808_0X9206.MemoryPositon = byte.Parse(request.MemoryType);
                jT808_0X9206.TaskExcuteCondition = byte.Parse(request.TaskExcuteCondition);
                jT808Package.Bodies = jT808_0X9206;
                result.Result.Hex = jt1078_serializer.Serialize(jT808Package).ToHexString();
            }
            catch (Exception ex)
            {
                result.Error(ex);
            }
            return result;
        }
    }
}
