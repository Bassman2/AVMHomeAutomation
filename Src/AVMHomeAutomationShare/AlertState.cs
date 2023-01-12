using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Alarm sensor state.
    /// </summary>
    public enum AlertState
    {
        /// <summary>
        /// OK
        /// </summary>
        [XmlEnum("0")]
        OK = 0,

        /// <summary>
        /// Alarm
        /// </summary>
        [XmlEnum("1")]
        Alarm = 1,

        /// <summary>
        /// Temperature alarm
        /// </summary>
        [XmlEnum("2")]
        TemperatureAlarm = 2,
    }
}
