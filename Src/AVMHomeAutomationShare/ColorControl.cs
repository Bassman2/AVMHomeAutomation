using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class ColorControl
    {
        [XmlElement("hue")]
        public XmlNullableInt Hue { get; set; }

        [XmlElement("saturation")]
        public XmlNullableInt Saturation { get; set; }

        [XmlElement("unmapped_hue")]
        public XmlNullableInt UnmappedHue { get; set; }

        [XmlElement("unmapped_saturation")]
        public XmlNullableInt UnmappedSaturation { get; set; }

        [XmlElement("temperature")]
        public XmlNullableInt Temperature { get; set; }
    }
}
