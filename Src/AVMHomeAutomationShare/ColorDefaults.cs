using System.Collections.Generic;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [XmlRoot("colordefaults")]
    public class ColorDefaults
    {

        [XmlArray("hsdefaults")]
        [XmlArrayItem("hs")]
        public List<HS> HSDefaults { get; set; }

        [XmlArray("temperaturedefaults")]
        [XmlArrayItem("temp")]
        public List<Temp> TemperatureDefaults { get; set; }
    }
}
