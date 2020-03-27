using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JTTools.JsonConvert
{
    /// <summary>
    /// 
    /// ref:https://github.com/dotnet/corefx/blob/release/3.0/src/System.Text.Json/tests/Serialization/CustomConverterTests.Array.cs
    /// </summary>
    public class ByteArrayHexTextJsonConverter : JsonConverter<byte[]>
    {
        public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //string hexJson = reader.get();
            var hexJson = reader.GetString();
            var list = new List<byte>();
            foreach (string str in hexJson.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries))
            {
                list.Add(Convert.ToByte(str, 16));
            }
            return list.ToArray();
        }

        public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
        {
            var hexString = string.Join(" ", (value).Select(p => p.ToString("X2")));
            writer.WriteStringValue(hexString);
        }
    }
}
