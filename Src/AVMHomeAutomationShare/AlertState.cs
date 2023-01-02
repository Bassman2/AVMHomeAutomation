using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public enum AlertState
    {
        [XmlEnum("0")]
        OK = 0,

        [XmlEnum("1")]
        Alarm = 1,

        [XmlEnum("2")]
        TemperatureAlarm = 2,
    }
}
