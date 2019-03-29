using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Stats
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlAttribute("grid")]
        public int Grid { get; set; }
    }
}
