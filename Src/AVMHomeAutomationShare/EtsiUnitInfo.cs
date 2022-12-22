using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class EtsiUnitInfo
    {
        [XmlElement("etsideviceid")]
        public string EtsiDeviceId { get; set; }

        [XmlElement("unittype")]
        public string UnitType { get; set; }

        [XmlElement("interfaces")]
        public string Interfaces { get; set; }
    }
}
