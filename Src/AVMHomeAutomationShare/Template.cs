using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
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
