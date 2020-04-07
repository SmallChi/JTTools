using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace JTTools.Configs
{
    public static class JTJsonWriterOptions
    {
        /// <summary>
        /// 汉字编码
        /// </summary>
        public readonly static JsonWriterOptions Instance = new System.Text.Json.JsonWriterOptions
        {
            Indented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };  
    }
}
