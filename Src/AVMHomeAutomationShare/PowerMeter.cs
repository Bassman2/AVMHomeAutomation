using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AVMHomeAutomation
{
    /// <summary>
    /// Energy meter
    /// </summary>
    public class PowerMeter //: IXmlSerializable
    {
        /// <summary>
        /// Value in 0.001 V (current voltage, updated approximately every 2 minutes)
        /// </summary>
        [XmlElement("voltage")]
        public double Voltage { get; set; }

        /// <summary>
        /// Value in 0.001 W (current performance, refreshed approximately every 2 minutes)
        /// </summary>
        [XmlElement("power")]
        public double Power { get; set; }
                
        /// <summary>
        /// Value in 1.0 Wh (absolute consumption since commissioning)
        /// </summary>
        [XmlElement("energy")]
        public double Energy { get; set; }
        
        /*
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            try
            {
                //reader.Read();
                //this.Voltage = reader.ReadElementContentAsDouble("voltage", "") / 1000.0;
                //this.Power = reader.ReadElementContentAsDouble("power", "") / 1000.0;
                //this.Energy = reader.ReadElementContentAsDouble("energy", "");

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                        case "voltage":
                            // Value in 0.001 V(current voltage, updated approximately every 2 minutes)
                            this.Voltage = reader.ReadElementContentAsDouble() / 1000.0;
                            break;
                        case "power":
                            // Value in 0.001 W(current performance, refreshed approximately every 2 minutes)
                            this.Power = reader.ReadElementContentAsDouble() / 1000.0;
                            break;
                        case "energy":
                            // Value in 1.0 Wh(absolute consumption since commissioning)
                            this.Energy = reader.ReadElementContentAsDouble();
                            break;
                        default:
                            break;
                        }
                    }
                }
                //reader.Read();


            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new System.NotImplementedException();
        }
        */
    }
}
