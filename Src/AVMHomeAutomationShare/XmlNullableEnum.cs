using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Class for nullable Enum serilization.
    /// </summary>
    /// <typeparam name="T">Underlying enum type.</typeparam>
    public struct XmlNullableEnum<T> : IXmlSerializable where T : struct 
    {
        private bool hasValue;
        private T value;

        /// <summary>
        /// Initializes a new instance of the XmlNullableEnum structure to the specified value.
        /// </summary>
        /// <param name="value">A int value.</param>
        public XmlNullableEnum(T value)
        {
            this.hasValue = true;
            this.value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the current object has a valid value.
        /// </summary>
        public bool HasValue { get => hasValue; }

        /// <summary>
        /// Gets the value of the current object if it has been assigned a valid underlying value.
        /// </summary>
        public T Value { get { if (!hasValue) throw new InvalidOperationException("No value"); return value; } }

        /// <summary>
        /// Indicates whether the current object is equal to a specified object.
        /// </summary>
        /// <param name="other">An object.</param>
        /// <returns>true if the other parameter is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object other)
        {
            if (!this.hasValue)
            {
                return other == null;
            }
            if (other == null)
            {
                return false;
            }
            return this.value.Equals(other);
        }

        /// <summary>
        ///  Retrieves the hash code of the object returned by the Value property.
        /// </summary>
        /// <returns>The hash code of the object returned by the Value property.</returns>
        public override int GetHashCode()
        {
            return this.HasValue ? this.Value.GetHashCode() : 0;
        }

        /// <summary>
        /// Returns the text representation of the value of the current object.
        /// </summary>
        /// <returns>The text representation of the value of the current object</returns>
        public override string ToString()
        {
            return this.hasValue ? this.value.ToString() : string.Empty;
        }

        /// <summary>
        /// Creates a new object initialized to a specified value.
        /// </summary>
        /// <param name="value">A value.</param>
        /// <returns>New instance.</returns>
        public static implicit operator XmlNullableEnum<T>(T value)
        {
            return new XmlNullableEnum<T>(value);
        }

        /// <summary>
        /// Defines an conversion of a instance to its underlyling value.
        /// </summary>
        /// <param name="value">A value.</param>
        /// <returns>The value.</returns>
        public static implicit operator T(XmlNullableEnum<T> value)
        {
            return value.Value;
        }

        /// <summary>
        /// Defines an conversion of a instance to its underlyling nullable value.
        /// </summary>
        /// <param name="value">A value.</param>
        /// <returns>The value.</returns>
        public static implicit operator Nullable<T>(XmlNullableEnum<T> value)
        {
            return value.hasValue ? ((Nullable<T>)value.value) : null;
        }

        #region IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used.
        /// </summary>
        /// <returns>Return null.</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The XmlReader stream from which the object is deserialized.</param>
        public void ReadXml(XmlReader reader)
        {
            string str = reader.ReadElementContentAsString();
            if (this.hasValue = int.TryParse(str, out int val))
            {
                this.value = (T)Enum.ToObject(typeof(T), val);
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The XmlWriter stream to which the object is serialized.</param>
        /// <exception cref="NotImplementedException">Not implemented in this class.</exception>
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        #endregion        
    }
}
