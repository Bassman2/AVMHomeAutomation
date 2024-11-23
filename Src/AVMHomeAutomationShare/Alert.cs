namespace AVMHomeAutomation;

/// <summary>
/// Alarm sensor data.
/// </summary>
public class Alert
{
    /// <summary>
    /// Last reported alarm condition.
    /// </summary>
    [XmlElement("state", IsNullable = true)]
    public AlertState? State { get; set; }

    /// <summary>
    /// Time of last alarm status change.
    /// </summary>
    [XmlElement("lastalertchgtimestamp")]
    public DateTime? LastAlertChangeTimestamp { get; set;}
}
