using JTTools.JsonConvert;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xunit;

namespace JTTools.Test
{
    public class ByteArrayHexTextJsonConverterTest
    {
        [Fact]
        public void Test1()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ByteArrayHexTextJsonConverter());
            string jsonSerialized = JsonSerializer.Serialize(new byte[] { 0xA1,0x2D,0xF6}, options);
            Assert.Equal("\"A1 2D F6\"", jsonSerialized);
        }

        [Fact]
        public void Test2()
        {
            string json = "\"A1 2D,F6\"";
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ByteArrayHexTextJsonConverter());
            byte[] arr = JsonSerializer.Deserialize<byte[]>(json, options);
            Assert.Equal(0xA1, arr[0]);
            Assert.Equal(0x2D, arr[1]);
            Assert.Equal(0xF6, arr[2]);
        }

        [Fact]
        public void Test3()
        {
            string json = "{\"Array1\":\"A1 2D,F6\"}";
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ByteArrayHexTextJsonConverter());
            ClassWithProperty obj = JsonSerializer.Deserialize<ClassWithProperty>(json, options);
            Assert.Equal(0xA1, obj.Array1[0]);
            Assert.Equal(0x2D, obj.Array1[1]);
            Assert.Equal(0xF6, obj.Array1[2]);
        }


        [Fact]
        public void Test4()
        {
            string json = "{\"Array1\":\"A1 2D,O6\"}";
            var options = new JsonSerializerOptions();
            options.Converters.Add(new ByteArrayHexTextJsonConverter());
            try
            {
                ClassWithProperty obj = JsonSerializer.Deserialize<ClassWithProperty>(json, options);
            }
            catch (System.FormatException ex)
            {
                Assert.Equal("Could not find any recognizable digits.", ex.Message);
            }
        }


        private class ClassWithProperty
        {
            public byte[] Array1 { get; set; }
        }

    }
}
