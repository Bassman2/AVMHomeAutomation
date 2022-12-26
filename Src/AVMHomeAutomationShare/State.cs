using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [XmlRoot("state")]
    public class State
    {
        [XmlAttribute("code")]
        public Code Code { get; set; }

        [XmlElement("latestain")]
        public string LatestAin { get; set; }
    }
}
