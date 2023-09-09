using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// HAN-FUN interfaces
    /// </summary>
    public enum EtsiInterfaces
    {
        /// <summary>
        /// Keep alive
        /// </summary>
        [XmlEnum("KEEP_ALIVE")] 
        KeepAlive = 277,

        /// <summary>
        /// Alert
        /// </summary>
        [XmlEnum("ALERT")] 
        Alert = 256,

        /// <summary>
        /// On off
        /// </summary>
        [XmlEnum("ON_OFF")] 
        OnOff = 512,

        /// <summary>
        /// Level control
        /// </summary>
        [XmlEnum("LEVEL_CTRL")] 
        LevelCtrl = 513,

        /// <summary>
        /// Color control
        /// </summary>
        [XmlEnum("COLOR_CTRL")] 
        ColorCtrl = 514,

        /// <summary>
        /// Open close
        /// </summary>
        [XmlEnum("OPEN_CLOSE")] 
        OpenClose = 516,

        /// <summary>
        /// Open close configuration
        /// </summary>
        [XmlEnum("OPEN_CLOSE_CONFIG")] 
        OpenCloseConfig = 517,

        /// <summary>
        /// Simple button
        /// </summary>
        [XmlEnum("SIMPLE_BUTTON")] 
        SimpleButton = 772,

        /// <summary>
        /// SUOTA Update
        /// </summary>
        [XmlEnum("SUOTA_Update")] 
        SUOTAUpdate = 1024,
    }
}
