using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Temperature
    {
        /// <summary>
        /// Value in 0.1 ° C, negative and positive values possible
        /// </summary>
        [XmlElement("celsius", IsNullable=true)]
        public int? Celsius { get; set; }

        /// <summary>
        /// Value in 0.1 ° C, negative and positive values possible
        /// </summary>
        [XmlElement("offset", IsNullable = true)]
        public int? Offset { get; set; }
    }
}
