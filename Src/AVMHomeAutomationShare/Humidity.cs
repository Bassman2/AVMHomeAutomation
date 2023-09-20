using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Humidity data
    /// </summary>
    public class Humidity
    {
        /// <summary>
        /// Relative Humidity in percent 0 - 100, -9999 for unknown
        /// </summary>
        [XmlElement("rel_humidity")]
        public int? RelHumidity { get; set; }
    }
}
