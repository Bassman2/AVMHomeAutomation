using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Alert
    {
        [XmlElement("state")]
        public XmlEnum<AlertState> State { get; set; }

        [XmlElement("lastalertchgtimestamp")]
        public XmlNullableDateTime LastAlertChangeTimestamp { get; set;}
    }
}
