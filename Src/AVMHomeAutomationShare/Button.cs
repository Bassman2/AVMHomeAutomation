namespace AVMHomeAutomation;

/// <summary>
/// Button data.
/// </summary>
public class Button : IXSerializable
{
    /// <summary>
    /// Unique ID.
    [XmlAttribute("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Internal device ID.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// ColorName
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Time of the last key press.
    /// </summary>
    public DateTime? LastPressedTimestamp { get; set; }

    public void ReadX(XElement elm)
    {
        Identifier = elm.GetStringAttribute("identifier");
        Id = elm.GetStringAttribute("id");
        Name = elm.GetStringElement("name");
        LastPressedTimestamp = elm.GetDateTimeElement("lastpressedtimestamp");
    }
}
