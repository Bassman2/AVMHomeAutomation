using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// List of all devices.
    /// </summary>
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

        /// <summary>
        /// Devices and groups
        /// </summary>
        [XmlElement("device", typeof(Device))]
        [XmlElement("group", typeof(Group))]
        public List<Device> Devices { get; set; }
    }
}
