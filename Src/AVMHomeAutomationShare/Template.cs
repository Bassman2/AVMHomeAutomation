namespace AVMHomeAutomation;

/// <summary>
/// Data for template.
/// </summary>
public class Template : IXSerializable
{
    /// <summary>
    /// Identifier of the template.
    /// </summary>
    public string? Identifier { get; set; }

    /// <summary>
    /// ID of the template.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Functional bitmask of the template.
    /// </summary>
    public Functions FunctionBitMask { get; set; }

    /// <summary>
    /// Subnodes depending on which configuration is set.
    /// </summary>
    public int? ApplyBitMask { get; set; }
        
    /// <summary>
    /// Was template generated automatically?
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public int? AutocCeate { get; set; }        

    /// <summary>
    /// Name of the template
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Json metadata
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public string? MetaData { get; set; }

    /// <summary>
    /// List of devices 
    /// </summary>
    public List<ItemIdentifier>? Devices { get; set; }

    /// <summary>
    /// Subnodes depending on which configuration is set.
    /// </summary>
    public ApplyMask? ApplyMask { get; set; }

    /// <summary>
    /// List of subtemplates 
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public List<ItemIdentifier>? SubTemplates { get; set; }

    /// <summary>
    /// List of sub triggers 
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public List<TemplateTrigger>? Triggers { get; set; }

    public void ReadX(XElement elm)
    {
        Identifier = elm.GetStringAttribute("identifier");
        Id = elm.GetStringAttribute("id");
        FunctionBitMask = elm.GetEnumAttribute<Functions>("functionbitmask");
        ApplyBitMask = elm.GetIntAttribute("applymask");
        AutocCeate = elm.GetIntAttribute("autocreate");
        Name = elm.GetStringElement("name");
        MetaData = elm.GetStringElement("metadata");
        Devices = elm.GetListElements<ItemIdentifier>("devices", "device");
        ApplyMask = elm.GetItemElement<ApplyMask>("applymask");
        SubTemplates = elm.GetListElements<ItemIdentifier>("sub_templates", "template");
        Triggers = elm.GetListElements<TemplateTrigger>("triggers", "trigger");
    }
}
