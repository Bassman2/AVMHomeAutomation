using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Radiator regulator
    /// </summary>
    public class Hkr
    {
        /// <summary>
        /// Actual temperature in ° C. (8 to 28 ° C or ON / OFF)
        /// </summary>
        [XmlElement("tist")]
        public XmlNullableHkrTemperature TIst { get; set; }

        /// <summary>
        /// Target temperature in ° C. (8 to 28 ° C or ON / OFF)
        /// </summary>
        [XmlElement("tsoll")]
        public XmlNullableHkrTemperature TSoll { get; set; }

        /// <summary>
        /// Lowering temperature in ° C. (8 to 28 ° C or ON / OFF)
        /// </summary>
        [XmlElement("absenk")]
        public XmlNullableHkrTemperature Absenk { get; set; }

        /// <summary>
        /// Comfort temperature in ° C. (8 to 28 ° C or ON / OFF)
        /// </summary>
        [XmlElement("komfort")]
        public XmlNullableHkrTemperature Komfort { get; set; }

        /// <summary>
        /// Keylock via UI / API on no / yes 
        /// </summary>
        [XmlElement("lock")]
        public XmlNullableBool Lock { get; set; }

        /// <summary>
        /// Key lock directly on the device on no / yes 
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
        /// Window oven detected
        /// </summary>
        [XmlElement("windowopenactiv")]
        public XmlNullableBool WindowOpenActiv { get; set; }

        /// <summary>
        /// Window open end time
        /// </summary>
        [XmlElement("windowopenactiveendtime")]
        public XmlNullableDateTime WindowOpenActivEndTime { get; set; }

        /// <summary>
        ///  Boost active
        /// </summary>
        [XmlElement("boostactive")]
        public XmlNullableBool BoostActive { get; set; }

        /// <summary>
        /// Boost active end time.
        /// </summary>
        [XmlElement("boostactiveendtime")]
        public XmlNullableDateTime BoostActiveEndTime { get; set; }

        /// <summary>
        /// Battery low - please change the battery
        /// </summary>
        [XmlElement("batterylow")]
        public XmlNullableBool BatteryLow { get; set; }

        /// <summary>
        /// Battery state of charge in percent. (0 - 100)
        /// </summary>
        [XmlElement("battery")]
        public XmlNullableInt Battery{ get; set; }

        /// <summary>
        /// Next temperature change
        /// </summary>
        [XmlElement("nextchange")]
        public NextChange NextChange { get; set; }

        /// <summary>
        /// Is the HKR currently in a vacation period?
        /// </summary>
        [XmlElement("summeractive")]
        public XmlNullableBool SummerActive { get; set; }

        /// <summary>
        /// Is the HKR currently in a Holiday period?
        /// </summary>
        [XmlElement("holidayactive")]
        public XmlNullableBool HolidayActive { get; set; }        
    }
}
