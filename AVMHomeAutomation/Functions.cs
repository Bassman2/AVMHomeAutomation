using System;

namespace AVMHomeAutomation
{
    [Flags]
    public enum Functions
    {
        HANFUNDevice = 0x0001,
        Alarm = 0x0010,
        Heater = 0x0040,
        Energy = 0x0080,
        Temperature = 0x0100,
        Switch = 0x0200,
        Repeater = 0x0400,
        Microphone = 0x0800,
        HANFUNUnit = 0x2000
    }
}
