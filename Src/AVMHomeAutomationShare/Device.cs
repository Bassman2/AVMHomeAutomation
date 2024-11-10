namespace AVMHomeAutomation;

/// <summary>
/// Device data.
/// </summary>
[DebuggerDisplay("Device: {Name} -  {Manufacturer} - {ProductName} - {Identifier}")]
[XmlRoot("device")]
public class Device
{
    /// <summary>
    /// AIN, MAC address or unique ID
    /// </summary>
    [XmlAttribute("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Internal device ID
    /// </summary>
    [XmlAttribute("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Firmware version of the device
    /// </summary>
    [XmlAttribute("fwversion")]
    public string? FirmwareVersion { get; set; }

    /// <summary>
    /// Manufacturer of the device
    /// </summary>
    [XmlAttribute("manufacturer")]
    public string? Manufacturer { get; set; }

    /// <summary>
    /// Product name of the device, empty with unknown / undefined device
    /// </summary>
    [XmlAttribute("productname")]
    public string? ProductName { get; set; }

    /// <summary>
    /// Bit mask of the device function classes, starting with bit 0, several bits can be set. For internal use only. Use Functions instead.
    /// </summary>
    [XmlAttribute("functionbitmask")]
    public int FunctionBitMask { get; set; }        
    
    /// <summary>
    /// Functions of the device
    /// </summary>
    [XmlIgnore]
    public Functions Functions { get { return (Functions)FunctionBitMask; } }
    
    /// <summary>
    /// 0/1 - Device connected no / yes. For internal use only. Use IsPresent instead.
    /// </summary>
    [XmlElement("present")]
    public XmlNullableBool IsPresent { get; set; }

    /// <summary>
    /// A command (such as a switching command or change brightness) is running.
    /// </summary>
    [XmlElement("txbusy")]
    public XmlNullableBool IsTXBusy { get; set; }
    
    /// <summary>
    /// Name of the device.
    /// </summary>
    [XmlElement("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Battery charge level low - please change battery.
    /// </summary>
    [XmlElement("batterylow", IsNullable=true)]
    public XmlNullableBool IsBatteryLow { get; set; }

    /// <summary>
    /// Battery state of charge in percent. (0 - 100)
    /// </summary>
    [XmlElement("battery", IsNullable = true)]
    public XmlNullableInt Battery { get; set; }

    /// <summary>
    /// Data for switch socket.
    /// </summary>
    [XmlElement("switch", IsNullable = true)]
    public Switch? Switch { get; set; }

    /// <summary>
    /// Energy gauge data
    /// </summary>
    [XmlElement("powermeter", IsNullable = true)]
    public PowerMeter? PowerMeter { get; set; }

    /// <summary>
    /// Temperature sensor data.
    /// </summary>
    [XmlElement("temperature", IsNullable = true)]
    public Temperature? Temperature { get; set; }

    /// <summary>
    /// Alarm sensor data.
    /// </summary>
    [XmlElement("alert", IsNullable = true)]
    public Alert? Alert { get; set; }

    /// <summary>
    /// Button data.
    /// </summary>
    [XmlElement("button")]
    public List<Button>? Buttons { get; set; }

    /// <summary>
    /// HAN-FUN / ETSI unit data
    /// </summary>
    [XmlElement("etsiunitinfo", IsNullable = true)]
    public EtsiUnitInfo? EtsiUnitInfo { get; set; }

    /// <summary>
    /// Device/socket/lamp/actuator that can be switched on/off.
    /// </summary>
    [XmlElement("simpleonoff", IsNullable = true)]
    public SimpleOnOff? SimpleOnOff { get; set; }

    /// <summary>
    /// Device with adjustable dimming, height, brightness or level.
    /// </summary>
    [XmlElement("levelcontrol", IsNullable = true)]
    public LevelControl? LevelControl { get; set; }

    /// <summary>
    /// Lamp with adjustable colour/colour temperature.
    /// </summary>
    [XmlElement("colorcontrol", IsNullable = true)]
    public ColorControl? ColorControl { get; set; }

    /// <summary>
    /// Radiator control data
    /// </summary>
    [XmlElement("hkr", IsNullable = true)]
    public Hkr? Hkr { get; set; }

    [XmlIgnore]
    public List<Device>? Children { get; internal set; }

    [XmlIgnore]
    public DeviceType DeviceType { get; internal set; }
    //{ 
    //    get 
    //    {
    //        DeviceType deviceType = DeviceType.Unknown;
    //        switch (this.ProductName)
    //        {
    //        case "FRITZ!DECT Repeater 100":
    //            deviceType = DeviceType.Repeater;
    //            break;

    //        case "FRITZ!DECT 200":
    //        case "FRITZ!DECT 210":
    //            deviceType = DeviceType.Socket;
    //            break;

    //        case "FRITZ!DECT 300":
    //        case "FRITZ!DECT 301":
    //        case "FRITZ!DECT 302":
    //            deviceType = DeviceType.Heater;
    //            break;

    //        case "FRITZ!DECT 400":
    //            deviceType = DeviceType.Button;
    //            break;

    //        case "FRITZ!DECT 440":
    //            deviceType = DeviceType.Control;
    //            break;

    //        case "FRITZ!DECT 500":
    //            deviceType = DeviceType.Light;
    //            break;

    //        default:
    //            if (this.Functions.HasFlag(Functions.Light) || this.Functions.HasFlag(Functions.LightColor))
    //            {
    //                deviceType = DeviceType.Light;
    //            }
    //            else if (this.Functions.HasFlag(Functions.AVMButton) || this.Functions.HasFlag(Functions.Switch))
    //            {
    //                deviceType = DeviceType.Button;
    //            }
    //            //else if (this.Functions.HasFlag(Functions.AVMButton) || this.Functions.HasFlag(Functions.Switch))
    //            //{
    //            //    deviceType = DeviceType.Button;
    //            //}
    //            else if (this.Functions.HasFlag(Functions.AVMHeater))
    //            {
    //                deviceType = DeviceType.Heater;
    //            }
    //            else if (this.Functions.HasFlag(Functions.AVMSwitchOutlet))
    //            {
    //                deviceType = DeviceType.Socket;
    //            }
    //            else if (this.Functions.HasFlag(Functions.Blind))
    //            {
    //                deviceType = DeviceType.Rollotron;
    //            }
    //            break;
    //        }
    //        if (this.EtsiUnitInfo != null && this.EtsiUnitInfo.UnitType.HasValue) 
    //        {
    //            switch (this.EtsiUnitInfo.UnitType.Value)
    //            {
    //            case EtsiUnitType.SimpleButton:
    //            case EtsiUnitType.SimpleOnOffSwitchable:
    //            case EtsiUnitType.SimpleOnOffSwitch:
    //            case EtsiUnitType.ACOutletSimplePowerMetering:
    //            case EtsiUnitType.SimpleLight:
    //            case EtsiUnitType.DimmableLight:
    //            case EtsiUnitType.DimmerSwitch:
    //            case EtsiUnitType.ColorBulb:
    //            case EtsiUnitType.DimmableColorBulb:
    //            case EtsiUnitType.Blind:
    //            case EtsiUnitType.Lamellar:
    //            case EtsiUnitType.SimpleDetector:
    //            case EtsiUnitType.DoorOpenCloseDetector:
    //            case EtsiUnitType.WindowOpenCloseDetector:
    //            case EtsiUnitType.MotionDetector:
    //            case EtsiUnitType.FloodDetector:
    //            case EtsiUnitType.GlasBreakDetector:
    //            case EtsiUnitType.VibrationDetector:
    //            case EtsiUnitType.Siren:
    //                break;
    //            }
    //        }
    //        return deviceType;
    //    }
    //}        
}
