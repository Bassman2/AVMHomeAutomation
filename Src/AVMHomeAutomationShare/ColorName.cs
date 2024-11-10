namespace AVMHomeAutomation;

/// <summary>
/// ColorName of a color
/// </summary>
public class ColorName
{
    /// <summary>
    /// Number of the color
    /// </summary>
    [XmlAttribute("enum")]
    public int Enum { get; set; }

    /// <summary>
    /// ColorName of the color
    /// </summary>
    [XmlText]
    public string? Value { get; set; }
}
