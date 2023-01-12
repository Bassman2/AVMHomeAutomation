using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Subscription state code
    /// </summary>
    public enum SubscriptionCode
    {
        /// <summary>
        /// No subscription running.
        /// </summary>
        [XmlEnum("0")]
        NoSubscription = 0,

        /// <summary>
        /// Subscription running.
        /// </summary>
        [XmlEnum("1")]
        SubscriptionRunning = 1,

        /// <summary>
        /// Timeout
        /// </summary>
        [XmlEnum("2")]
        Timeout = 2,

        /// <summary>
        /// Error
        /// </summary>
        [XmlEnum("3")]
        Error =3  
    }
}
