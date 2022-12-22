using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class GroupInfo
    {
        [XmlElement("masterdeviceid")]
        public string masterdeviceid { get; set; }

        [XmlElement("members")]
        public string Members { get; set; }
    }
}
