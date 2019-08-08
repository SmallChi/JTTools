using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JTTools.Dtos
{
    public class JTRequestDto
    {
        public string HexData { get; set; }
        public bool Skip { get; set; }
        public bool Custom { get; set; }
    }
}
