namespace AVMHomeAutomation.Service.Model;

/// <summary>
/// ColorName of a color
/// </summary>
public class ColorNameModel
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
