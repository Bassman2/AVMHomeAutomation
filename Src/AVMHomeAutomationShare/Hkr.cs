using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Radiator regulator
    /// </summary>
    public class Hkr
    {
        /// <summary>
        /// Actual temperature in 0.5 ° C, value range: 0x10 - 0x3816 - 56 (8 to 28 ° C), 16 &lt;= 8 ° C, 17 = 8.5 ° C ...... 56> = 28 ° C, 254 = ON, 253 = OFF
        /// </summary>
        [XmlElement("tist")]
        public XmlNullableHkrTemperature TIst { get; set; }

        /// <summary>
        /// Target temperature in 0.5 ° C, value range: 0x10 - 0x38 16 - 56 (8 to 28 ° C), 16 &lt;= 8 ° C, 17 = 8.5 ° C...... 56> = 28 ° C, 254 = ON, 253 = OFF
        /// </summary>
        [XmlElement("tsoll")]
        public XmlNullableHkrTemperature TSoll { get; set; }

        /// <summary>
        /// Lowering temperature in 0.5 ° C, value range: 0x10 - 0x38 16 - 56 (8 to 28 ° C), 16 &lt;= 8 ° C, 17 = 8.5 ° C...... 56> = 28 ° C, 254 = ON, 253 = OFF
        /// </summary>
        [XmlElement("absenk")]
        public XmlNullableHkrTemperature Absenk { get; set; }

        /// <summary>
        /// Comfort temperature in 0.5 ° C, value range: 0x10 - 0x38 16 - 56 (8 to 28 ° C), 16 &lt;= 8 ° C, 17 = 8.5 ° C...... 56> = 28 ° C, 254 = ON, 253 = OFF
        /// </summary>
        [XmlElement("komfort")]
        public XmlNullableHkrTemperature Komfort { get; set; }

        /// <summary>
        /// 0/1 - Keylock via UI / API on no / yes (empty if unknown or error)
        /// </summary>
        [XmlElement("lock")]
        public XmlNullableBool Lock { get; set; }

        /// <summary>
        /// 0/1 - key lock directly on the device on no / yes (empty if unknown or error)
        /// </summary>
        [XmlElement("devicelock")]
        public XmlNullableBool DeviceLock { get; set; }

        /// <summary>
        /// Error codes supplied by the HKR (eg if there was a problem during the installation of the HKR):
        /// 0: no error
        /// 1: No adaptation possible. Device correctly mounted on the radiator?
        /// 2: Valve lift too short or battery power too low. Open the valve lifter by hand several times and close orinsert new batteries.
        /// 3: No valve movement possible. Valve tappets free?
        /// 4: The installation is being prepared.
        /// 5: The radiator controller is in installation mode and can be mounted on the heater valve.
        /// 6: The radiator controller now adapts to the stroke of the heating valve.
        /// </summary>
        [XmlElement("errorcode")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 0 or 1: window oven detected
        /// </summary>
        [XmlElement("windowopenactiv")]
        public XmlNullableBool WindowOpenActiv { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("windowopenactiveendtime")]
        public XmlNullableDateTime WindowOpenActivEndTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("boostactive")]
        public XmlNullableBool BoostActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("boostactiveendtime")]
        public XmlNullableDateTime BoostActiveEndTime { get; set; }

        /// <summary>
        /// 0 or 1: Battery low - please change the battery
        /// </summary>
        [XmlElement("batterylow")]
        public XmlNullableBool BatteryLow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("battery")]
        public XmlNullable<int> Battery{ get; set; }

        /// <summary>
        /// Next temperature change
        /// </summary>
        [XmlElement("nextchange")]
        public NextChange NextChange { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("summeractive")]
        public XmlNullableBool SummerActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("holidayactive")]
        public XmlNullableBool HolidayActive { get; set; }
        
    }
}
