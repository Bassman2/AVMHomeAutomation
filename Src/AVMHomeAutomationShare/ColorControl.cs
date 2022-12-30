using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class ColorControl
    {
        [XmlElement("hue")]
        public XmlNullable<int> Hue { get; set; }

        [XmlElement("saturation")]
        public XmlNullable<int> Saturation { get; set; }

        [XmlElement("unmapped_hue")]
        public XmlNullable<int> UnmappedHue { get; set; }

        [XmlElement("unmapped_saturation")]
        public XmlNullable<int> UnmappedSaturation { get; set; }

        [XmlElement("temperature")]
        public XmlNullable<int> Temperature { get; set; }
    }
}
