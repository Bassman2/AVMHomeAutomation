using AVMHomeAutomation.Converter;
using Serialization;
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
        [XmlConverter(typeof(KiloConverter))]
        public double? Voltage { get; set; }

        /// <summary>
        /// Power value in W
        /// </summary>
        [XmlElement("power")]
        [XmlConverter(typeof(KiloConverter))]
        public double? Power { get; set; }
                
        /// <summary>
        /// Energy value in kWh
        /// </summary>
        [XmlElement("energy")]
        [XmlConverter(typeof(KiloConverter))]
        public double? Energy { get; set; }
    }
}
