using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class ColorControl
    {
        [XmlElement("hue")]
        public int Hue { get; set; }

        [XmlElement("saturation")]
        public int Saturation { get; set; }

        [XmlElement("unmapped_hue")]
        public int UnmappedHue { get; set; }

        [XmlElement("unmapped_saturation")]
        public int UnmappedSaturation { get; set; }

        [XmlElement("temperature")]
        public XmlNullable<int> Temperature { get; set; }
    }
}
