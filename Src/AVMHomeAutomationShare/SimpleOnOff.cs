using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Device/socket/lamp/actuator that can be switched on/off.
    /// </summary>
    public class SimpleOnOff
    {
        /// <summary>
        /// Current switching status.
        /// </summary>
        [XmlElement("state")]
        public XmlNullableBool State { get; set; }
    }
}
