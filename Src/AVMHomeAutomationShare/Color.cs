namespace AVMHomeAutomation;

/// <summary>
/// Color data.
/// </summary>
public class Color(ColorModel model)
{
    
    public int SatIndex { get; set; } = model.SatIndex;

    public int Hue { get; set; } = model.Hue;

    public int Sat { get; set; } = model.Sat;

    public int Val { get; set; } = model.Val;
}
