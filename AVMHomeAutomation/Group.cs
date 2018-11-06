using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Group : Device
    {
        [XmlElement("groupinfo")]
        public GroupInfo GroupInfo { get; set; }
    }
}
