using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    [XmlRoot("colordefaults>")]
    public class ColorDefaults
    {
        [XmlElement("hsdefaults")]
        public HSDefaults HSDefaults { get; set; }

        [XmlElement("temperaturedefaults")]
        public TemperatureDefaults TemperatureDefaults { get; set; }
    }
}
