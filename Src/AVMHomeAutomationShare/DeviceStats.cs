using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [XmlRoot("devicestats")]
    public class DeviceStats
    {
        [XmlArray("temperature")]
        [XmlArrayItem("stats")]
        public List<Stats> Temperature { get; set; }

        [XmlArray("voltage")]
        [XmlArrayItem("stats")]
        public List<Stats> Voltage { get; set; }

        [XmlArray("power")]
        [XmlArrayItem("stats")]
        public List<Stats> Power { get; set; }

        [XmlArray("energy")]
        [XmlArrayItem("stats")]
        public List<Stats> Energy { get; set; }

        [XmlArray("humidity")]
        [XmlArrayItem("stats")]
        public List<Stats> Humidity { get; set; }
    }
}
