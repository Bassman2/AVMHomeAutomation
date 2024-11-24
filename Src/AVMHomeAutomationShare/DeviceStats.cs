
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

    public void ReadX(XElement elm)
    {
        Temperature = elm.GetListElements<Stats>("temperature", "stats");
        Voltage = elm.GetListElements<Stats>("voltage", "stats");
        Power = elm.GetListElements<Stats>("power", "stats");
        Energy = elm.GetListElements<Stats>("energy", "stats");
        Humidity = elm.GetListElements<Stats>("humidity", "stats");
    }
}
