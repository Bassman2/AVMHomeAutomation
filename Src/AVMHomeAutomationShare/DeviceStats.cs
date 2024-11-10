namespace AVMHomeAutomation;

/// <summary>
/// Device status
/// </summary>
[XmlRoot("devicestats")]
public class DeviceStats
{
    /// <summary>
    /// Temeratures
    /// </summary>
    [XmlArray("temperature")]
    [XmlArrayItem("stats")]
    public List<Stats>? Temperature { get; set; }

    /// <summary>
    /// Voltages
    /// </summary>
    [XmlArray("voltage")]
    [XmlArrayItem("stats")]
    public List<Stats>? Voltage { get; set; }

    /// <summary>
    /// Power
    /// </summary>
    [XmlArray("power")]
    [XmlArrayItem("stats")]
    public List<Stats>? Power { get; set; }

    /// <summary>
    /// Energy
    /// </summary>
    [XmlArray("energy")]
    [XmlArrayItem("stats")]
    public List<Stats>? Energy { get; set; }

    /// <summary>
    /// Humidity
    /// </summary>
    [XmlArray("humidity")]
    [XmlArrayItem("stats")]
    public List<Stats>? Humidity { get; set; }
}
