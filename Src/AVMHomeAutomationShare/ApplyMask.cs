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
        public string HkrSummer { get; set; }

        /// <summary>
        /// HKR target temperature.
        /// </summary>
        [XmlElement("hkr_temperature")]
        public string HkrTemperature { get; set; }

        /// <summary>
        /// HKR holiday bookings
        /// </summary>
        [XmlElement("hkr_holidays")]
        public string HkrHolidays { get; set; }

        /// <summary>
        /// HKR time switch
        /// </summary>
        [XmlElement("hkr_time_table")]
        public string HkrTimeTable { get; set; }

        /// <summary>
        /// Switchable socket/lamp/actuator ON/OFF.
        /// </summary>
        [XmlElement("relay_manual")]
        public string RelayManual { get; set; }

        /// <summary>
        /// Switchable socket/lamp/roller shutter time switch.
        /// </summary>
        [XmlElement("relay_automatic")]
        public string RelayAutomatic { get; set; }

        /// <summary>
        /// Level or brightness of lamp/roller shutter.
        /// </summary>
        [XmlElement("level")]
        public string Level { get; set; }

        /// <summary>
        /// Color or color temperature.
        /// </summary>
        [XmlElement("color")]
        public string Color { get; set; }

        /// <summary>
        /// Announcement.
        /// </summary>
        [XmlElement("dialhelper")]
        public string Dialhelper { get; set; }
    }
}
