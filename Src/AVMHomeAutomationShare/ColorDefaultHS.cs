using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Hue and saturation color default values
    /// </summary>
    public class ColorDefaultHS
    {
        /// <summary>
        /// Hue index.
        /// </summary>
        [XmlAttribute("hue_index")]
        public int HueIndex { get; set; }

        /// <summary>
        /// ColorName of the color
        /// </summary>
        [XmlElement("name")]
        public ColorName Name {  get; set;}

        /// <summary>
        /// Colors
        /// </summary>
        [XmlElement("color")]
        public List<Color> Colors { get; set; }
    }
}
