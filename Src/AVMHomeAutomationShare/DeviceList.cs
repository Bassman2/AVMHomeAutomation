using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [XmlRoot("devicelist")]
    public class DeviceList
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("fwversion")]
        public string FirmwareVersion { get; set; }

        [XmlElement("device", typeof(Device))]
        [XmlElement("group", typeof(Group))]
        public List<Device> Devices { get; set; }
    }
}
