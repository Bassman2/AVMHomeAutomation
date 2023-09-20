﻿using Serialization;
using System;
using System.Xml;

namespace AVMHomeAutomation.Converter
{
    /// <summary>
    /// Converts string to decimal number
    /// </summary>
    public class DeciConverter : IXmlConverter
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <returns></returns>
        public object Read(XmlReader reader, Type typeToConvert)
        {
            string value = reader.Value;
            if (double.TryParse(value, out double res))
            {
                return (double?)(res / 10.0);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="elementName"></param>
        /// <param name="value"></param>
        /// <param name="typeToConvert"></param>
        public void Write(XmlWriter writer, string elementName, object value, Type typeToConvert)
        {
            if (value != null)
            {
                writer.WriteElementString(elementName, Convert.ToInt32(((double)value) * 10.0).ToString());
            }
        }
    }
}