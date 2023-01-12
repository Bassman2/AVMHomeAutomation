using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Template device
    /// </summary>
    public class TemplateDevice
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [XmlAttribute("identifier")]
        public string Identifier { get; set; }
    }
}
