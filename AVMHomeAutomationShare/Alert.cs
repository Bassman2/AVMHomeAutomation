using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Alert
    {
        [XmlElement("state")]
        public string State { get; set; }
    }
}
