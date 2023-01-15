using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Subnodes depending on which configuration is set.
    /// </summary>
    public class ApplyMask
    {
        /// <summary>
        /// HKR heating switch-off (in summer).
        /// </summary>
        [XmlElement("hkr_summer")]
        public XmlAvailable HkrSummer { get; set; }

        /// <summary>
        /// HKR target temperature.
        /// </summary>
        [XmlElement("hkr_temperature")]
        public XmlAvailable HkrTemperature { get; set; }

        /// <summary>
        /// HKR holiday bookings
        /// </summary>
        [XmlElement("hkr_holidays")]
        public XmlAvailable HkrHolidays { get; set; }

        /// <summary>
        /// HKR time switch
        /// </summary>
        [XmlElement("hkr_time_table")]
        public XmlAvailable HkrTimeTable { get; set; }

        /// <summary>
        /// Switchable socket/lamp/actuator ON/OFF.
        /// </summary>
        [XmlElement("relay_manual")]
        public XmlAvailable RelayManual { get; set; }

        /// <summary>
        /// Switchable socket/lamp/roller shutter time switch.
        /// </summary>
        [XmlElement("relay_automatic")]
        public XmlAvailable RelayAutomatic { get; set; }

        /// <summary>
        /// Level or brightness of lamp/roller shutter.
        /// </summary>
        [XmlElement("level")]
        public XmlAvailable Level { get; set; }

        /// <summary>
        /// Color or color temperature.
        /// </summary>
        [XmlElement("color")]
        public XmlAvailable Color { get; set; }

        /// <summary>
        /// Announcement.
        /// </summary>
        [XmlElement("dialhelper")]
        public XmlAvailable Dialhelper { get; set; }

        /// <summary>
        /// Light sunrise and sunset simulation.
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("sun_simulation")]
        public XmlAvailable SunSimulation { get; set; }

        /// <summary>
        /// Grouped templates, scenarios.
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("sub_templates")]
        public XmlAvailable SubTemplates { get; set; }

        /// <summary>
        /// WIFI on/off
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("main_wifi")]
        public XmlAvailable MainWifi { get; set; }

        /// <summary>
        /// Guest WIFI on/off.
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("guest_wifi")]
        public XmlAvailable GuestWifi { get; set; }

        /// <summary>
        /// Answering machine on/off.
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("tam_control")]
        public XmlAvailable TamControl { get; set; }

        /// <summary>
        /// Send any HTTP request.
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("http_request")]
        public XmlAvailable HttpRequest { get; set; }

        /// <summary>
        /// Activate HKR Boost/window open/temperature override.
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("timer_control")]
        public XmlAvailable TimerControl { get; set; }

        /// <summary>
        /// Switch devices to state of other devices.
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("switch_master")]
        public XmlAvailable SwitchMaster { get; set; }

        /// <summary>
        /// Trigger pushmail/app notification.
        /// </summary>
        /// <remarks>New in Fritz!OS 7.39</remarks>
        [XmlElement("custom_notification")]
        public XmlAvailable CustomNotification { get; set; }
    }
}
