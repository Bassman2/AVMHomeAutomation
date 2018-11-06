using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Button
    {
        [XmlElement("lastpressedtimestamp")]
        public string LastPressedTimestamp { get; set; }
    }
}
