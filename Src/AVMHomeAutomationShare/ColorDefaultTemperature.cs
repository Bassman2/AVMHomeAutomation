
namespace AVMHomeAutomation;

/// <summary>
/// Color temperature default values
/// </summary>
public class ColorDefaultTemperature : IXSerializable
{
    /// <summary>
    /// Color temperatur value in ° Kelvin. (2700° bis 6500°)
    /// </summary>
    [XmlAttribute("value")]
    public int Value { get; set; }

    public void ReadX(XContainer container)
    {
        throw new NotImplementedException();
    }
}
