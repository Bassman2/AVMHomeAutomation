using System;

namespace AVMHomeAutomation
{
    [Flags]
    public enum Functions
    {
        /// <summary>
        /// HANFUN Device
        /// </summary>
        HANFUNDevice = 0x0001,          // Bit 0

        /// <summary>
        /// Alarm
        /// </summary>
        Alarm = 0x0010,                 // Bit 4 

        /// <summary>
        /// Heater
        /// </summary>
        Heater = 0x0040,                // Bit 6

        /// <summary>
        /// Energy
        /// </summary>
        Energy = 0x0080,                // Bit 7

        /// <summary>
        /// Temperature
        /// </summary>
        Temperature = 0x0100,           // Bit 8

        /// <summary>
        /// Switch
        /// </summary>
        Switch = 0x0200,                // Bit 9

        /// <summary>
        /// DEVT Repeater
        /// </summary>
        Repeater = 0x0400,              // Bit 10

        /// <summary>
        /// Microphone
        /// </summary>
        Microphone = 0x0800,            // Bit 11

        /// <summary>
        /// Group
        /// </summary>
        Group = 0x1000,               // Bit 12

        /// <summary>
        /// HANFUN Unit
        /// </summary>
        HANFUNUnit = 0x2000             // Bit 13
    }
}
