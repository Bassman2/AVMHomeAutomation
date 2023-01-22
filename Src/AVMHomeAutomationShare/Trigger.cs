using System;
using System.Collections.Generic;
using System.Text;
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

        /// <summary>
        /// Identifier of the trigger.
        /// </summary>
        [XmlAttribute("active:")]
        public int Active { get; set; }

        /// <summary>
        /// Name of the trigger.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
