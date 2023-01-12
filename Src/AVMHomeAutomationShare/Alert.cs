using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Alarm sensor data.
    /// </summary>
    public class Alert
    {
        /// <summary>
        /// Last reported alarm condition.
        /// </summary>
        [XmlElement("state", IsNullable = true)]
        public XmlNullableEnum<AlertState> State { get; set; }

        /// <summary>
        /// Time of last alarm status change.
        /// </summary>
        [XmlElement("lastalertchgtimestamp")]
        public XmlNullableDateTime LastAlertChangeTimestamp { get; set;}
    }
}
