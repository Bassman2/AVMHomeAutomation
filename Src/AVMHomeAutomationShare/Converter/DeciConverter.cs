using System;
using System.Xml;
using XSerializer;

namespace AVMHomeAutomation.Converter
{
    public class DeciConverter : IXmlConverter
    {
        public object Read(XmlReader reader, Type typeToConvert)
        {
            string value = reader.Value;
            if (double.TryParse(value, out double res))
            {
                return (double?)(res / 10.0);
            }
            return null;
        }

        public void Write(XmlWriter writer, string elementName, object value, Type typeToConvert)
        {
            if (value != null)
            {
                writer.WriteElementString(elementName, Convert.ToInt32(((double)value) * 10.0).ToString());
            }
        }
    }
}
