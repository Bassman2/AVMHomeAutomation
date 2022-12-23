using System;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class NextChange
    {
        static DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, 0) + (DateTime.Now - DateTime.UtcNow);

        [XmlElement("endperiod")]
        public long endPeriod { get; set; }

        //[XmlIgnore]
        //public DateTime? EndPeriod => (endPeriod == 0) ? (DateTime?)null : baseDate.AddSeconds(endPeriod);
            
        [XmlElement("tchange")]
        public int TChange { get; set; }
    }
}
