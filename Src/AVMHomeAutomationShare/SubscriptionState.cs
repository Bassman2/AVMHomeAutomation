namespace AVMHomeAutomation;

/// <summary>
/// Subscription state data.
/// </summary>
public class SubscriptionState : IXSerializable
{
    /// <summary>
    /// Subscription state code.
    /// </summary>
    public SubscriptionCode Code { get; set; }

    /// <summary>
    /// AIN of the last registered device.
    /// </summary>
    public string? LatestAin { get; set; }

    public void ReadX(XElement elm)
    {
        Code = elm.GetEnumAttribute<SubscriptionCode>("code");
        LatestAin = elm.GetStringElement("latestain"); 
    }
}
