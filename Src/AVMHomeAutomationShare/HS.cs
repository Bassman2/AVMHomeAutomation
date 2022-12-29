using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class HS
    {
        [XmlAttribute("hue_index")]
        public int HueIndex { get; set; }

        [XmlElement("name")]
        public Name Name {  get; set;}

        [XmlElement("color")]
        public List<Color> Colors { get; set; }
    }
}
