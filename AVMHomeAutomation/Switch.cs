using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Switch
    {
        /// <summary>
        /// 0/1 - Switching state off / on (empty if unknown or error)
        /// </summary>
        [XmlElement("state")]
        public string State { get; set; }

        /// <summary>
        /// "auto" or "manual" -> automatic time switching or manual switching (empty if unknown or error)
        /// </summary>
        [XmlElement("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// 0/1 - Switch lock via UI / API on no / yes (empty if unknown or error)
        /// </summary>
        [XmlElement("lock")]
        public string Lock { get; set; }

        /// <summary>
        /// 0/1 - Switching lock directly on the device on no / yes (empty if unknown or error)
        /// </summary>
        [XmlElement("devicelock")]
        public string DeviceLock { get; set; }
    }
}
