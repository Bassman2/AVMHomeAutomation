using System;

namespace Serialization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class XmlSerializableAttribute : Attribute
    {
        public XmlSerializableAttribute(Type type)
        { 
            this.Type = type;
        }

        public Type Type { get; }
    }
}
