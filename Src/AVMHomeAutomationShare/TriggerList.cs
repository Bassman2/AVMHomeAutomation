using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// List of all triggers.
    /// </summary>
    [XmlRoot("triggerlist")]
    public class TriggerList
    {
        /// <summary>
        /// Version of template list
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; }

        /// <summary>
        /// Devices and groups
        /// </summary>
        [XmlElement("trigger")]
        public List<Trigger> Triggers { get; set; }

    }
}
