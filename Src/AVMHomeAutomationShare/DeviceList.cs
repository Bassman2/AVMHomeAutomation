using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("devicelist")]
    public class DeviceList
    {
        /// <summary>
        /// Version of the device list.
        /// </summary>
        [XmlAttribute("version")]
        public Version Version { get; set; }

        /// <summary>
        /// Firmware version
        /// </summary>
        [XmlAttribute("fwversion")]
        public Version FirmwareVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("device")]
        public List<Device> Devices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("group")]
        public List<Group> Groups { get; set; }
    }
}