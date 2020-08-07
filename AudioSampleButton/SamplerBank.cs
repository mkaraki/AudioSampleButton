using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace AudioSampleButton
{
    class SamplerBank
    {
        [YamlMember(Alias = "width")]
        public int Width { get; set; }

        [YamlMember(Alias = "height")]
        public int Height { get; set; }

        [YamlMember(Alias = "samples")]
        public SampleInfo[][] Samples { get; set; }
    }
}
