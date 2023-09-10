using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [XmlRoot("devicelist")]
    public class DeviceList
    {
        /// <summary>
        /// Version of the device list.
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; }

        /// <summary>
        /// Firmware version
        /// </summary>
        [XmlAttribute("fwversion")]
        public string FirmwareVersion { get; set; }

        [XmlElement("device")]
        public List<Device> Devices { get; set; }

        [XmlElement("group")]
        public List<Group> Groups { get; set; }
    }
}