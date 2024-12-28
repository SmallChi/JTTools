namespace JTTools.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class JT808AnalyzeDto
    {
        /// <summary>
        ///  
        /// </summary>
        public string ProtocolType { get; set; } = "";
        /// <summary>
        ///  hex字符串
        /// </summary>
        public List<string> Hex { get; set; } = new List<string>();
    }
}
