using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Temp
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }
}
