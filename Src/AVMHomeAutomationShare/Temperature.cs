namespace AVMHomeAutomation;

/// <summary>
/// Temperature sensor data.
/// </summary>
public class Temperature
{
    /// <summary>
    /// Temperatur value in ° Celsius
    /// </summary>
    [XmlElement("celsius")]
    public double? Celsius { get; set; }

    /// <summary>
    /// Temperatur offset value in ° Celsius
    /// </summary>
    [XmlElement("offset")]
    public double? Offset { get; set; }
}
