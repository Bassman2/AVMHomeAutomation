﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using AVMHomeAutomation;
using AVMHomeAutomation.Converter;

namespace Serialization
{
    internal static class XSerializerGen
    {
        public static string Serialize(object value, Type inputType, XmlWriterSettings settings = null)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, settings);
            Serialize(writer, value, inputType);
            writer.Flush();
            writer.Close();
            return sb.ToString();
        }
                
        public static void Serialize(XmlWriter writer, object value, Type inputType)
        {
            switch (inputType.FullName)
            {
            case nameof(DeviceList): SerializeDeviceList(writer, (DeviceList)value, inputType); break;
            case nameof(Device): SerializeDeviceList(writer, (DeviceList)value, inputType); break;
            case nameof(Group): SerializeDeviceList(writer, (DeviceList)value, inputType); break;
            default: throw new ArgumentException("Unknown type", inputType.Name);
            }
        }

        public static object Deserialize(string xml, Type returnType, XmlReaderSettings settings = null)
        {
            XmlReader reader = XmlReader.Create(new StringReader(xml), settings);
            return Deserialize(reader, returnType);
        }

        public static object Deserialize(XmlReader reader, Type returnType)
        {
            object result = null;
            reader.MoveToContent();
            switch (returnType.FullName)
            {
            case "AVMHomeAutomation.DeviceList": result = DeserializeDeviceList(reader, returnType); break;
            case nameof(Device): result = DeserializeDeviceList(reader, returnType); break;
            case nameof(Group): result = DeserializeDeviceList(reader, returnType); break;
            default: throw new ArgumentException("Unknown type", returnType.Name);
            };
            return result;
        }



        private static void SerializeDemo1(XmlWriter writer, Demo1 value, Type inputType)
        {
            writer.WriteStartElement("Demo1");
            //writer.WriteAttributeString("version", value.Version);
            //writer.WriteAttributeString("fwversion", value.FirmwareVersion);
            //foreach (var item in value.DevicesList)
            //{
            //    SerializeDevice(item, writer);
            //}
            //foreach (var item in value.GroupsList)
            //{
            //    SerializeGroup(item, writer);
            //}
            writer.WriteEndElement();
        }

        private static Demo1 DeserializeDemo1(XmlReader reader, Type inputType)
        {
            return new Demo1();
        }


        private static void SerializeProgram(XmlWriter writer, Program value, Type inputType)
        {
            writer.WriteStartElement("Program");
            //writer.WriteAttributeString("version", value.Version);
            //writer.WriteAttributeString("fwversion", value.FirmwareVersion);
            //foreach (var item in value.DevicesList)
            //{
            //    SerializeDevice(item, writer);
            //}
            //foreach (var item in value.GroupsList)
            //{
            //    SerializeGroup(item, writer);
            //}
            writer.WriteEndElement();
        }

        private static Program DeserializeProgram(XmlReader reader, Type inputType)
        {
            return new Program();
        }


    }
}