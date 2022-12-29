using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Color
    {
        [XmlAttribute("sat_index")]
        public int SatIndex { get; set; }

        [XmlAttribute("hue")]
        public int Hue { get; set; }

        [XmlAttribute("sat")]
        public int Sat { get; set; }

        [XmlAttribute("val")]
        public int Val { get; set; }
    }
}
