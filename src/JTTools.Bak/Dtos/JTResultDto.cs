using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JTTools.Dtos
{
    public class JTResultDto
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
