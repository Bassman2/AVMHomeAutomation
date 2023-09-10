using System;
using System.Diagnostics.CodeAnalysis;
namespace XSerializer
{
    //
    // Summary:
    //     When placed on a property or type, specifies the converter type to use.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface, AllowMultiple = false)]
    public class XmlConverterAttribute : Attribute
    {
        //
        // Summary:
        //     Initializes a new instance of System.Text.Json.Serialization.JsonConverterAttribute
        //     with the specified converter type.
        //
        // Parameters:
        //   converterType:
        //     The type of the converter.
        public XmlConverterAttribute(/*[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] */Type converterType)
        {
            ConverterType = converterType;
        }
        //
        // Summary:
        //     Initializes a new instance of System.Text.Json.Serialization.JsonConverterAttribute.
        protected XmlConverterAttribute()
        { }

        //
        // Summary:
        //     Gets the type of the System.Text.Json.Serialization.JsonConverterAttribute, or
        //     null if it was created without a type.
        //
        // Returns:
        //     The type of the System.Text.Json.Serialization.JsonConverterAttribute, or null
        //     if it was created without a type.
        //[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
        public Type ConverterType { get; }

        //
        // Summary:
        //     When overridden in a derived class and System.Text.Json.Serialization.JsonConverterAttribute.ConverterType
        //     is null, allows the derived class to create a System.Text.Json.Serialization.JsonConverter
        //     in order to pass additional state.
        //
        // Parameters:
        //   typeToConvert:
        //     The type of the converter.
        //
        // Returns:
        //     The custom converter.
        public virtual IXmlConverter CreateConverter(Type typeToConvert)
        {
            return (IXmlConverter)Activator.CreateInstance(typeToConvert);
        }
    }

}
