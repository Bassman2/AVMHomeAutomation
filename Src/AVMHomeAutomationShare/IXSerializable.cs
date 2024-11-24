namespace AVMHomeAutomation;

internal interface IXSerializable
{
    void ReadX(XElement elm);
}

internal static class XSerializableExt
{
    private readonly static DateTime begin = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

    public static T? XDeserialize<T>(this string? value, string rootName) where T : IXSerializable, new()
    {
        if (value is null)
        {
            return default;
        }

        var res = new T();
        var doc = XDocument.Parse(value);
        var elm = doc.Element(rootName)!;
        res.ReadX(elm);
        return res;
    }

    internal static string? ReadAttributeString(this XElement? elm, string name)
    {
        return elm?.Attribute(name)?.Value;
    }

    internal static int? ReadAttributeInt(this XElement? elm, string name)
    {
        string? value = elm?.Attribute(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return val;
        }
        return null;
    }

    internal static bool? ReadAttributeBool(this XElement? elm, string name)
    {
        string? value = elm?.Attribute(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return val != 0;
        }
        return null;
    }

    
    internal static T? ReadAttributeEnum<T>(this XElement? elm, string name) where T : Enum
    {
        string? value = elm?.Attribute(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return (T)(object)val;
        }
        return default;
    }

    internal static string? ReadElementString(this XElement? elm, string name)
    {
        return elm?.Element(name)?.Value;
    }

    internal static int? ReadElementInt(this XElement? elm, string name)
    {
        string? value = elm?.Element(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return val;
        }
        return null;
    }

    internal static bool? ReadElementBool(this XElement? elm, string name)
    {
        string? value = elm?.Element(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return val != 0;
        }
        return null;
    }

    internal static DateTime? ReadElementDateTime(this XElement? elm, string name)
    {
        string? value = elm?.Element(name)?.Value;
        if (long.TryParse(value, out var val))
        {
            return begin.AddSeconds(val); //.ToLocalTime();
        }
        return null;
    }

    internal static T? ReadElementEnum<T>(this XElement? elm, string name) where T : Enum
    {
        string? value = elm?.Element(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return (T)(object)val;
        }
        return default;
    }

    internal static List<T>? ReadElementEnums<T>(this XElement? elm, string name) where T : Enum
    {
        return elm?.Elements(name).Select(i => (T)(object)(int.TryParse(i.Value, out int val) ? val : 0))?.ToList();
    }

    internal static T? ReadElementItem<T>(this XElement? elm, string name) where T : IXSerializable, new()
    {
        var child = elm?.Element(name);
        if (child is null)
        {
            return default;
        }
        var item = new T();
        item.ReadX(child); 
        return item;
        
    }
    internal static List<string>? ReadElementStrings(this XElement? elm, string name)
    {
        return elm?.Elements(name).Select(e => e.Value).ToList();
    }

    internal static List<T>? ReadElementList<T>(this XElement? elm, string name) where T : IXSerializable, new()
    {
        return elm?.Elements(name).Select(e => { T i = new(); i.ReadX(e); return i; }).ToList();
    }
    internal static List<T>? ReadElementList<T>(this XElement? elm, string array,string name) where T : IXSerializable, new()
    {
        return elm?.Element(array)?.Elements(name).Select(e => { T i = new(); i.ReadX(e); return i; }).ToList();
    }

    

}