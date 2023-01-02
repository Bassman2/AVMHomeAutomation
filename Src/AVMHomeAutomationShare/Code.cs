using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public enum Code
    {
        [XmlEnum("0")]
        NoSubscription = 0,

        [XmlEnum("1")]
        SubscriptionRunning = 1,

        [XmlEnum("2")]
        Timeout = 2,

        [XmlEnum("3")]
        Error =3  
    }
}
