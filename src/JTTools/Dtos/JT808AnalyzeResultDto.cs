namespace JTTools.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class JT808AnalyzeResultDto
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsSubpackage {  get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public string JsonValue { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public List<JT808PackageInfoDto> Packages{ get; set; } = new List<JT808PackageInfoDto>();
    }

    /// <summary>
    /// 
    /// </summary>
    public class JT808PackageInfoDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string TerminalPhoneNo { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string MsgId { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public int MsgNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProtocolVersion { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public int PackgeCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PackageIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DataLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Encrypt { get; set; }= false;
        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; } = "";
    }
}
