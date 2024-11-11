namespace AVMHomeAutomation.Service.Model;

/// <summary>
/// Hue and saturation color default values
/// </summary>
public class ColorDefaultHSModel
{
    /// <summary>
    /// Hue index.
    /// </summary>
    [XmlAttribute("hue_index")]
    public int HueIndex { get; set; }

    /// <summary>
    /// ColorName of the color
    /// </summary>
    [XmlElement("name")]
    public ColorNameModel? Name {  get; set;}

    /// <summary>
    /// Colors
    /// </summary>
    [XmlElement("color")]
    public List<ColorModel>? Colors { get; set; }
}
