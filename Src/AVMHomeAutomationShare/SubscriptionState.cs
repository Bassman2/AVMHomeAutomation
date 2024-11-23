
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


    #region IXSerializable
    
    public void ReadX(XContainer container)
    {
        var state = container.Element("state");
        Code = state.GetEnumAttribute<SubscriptionCode>("code");
        LatestAin = state.GetStringElement("latestain"); 
    }

    #endregion
}
