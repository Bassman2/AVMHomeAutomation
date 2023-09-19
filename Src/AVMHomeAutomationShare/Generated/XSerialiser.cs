using AVMHomeAutomation;
using AVMHomeAutomation.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml;

namespace Serialization
{
    internal static partial class XSerializer
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
            case "AVMHomeAutomation.DeviceList": writer.Serialize("devicelist", (DeviceList)value, inputType); break;
            case "AVMHomeAutomation.DeviceStats": writer.Serialize("devicestats", (DeviceStats)value, inputType); break;
            case "AVMHomeAutomation.TriggerList": writer.Serialize("triggerlist", (TriggerList)value, inputType); break;
            case "AVMHomeAutomation.TemplateList": writer.Serialize("templatelist", (TemplateList)value, inputType); break;
            case "AVMHomeAutomation.ColorDefaults": writer.Serialize("colordefaults", (ColorDefaults)value, inputType); break;
            case "AVMHomeAutomation.SubscriptionState": writer.Serialize("state", (SubscriptionState)value, inputType); break;
            case "AVMHomeAutomation.Device": writer.Serialize("device", (Device)value, inputType); break;
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
            case "AVMHomeAutomation.DeviceList": result = reader.Deserialize("devicelist", new DeviceList(), returnType); break;
            case "AVMHomeAutomation.DeviceStats": result = reader.Deserialize("devicestats", new DeviceStats(), returnType); break;
            case "AVMHomeAutomation.TriggerList": result = reader.Deserialize("triggerlist", new TriggerList(), returnType); break;
            case "AVMHomeAutomation.TemplateList": result = reader.Deserialize("templatelist", new TemplateList(), returnType); break;
            case "AVMHomeAutomation.ColorDefaults": result = reader.Deserialize("colordefaults", new ColorDefaults(), returnType); break;
            case "AVMHomeAutomation.SubscriptionState": result = reader.Deserialize("state", new SubscriptionState(), returnType); break;
            case "AVMHomeAutomation.Device": result = reader.Deserialize("device", new Device(), returnType); break;
            default: throw new ArgumentException("Unknown type", returnType.Name);
            };
            return result;
        }

        private static void Serialize(this XmlWriter writer, string elementName, DeviceList value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("version", value.Version);
            writer.WriteAttributeString("fwversion", value.FirmwareVersion);
            foreach (var item in value.Devices)
            {
                writer.Serialize("device", item, typeof(Device));
            }
            foreach (var item in value.Groups)
            {
                writer.Serialize("group", item, typeof(Group));
            }
            writer.WriteEndElement();
        }

        private static DeviceList Deserialize(this XmlReader reader, string elementName, DeviceList value, Type returnType)
        {
            reader.CheckElement(elementName);
            
            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "version": value.Version = reader.ReadAttributeVersion(); break;
                    case "fwversion": value.FirmwareVersion = reader.ReadAttributeVersion(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "device": value.Devices = AddElement(value.Devices, reader.Deserialize("device", new Device(), typeof(Device))); break;
                    case "group": value.Groups = AddElement(value.Groups, reader.Deserialize("group", new Group(), typeof(Group))); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }

            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Device value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("id", value.Id);
            writer.WriteAttributeString("fwversion", value.FirmwareVersion);
            writer.WriteAttributeString("manufacturer", value.Manufacturer);
            writer.WriteAttributeString("productname", value.ProductName);
            writer.WriteAttributeString("functionbitmask", ((uint)value.FunctionBitMask).ToString()); // enum

            writer.WriteElementString("present", value.IsPresent);
            writer.WriteElementString("txbusy", value.IsTXBusy);
            writer.WriteElementString("name", value.Name);
            writer.WriteElementString("batterylow", value.IsBatteryLow);
            writer.WriteElementString("battery", value.Battery);

            writer.Serialize("switch", value.Switch, typeof(Switch));
            writer.Serialize("powermeter", value.PowerMeter, typeof(PowerMeter));
            writer.Serialize("temperature", value.Temperature, typeof(Temperature));
            writer.Serialize("alert", value.Alert, typeof(Alert));

            foreach (var item in value.Buttons)
            {
                writer.Serialize("button", item, typeof(Button));
            }

            writer.Serialize("etsiunitinfo", value.EtsiUnitInfo, typeof(EtsiUnitInfo));
            writer.Serialize("simpleoboff", value.SimpleOnOff, typeof(SimpleOnOff));
            writer.Serialize("levelcontrol", value.LevelControl, typeof(LevelControl));
            writer.Serialize("colorControl", value.ColorControl, typeof(ColorControl));
            writer.Serialize("hkr", value.Hkr, typeof(Hkr));

            writer.WriteEndElement();
        }

        private static Device Deserialize(this XmlReader reader, string elementName, Device value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeString(); break;
                    case "id": value.Id = reader.ReadAttributeString(); break;
                    case "fwversion": value.FirmwareVersion = reader.ReadAttributeString(); break;
                    case "manufacturer": value.Manufacturer = reader.ReadAttributeString(); break;
                    case "productname": value.ProductName = reader.ReadAttributeString(); break;
                    case "functionbitmask": value.FunctionBitMask = reader.ReadAttributeEnum<FunctionBitMask>(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "present": value.IsPresent = reader.ReadElementNullableBool(); break;
                    case "txbusy": value.IsTXBusy = reader.ReadElementNullableBool(); break;
                    case "name": value.Name = reader.ReadElementString(); break;
                    case "batterylow": value.IsBatteryLow = reader.ReadElementNullableBool(); break;
                    case "battery": value.Battery = reader.ReadElementNullableInt(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Group value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("id", value.Id);
            writer.WriteAttributeString("fwversion", value.FirmwareVersion);
            writer.WriteAttributeString("manufacturer", value.Manufacturer);
            writer.WriteAttributeString("productname", value.ProductName);
            writer.WriteAttributeString("functionbitmask", ((uint)value.FunctionBitMask).ToString()); // enum

            writer.WriteElementString("present", value.IsPresent);
            writer.WriteElementString("txbusy", value.IsTXBusy);
            writer.WriteElementString("name", value.Name);
            writer.WriteElementString("batterylow", value.IsBatteryLow);
            writer.WriteElementString("battery", value.Battery);

            writer.Serialize("switch", value.Switch, typeof(Switch));
            writer.Serialize("powermeter", value.PowerMeter, typeof(PowerMeter));
            writer.Serialize("temperature", value.Temperature, typeof(Temperature));
            writer.Serialize("alert", value.Alert, typeof(Alert));

            foreach (var item in value.Buttons)
            {
                writer.Serialize("button", item, typeof(Button));
            }

            writer.Serialize("etsiunitinfo", value.EtsiUnitInfo, typeof(EtsiUnitInfo));
            writer.Serialize("simpleoboff", value.SimpleOnOff, typeof(SimpleOnOff));
            writer.Serialize("levelcontrol", value.LevelControl, typeof(LevelControl));
            writer.Serialize("colorControl", value.ColorControl, typeof(ColorControl));
            writer.Serialize("hkr", value.Hkr, typeof(Hkr));

            writer.WriteEndElement();
        }

        private static Group Deserialize(this XmlReader reader, string elementName, Group value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeString(); break;
                    case "id": value.Id = reader.ReadAttributeString(); break;
                    case "fwversion": value.FirmwareVersion = reader.ReadAttributeString(); break;
                    case "manufacturer": value.Manufacturer = reader.ReadAttributeString(); break;
                    case "productname": value.ProductName = reader.ReadAttributeString(); break;
                    case "functionbitmask": value.FunctionBitMask = reader.ReadAttributeEnum<FunctionBitMask>(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "present": value.IsPresent = reader.ReadElementNullableBool(); break;
                    case "txbusy": value.IsTXBusy = reader.ReadElementNullableBool(); break;
                    case "name": value.Name = reader.ReadElementString(); break;
                    case "batterylow": value.IsBatteryLow = reader.ReadElementNullableBool(); break;
                    case "battery": value.Battery = reader.ReadElementNullableInt(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Switch value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("state", value.State);
            writer.WriteElementString("mode", value.Mode);
            writer.WriteElementString("lock", value.Lock);
            writer.WriteElementString("devicelock", value.DeviceLock);
            writer.WriteEndElement();
        }

        private static Switch Deserialize(XmlReader reader, string elementName, Switch value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "state": value.State = reader.ReadElementNullableBool(); break;
                    case "mode": value.Mode = reader.ReadElementNullableBool(); break;
                    case "lock": value.Lock = reader.ReadElementNullableBool(); break;
                    case "devicelock": value.DeviceLock = reader.ReadElementNullableBool(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, PowerMeter value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteConverter("voltage", value.Voltage, typeof(double?), typeof(KiloConverter));
            writer.WriteConverter("power", value.Power, typeof(double?), typeof(KiloConverter));
            writer.WriteConverter("energy", value.Energy, typeof(double?), typeof(KiloConverter));
            writer.WriteEndElement();
        }

        private static PowerMeter Deserialize(XmlReader reader, string elementName, PowerMeter value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "voltage": value.Voltage = reader.ReadElementNullableDouble(); break;
                    case "power": value.Power = reader.ReadElementNullableDouble(); break;
                    case "energy": value.Energy = reader.ReadElementNullableDouble(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }

            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Temperature value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteConverter("celsius", value.Celsius, typeof(double?), typeof(DeciConverter));
            writer.WriteConverter("offset", value.Offset, typeof(double?), typeof(DeciConverter));
            writer.WriteEndElement();
        }

        private static Temperature Deserializee(XmlReader reader, string elementName, Temperature value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "celsius": value.Celsius = reader.ReadElementNullableDouble(); break;
                    case "offset": value.Offset = reader.ReadElementNullableDouble(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }

            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Alert value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("state", value.State);
            writer.WriteElementString("lastalertchgtimestamp", value.LastAlertChangeTimestamp);
            writer.WriteEndElement();
        }

        private static Alert Deserialize(this XmlReader reader, string elementName, Alert value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "state": value.State = reader.ReadElementNullableEnum<AlertState>(); break;
                    case "lastalertchgtimestamp": value.LastAlertChangeTimestamp = reader.ReadElementNullableDateTime(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Button value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("id", value.Id);
            writer.WriteElementString("name", value.Name);
            writer.WriteElementString("lastpressedtimestamp", value.LastPressedTimestamp);
            writer.WriteEndElement();
        }

        private static Button Deserialize(this XmlReader reader, string elementName, Button value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeString(); break;
                    case "id": value.Id = reader.ReadAttributeString(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "name": value.Name = reader.ReadElementString(); break;
                    case "lastpressedtimestamp": value.LastPressedTimestamp = reader.ReadElementNullableDateTime(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, EtsiUnitInfo value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("etsideviceid", value.EtsiDeviceId);
            writer.WriteElementString("unittype", value.UnitType);
            foreach (var item in value.Interfaces)
            {
                writer.WriteElementString("interfaces", item);
            }
            writer.WriteEndElement();
        }

        private static EtsiUnitInfo Deserialize(this XmlReader reader, string elementName, EtsiUnitInfo value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "etsideviceid": value.EtsiDeviceId = reader.ReadElementString(); break;
                    case "unittype": value.UnitType = reader.ReadElementEnum<EtsiUnitType>(); break;
                    case "interfaces": value.Interfaces.Add(reader.ReadElementEnum<EtsiInterfaces>()); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, SimpleOnOff value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("state", value.State);
            writer.WriteEndElement();
        }

        private static SimpleOnOff Deserialize(this XmlReader reader, string elementName, SimpleOnOff value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "state": value.State = reader.ReadElementNullableBool(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, LevelControl value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("level", value.Level);
            writer.WriteElementString("levelpercentage", value.LevelPercentage);
            writer.WriteEndElement();
        }

        private static LevelControl Deserialize(this XmlReader reader, string elementName, LevelControl value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "level": value.Level = reader.ReadElementNullableInt(); break;
                    case "levelpercentage": value.LevelPercentage = reader.ReadElementNullableInt(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, ColorControl value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("supported_modes", value.SupportedModes);
            writer.WriteAttributeString("current_mode", value.CurrentMode);
            writer.WriteElementString("hue", value.Hue);
            writer.WriteElementString("saturation", value.Saturation);
            writer.WriteElementString("unmapped_hue", value.UnmappedHue);
            writer.WriteElementString("unmapped_saturation", value.UnmappedSaturation);
            writer.WriteElementString("temperature", value.Temperature);
            writer.WriteEndElement();
        }

        private static ColorControl Deserialize(this XmlReader reader, string elementName, ColorControl value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "supported_modes": value.SupportedModes = reader.ReadAttributeString(); break;
                    case "current_mode": value.CurrentMode = reader.ReadAttributeString(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "hue": value.Hue = reader.ReadElementNullableInt(); break;
                    case "saturation": value.Saturation = reader.ReadElementNullableInt(); break;
                    case "unmapped_hue": value.UnmappedHue = reader.ReadElementNullableInt(); break;
                    case "unmapped_saturation": value.UnmappedSaturation = reader.ReadElementNullableInt(); break;
                    case "temperature": value.Temperature = reader.ReadElementNullableInt(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Hkr value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("tist", value.TIst);
            writer.WriteElementString("tsoll", value.TSoll);
            writer.WriteElementString("absenk", value.Absenk);
            writer.WriteElementString("komfort", value.Komfort);
            writer.WriteElementString("lock", value.Lock);
            writer.WriteElementString("devicelock", value.DeviceLock);
            writer.WriteElementString("errorcode", value.ErrorCode);
            writer.WriteElementString("windowopenactiv", value.WindowOpenActiv);
            writer.WriteElementString("windowopenactiveendtime", value.WindowOpenActivEndTime);
            writer.WriteElementString("boostactive", value.BoostActive);
            writer.WriteElementString("boostactiveendtime", value.BoostActiveEndTime);
            writer.WriteElementString("batterylow", value.BatteryLow);
            writer.WriteElementString("battery", value.Battery);
            writer.Serialize("nextchange", value.NextChange, typeof(NextChange));
            writer.WriteElementString("summeractive", value.SummerActive);
            writer.WriteElementString("holidayactive", value.HolidayActive);
            writer.WriteEndElement();
        }

        private static Hkr Deserialize(XmlReader reader, string elementName, Hkr value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "tist": value.TIst = reader.ReadElementNullableDouble(); break;
                    case "tsoll": value.TSoll = reader.ReadElementNullableDouble(); break;
                    case "absenk": value.Absenk = reader.ReadElementNullableDouble(); break;
                    case "komfort": value.Komfort = reader.ReadElementNullableDouble(); break;
                    case "lock": value.Lock = reader.ReadElementNullableBool(); break;
                    case "devicelock": value.DeviceLock = reader.ReadElementNullableBool(); break;
                    case "errorcode": value.ErrorCode = reader.ReadElementInt(); break;
                    case "windowopenactiv": value.WindowOpenActiv = reader.ReadElementNullableBool(); break;
                    case "windowopenactiveendtime": value.WindowOpenActivEndTime = reader.ReadElementNullableDateTime(); break;
                    case "boostactive": value.BoostActiveEndTime = reader.ReadElementNullableDateTime(); break;
                    case "batterylow": value.BatteryLow = reader.ReadElementNullableBool(); break;
                    case "battery": value.Battery = reader.ReadElementNullableInt(); break;
                    case "nextchange": value.NextChange = reader.Deserialize("nextchange", new NextChange(), typeof(NextChange)); break;
                    case "summeractive": value.SummerActive = reader.ReadElementNullableBool(); break;
                    case "holidayactive": value.HolidayActive = reader.ReadElementNullableBool(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, NextChange value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("endperiod", value.EndPeriod);
            writer.WriteElementString("tchange", value.TChange);
            writer.WriteEndElement();
        }

        private static NextChange Deserialize(this XmlReader reader, string elementName, NextChange value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "endperiod": value.EndPeriod = reader.ReadElementNullableDateTime(); break;
                    case "tchange": value.TChange = reader.ReadElementNullableDouble(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, DeviceStats value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementList("temperature", "stats", value.Temperature, i => writer.Serialize("stats", i, typeof(Stats)));
            writer.WriteElementList("voltage", "stats", value.Voltage, i => writer.Serialize("stats", i, typeof(Stats)));
            writer.WriteElementList("power", "stats", value.Power, i => writer.Serialize("stats", i, typeof(Stats)));
            writer.WriteElementList("energy", "stats", value.Energy, i => writer.Serialize("stats", i, typeof(Stats)));
            writer.WriteElementList("humidity", "stats", value.Humidity, i => writer.Serialize("stats", i, typeof(Stats)));
            writer.WriteEndElement();
        }

        private static DeviceStats Deserialize(this XmlReader reader, string elementName, DeviceStats value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "temperature": value.Temperature = reader.ReadElementList<Stats>("temperature", "stats", () => reader.Deserialize("stats", new Stats(), typeof(Stats))); break;
                    case "voltage": value.Voltage = reader.ReadElementList<Stats>("voltage", "stats", () => reader.Deserialize("stats", new Stats(), typeof(Stats))); break;
                    case "power": value.Power = reader.ReadElementList<Stats>("power", "stats", () => reader.Deserialize("stats", new Stats(), typeof(Stats))); break;
                    case "energy": value.Energy = reader.ReadElementList<Stats>("energy", "stats", () => reader.Deserialize("stats", new Stats(), typeof(Stats))); break;
                    case "humidity": value.Humidity = reader.ReadElementList<Stats>("humidity", "stats", () => reader.Deserialize("stats", new Stats(), typeof(Stats))); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Stats value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("count", value.Count);
            writer.WriteAttributeString("grid", value.Grid);
            writer.WriteValue(value.Value);            
            writer.WriteEndElement();
        }

        private static Stats Deserialize(this XmlReader reader, string elementName, Stats value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "count": value.Count = reader.ReadAttributeInt(); break;
                    case "grid": value.Grid = reader.ReadAttributeInt(); break;
                    }
                    break;
                case XmlNodeType.Text:
                    value.Value = reader.Value; 
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, TriggerList value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("version", value.Version);
            writer.WriteElementList<Trigger>(null, "trigger", value.Triggers, i => writer.Serialize("trigger", i, typeof(Trigger)));
            writer.WriteEndElement();
        }

        private static TriggerList Deserialize(this XmlReader reader, string elementName, TriggerList value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "version": value.Version = reader.ReadAttributeVersion(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "trigger": value.Triggers = AddElement<Trigger>(value.Triggers, reader.Deserialize("trigger", new Trigger(), typeof(Trigger))); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Trigger value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("active", value.Active);
            writer.WriteElementString("name", value.Name);
            writer.WriteEndElement();
        }

        private static Trigger Deserialize(this XmlReader reader, string elementName, Trigger value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeString(); break;
                    case "active": value.Active = reader.ReadAttributeInt(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "name": value.Name = reader.ReadElementString(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, TemplateList value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("version", value.Version);
            writer.WriteElementList(null, "template", value.Templates, i => writer.Serialize("template", i, typeof(Template)));
            writer.WriteEndElement();
        }

        private static TemplateList Deserialize(this XmlReader reader, string elementName, TemplateList value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "version": value.Version = reader.ReadAttributeVersion(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "template": value.Templates = AddElement<Template>(value.Templates, reader.Deserialize("template", new Template(), typeof(Template))); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, Template value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("id", value.Id);
            writer.WriteAttributeString("functionbitmask", value.FunctionBitMask);
            writer.WriteAttributeString("applymask", value.ApplyBitMask);
            writer.WriteAttributeString("autocreate", value.AutocCeate);
            writer.WriteElementString("name", value.Name);
            writer.WriteElementString("metadata", value.MetaData);
            writer.WriteElementList<ItemIdentifier>("devices", "device", value.Devices, (i) => writer.Serialize("device", i, typeof(ItemIdentifier)));
            writer.Serialize("applymask", value.ApplyMask, typeof(ApplyMask));
            writer.WriteElementList<ItemIdentifier>("sub_templates", "template", value.SubTemplates, i => writer.Serialize("template", i, typeof(ItemIdentifier)));
            writer.WriteElementList<ItemIdentifier>("triggers", "trigger", value.Triggers, i => writer.Serialize("trigger", i, typeof(ItemIdentifier)));
            writer.WriteEndElement();
        }

        private static Template Deserialize(this XmlReader reader, string elementName, Template value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeString(); break;
                    case "id": value.Id = reader.ReadAttributeString(); break;
                    case "functionbitmask": value.FunctionBitMask = reader.ReadAttributeEnum<FunctionBitMask>(); break;
                    case "applymask": value.ApplyBitMask = reader.ReadAttributeInt(); break;
                    case "autocreate": value.AutocCeate = reader.ReadAttributeInt(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "name": value.Name = reader.ReadElementString(); break;
                    case "metadata": value.MetaData = reader.ReadElementString(); break;
                    case "devices": value.Devices = reader.ReadElementList<ItemIdentifier>("devices", "device", () => reader.Deserialize("device", new ItemIdentifier(), typeof(ItemIdentifier))); break;
                    case "applymask": value.ApplyMask = reader.Deserialize("applymask", new ApplyMask(), typeof(ApplyMask)); break;
                    case "sub_templates": value.SubTemplates = reader.ReadElementList<ItemIdentifier>("sub_templates", "template", () => reader.Deserialize("template", new ItemIdentifier(), typeof(ItemIdentifier))); break;
                    case "triggers": value.Triggers = reader.ReadElementList<ItemIdentifier>("triggers", "trigger", () => reader.Deserialize("trigger", new ItemIdentifier(), typeof(ItemIdentifier))); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, ItemIdentifier value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteEndElement();
        }

        private static ItemIdentifier Deserialize(this XmlReader reader, string elementName, ItemIdentifier value, Type inputType)
        {
            reader.CheckElement(elementName);
            
            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeString(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }        

        private static void Serialize(this XmlWriter writer, string elementName, ApplyMask value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("hkr_summer", value.HkrSummer);
            writer.WriteElementString("hkr_temperature", value.HkrTemperature);
            writer.WriteElementString("hkr_holidays", value.HkrHolidays);
            writer.WriteElementString("hkr_time_table", value.HkrTimeTable);
            writer.WriteElementString("relay_manual", value.RelayManual);
            writer.WriteElementString("relay_automatic", value.RelayAutomatic);
            writer.WriteElementString("level", value.Level);
            writer.WriteElementString("color", value.Color);
            writer.WriteElementString("dialhelper", value.Dialhelper);
            writer.WriteElementString("sun_simulation", value.SunSimulation);
            writer.WriteElementString("sub_templates", value.SubTemplates);
            writer.WriteElementString("main_wifi", value.MainWifi);
            writer.WriteElementString("guest_wifi", value.GuestWifi);
            writer.WriteElementString("tam_control", value.TamControl);
            writer.WriteElementString("http_request", value.HttpRequest);
            writer.WriteElementString("timer_control", value.TimerControl);
            writer.WriteElementString("switch_master", value.SwitchMaster);
            writer.WriteElementString("custom_notification", value.CustomNotification);
            writer.WriteEndElement();
        }

        private static ApplyMask Deserialize(this XmlReader reader, string elementName, ApplyMask value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "hkr_summer": value.HkrSummer = reader.ReadElementBool(); break;
                    case "hkr_temperature": value.HkrTemperature = reader.ReadElementBool(); break;
                    case "hkr_holidays": value.HkrHolidays = reader.ReadElementBool(); break;
                    case "hkr_time_table": value.HkrTimeTable = reader.ReadElementBool(); break;
                    case "relay_manual": value.RelayManual = reader.ReadElementBool(); break;
                    case "relay_automatic": value.RelayAutomatic = reader.ReadElementBool(); break;
                    case "level": value.Level = reader.ReadElementBool(); break;
                    case "color": value.Color = reader.ReadElementBool(); break;
                    case "dialhelper": value.Dialhelper = reader.ReadElementBool(); break;
                    case "sun_simulation": value.SunSimulation = reader.ReadElementBool(); break;
                    case "sub_templates": value.SubTemplates = reader.ReadElementBool(); break;
                    case "main_wifi": value.MainWifi = reader.ReadElementBool(); break;
                    case "guest_wifi": value.GuestWifi = reader.ReadElementBool(); break;
                    case "tam_control": value.TamControl = reader.ReadElementBool(); break;
                    case "http_request": value.HttpRequest = reader.ReadElementBool(); break;
                    case "timer_control": value.TimerControl = reader.ReadElementBool(); break;
                    case "switch_master": value.SwitchMaster = reader.ReadElementBool(); break;
                    case "custom_notification": value.CustomNotification = reader.ReadElementBool(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, ColorDefaults value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementList<ColorDefaultHS>("hsdefaults", "hs", value.HSDefaults, i => writer.Serialize("hs", i, typeof(ColorDefaultHS)));
            writer.WriteElementList<ColorDefaultTemperature>("temperaturedefaults", "temp", value.TemperatureDefaults, i => writer.Serialize("temp", i, typeof(ColorDefaultTemperature)));
            
            writer.WriteEndElement();
        }

        private static ColorDefaults Deserialize(this XmlReader reader, string elementName, ColorDefaults value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    //case "hsdefaults": value.HSDefaults = reader.ReadElementList<ColorDefaultHS>("hsdefaults", "hs"); break;
                    //case "temperaturedefaults": value.TemperatureDefaults = reader.ReadElementList<ColorDefaultTemperature>("temperaturedefaults", "temp"); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }

            }
            return value;
        }

        private static void Serialize(this XmlWriter writer, string elementName, SubscriptionState value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("code", value.Code);
            writer.WriteElementString("latestain", value.LatestAin);
            writer.WriteEndElement();
        }

        private static SubscriptionState Deserialize(this XmlReader reader, string elementName, SubscriptionState value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "code": value.Code = reader.ReadAttributeEnum<SubscriptionCode>(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "latestain": value.LatestAin = reader.ReadElementString(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }




        
    }
}