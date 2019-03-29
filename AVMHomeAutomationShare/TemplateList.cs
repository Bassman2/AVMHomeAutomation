using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [XmlRoot("templatelist")]
    public class TemplateList
    {
        [XmlAttribute("identifier")]
        public string Identifier { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("functionbitmask")]
        public int FunctionBitMask { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlArray("devices")]
        [XmlArrayItem("device")]
        public List<TemplateDevice> Devices { get; set; }

        [XmlElement("applymask")]
        public ApplyMask ApplyMask { get; set; }
    }
}
