using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Alert
    {
        [XmlElement("state", IsNullable = true)]
        public XmlNullableEnum<AlertState> State { get; set; }
        //public AlertState? State { get; set; }

        [XmlElement("lastalertchgtimestamp")]
        public XmlNullableDateTime LastAlertChangeTimestamp { get; set;}
    }
}
