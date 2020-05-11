using JT809.Protocol.Enums;
using JT809.Protocol.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JTTools.Configs
{
    public class JT809_2019_Config : JT809GlobalConfigBase
    {
        public override string ConfigId { get; }= "JT809_2019";

        public JT809_2019_Config()
        {
            Version = JT809Version.JTT2019;
        }
    }
}
