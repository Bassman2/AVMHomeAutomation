using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Subscription state data.
    /// </summary>
    [XmlRoot("state")]
    public class SubscriptionState
    {
        /// <summary>
        /// Subscription state code.
        /// </summary>
        [XmlAttribute("code")]
        public SubscriptionCode Code { get; set; }

        /// <summary>
        /// AIN of the last registered device.
        /// </summary>
        [XmlElement("latestain")]
        public string LatestAin { get; set; }
    }
}
