﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    public class SimpleOnOff
    {
        [XmlElement("state")]
        public string State { get; set; }
    }
}
