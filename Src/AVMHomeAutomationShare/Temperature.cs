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
        public XmlNullableTemperature Celsius { get; set; }

        /// <summary>
        /// Temperatur offset value in ° Celsius
        /// </summary>
        [XmlElement("offset")]
        public XmlNullableTemperature Offset { get; set; }
    }
}
