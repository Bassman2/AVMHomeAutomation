using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Data for template.
    /// </summary>
    public class Template
    {
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
        /// Functions of the template
        /// </summary>
        [XmlIgnore]
        public Functions Functions { get => (Functions)FunctionBitMask;  }

        /// <summary>
        /// Was template generated automatically?
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlAttribute("autocreate")]
        public int AutocCeate { get; set; }

        /// <summary>
        /// Subnodes depending on which configuration is set.
        /// </summary>
        [XmlAttribute("applymask")]
        public int ApplyBitMask { get; set; }

        /// <summary>
        /// Functions of the template
        /// </summary>
        [XmlIgnore]
        public int Applies { get => ApplyBitMask; } 

        /// <summary>
        /// Name of the template
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Json metadata
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("metadata")]
        public string MetaData { get; set; }

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

        /// <summary>
        /// List of subtemplates 
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlArray("sub_templates")]
        [XmlArrayItem("template")]
        public List<Template> SubTemplates { get; set; }

        /// <summary>
        /// List of sub triggers 
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlArray("triggers")]
        [XmlArrayItem("trigger>")]
        public List<Trigger> Triggers { get; set; }
    }
}
