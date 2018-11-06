using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Hkr
    {
        [XmlElement("tist")]
        public string TIst { get; set; }

        [XmlElement("tsoll")]
        public string TSoll { get; set; }

        [XmlElement("komfort")]
        public string Komfort { get; set; }

        [XmlElement("absenk")]
        public string Absenk { get; set; }

        [XmlElement("batterylow")]
        public string BatteryLow { get; set; }

        [XmlElement("windowopenactiv")]
        public string WindowOpenActiv { get; set; }

        [XmlElement("lock")]
        public string Lock { get; set; }

        [XmlElement("devicelock")]
        public string DeviceLock { get; set; }

        [XmlElement("nextchange")]
        public NextChange NextChange { get; set; }

        [XmlElement("errorcode")]
        public int ErrorCode { get; set; }

    }
}
