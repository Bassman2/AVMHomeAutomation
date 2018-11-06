using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class TemplateDevice
    {
        [XmlAttribute("identifier")]
        public string Identifier { get; set; }
    }
}
