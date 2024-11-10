namespace AVMHomeAutomation.Service.Model
{
    /// <summary>
    /// Color data.
    /// </summary>
    public class ColorModel
    {
        /// <summary>
        /// Suturation index.
        /// </summary>
        [XmlAttribute("sat_index")]
        public int SatIndex { get; set; }

        /// <summary>
        /// Hue value of the color. (0 is 359)
        /// </summary>
        [XmlAttribute("hue")]
        public int Hue { get; set; }

        /// <summary>
        /// Saturation value of the color. (0 - 255)
        /// </summary>
        [XmlAttribute("sat")]
        public int Sat { get; set; }

        /// <summary>
        /// Value (0-255)
        /// </summary>
        [XmlAttribute("val")]
        public int Val { get; set; }
    }
}
