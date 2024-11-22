namespace AVMHomeAutomation
{
    /// <summary>
    /// Meta data
    /// </summary>
    public class MetaData
    {
        /// <summary>
        /// Icon
        /// </summary>
        [JsonPropertyName("icon")]
        public int Icon { get; set; }

        /// <summary>
        /// Scenario type
        /// </summary>
        [JsonPropertyName("type")]
        public TypeEnum Type { get; set; }
    }

    /// <summary>
    /// Scenario type
    /// </summary>
    [DataContract]
    public enum TypeEnum
    {
        /// <summary>
        /// Coming
        /// </summary>
        [EnumMember(Value = "coming")]
        Coming,

        /// <summary>
        /// Leaving
        /// </summary>
        [EnumMember(Value = "leaving")]
        Leaving,

        /// <summary>
        /// Generic
        /// </summary>
        [EnumMember(Value = "generic")]
        Generic
    }
}
