using System.ComponentModel;

namespace AVMHomeAutomation;

internal interface IXSerializable
{
    public void ReadX(XContainer container);
}

internal static class XSerializableExt
{
    internal static string? GetStringAttribute(this XElement? elm, string name)
    {
        return elm?.Attribute(name)?.Value;
    }

    internal static int? GetIntAttribute(this XElement? elm, string name)
    {
        string? value = elm?.Attribute(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return val;
        }
        return null;
    }

    internal static T? GetEnumAttribute<T>(this XElement? elm, string name) where T : Enum
    {
        string? value = elm?.Attribute(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return (T)(object)val;
        }
        return default(T);
    }

    internal static string? GetStringElement(this XElement? elm, string name)
    {
        return elm?.Element(name)?.Value;
    }

    internal static int? GetIntElement(this XElement? elm, string name)
    {
        string? value = elm?.Element(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return val;
        }
        return null;
    }

    internal static bool? GetBoolElement(this XElement? elm, string name)
    {
        string? value = elm?.Element(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return val != 0;
        }
        return null;
    }

    internal static List<T>? GetListElemets<T>(this XElement? elm, string name) where T : IXSerializable, new()
    {
        return elm?.Elements(name).Select(e => { T i = new T(); i.ReadX(e); return i; }).ToList();
    }
    internal static List<T>? GetListElemets<T>(this XElement? elm, string array,string name) where T : IXSerializable, new()
    {
        return elm?.Element(array)?.Elements(name).Select(e => { T i = new T(); i.ReadX(e); return i; }).ToList();
    }

}