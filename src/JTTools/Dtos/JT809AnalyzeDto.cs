using JT809.Protocol.Configs;

namespace JTTools.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class JT809AnalyzeDto
    {
        /// <summary>
        ///  
        /// </summary>
        public string ProtocolType { get; set; } = "2011";
        /// <summary>
        /// 
        /// </summary>
        public bool IsEncrypt { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public long M1 { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public long IA1 { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        public long IC1 { get; set; } = 0;
        /// <summary>
        ///  hex字符串
        /// </summary>
        public string Hex { get; set; } = "";
    }
}
