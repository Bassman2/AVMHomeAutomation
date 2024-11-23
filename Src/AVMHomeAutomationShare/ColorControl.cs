namespace AVMHomeAutomation;

/// <summary>
/// Lamp with adjustable colour/colour temperature.
/// </summary>
public class ColorControl
{
    /// <summary>
    /// Supported color modes
    /// </summary>
    [XmlAttribute("supported_modes")]
    public string? SupportedModes { get; set; }

    /// <summary>
    /// Current color mode
    /// </summary>
    [XmlAttribute("current_mode")]
    public string? CurrentMode { get; set; }

    /// <summary>
    /// Hue value of the color. (0° bis 359°)
    /// </summary>
    [XmlElement("hue")]
    public int? Hue { get; set; }

    /// <summary>
    /// Saturation value of the color. (0 bis 255)
    /// </summary>
    [XmlElement("saturation")]
    public int? Saturation { get; set; }

    /// <summary>
    /// Unmapped hue value.
    /// </summary>
    [XmlElement("unmapped_hue")]
    public int? UnmappedHue { get; set; }

    /// <summary>
    ///  Unmapped Saturation value
    /// </summary>
    [XmlElement("unmapped_saturation")]
    public int? UnmappedSaturation { get; set; }

    /// <summary>
    /// Color temperature in ° Kelvin. (2700° bis 6500° Kelvin)
    /// </summary>
    [XmlElement("temperature")]
    public int? Temperature { get; set; }
}
