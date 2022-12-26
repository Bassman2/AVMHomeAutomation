using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class Name
    {
        [XmlAttribute("enum")]
        public int Enum { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
