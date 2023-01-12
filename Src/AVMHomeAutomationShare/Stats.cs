using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Status values
    /// </summary>
    public class Stats
    {
        /// <summary>
        /// Number of values
        /// </summary>
        [XmlAttribute("count")]
        public int Count { get; set; }

        /// <summary>
        /// Grid of values
        /// </summary>
        [XmlAttribute("grid")]
        public int Grid { get; set; }

        /// <summary>
        /// Values
        /// </summary>
        [XmlText]
        public string Value { get; set; }
    }
}
