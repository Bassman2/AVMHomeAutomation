namespace AVMHomeAutomation;

/// <summary>
/// Group of devices
/// </summary>
[DebuggerDisplay("Group: {ColorName} -  {Manufacturer} - {ProductName}")]     
public class Group : Device
{
    /// <summary>
    /// Is synchronized?
    /// </summary>
    [XmlAttribute("synchronized")]
    public bool Synchronized { get; set; }

    /// <summary>
    /// Group information
    /// </summary>
    [XmlElement("groupinfo")]
    public GroupInfo? GroupInfo { get; set; }

    public override void ReadX(XContainer container)
    {
        var elm = container.Element("device");

        Identifier = elm.GetStringAttribute("identifier");
        Id = elm.GetStringAttribute("id");
        FirmwareVersion = elm.GetStringAttribute("fwversion");
        Manufacturer = elm.GetStringAttribute("manufacturer");
        ProductName = elm.GetStringAttribute("productname");
        FunctionBitMask = elm.GetEnumAttribute<Functions>("functionbitmask");

        IsPresent = elm.GetBoolElement("present");
        IsTXBusy = elm.GetBoolElement("txbusy");
        Name = elm.GetStringElement("name");
        IsBatteryLow = elm.GetBoolElement("batterylow");
        Battery = elm.GetIntElement("batterylow");
    }
}
