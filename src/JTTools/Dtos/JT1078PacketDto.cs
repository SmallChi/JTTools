using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace JTTools.Dtos
{

    public class JT1078_0x9101_Dto
    {
        [Required]
        public string Sim { get; set; } = "123456789012";
        [Required]
        public int SN { get; set; } = new Random().Next(1, 2000);
        [Required]
        public string IPAddress { get; set; } = "127.0.0.1";
        [Required]
        public int TcpPort { get; set; }
        [Required]
        public int UdpPort { get; set; }
        [Required]
        public byte LogicalChannelNo { get; set; }
        [Required]
        public int DataType { get; set; } = 1;
        [Required]
        public int StreamType { get; set; } = 1;
    }

    public class JT1078_0x9102_Dto
    {
        [Required]
        public string Sim { get; set; } = "123456789012";
        [Required]
        public int SN { get; set; } = new Random().Next(1, 2000);
        [Required]
        public byte LogicalChannelNo { get; set; }
        [Required]
        public string ControlCmd { get; set; } = "0";
        [Required]
        public string CloseAVData { get; set; } = "0";
        [Required]
        public string SwitchStreamType { get; set; } = "1";
    }
    
    public class JT1078_0x9205_Dto
    {
        [Required]
        public string Sim { get; set; } = "123456789012";
        [Required]
        public int SN { get; set; } = new Random().Next(1, 2000);
        [Required, DisplayName("逻辑通道号")]
        public byte LogicalChannelNo { get; set; } = 4;

        [Required, DisplayName("开始时间")]
        public DateTime BeginTime { get; set; } = DateTime.Today;
        [Required, DisplayName("结束时间")]
        public DateTime EndTime { get; set; } = DateTime.Now;
        [Required, DisplayName("报警标志")]
        public string AlarmFlag { get; set; } = "00000000000000000000000000000000";
        [Required, DisplayName("音视频资源类型")]
        public string MediaType { get; set; } = "0";
        [Required, DisplayName("码流类型")]
        public string StreamType { get; set; } = "0";
        [Required, DisplayName("存储器类型")]
        public string MemoryType { get; set; } = "0";
    }
    /// <summary>
    /// 
    /// </summary>
    public class JT1078_0x9206_Dto
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Sim { get; set; } = "123456789012";
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int SN { get; set; } = new Random().Next(1, 2000);
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public byte LogicalChannelNo { get; set; } = 4;
        /// <summary>
        /// 
        /// </summary>
        public string ServerIP { get; set; } = "127.0.0.1";
        /// <summary>
        /// 
        /// </summary>
        public string Port { get; set; } = "6201";
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; } = "053500";
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; } = "053500";
        /// <summary>
        /// 
        /// </summary>
        public string FileUploadPath { get; set; } = "./aaaaaaa";
        [Required, DisplayName("开始时间")]
        public DateTime BeginTime { get; set; } = DateTime.Today;
        [Required, DisplayName("结束时间")]
        public DateTime EndTime { get; set; } = DateTime.Now;
        [Required, DisplayName("报警标志")]
        public string AlarmFlag { get; set; } = "00000000000000000000000000000000";
        [Required, DisplayName("音视频资源类型")]
        public string MediaType { get; set; } = "0";
        [Required, DisplayName("码流类型")]
        public string StreamType { get; set; } = "0";
        [Required, DisplayName("存储器类型")]
        public string MemoryType { get; set; } = "0";

        public string TaskExcuteCondition { get; set; } = "7";
    }
}
