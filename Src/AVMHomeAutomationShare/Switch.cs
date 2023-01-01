using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Switch
    {
        /// <summary>
        /// 0/1 - Switching state off / on (empty if unknown or error)
        /// </summary>
        [XmlElement("state")]
        public XmlNullableBool State { get; set; }

        /// <summary>
        /// "auto" or "manual" -> automatic time switching or manual switching (empty if unknown or error)
        /// </summary>
        [XmlElement("mode")]
        public XmlNullableBool Mode { get; set; }

        /// <summary>
        /// 0/1 - Switch lock via UI / API on no / yes (empty if unknown or error)
        /// </summary>
        [XmlElement("lock")]
        public XmlNullableBool Lock { get; set; }

        /// <summary>
        /// 0/1 - Switching lock directly on the device on no / yes (empty if unknown or error)
        /// </summary>
        [XmlElement("devicelock")]
        public XmlNullableBool DeviceLock { get; set; }
    }
}
