using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class DeviceViewModel : ObservableObject
    {
        private Device device;

        public DeviceViewModel(Device device)
        {
            this.device = device;
        }

        #region Device

        public string Identifier => this.device.Identifier;            

        public string Id => this.device.Id;
           
        public string FirmwareVersion => this.device.FirmwareVersion;

        public string Manufacturer => this.device.Manufacturer;

        public string ProductName => this.device.ProductName;

        public Functions Functions => this.device.Functions;

        public bool IsHANFUN => this.Functions.HasFlag(Functions.HANFUNDevice) || this.Functions.HasFlag(Functions.HANFUNUnit); 

        public bool IsAlarm => this.Functions.HasFlag(Functions.Alarm); 

        public bool IsHeater => this.Functions.HasFlag(Functions.Heater); 

        public bool IsEnergy => this.Functions.HasFlag(Functions.Energy); 

        public bool IsTemperature => this.Functions.HasFlag(Functions.Temperature);

        public bool IsSwitch =>  this.Functions.HasFlag(Functions.Switch);

        public bool IsRepeater => this.Functions.HasFlag(Functions.AVMDECTRepeater); 

        public bool IsMicrophone => this.Functions.HasFlag(Functions.Microphone); 

        public bool IsPresent => this.device.IsPresent;
            

        public string Name => this.device.Name;

        #endregion

        #region Temperature

        //public double? TemperatureCelsius => this.device.Temperature.Celsius.GetValueOrDefault(); //.HasValue ? this.device.Temperature.Celsius.Value / 10.0 : (double?)null ?? null;

        //public double? TemperatureOffset => this.device.Temperature.Offset.GetValueOrDefault(); // ? this.device.Temperature.Offset.Value / 10.0 : (double?)null;

        #endregion
    }
}
