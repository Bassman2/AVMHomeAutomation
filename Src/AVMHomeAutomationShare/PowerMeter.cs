using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Energy meter
    /// </summary>
    public class PowerMeter 
    {
        /// <summary>
        /// Voltage value in Volt
        /// </summary>
        [XmlElement("voltage")]
        public XmlKilo Voltage { get; set; }

        /// <summary>
        /// Power value in W
        /// </summary>
        [XmlElement("power")]
        public XmlKilo Power { get; set; }
                
        /// <summary>
        /// Energy value in kWh
        /// </summary>
        [XmlElement("energy")]
        public XmlKilo Energy { get; set; }
    }
}
