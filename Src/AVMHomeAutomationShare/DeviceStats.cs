
namespace AVMHomeAutomation;

/// <summary>
/// Device status
/// </summary>
public class DeviceStats : IXSerializable
{
    /// <summary>
    /// Temeratures
    /// </summary>
    public List<Stats>? Temperature { get; set; }

    /// <summary>
    /// Voltages
    /// </summary>
    public List<Stats>? Voltage { get; set; }

    /// <summary>
    /// Power
    /// </summary>
    public List<Stats>? Power { get; set; }

    /// <summary>
    /// Energy
    /// </summary>
    public List<Stats>? Energy { get; set; }

    /// <summary>
    /// Humidity
    /// </summary>
    public List<Stats>? Humidity { get; set; }

    public void ReadX(XContainer container)
    {
        var elm = container.Element("devicestats");
        Temperature = elm.GetListElemets<Stats>("temperature", "stats");
        Voltage = elm.GetListElemets<Stats>("voltage", "stats");
        Power = elm.GetListElemets<Stats>("power", "stats");
        Energy = elm.GetListElemets<Stats>("energy", "stats");
        Humidity = elm.GetListElemets<Stats>("humidity", "stats");
    }
}
