﻿using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// HAN-FUN / ETSI unit data
    /// </summary>
    public class EtsiUnitInfo
    {
        /// <summary>
        /// Internal device ID of the associated HAN-FUN device.
        /// </summary>
        [XmlElement("etsideviceid")]
        public string EtsiDeviceId { get; set; }

        /// <summary>
        /// HAN-FUN unit typ
        /// </summary>
        [XmlElement("unittype")]
        public XmlNullableEnum<EtsiUnitType> UnitType { get; set; }

        /// <summary>
        /// HAN-FUN interfaces
        /// </summary>
        [XmlElement("interfaces")]
        public XmlList<EtsiInterfaces> Interfaces { get; set; }
    }
}
