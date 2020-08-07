using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace AudioSampleButton
{
    class SampleInfo
    {
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        [YamlMember(Alias = "audio")]
        public string AudioFile { get; set; }

        [YamlMember(Alias = "color")]
        public string Color { get; set; }

        [YamlMember(Alias = "bgcolor")]
        public string BackgroundColor { get; set; }
    }
}
