using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Serialization
{
    public static class XSerializer
    {
        public static string Serialize(object value, Type inputType, XmlSerializerContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, null);
            context.Serialize(writer, value, inputType);
            writer.Flush();
            writer.Close();
            return sb.ToString();
        }

        public static object Deserialize(string xml, Type returnType, XmlSerializerContext context)
        {
            XmlReader reader = XmlReader.Create(new StringReader(xml), null);
            return context.Deserialize(reader, returnType);
        }
    }
}
