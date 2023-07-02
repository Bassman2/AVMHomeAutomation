using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Template device
    /// </summary>
    public class ItemIdentifier

    {
        /// <summary>
        /// Identifier
        /// </summary>
        [XmlAttribute("identifier")]
        public string Identifier { get; set; }
    }
}
