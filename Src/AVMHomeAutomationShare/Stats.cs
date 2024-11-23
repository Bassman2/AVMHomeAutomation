namespace AVMHomeAutomation;

/// <summary>
/// Status values
/// </summary>
public class Stats : IXSerializable
{
    /// <summary>
    /// Number of values
    /// </summary>
    public int? Count { get; set; }

    /// <summary>
    /// Grid of values
    /// </summary>
    public int? Grid { get; set; }

    /// <summary>
    /// Values
    /// </summary>
    public string? Value { get; set; }

    public void ReadX(XContainer container)
    {
        var elm = container.Element("studs");
        Count = elm.GetIntAttribute("count");
        Grid = elm.GetIntAttribute("grid");
        Value = elm?.Value;
    }
}
