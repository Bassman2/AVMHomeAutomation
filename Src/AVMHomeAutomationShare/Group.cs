using System.Diagnostics;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [DebuggerDisplay("Group: {Name} -  {Manufacturer} - {ProductName}")]

    public class Group : Device
    {
        [XmlAttribute("synchronized")]
        public string Synchronized { get; set; }

        [XmlElement("groupinfo")]
        public GroupInfo GroupInfo { get; set; }
    }
}
