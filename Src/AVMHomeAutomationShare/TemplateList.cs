using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Template list
    /// </summary>
    [XmlRoot("templatelist")]
    public class TemplateList
    {
        /// <summary>
        /// Version of template list
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; }

        /// <summary>
        /// Identifier of the template.
        /// </summary>
        [XmlAttribute("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// ID of the template.
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// Functional bitmask of the template.
        /// </summary>
        [XmlAttribute("functionbitmask")]
        public int FunctionBitMask { get; set; }

        /// <summary>
        /// Name of the template
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// List of devices 
        /// </summary>
        [XmlArray("devices")]
        [XmlArrayItem("device")]
        public List<TemplateDevice> Devices { get; set; }

        /// <summary>
        /// Subnodes depending on which configuration is set.
        /// </summary>
        [XmlElement("applymask")]
        public ApplyMask ApplyMask { get; set; }
    }
}
