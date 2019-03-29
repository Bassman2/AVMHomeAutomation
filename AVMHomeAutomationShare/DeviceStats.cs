using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [XmlRoot("devicestats")]
    public class DeviceStats
    {
        [XmlElement("temperature>")]
        public DeviceStat Temperature { get; set; }

        [XmlElement("voltage")]
        public DeviceStat Voltage { get; set; }

        [XmlElement("power")]
        public DeviceStat Power { get; set; }
    }
}
