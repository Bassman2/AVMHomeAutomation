using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Temperature
    {
        [XmlElement("celsius")]
        public string Celsius { get; set; }

        [XmlElement("offset")]
        public string Offset { get; set; }
    }
}
