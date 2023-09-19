using AVMHomeAutomation;
using AVMHomeAutomation.Converter;
using Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Xml;

namespace AVMHomeAutomation
{
    internal partial class GenerationContext : XmlSerializerContext    
    {
       
                
        public override void Serialize(XmlWriter writer, object value, Type inputType)
        {
            switch (inputType.FullName)
            {
            case "AVMHomeAutomation.DeviceList": Serialize(writer, "devicelist", (DeviceList)value, inputType); break;
            case "AVMHomeAutomation.DeviceStats": Serialize(writer, "devicestats", (DeviceStats)value, inputType); break;
            case "AVMHomeAutomation.TriggerList": Serialize(writer, "triggerlist", (TriggerList)value, inputType); break;
            case "AVMHomeAutomation.TemplateList": Serialize(writer, "templatelist", (TemplateList)value, inputType); break;
            case "AVMHomeAutomation.ColorDefaults": Serialize(writer, "colordefaults", (ColorDefaults)value, inputType); break;
            case "AVMHomeAutomation.SubscriptionState": Serialize(writer, "state", (SubscriptionState)value, inputType); break;
            case "AVMHomeAutomation.Device": Serialize(writer, "device", (Device)value, inputType); break;
            default: throw new ArgumentException("Unknown type", inputType.Name);
            }
        }

        

        public override object Deserialize(XmlReader reader, Type returnType)
        {
            object result = null;
            reader.MoveToContent();
            switch (returnType.FullName)
            {
            case "AVMHomeAutomation.DeviceList": result = Deserialize(reader, "devicelist", new DeviceList(), returnType); break;
            case "AVMHomeAutomation.DeviceStats": result = Deserialize(reader, "devicestats", new DeviceStats(), returnType); break;
            case "AVMHomeAutomation.TriggerList": result = Deserialize(reader, "triggerlist", new TriggerList(), returnType); break;
            case "AVMHomeAutomation.TemplateList": result = Deserialize(reader, "templatelist", new TemplateList(), returnType); break;
            case "AVMHomeAutomation.ColorDefaults": result = Deserialize(reader, "colordefaults", new ColorDefaults(), returnType); break;
            case "AVMHomeAutomation.SubscriptionState": result = Deserialize(reader, "state", new SubscriptionState(), returnType); break;
            case "AVMHomeAutomation.Device": result = Deserialize(reader, "device", new Device(), returnType); break;
            default: throw new ArgumentException("Unknown type", returnType.Name);
            };
            return result;
        }

        private static void Serialize(XmlWriter writer, string elementName, DeviceList value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("version", value.Version);
            writer.WriteAttributeString("fwversion", value.FirmwareVersion);
            foreach (var item in value.Devices)
            {
                Serialize(writer, "device", item, typeof(Device));
            }
            foreach (var item in value.Groups)
            {
                Serialize(writer, "group", item, typeof(Group));
            }
            writer.WriteEndElement();
        }

