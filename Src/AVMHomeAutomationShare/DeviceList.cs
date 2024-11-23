namespace AVMHomeAutomation;

/// <summary>
/// List of all devices.
/// </summary>
[XmlRoot("devicelist")]
public class DeviceList : IXSerializable
{
    /// <summary>
    /// Version of the device list.
    /// </summary>
    [XmlAttribute("version")]
    public string? Version { get; set; }

    /// <summary>
    /// Firmware version
    /// </summary>
    [XmlAttribute("fwversion")]
    public string? FirmwareVersion { get; set; }

    /// <summary>
    /// Devices and groups
    /// </summary>
    [XmlElement("device", typeof(Device))]
    [XmlElement("group", typeof(Group))]
    public List<Device> RowDevices { get; } = [];

    [XmlIgnore]
    public List<Device>? ItemsList { get; private set; }

    [XmlIgnore]
    public List<Device>? ItemsTree { get; private set; }


    [XmlIgnore]
    public List<Device>? DevicesList { get; private set; }
    
    [XmlIgnore]
    public List<Device>? DevicesTree { get; private set; }

    [XmlIgnore]
    public List<Group>? GroupsList { get; private set; }

    [XmlIgnore]
    public List<Group>? GroupsTree { get; private set; }

    public void ReadX(XContainer container)
    {
        var elm = container.Element("devicelist");
        Version = elm.GetStringAttribute("version");
        FirmwareVersion = elm.GetStringAttribute("fwversion");
        foreach (var item in elm?.Elements() ?? [])
        {
            if (item.Name == "device")
            {
                var device = new Device();
                device.ReadX(item);
                RowDevices.Add(device); 
            }
            else if (item.Name == "group")
            {
                var group = new Group();
                group.ReadX(item);
                RowDevices.Add(group);
            }
        }
    }




    internal void Fill()
    {
        this.ItemsList = new List<Device>();
        this.ItemsTree = new List<Device>();
        this.DevicesList = new List<Device>();
        this.DevicesTree = new List<Device>();
        this.GroupsList = new List<Group>();
        this.GroupsTree = new List<Group>();

        Device? master = null;
        foreach (Device device in RowDevices!)
        {
            SetDeviceType(device);

            if (master != null && device.Identifier!.StartsWith(master.Identifier!))
            {
                master.DeviceType = device.DeviceType;
                (master.Children = master.Children ?? new List<Device>()).Add(device);

                this.ItemsList.Add(device);
                if (device.GetType() == typeof(Group))
                {
                    this.GroupsList.Add((Group)device);
                }
                else
                {
                    this.DevicesList.Add(device);
                }
            }
            else
            {
                this.ItemsList.Add(device);
                this.ItemsTree.Add(device);
                if (device.GetType() == typeof(Group))
                {
                    this.GroupsList.Add((Group)device);
                    this.GroupsTree.Add((Group)device);
                }
                else
                {
                    this.DevicesList.Add(device);
                    this.DevicesTree.Add(device);
                }
                master = device;
            }
        }
    }

    private static void SetDeviceType(Device device)
    {
        DeviceType deviceType = DeviceType.Unknown;
        switch (device.ProductName)
        {
        case "FRITZ!DECT Repeater 100":
            deviceType = DeviceType.Repeater;
            break;

        case "FRITZ!DECT 200":
        case "FRITZ!DECT 210":
            deviceType = DeviceType.Socket;
            break;

        case "FRITZ!DECT 300":
        case "FRITZ!DECT 301":
        case "FRITZ!DECT 302":
            deviceType = DeviceType.Heater;
            break;

        case "FRITZ!DECT 400":
            deviceType = DeviceType.Button;
            break;

        case "FRITZ!DECT 440":
            deviceType = DeviceType.Control;
            break;

        case "FRITZ!DECT 500":
            deviceType = DeviceType.Light;
            break;

        default:
            if (device.EtsiUnitInfo != null && device.EtsiUnitInfo.UnitType.HasValue)
            {
                switch (device.EtsiUnitInfo.UnitType.Value)
                {
                case EtsiUnitType.SimpleButton:
                case EtsiUnitType.SimpleOnOffSwitch:
                    deviceType = DeviceType.Button;
                    break;

                case EtsiUnitType.SimpleLight:
                case EtsiUnitType.DimmableLight:
                case EtsiUnitType.ColorBulb:
                case EtsiUnitType.DimmableColorBulb:
                    deviceType = DeviceType.Light;
                    break;

                case EtsiUnitType.Blind:
                case EtsiUnitType.Lamellar:
                    deviceType = DeviceType.Rollotron;
                    break;

                case EtsiUnitType.ACOutlet:
                case EtsiUnitType.ACOutletSimplePowerMetering:
                    deviceType = DeviceType.Socket;
                    break;

                case EtsiUnitType.DoorOpenCloseDetector:
                case EtsiUnitType.WindowOpenCloseDetector:
                    deviceType = DeviceType.DoorContact;
                    break;

                case EtsiUnitType.MotionDetector:
                    deviceType = DeviceType.MotionDetector;
                    break;

                case EtsiUnitType.SimpleOnOffSwitchable:
                case EtsiUnitType.DimmerSwitch:
                case EtsiUnitType.SimpleDetector:
                
                
                case EtsiUnitType.FloodDetector:
                case EtsiUnitType.GlasBreakDetector:
                case EtsiUnitType.VibrationDetector:
                case EtsiUnitType.Siren:
                    break;
                }
            }
            break;
        }
        device.DeviceType = deviceType;
    }
}
