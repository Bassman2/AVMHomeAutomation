using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public enum OnOff
    {
        [XmlEnum("0")]
        Off = 0,

        [XmlEnum("1")]
        On = 1,

        [XmlEnum("2")]
        Toggle = 2
    }

}
