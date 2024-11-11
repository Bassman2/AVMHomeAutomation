namespace AVMHomeAutomation.Service.Model;

/// <summary>
/// Color defaults.
/// </summary>
[XmlRoot("colordefaults")]
public class ColorDefaultsModel
{
    /// <summary>
    /// Hue and saturation values
    /// </summary>
    [XmlArray("hsdefaults")]
    [XmlArrayItem("hs")]
    public List<ColorDefaultHSModel>? HSDefaults { get; set; }

    /// <summary>
    /// Temperature values
    /// </summary>
    [XmlArray("temperaturedefaults")]
    [XmlArrayItem("temp")]
    public List<ColorDefaultTemperatureModel>? TemperatureDefaults { get; set; }
}
