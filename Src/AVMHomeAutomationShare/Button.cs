namespace AVMHomeAutomation;

/// <summary>
/// Button data.
/// </summary>
public class Button
{
    /// <summary>
    /// Unique ID.
    /// </summary>
    [XmlAttribute("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Internal device ID.
    /// </summary>
    [XmlAttribute("id")]
    public string? Id { get; set; }

    /// <summary>
    /// ColorName
    /// </summary>
    [XmlElement("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Time of the last key press.
    /// </summary>
    [XmlElement("lastpressedtimestamp")]
    public XmlNullableDateTime LastPressedTimestamp { get; set; }
}
