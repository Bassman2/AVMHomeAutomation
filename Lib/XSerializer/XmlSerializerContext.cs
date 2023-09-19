using System.Xml;
using System;
using System.Collections.Generic;

namespace Serialization
{
    public abstract class XmlSerializerContext
    {
        public abstract void Serialize(XmlWriter writer, object value, Type inputType);

        public abstract object Deserialize(XmlReader reader, Type returnType);

        protected static List<T> AddElement<T>(List<T> list, T obj)
        {
            list = list ?? new List<T>();
            list.Add(obj);
            return list;
        }
    }
}
