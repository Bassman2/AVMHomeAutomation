using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class HSDefaults
    {
        [XmlElement("hs")]
        public List<HS> HSs { get; set; }
    }
}
