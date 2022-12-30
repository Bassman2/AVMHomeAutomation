using System;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class NextChange
    {
        [XmlElement("endperiod")]
        public XmlNullableDateTime EndPeriod { get; set; }
            
        [XmlElement("tchange")]
        public int TChange { get; set; }
    }
}
