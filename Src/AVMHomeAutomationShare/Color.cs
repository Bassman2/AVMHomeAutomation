using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Color
    {
        [XmlAttribute("sat_index")]
        public XmlNullableInt SatIndex { get; set; }

        [XmlAttribute("hue")]
        public XmlNullableInt Hue { get; set; }

        [XmlAttribute("sat")]
        public XmlNullableInt Sat { get; set; }

        [XmlAttribute("val")]
        public XmlNullableInt Val { get; set; }
    }
}
