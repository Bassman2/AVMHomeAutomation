using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class LevelControl
    {
        [XmlElement("level")]
        public XmlNullableInt Level { get; set; }

        [XmlElement("levelpercentage")]
        public XmlNullableInt LevelPercentage { get; set; }
    }
}
