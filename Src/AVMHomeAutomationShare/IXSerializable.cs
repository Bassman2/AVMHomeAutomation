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

    internal static bool? GetBoolAttribute(this XElement? elm, string name)
    {
        string? value = elm?.Attribute(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return val != 0;
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
        return default;
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

    internal static DateTime? GetDateTimeElement(this XElement? elm, string name)
    {
        string? value = elm?.Element(name)?.Value;
        if (long.TryParse(value, out var val))
        {
            return begin.AddSeconds(val); //.ToLocalTime();
        }
        return null;
    }

    internal static T? GetEnumElement<T>(this XElement? elm, string name) where T : Enum
    {
        string? value = elm?.Element(name)?.Value;
        if (int.TryParse(value, out var val))
        {
            return (T)(object)val;
        }
        return default;
    }

    internal static T? GetItemElement<T>(this XElement? elm, string name) where T : IXSerializable, new()
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
    internal static List<string>? GetListStringsElement(this XElement? elm, string name)
    {
        return elm?.Elements(name).Select(e =>  e.Value).ToList();
    }

    internal static List<T>? GetListElements<T>(this XElement? elm, string name) where T : IXSerializable, new()
    {
        return elm?.Elements(name).Select(e => { T i = new(); i.ReadX(e); return i; }).ToList();
    }
    internal static List<T>? GetListElements<T>(this XElement? elm, string array,string name) where T : IXSerializable, new()
    {
        return elm?.Element(array)?.Elements(name).Select(e => { T i = new(); i.ReadX(e); return i; }).ToList();
    }

    

}