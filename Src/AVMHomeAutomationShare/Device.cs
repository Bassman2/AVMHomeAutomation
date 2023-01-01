using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [DebuggerDisplay("Device: {Name} -  {Manufacturer} - {ProductName}")]
    [XmlRoot("device")]
    public class Device
    {
        /// <summary>
        /// AIN, MAC address or unique ID
        /// </summary>
        [XmlAttribute("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Internal device ID
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// Firmware version of the device
        /// </summary>
        [XmlAttribute("fwversion")]
        public string FirmwareVersion { get; set; }

        /// <summary>
        /// Manufacturer of the device
        /// </summary>
        [XmlAttribute("manufacturer")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Product name of the device, empty with unknown / undefined device
        /// </summary>
        [XmlAttribute("productname")]
        public string ProductName { get; set; }

        /// <summary>
        /// Bit mask of the device function classes, starting with bit 0, several bits can be set. For internal use only. Use Functions instead.
        /// </summary>
        [XmlAttribute("functionbitmask")]
        public int FunctionBitMask { get; set; }        
        
        /// <summary>
        /// Functions of the device
        /// </summary>
        [XmlIgnore]
        public Functions Functions { get { return (Functions)FunctionBitMask; } }
        
        /// <summary>
        /// 0/1 - Device connected no / yes. For internal use only. Use IsPresent instead.
        /// </summary>
        [XmlElement("present")]
        public XmlNullableBool IsPresent { get; set; }
        
        [XmlElement("txbusy")]
        public XmlNullableBool IsTXBusy { get; set; }
        
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("batterylow", IsNullable=true)]
        public XmlNullableBool IsBatteryLow { get; set; }

        [XmlElement("battery", IsNullable = true)]
        public XmlNullableInt Battery { get; set; }



        [XmlElement("switch", IsNullable = true)]
        public Switch Switch { get; set; }

        [XmlElement("powermeter", IsNullable = true)]
        public PowerMeter PowerMeter { get; set; }

        [XmlElement("temperature", IsNullable = true)]
        public Temperature Temperature { get; set; }

        [XmlElement("alert", IsNullable = true)]
        public Alert Alert { get; set; }

        [XmlElement("button")]
        public List<Button> Buttons { get; set; }

        [XmlElement("etsiunitinfo", IsNullable = true)]
        public EtsiUnitInfo EtsiUnitInfo { get; set; }

        [XmlElement("simpleonoff", IsNullable = true)]
        public SimpleOnOff SimpleOnOff { get; set; }

        [XmlElement("levelcontrol", IsNullable = true)]
        public LevelControl LevelControl { get; set; }

        [XmlElement("colorcontrol", IsNullable = true)]
        public ColorControl ColorControl { get; set; }











        [XmlElement("hkr", IsNullable = true)]
        public Hkr Hkr { get; set; }
        
    }
}