        private static DeviceList Deserialize(XmlReader reader, string elementName, DeviceList value, Type returnType)
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
                    case "device": value.Devices = AddElement(value.Devices, Deserialize(reader, "device", new Device(), typeof(Device))); break;
                    case "group": value.Groups = AddElement(value.Groups, Deserialize(reader, "group", new Group(), typeof(Group))); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }

            }
            return value;
        }

        private static void Serialize(XmlWriter writer, string elementName, Device value, Type inputType)
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

            Serialize(writer, "switch", value.Switch, typeof(Switch));
            Serialize(writer, "powermeter", value.PowerMeter, typeof(PowerMeter));
            Serialize(writer, "temperature", value.Temperature, typeof(Temperature));
            Serialize(writer, "alert", value.Alert, typeof(Alert));

            foreach (var item in value.Buttons)
            {
                Serialize(writer, "button", item, typeof(Button));
            }

            Serialize(writer, "etsiunitinfo", value.EtsiUnitInfo, typeof(EtsiUnitInfo));
            Serialize(writer, "simpleoboff", value.SimpleOnOff, typeof(SimpleOnOff));
            Serialize(writer, "levelcontrol", value.LevelControl, typeof(LevelControl));
            Serialize(writer, "colorControl", value.ColorControl, typeof(ColorControl));
            Serialize(writer, "hkr", value.Hkr, typeof(Hkr));

            writer.WriteEndElement();
        }

        private static Device Deserialize(XmlReader reader, string elementName, Device value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeText(); break;
                    case "id": value.Id = reader.ReadAttributeText(); break;
                    case "fwversion": value.FirmwareVersion = reader.ReadAttributeText(); break;
                    case "manufacturer": value.Manufacturer = reader.ReadAttributeText(); break;
                    case "productname": value.ProductName = reader.ReadAttributeText(); break;
                    case "functionbitmask": value.FunctionBitMask = reader.ReadAttributeEnum<FunctionBitMask>(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "present": value.IsPresent = reader.ReadElementNullableBool(); break;
                    case "txbusy": value.IsTXBusy = reader.ReadElementNullableBool(); break;
                    case "name": value.Name = reader.ReadElementText(); break;
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

        private static void Serialize(XmlWriter writer, string elementName, Group value, Type inputType)
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

            Serialize(writer, "switch", value.Switch, typeof(Switch));
            Serialize(writer, "powermeter", value.PowerMeter, typeof(PowerMeter));
            Serialize(writer, "temperature", value.Temperature, typeof(Temperature));
            Serialize(writer, "alert", value.Alert, typeof(Alert));

            foreach (var item in value.Buttons)
            {
                Serialize(writer, "button", item, typeof(Button));
            }

            Serialize(writer, "etsiunitinfo", value.EtsiUnitInfo, typeof(EtsiUnitInfo));
            Serialize(writer, "simpleoboff", value.SimpleOnOff, typeof(SimpleOnOff));
            Serialize(writer, "levelcontrol", value.LevelControl, typeof(LevelControl));
            Serialize(writer, "colorControl", value.ColorControl, typeof(ColorControl));
            Serialize(writer, "hkr", value.Hkr, typeof(Hkr));

            writer.WriteEndElement();
        }

        private static Group Deserialize(XmlReader reader, string elementName, Group value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeText(); break;
                    case "id": value.Id = reader.ReadAttributeText(); break;
                    case "fwversion": value.FirmwareVersion = reader.ReadAttributeText(); break;
                    case "manufacturer": value.Manufacturer = reader.ReadAttributeText(); break;
                    case "productname": value.ProductName = reader.ReadAttributeText(); break;
                    case "functionbitmask": value.FunctionBitMask = reader.ReadAttributeEnum<FunctionBitMask>(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "present": value.IsPresent = reader.ReadElementNullableBool(); break;
                    case "txbusy": value.IsTXBusy = reader.ReadElementNullableBool(); break;
                    case "name": value.Name = reader.ReadElementText(); break;
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

        private static void Serialize(XmlWriter writer, string elementName, Switch value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, PowerMeter value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, Temperature value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, Alert value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("state", value.State);
            writer.WriteElementString("lastalertchgtimestamp", value.LastAlertChangeTimestamp);
            writer.WriteEndElement();
        }

        private static Alert Deserialize(XmlReader reader, string elementName, Alert value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, Button value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("id", value.Id);
            writer.WriteElementString("name", value.Name);
            writer.WriteElementString("lastpressedtimestamp", value.LastPressedTimestamp);
            writer.WriteEndElement();
        }

        private static Button Deserialize(XmlReader reader, string elementName, Button value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeText(); break;
                    case "id": value.Id = reader.ReadAttributeText(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "name": value.Name = reader.ReadElementText(); break;
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

        private static void Serialize(XmlWriter writer, string elementName, EtsiUnitInfo value, Type inputType)
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

        private static EtsiUnitInfo Deserialize(XmlReader reader, string elementName, EtsiUnitInfo value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "etsideviceid": value.EtsiDeviceId = reader.ReadElementText(); break;
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

        private static void Serialize(XmlWriter writer, string elementName, SimpleOnOff value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("state", value.State);
            writer.WriteEndElement();
        }

        private static SimpleOnOff Deserialize(XmlReader reader, string elementName, SimpleOnOff value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, LevelControl value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("level", value.Level);
            writer.WriteElementString("levelpercentage", value.LevelPercentage);
            writer.WriteEndElement();
        }

        private static LevelControl Deserialize(XmlReader reader, string elementName, LevelControl value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, ColorControl value, Type inputType)
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

        private static ColorControl Deserialize(XmlReader reader, string elementName, ColorControl value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "supported_modes": value.SupportedModes = reader.ReadAttributeText(); break;
                    case "current_mode": value.CurrentMode = reader.ReadAttributeText(); break;
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

        private static void Serialize(XmlWriter writer, string elementName, Hkr value, Type inputType)
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
            Serialize(writer, "nextchange", value.NextChange, typeof(NextChange));
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
                    case "nextchange": value.NextChange = Deserialize(reader, "nextchange", new NextChange(), typeof(NextChange)); break;
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

        private static void Serialize(XmlWriter writer, string elementName, NextChange value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementString("endperiod", value.EndPeriod);
            writer.WriteElementString("tchange", value.TChange);
            writer.WriteEndElement();
        }

        private static NextChange Deserialize(XmlReader reader, string elementName, NextChange value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, DeviceStats value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementList("temperature", "stats", value.Temperature, i => Serialize(writer, "stats", i, typeof(Stats)));
            writer.WriteElementList("voltage", "stats", value.Voltage, i => Serialize(writer, "stats", i, typeof(Stats)));
            writer.WriteElementList("power", "stats", value.Power, i => Serialize(writer, "stats", i, typeof(Stats)));
            writer.WriteElementList("energy", "stats", value.Energy, i => Serialize(writer, "stats", i, typeof(Stats)));
            writer.WriteElementList("humidity", "stats", value.Humidity, i => Serialize(writer, "stats", i, typeof(Stats)));
            writer.WriteEndElement();
        }

        private static DeviceStats Deserialize(XmlReader reader, string elementName, DeviceStats value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "temperature": value.Temperature = reader.ReadElementList<Stats>("temperature", "stats", () => Deserialize(reader, "stats", new Stats(), typeof(Stats))); break;
                    case "voltage": value.Voltage = reader.ReadElementList<Stats>("voltage", "stats", () => Deserialize(reader, "stats", new Stats(), typeof(Stats))); break;
                    case "power": value.Power = reader.ReadElementList<Stats>("power", "stats", () => Deserialize(reader, "stats", new Stats(), typeof(Stats))); break;
                    case "energy": value.Energy = reader.ReadElementList<Stats>("energy", "stats", () => Deserialize(reader, "stats", new Stats(), typeof(Stats))); break;
                    case "humidity": value.Humidity = reader.ReadElementList<Stats>("humidity", "stats", () => Deserialize(reader, "stats", new Stats(), typeof(Stats))); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(XmlWriter writer, string elementName, Stats value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("count", value.Count);
            writer.WriteAttributeString("grid", value.Grid);
            writer.WriteValue(value.Value);            
            writer.WriteEndElement();
        }

        private static Stats Deserialize(XmlReader reader, string elementName, Stats value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, TriggerList value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("version", value.Version);
            writer.WriteElementList<Trigger>(null, "trigger", value.Triggers, i => Serialize(writer, "trigger", i, typeof(Trigger)));
            writer.WriteEndElement();
        }

        private static TriggerList Deserialize(XmlReader reader, string elementName, TriggerList value, Type inputType)
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
                    case "trigger": value.Triggers = AddElement<Trigger>(value.Triggers, Deserialize(reader, "trigger", new Trigger(), typeof(Trigger))); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(XmlWriter writer, string elementName, Trigger value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("active", value.Active);
            writer.WriteElementString("name", value.Name);
            writer.WriteEndElement();
        }

        private static Trigger Deserialize(XmlReader reader, string elementName, Trigger value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeText(); break;
                    case "active": value.Active = reader.ReadAttributeInt(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "name": value.Name = reader.ReadElementText(); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(XmlWriter writer, string elementName, TemplateList value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("version", value.Version);
            writer.WriteElementList(null, "template", value.Templates, i => Serialize(writer, "template", i, typeof(Template)));
            writer.WriteEndElement();
        }

        private static TemplateList Deserialize(XmlReader reader, string elementName, TemplateList value, Type inputType)
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
                    case "template": value.Templates = AddElement<Template>(value.Templates, Deserialize(reader, "template", new Template(), typeof(Template))); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(XmlWriter writer, string elementName, Template value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteAttributeString("id", value.Id);
            writer.WriteAttributeString("functionbitmask", value.FunctionBitMask);
            writer.WriteAttributeString("applymask", value.ApplyBitMask);
            writer.WriteAttributeString("autocreate", value.AutocCeate);
            writer.WriteElementString("name", value.Name);
            writer.WriteElementString("metadata", value.MetaData);
            writer.WriteElementList<ItemIdentifier>("devices", "device", value.Devices, (i) => Serialize(writer, "device", i, typeof(ItemIdentifier)));
            Serialize(writer, "applymask", value.ApplyMask, typeof(ApplyMask));
            writer.WriteElementList<ItemIdentifier>("sub_templates", "template", value.SubTemplates, i => Serialize(writer, "template", i, typeof(ItemIdentifier)));
            writer.WriteElementList<ItemIdentifier>("triggers", "trigger", value.Triggers, i => Serialize(writer, "trigger", i, typeof(ItemIdentifier)));
            writer.WriteEndElement();
        }

        private static Template Deserialize(XmlReader reader, string elementName, Template value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeText(); break;
                    case "id": value.Id = reader.ReadAttributeText(); break;
                    case "functionbitmask": value.FunctionBitMask = reader.ReadAttributeEnum<FunctionBitMask>(); break;
                    case "applymask": value.ApplyBitMask = reader.ReadAttributeInt(); break;
                    case "autocreate": value.AutocCeate = reader.ReadAttributeInt(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "name": value.Name = reader.ReadElementText(); break;
                    case "metadata": value.MetaData = reader.ReadElementText(); break;
                    case "devices": value.Devices = reader.ReadElementList<ItemIdentifier>("devices", "device", () => Deserialize(reader, "device", new ItemIdentifier(), typeof(ItemIdentifier))); break;
                    case "applymask": value.ApplyMask = Deserialize(reader, "applymask", new ApplyMask(), typeof(ApplyMask)); break;
                    case "sub_templates": value.SubTemplates = reader.ReadElementList<ItemIdentifier>("sub_templates", "template", () => Deserialize(reader, "template", new ItemIdentifier(), typeof(ItemIdentifier))); break;
                    case "triggers": value.Triggers = reader.ReadElementList<ItemIdentifier>("triggers", "trigger", () => Deserialize(reader, "trigger", new ItemIdentifier(), typeof(ItemIdentifier))); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(XmlWriter writer, string elementName, ItemIdentifier value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("identifier", value.Identifier);
            writer.WriteEndElement();
        }

        private static ItemIdentifier Deserialize(XmlReader reader, string elementName, ItemIdentifier value, Type inputType)
        {
            reader.CheckElement(elementName);
            
            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "identifier": value.Identifier = reader.ReadAttributeText(); break;
                    }
                    break;

                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }        

        private static void Serialize(XmlWriter writer, string elementName, ApplyMask value, Type inputType)
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

        private static ApplyMask Deserialize(XmlReader reader, string elementName, ApplyMask value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, ColorDefaults value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteElementList<ColorDefaultHS>("hsdefaults", "hs", value.HSDefaults, i => Serialize(writer, "hs", i, typeof(ColorDefaultHS)));
            writer.WriteElementList<ColorDefaultTemperature>("temperaturedefaults", "temp", value.TemperatureDefaults, i => Serialize(writer, "temp", i, typeof(ColorDefaultTemperature)));
            
            writer.WriteEndElement();
        }

        private static ColorDefaults Deserialize(XmlReader reader, string elementName, ColorDefaults value, Type inputType)
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

        private static void Serialize(XmlWriter writer, string elementName, ColorDefaultHS value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("hue_index", value.HueIndex);
            Serialize(writer, "name", value.Name, typeof(ColorName));
            writer.WriteElementList<Color>(null, "color", value.Colors, (i) => Serialize(writer, "color", i, typeof(Color)));
            writer.WriteEndElement();
        }

        private static ColorDefaultHS Deserialize(XmlReader reader, string elementName, ColorDefaultHS value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "hue_index": value.HueIndex = reader.ReadAttributeInt(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    switch (reader.Name)
                    {
                    case "name": value.Name = Deserialize(reader, "name", new ColorName(), typeof(ColorName)); break;
                    case "color": value.Colors = AddElement(value.Colors, Deserialize(reader, "color", new Color(), typeof(Color))); break;
                    default: reader.ReadInnerXml(); break;
                    }
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(XmlWriter writer, string elementName, ColorDefaultTemperature value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("value", value.Value);
            writer.WriteEndElement();
        }

        private static ColorDefaultTemperature Deserialize(XmlReader reader, string elementName, ColorDefaultTemperature value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "value": value.Value = reader.ReadAttributeInt(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    reader.ReadInnerXml();
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(XmlWriter writer, string elementName, ColorName value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("enum", value.Enum);
            writer.WriteValue(value.Value);
            writer.WriteEndElement();
        }

        private static ColorName Deserialize(XmlReader reader, string elementName, ColorName value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "enum": value.Enum = reader.ReadAttributeInt(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    reader.ReadInnerXml(); 
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

        private static void Serialize(XmlWriter writer, string elementName, Color value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("sat_index", value.SatIndex);
            writer.WriteAttributeString("hue", value.Hue);
            writer.WriteAttributeString("sat", value.Sat);
            writer.WriteAttributeString("val", value.Val);
            writer.WriteEndElement();
        }

        private static Color Deserialize(XmlReader reader, string elementName, Color value, Type inputType)
        {
            reader.CheckElement(elementName);

            while (reader.MoveToNextAttribute() || reader.Read())
            {
                switch (reader.NodeType)
                {
                case XmlNodeType.Attribute:
                    switch (reader.Name)
                    {
                    case "sat_index": value.SatIndex = reader.ReadAttributeInt(); break;
                    case "hue": value.Hue = reader.ReadAttributeInt(); break;
                    case "sat": value.Sat = reader.ReadAttributeInt(); break;
                    case "val": value.Val = reader.ReadAttributeInt(); break;
                    }
                    break;
                case XmlNodeType.Element:
                    reader.ReadInnerXml(); 
                    break;
                case XmlNodeType.EndElement:
                    return value;
                }
            }
            return value;
        }

        private static void Serialize(XmlWriter writer, string elementName, SubscriptionState value, Type inputType)
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("code", value.Code);
            writer.WriteElementString("latestain", value.LatestAin);
            writer.WriteEndElement();
        }

        private static SubscriptionState Deserialize(XmlReader reader, string elementName, SubscriptionState value, Type inputType)
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
                    case "latestain": value.LatestAin = reader.ReadElementText(); break;
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