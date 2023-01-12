using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Device with adjustable dimming, height, brightness or level
    /// </summary>
    public class LevelControl
    {
        /// <summary>
        /// Level (0 - 255)
        /// </summary>
        [XmlElement("level")]
        public XmlNullableInt Level { get; set; }

        /// <summary>
        /// Percentage level (0% to 100%)
        /// </summary>
        [XmlElement("levelpercentage")]
        public XmlNullableInt LevelPercentage { get; set; }
    }
}
