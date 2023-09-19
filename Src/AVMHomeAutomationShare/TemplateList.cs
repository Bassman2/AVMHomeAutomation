using System;
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
        public Version Version { get; set; }

        /// <summary>
        /// Devices and groups
        /// </summary>
        [XmlElement("template")]
        public List<Template> Templates { get; set; }        
    }
}
