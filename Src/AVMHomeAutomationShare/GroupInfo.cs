using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Group information data
    /// </summary>
    public class GroupInfo
    {
        /// <summary>
        /// Internal id of the master/boss switch, 0 for "none set".
        /// </summary>
        [XmlElement("masterdeviceid")]
        public string masterdeviceid { get; set; }

        /// <summary>
        /// Internal ids of group members
        /// </summary>
        [XmlElement("members")]
        public XmlList<string> Members { get; set; }
    }
}
