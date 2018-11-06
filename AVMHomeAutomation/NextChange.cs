using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class NextChange
    {
        [XmlElement("endperiod")]
        public string EndPeriod { get; set; }

        [XmlElement("tchange")]
        public string TChange { get; set; }
    }
}
