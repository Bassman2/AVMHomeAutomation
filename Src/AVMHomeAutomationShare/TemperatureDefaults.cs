using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class TemperatureDefaults
    {
        [XmlElement("temp")]
        public List<Temp> Temps { get; set; }
    }
}
