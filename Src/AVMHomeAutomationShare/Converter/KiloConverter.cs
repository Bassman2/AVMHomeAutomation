using System;
using System.Xml;
using XSerializer;

namespace AVMHomeAutomation.Converter
{
    public class KiloConverter : IXmlConverter
    {
        public object Read(XmlReader reader, Type typeToConvert)
        {
            string value = reader.Value;
            if (double.TryParse(value, out double res))
            {
                return (double?)(res / 1000.0);
            }
            return null;
        }

        public void Write(XmlWriter writer, string elementName, object value, Type typeToConvert)
        {
            if (value != null)
            {
                writer.WriteElementString(elementName, Convert.ToInt32(((double)value) * 1000.0).ToString());
            }
        }
    }
}
