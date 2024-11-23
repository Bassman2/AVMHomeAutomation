namespace AVMHomeAutomation;

/// <summary>
/// HAN-FUN unit typ
/// </summary>
public enum EtsiUnitType

{
    /// <summary>
    /// Simple button
    /// </summary>
    [XmlEnum("SIMPLE_BUTTON")]
    SimpleButton = 273,

    /// <summary>
    /// Simple on off switchable
    /// </summary>
    [XmlEnum("SIMPLE_ON_OFF_SWITCHABLE")]
    SimpleOnOffSwitchable = 256,

    /// <summary>
    /// Simple on off switch
    /// </summary>
    [XmlEnum("SIMPLE_ON_OFF_SWITCH")] 
    SimpleOnOffSwitch = 257,

    /// <summary>
    /// AC outlet
    /// </summary>
    [XmlEnum("AC_OUTLET")] 
    ACOutlet = 262,

    /// <summary>
    /// AC outlet simple power metering
    /// </summary>
    [XmlEnum("AC_OUTLET_SIMPLE_POWER_METERING")] 
    ACOutletSimplePowerMetering = 263,

    /// <summary>
    /// Simple light
    /// </summary>
    [XmlEnum("SIMPLE_LIGHT")] 
    SimpleLight = 264,

    /// <summary>
    /// Dimmable light
    /// </summary>
    [XmlEnum("DIMMABLE_LIGHT")] 
    DimmableLight = 265,

    /// <summary>
    /// Dimmer switch
    /// </summary>
    [XmlEnum("DIMMER_SWITCH")] 
    DimmerSwitch = 266,

    /// <summary>
    /// Color bulb
    /// </summary>
    [XmlEnum("COLOR_BULB")] 
    ColorBulb = 277,

    /// <summary>
    /// Dimmable color bulb
    /// </summary>
    [XmlEnum("DIMMABLE_COLOR_BULB")]
    DimmableColorBulb = 278,

    /// <summary>
    /// Blind
    /// </summary>
    [XmlEnum("BLIND")] 
    Blind = 281,

    /// <summary>
    /// Lamellar
    /// </summary>
    [XmlEnum("LAMELLAR")] 
    Lamellar = 282,

    /// <summary>
    /// Simple detector
    /// </summary>
    [XmlEnum("SIMPLE_DETECTOR")] 
    SimpleDetector = 512,

    /// <summary>
    /// Door open close detector
    /// </summary>
    [XmlEnum("DOOR_OPEN_CLOSE_DETECTOR")] 
    DoorOpenCloseDetector = 513,

    /// <summary>
    /// Window open close detector
    /// </summary>
    [XmlEnum("WINDOW_OPEN_CLOSE_DETECTOR")] 
    WindowOpenCloseDetector = 514,

    /// <summary>
    /// Motion detector
    /// </summary>
    [XmlEnum("MOTION_DETECTOR")] 
    MotionDetector = 515,

    /// <summary>
    /// Flood detector
    /// </summary>
    [XmlEnum("FLOOD_DETECTOR")] 
    FloodDetector = 518,

    /// <summary>
    /// Flas break detector
    /// </summary>
    [XmlEnum("GLAS_BREAK_DETECTOR")] 
    GlasBreakDetector = 519,

    /// <summary>
    /// Vibration detector
    /// </summary>
    [XmlEnum("VIBRATION_DETECTOR")] 
    VibrationDetector = 520,

    /// <summary>
    /// Siren
    /// </summary>
    [XmlEnum("SIREN")] 
    Siren = 640,
}
