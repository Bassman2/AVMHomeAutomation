using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Class for nullable Hkr Temperature serilization.
    /// </summary>
    public struct XmlNullableHkrTemperature : IXmlSerializable
    {
        private bool hasValue;
        private double value;

        /// <summary>
        /// Initializes a new instance of the XmlNullableHkrTemperature structure to the specified value.
        /// </summary>
        /// <param name="value">A double value.</param>
        public XmlNullableHkrTemperature(double value)
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
        public double Value { get { if (!hasValue) throw new InvalidOperationException("No value"); return value; } }

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
            return this.hasValue ? this.value.GetHashCode() : 0;
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
        public static implicit operator XmlNullableHkrTemperature(double value)
        {
            return new XmlNullableHkrTemperature(value);
        }

        /// <summary>
        /// Defines an conversion of a instance to its underlyling value.
        /// </summary>
        /// <param name="value">A value.</param>
        public static implicit operator double(XmlNullableHkrTemperature value)
        {
            return value.Value;
        }

        /// <summary>
        /// Defines an conversion of a instance to its underlyling nullable value.
        /// </summary>
        /// <param name="value">A value.</param>
        public static implicit operator double?(XmlNullableHkrTemperature value)
        {
            return value.hasValue ? (double?)value.value : null;
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
                // 0,5 °C, Wertebereich: 0x0 – 0x64
                // 0 <= 0°C, 1 = 0,5°C......120 = 60°C, 254 = ON , 253 = OFF
                switch (val)
                {
                case 254: // on
                    this.value = double.MaxValue;
                    this.hasValue = true;
                    break;
                case 253: // off
                    this.value = double.MinValue;
                    this.hasValue = true;
                    break;
                default:
                    this.value = val * 0.5;
                    this.hasValue = true;
                    break;
                }
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
