namespace AVMHomeAutomation;

/// <summary>
/// Data for trigger.
/// </summary>
public class Trigger : IXSerializable
{
    /// <summary>
    /// Identifier of the trigger.
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// Identifier of the trigger.
    /// </summary>
    public int? Active { get; set; }

    /// <summary>
    /// Name of the trigger.
    /// </summary>
    public string? Name { get; set; }

    public void ReadX(XContainer container)
    {
        var elm = container.Element("trigger");
        Identifier = elm.GetStringAttribute("identifier");
        Active = elm.GetIntAttribute("active");            
        Name = elm.GetStringElement("name");
    }
}
