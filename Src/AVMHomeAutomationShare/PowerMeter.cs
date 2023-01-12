using System.Xml;
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
        public XmlNullableKilo Voltage { get; set; }

        /// <summary>
        /// Power value in W
        /// </summary>
        [XmlElement("power")]
        public XmlNullableKilo Power { get; set; }
                
        /// <summary>
        /// Energy value in kWh
        /// </summary>
        [XmlElement("energy")]
        public XmlNullableKilo Energy { get; set; }
    }
}
