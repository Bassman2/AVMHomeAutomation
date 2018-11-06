using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class PowerMeter
    {
        [XmlElement("power")]
        public string Power { get; set; }

        [XmlElement("energy")]
        public string Energy { get; set; }

        [XmlElement("voltage")]
        public string Voltage { get; set; }

    }
}
