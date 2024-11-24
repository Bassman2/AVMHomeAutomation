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
    public bool? Synchronized { get; set; }

    /// <summary>
    /// Group information
    /// </summary>
    [XmlElement("groupinfo")]
    public GroupInfo? GroupInfo { get; set; }

    public override void ReadX(XElement elm)
    {
        base.ReadX(elm);
        Synchronized = elm.GetBoolAttribute("synchronized");
        GroupInfo = elm.GetItemElement<GroupInfo>("groupinfo");
    }
}
