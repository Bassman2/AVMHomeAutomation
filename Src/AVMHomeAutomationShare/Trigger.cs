﻿namespace AVMHomeAutomation;

/// <summary>
/// Data for trigger.
/// </summary>
public class Trigger : IXSerializable
{
    /// <summary>
    /// Identifier of the trigger.
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// Identifier of the trigger.
    /// </summary>
    public int? Active { get; set; }

    /// <summary>
    /// Name of the trigger.
    /// </summary>
    public string? Name { get; set; }

    public void ReadX(XElement elm)
    {
        Identifier = elm.GetStringAttribute("identifier");
        Active = elm.GetIntAttribute("active");            
        Name = elm.GetStringElement("name");
    }
}
