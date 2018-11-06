using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Device
    {
        [XmlAttribute("identifier")]
        public string Identifier { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("fwversion")]
        public string FirmwareVersion { get; set; }

        [XmlAttribute("manufacturer")]
        public string Manufacturer { get; set; }

        [XmlAttribute("productname")]
        public string ProductName { get; set; }

        [XmlAttribute("functionbitmask")]
        public string FunctionBitMask { get; set; }

        [XmlElement("present")]
        public string Present { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("switch", IsNullable = true)]
        public Switch Switch { get; set; }

        [XmlElement("powermeter", IsNullable = true)]
        public PowerMeter PowerMeter { get; set; }

        [XmlElement("temperature", IsNullable = true)]
        public Temperature Temperature { get; set; }

        [XmlElement("alert", IsNullable = true)]
        public Alert Alert { get; set; }

        [XmlElement("button", IsNullable = true)]
        public Button Button { get; set; }

        [XmlElement("etsiunitinfo", IsNullable = true)]
        public EtsiUnitInfo EtsiUnitInfo { get; set; }

        [XmlElement("hkr", IsNullable = true)]
        public Hkr Hkr { get; set; }
    }
}
