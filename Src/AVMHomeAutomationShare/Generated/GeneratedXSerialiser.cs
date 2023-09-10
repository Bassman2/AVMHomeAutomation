using AVMHomeAutomation.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using XSerializer;


namespace AVMHomeAutomation
{
    public static class GeneratedXSerialiser
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
            reader.MoveToContent();
            object ret;
            switch (returnType.FullName)
            {
            case "AVMHomeAutomation.DeviceList": ret = DeserializeDeviceList(reader, returnType); break;
            case nameof(Device): ret = DeserializeDeviceList(reader, returnType); break;
            case nameof(Group): ret = DeserializeDeviceList(reader, returnType); break;
            default: throw new ArgumentException("Unknown type", returnType.Name);
            };
            return ret;
        }

        public static void SerializeDeviceList(XmlWriter writer, DeviceList value, Type inputType)
        {
            writer.WriteStartElement("devicelist");
            writer.WriteAttributeString("version", value.Version);
            writer.WriteAttributeString("fwversion", value.FirmwareVersion);
            foreach (var item in value.Devices)
            {
                SerializeDevice(writer, item, typeof(Device));
            }
            foreach (var item in value.Groups)
            {
                SerializeGroup(writer, item, typeof(Group));
            }
            writer.WriteEndElement();
        }

        public static DeviceList DeserializeDeviceList(XmlReader reader, Type returnType)
        {
            if (reader.NodeType != XmlNodeType.Element)
            {
                throw new Exception("Not an element node");
            }
            if (reader.Name != "devicelist")
            {
                throw new Exception($"Wrong element: {reader.Name}");
            }

            DeviceList obj = new DeviceList();
            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "version": obj.Version = reader.Value.ValueToString(); break;
                    case "fwversion": obj.FirmwareVersion = reader.Value.ValueToString(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "device": (obj.Devices ?? (obj.Devices = new List<Device>())).Add(DeserializeDevice(reader, typeof(Device))); break;
                    case "group": (obj.Groups ?? (obj.Groups = new List<Group>())).Add(DeserializeGroup(reader, typeof(Group))); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return obj;
                }

            }
            return obj;
        }

        public static void SerializeDevice(XmlWriter writer, Device value, Type inputType)
        {
            writer.WriteStartElement("device");
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("id", value.Id);
            writer.WriteAttributeString("fwversion", value.FirmwareVersion);
            writer.WriteAttributeString("manufacturer", value.Manufacturer);
            writer.WriteAttributeString("productname", value.ProductName);
            writer.WriteAttributeString("functionbitmask", ((uint)value.FunctionBitMask).ToString()); // enum

            writer.WriteElementString("present", value.IsPresent.ToElementString());
            writer.WriteElementString("txbusy", value.IsTXBusy.ToElementString());
            writer.WriteElementString("name", value.Name);
            writer.WriteElementString("batterylow", value.IsBatteryLow.ToElementString());
            writer.WriteElementString("battery", value.Battery.ToElementString());

            SerializeSwitch(writer, value.Switch, typeof(Switch));
            SerializePowerMeter(writer, value.PowerMeter, typeof(PowerMeter));
            SerializeTemperature(writer, value.Temperature, typeof(Temperature));
            SerializeAlert(writer, value.Alert, typeof(Alert));

            foreach (var item in value.Buttons)
            {
                SerializeButton(writer, item, typeof(Button));
            }

            SerializeEtsiUnitInfo(writer, value.EtsiUnitInfo, typeof(EtsiUnitInfo));
            SerializeSimpleOnOff(writer, value.SimpleOnOff, typeof(SimpleOnOff));
            SerializeLevelControl(writer, value.LevelControl, typeof(LevelControl));
            SerializeColorControl(writer, value.ColorControl, typeof(ColorControl));
            SerializeHkr(writer, value.Hkr, typeof(Hkr));

            writer.WriteEndElement();
        }

        public static Device DeserializeDevice(XmlReader reader, Type inputType)
        {
            if (reader.NodeType != XmlNodeType.Element)
            {
                throw new Exception("Not an element node");
            }
            if (reader.Name != "device")
            {
                throw new Exception($"Wrong element: {reader.Name}");
            }

            Device obj = new Device();
            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": obj.Identifier = reader.Value.ValueToString(); break;
                    case "id": obj.Id = reader.Value.ValueToString(); break;
                    case "fwversion": obj.FirmwareVersion = reader.Value.ValueToString(); break;
                    case "manufacturer": obj.Manufacturer = reader.Value.ValueToString(); break;
                    case "productname": obj.ProductName = reader.Value.ValueToString(); break;
                    case "functionbitmask": obj.FunctionBitMask = reader.Value.ValueToEnum<Functions>(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "present": obj.IsPresent = reader.ReadValue().ValueToNullableBool(); break;
                    case "txbusy": obj.IsTXBusy = reader.ReadValue().ValueToNullableBool(); break;
                    case "name": obj.Name = reader.ReadValue().ValueToString(); break;
                    case "batterylow": obj.IsBatteryLow = reader.ReadValue().ValueToNullableBool(); break;
                    case "battery": obj.Battery = reader.ReadValue().ValueToNullableInt(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return obj;
                }

            }
            return obj;
        }

        public static void SerializeGroup(XmlWriter writer, Group value, Type inputType)
        {
            writer.WriteStartElement("group");
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

        public static Group DeserializeGroup(XmlReader reader, Type inputType)
        {
            return new Group();
        }

        public static void SerializeSwitch(XmlWriter writer, Switch value, Type inputType)
        {
            writer.WriteStartElement("devicelist");
            writer.WriteElementString("state", value.State.ToElementString());
            writer.WriteElementString("mode", value.Mode.ToElementString());
            writer.WriteElementString("lock", value.Lock.ToElementString());
            writer.WriteElementString("devicelock", value.DeviceLock.ToElementString());
            writer.WriteEndElement();
        }

        public static void SerializePowerMeter(XmlWriter writer, PowerMeter value, Type inputType)
        {
            writer.WriteStartElement("powermeter");
            writer.WriteConverter("voltage", value.Voltage, typeof(double?), typeof(KiloConverter));
            writer.WriteConverter("power", value.Power, typeof(double?), typeof(KiloConverter));
            writer.WriteConverter("energy", value.Energy, typeof(double?), typeof(KiloConverter));
            writer.WriteEndElement();
        }

        public static void SerializeTemperature(XmlWriter writer, Temperature value, Type inputType)
        {
            writer.WriteStartElement("temperature");
            writer.WriteConverter("celsius", value.Celsius, typeof(double?), typeof(DeciConverter));
            writer.WriteConverter("offset", value.Offset, typeof(double?), typeof(DeciConverter));
            writer.WriteEndElement();
        }

        public static void SerializeAlert(XmlWriter writer, Alert value, Type inputType)
        {
            writer.WriteStartElement("alert");
            writer.WriteElementString("state", value.State.ToElementString());
            writer.WriteElementString("lastalertchgtimestamp", value.LastAlertChangeTimestamp.ToElementString());
            writer.WriteEndElement();
        }

        public static void SerializeButton(XmlWriter writer, Button value, Type inputType)
        {
            writer.WriteStartElement("button");
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("id", value.Id);
            writer.WriteElementString("name", value.Name);
            writer.WriteElementString("lastpressedtimestamp", value.LastPressedTimestamp.ToElementString());
            writer.WriteEndElement();
        }

        public static void SerializeEtsiUnitInfo(XmlWriter writer, EtsiUnitInfo value, Type inputType)
        {
            writer.WriteStartElement("etsiunitinfo");
            writer.WriteElementString("etsideviceid", value.EtsiDeviceId);
            writer.WriteElementString("unittype", value.UnitType.ToElementString());
            foreach (var item in value.Interfaces)
            {
                writer.WriteElementString("interfaces", item.ToElementString());
            }
            writer.WriteEndElement();
        }

        public static void SerializeSimpleOnOff(XmlWriter writer, SimpleOnOff value, Type inputType)
        {
            writer.WriteStartElement("simpleonoff");
            writer.WriteElementString("state", value.State.ToElementString());
            writer.WriteEndElement();
        }

        public static void SerializeLevelControl(XmlWriter writer, LevelControl value, Type inputType)
        {
            writer.WriteStartElement("levelcontrol");
            writer.WriteElementString("level", value.Level.ToElementString());
            writer.WriteElementString("levelpercentage", value.LevelPercentage.ToElementString());
            writer.WriteEndElement();
        }

        public static void SerializeColorControl(XmlWriter writer, ColorControl value, Type inputType)
        {
            writer.WriteStartElement("colorcontrol");
            writer.WriteAttributeString("supported_modes", value.SupportedModes);
            writer.WriteAttributeString("current_mode", value.CurrentMode);
            writer.WriteElementString("hue", value.Hue.ToElementString());
            writer.WriteElementString("saturation", value.Saturation.ToElementString());
            writer.WriteElementString("unmapped_hue", value.UnmappedHue.ToElementString());
            writer.WriteElementString("unmapped_saturation", value.UnmappedSaturation.ToElementString());
            writer.WriteElementString("temperature", value.Temperature.ToElementString());
            writer.WriteEndElement();
        }
        public static void SerializeHkr(XmlWriter writer, Hkr value, Type inputType)
        {
            writer.WriteStartElement("hkr");
            writer.WriteElementString("tist", value.TIst.ToElementString());
            writer.WriteElementString("tsoll", value.TSoll.ToElementString());
            writer.WriteElementString("absenk", value.Absenk.ToElementString());
            writer.WriteElementString("komfort", value.Komfort.ToElementString());
            writer.WriteElementString("lock", value.Lock.ToElementString());
            writer.WriteElementString("devicelock", value.DeviceLock.ToElementString());
            writer.WriteElementString("errorcode", value.ErrorCode.ToElementString());
            writer.WriteElementString("windowopenactiv", value.WindowOpenActiv.ToElementString());
            writer.WriteElementString("windowopenactiveendtime", value.WindowOpenActivEndTime.ToElementString());
            writer.WriteElementString("boostactive", value.BoostActive.ToElementString());
            writer.WriteElementString("boostactiveendtime", value.BoostActiveEndTime.ToElementString());
            writer.WriteElementString("batterylow", value.BatteryLow.ToElementString());
            writer.WriteElementString("battery", value.Battery.ToElementString());
            SerializeNextChange(writer, value.NextChange, typeof(NextChange));
            writer.WriteElementString("summeractive", value.SummerActive.ToElementString());
            writer.WriteElementString("holidayactive", value.HolidayActive.ToElementString());
            writer.WriteEndElement();
        }

        public static void SerializeNextChange(XmlWriter writer, NextChange value, Type inputType)
        {
            writer.WriteStartElement("nextchange");
            writer.WriteElementString("endperiod", value.EndPeriod.ToElementString());
            writer.WriteElementString("tchange", value.TChange.ToElementString());
            writer.WriteEndElement();
        }





        private static void WriteConverter(this XmlWriter writer, string elementName, object value, Type typeToConvert, Type converterType)
        {
            IXmlConverter converter = (IXmlConverter)Activator.CreateInstance(converterType);
            converter.Write(writer, elementName, value, typeToConvert);
        }

        private static string ToElementString(this int value)
        {
            return value.ToString();
        }

        private static string ToElementString(this int? value)
        {
            return value.HasValue ? value.Value.ToString() : string.Empty;
        }

        private static string ToElementString(this bool? value)
        {
            return value.HasValue ? value.Value.ToString() : string.Empty;
        }

        private static string ToElementString(this double? value)
        {
            return value.HasValue ? value.Value.ToString() : string.Empty;
        }

        private static string ToElementString(this DateTime? value)
        {
            return value.HasValue ? value.Value.ToString() : string.Empty;
        }

        private static string ToElementString<T>(this Nullable<T> value) where T : struct, Enum
        {
            return value.HasValue ? value.ToString() : string.Empty;
        }

        private static string ToElementString<T>(this T value) where T : struct, Enum
        {
            return value.ToString();
        }

        

        private static string ReadValue(this XmlReader reader)
        {
            string result = string.Empty;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Text: result = reader.Value; break;
                case XmlNodeType.EndElement: return result;
                }
            }
            throw new Exception("error");
        }

        private static string ValueToString(this string value)
        {
            return value;
        }

        private static bool? ValueToNullableBool(this string value)
        {
            if (value == "true" || value == "1")
            {
                return true;
            }
            if (value == "false" || value == "0")
            {
                return false;
            }
            return null;
        }

        private static int? ValueToNullableInt(this string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return null;
        }

        private static T ValueToEnum<T>(this string value) where T : Enum
        {
            if (int.TryParse(value, out var result))
            {
                return (T)Enum.ToObject(typeof(T), result); 
            }
            return (T)Enum.ToObject(typeof(T), 0);
        }
    }
}