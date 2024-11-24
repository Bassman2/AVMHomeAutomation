
namespace AVMHomeAutomation;

/// <summary>
/// Color defaults.
/// </summary>
[XmlRoot("colordefaults")]
public class ColorDefaults : IXSerializable
{
    /// <summary>
    /// Hue and saturation values
    /// </summary>
    [XmlArray("hsdefaults")]
    [XmlArrayItem("hs")]
    public List<ColorDefaultHS>? HSDefaults { get; set; }

    /// <summary>
    /// Temperature values
    /// </summary>
    [XmlArray("temperaturedefaults")]
    [XmlArrayItem("temp")]
    public List<ColorDefaultTemperature>? TemperatureDefaults { get; set; }

    public void ReadX(XElement elm)
    {
        throw new NotImplementedException();
    }
}
