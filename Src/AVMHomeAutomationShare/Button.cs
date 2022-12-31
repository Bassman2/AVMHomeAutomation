using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Button
    {
        [XmlAttribute("identifier")]
        public string Identifier { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("lastpressedtimestamp")]
        public XmlNullableDateTime LastPressedTimestamp { get; set; }
    }
}
