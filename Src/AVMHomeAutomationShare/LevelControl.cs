using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class LevelControl
    {
        [XmlElement("level")]
        public int Level { get; set; }

        [XmlElement("levelpercentage")]
        public int LevelPercentage { get; set; }
    }
}
