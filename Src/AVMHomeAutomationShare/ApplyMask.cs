namespace AVMHomeAutomation;

/// <summary>
/// Subnodes depending on which configuration is set.
/// </summary>
public class ApplyMask : IXSerializable
{
    /// <summary>
    /// HKR heating switch-off (in summer).
    /// </summary>
    public bool? HkrSummer { get; set; }

    /// <summary>
    /// HKR target temperature.
    /// </summary>
    public bool? HkrTemperature { get; set; }

    /// <summary>
    /// HKR holiday bookings
    /// </summary>
    public bool? HkrHolidays { get; set; }

    /// <summary>
    /// HKR time switch
    /// </summary>
    public bool? HkrTimeTable { get; set; }

    /// <summary>
    /// Switchable socket/lamp/actuator ON/OFF.
    /// </summary>
    public bool? RelayManual { get; set; }

    /// <summary>
    /// Switchable socket/lamp/roller shutter time switch.
    /// </summary>
    public bool? RelayAutomatic { get; set; }

    /// <summary>
    /// Level or brightness of lamp/roller shutter.
    /// </summary>
    public bool? Level { get; set; }

    /// <summary>
    /// Color or color temperature.
    /// </summary>
    public bool? Color { get; set; }

    /// <summary>
    /// Announcement.
    /// </summary>
    public bool? Dialhelper { get; set; }

    /// <summary>
    /// Light sunrise and sunset simulation.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? SunSimulation { get; set; }

    /// <summary>
    /// Grouped templates, scenarios.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? SubTemplates { get; set; }

    /// <summary>
    /// WIFI on/off
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? MainWifi { get; set; }

    /// <summary>
    /// Guest WIFI on/off.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? GuestWifi { get; set; }

    /// <summary>
    /// Answering machine on/off.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? TamControl { get; set; }

    /// <summary>
    /// Send any HTTP request.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? HttpRequest { get; set; }

    /// <summary>
    /// Activate HKR Boost/window open/temperature override.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? TimerControl { get; set; }

    /// <summary>
    /// Switch devices to state of other devices.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? SwitchMaster { get; set; }

    /// <summary>
    /// TemplateTrigger pushmail/app notification.
    /// </summary>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public bool? CustomNotification { get; set; }

    public void ReadX(XElement elm)
    {
        HkrSummer = elm.GetBoolElement("hkr_summer");
        HkrTemperature = elm.GetBoolElement("hkr_temperature");
        HkrHolidays = elm.GetBoolElement("hkr_holidays");
        HkrTimeTable = elm.GetBoolElement("hkr_time_table");
        RelayManual = elm.GetBoolElement("relay_manual");
        RelayAutomatic = elm.GetBoolElement("relay_automatic");
        Level = elm.GetBoolElement("level");
        Color = elm.GetBoolElement("color");
        Dialhelper = elm.GetBoolElement("dialhelper");
        SunSimulation = elm.GetBoolElement("sun_simulation");
        SubTemplates = elm.GetBoolElement("sub_templates");
        MainWifi = elm.GetBoolElement("main_wifi");
        GuestWifi = elm.GetBoolElement("guest_wifi");
        TamControl = elm.GetBoolElement("tam_control");
        HttpRequest = elm.GetBoolElement("http_request");
        TimerControl = elm.GetBoolElement("timer_control");
        SwitchMaster = elm.GetBoolElement("switch_master");
        CustomNotification = elm.GetBoolElement("custom_notification");
    }
}
