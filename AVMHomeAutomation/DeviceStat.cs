using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class DeviceStat
    {
        [XmlElement("stats")]
        public Stats Stats { get; set; }

        [XmlText]
        public string Stat { get; set; }
    }
}
