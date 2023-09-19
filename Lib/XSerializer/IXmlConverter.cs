using System;
using System.Xml;

namespace Serialization
{
    public interface IXmlConverter
    {
        object Read(XmlReader reader, Type typeToConvert);

        void Write(XmlWriter writer, string elementName, object value, Type typeToConvert);
    }
}
