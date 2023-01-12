using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Switch values
    /// </summary>
    public enum OnOff
    {
        /// <summary>
        /// Set to off.
        /// </summary>
        [XmlEnum("0")]
        Off = 0,

        /// <summary>
        /// Set to on.
        /// </summary>
        [XmlEnum("1")]
        On = 1,

        /// <summary>
        /// Toggle state.
        /// </summary>
        [XmlEnum("2")]
        Toggle = 2
    }
}
