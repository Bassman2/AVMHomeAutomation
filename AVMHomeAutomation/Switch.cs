using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Switch
    {
        [XmlElement("state")]
        public string State { get; set; }

        [XmlElement("mode")]
        public string Mode { get; set; }

        [XmlElement("lock")]
        public string Lock { get; set; }

        [XmlElement("devicelock")]
        public string DeviceLock { get; set; }
    }
}
