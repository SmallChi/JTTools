using JT809.Protocol.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JTTools.Dtos
{
    public class JT809RequestDto: JTRequestDto
    {
        public bool IsEncrypt { get; set; } = false;
        public JT809EncryptOptions EncryptOptions { get; set; }
    }
}
