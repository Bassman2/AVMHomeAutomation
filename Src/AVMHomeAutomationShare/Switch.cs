using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Data for switch socket.
    /// </summary>
    public class Switch
    {
        /// <summary>
        /// Switching state off / on 
        /// </summary>
        [XmlElement("state")]
        public XmlNullableBool State { get; set; }

        /// <summary>
        /// Automatic time switching (false) or manual switching (true)
        /// </summary>
        [XmlElement("mode")]
        public XmlNullableBool Mode { get; set; }

        /// <summary>
        /// Switch lock via UI / API on no / yes 
        /// </summary>
        [XmlElement("lock")]
        public XmlNullableBool Lock { get; set; }

        /// <summary>
        /// Switching lock directly on the device on no / yes 
        /// </summary>
        [XmlElement("devicelock")]
        public XmlNullableBool DeviceLock { get; set; }
    }
}
