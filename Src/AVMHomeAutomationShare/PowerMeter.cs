namespace AVMHomeAutomation;

/// <summary>
/// Energy meter
/// </summary>
public class PowerMeter 
{
    /// <summary>
    /// Voltage value in Volt
    /// </summary>
    [XmlElement("voltage")]
    public double? Voltage { get; set; }

    /// <summary>
    /// Power value in W
    /// </summary>
    [XmlElement("power")]
    public double? Power { get; set; }
            
    /// <summary>
    /// Energy value in kWh
    /// </summary>
    [XmlElement("energy")]
    public double? Energy { get; set; }
}
