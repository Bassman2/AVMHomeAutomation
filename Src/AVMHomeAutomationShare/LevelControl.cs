using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class LevelControl
    {
        [XmlElement("level")]
        public XmlNullable<int> Level { get; set; }

        [XmlElement("levelpercentage")]
        public XmlNullable<int> LevelPercentage { get; set; }
    }
}
