﻿using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Next temperature change
    /// </summary>
    public class NextChange
    {
        /// <summary>
        /// End of the time period.
        /// </summary>
        [XmlElement("endperiod")]
        public XmlNullableDateTime EndPeriod { get; set; }

        /// <summary>
        /// Target temperatur in °C or Off.
        /// </summary>           
        [XmlElement("tchange")]
        public XmlNullableHkrTemperature TChange { get; set; }
    }
}
