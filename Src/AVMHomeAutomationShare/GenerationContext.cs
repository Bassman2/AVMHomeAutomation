using Serialization;
using System.Text.Json.Serialization;

namespace AVMHomeAutomation
{
    [XmlSerializable(typeof(DeviceList))]
    [XmlSerializable(typeof(Device))]
    [XmlSerializable(typeof(Group))]
    [XmlSerializable(typeof(DeviceStats))]
    [XmlSerializable(typeof(TriggerList))]
    [XmlSerializable(typeof(TemplateList))]
    [XmlSerializable(typeof(ColorDefaults))]
    [XmlSerializable(typeof(SubscriptionState))]
    internal partial class GenerationContext : XmlSerializerContext
    {
    }
}
