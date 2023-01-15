using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Data for trigger.
    /// </summary>
    public class Trigger
    {
        /// <summary>
        /// Identifier of the trigger.
        /// </summary>
        [XmlAttribute("identifier")]
        public string Identifier { get; set; }
    }
}
