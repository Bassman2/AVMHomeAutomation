namespace AVMHomeAutomation
{
    /// <summary>
    /// Interface for XmlNullable structs
    /// </summary>
    public interface IXmlNullable
    {
        /// <summary>
        /// Gets a value indicating whether the current object has a valid value.
        /// </summary>
        bool HasValue { get; }
    }
}
