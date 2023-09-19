using AVMHomeAutomation.Converter;
using Serialization;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Temperature sensor data.
    /// </summary>
    public class Temperature
    {
        /// <summary>
        /// Temperatur value in ° Celsius
        /// </summary>
        [XmlElement("celsius")]
        [XmlConverter(typeof(DeciConverter))]
        public double? Celsius { get; set; }

        /// <summary>
        /// Temperatur offset value in ° Celsius
        /// </summary>
        [XmlElement("offset")]
        [XmlConverter(typeof(DeciConverter))]
        public double? Offset { get; set; }
    }
}
