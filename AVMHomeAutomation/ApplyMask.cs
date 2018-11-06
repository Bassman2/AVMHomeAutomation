using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class ApplyMask
    {
        [XmlElement("hkr_summer")]
        public string HkrSummer { get; set; }

        [XmlElement("hkr_temperature")]
        public string HkrTemperature { get; set; }

        [XmlElement("hkr_holidays")]
        public string HkrHolidays { get; set; }

        [XmlElement("hkr_time_table")]
        public string HkrTimeTable { get; set; }

        [XmlElement("relay_manual")]
        public string RelayManual { get; set; }

        [XmlElement("relay_automatic")]
        public string RelayAutomatic { get; set; }
    }
}
