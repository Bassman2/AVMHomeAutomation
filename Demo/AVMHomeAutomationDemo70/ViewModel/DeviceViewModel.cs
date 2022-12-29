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

        #region Device Attributes

        public string Identifier => this.device.Identifier;            

        public string Id => this.device.Id;
           
        public string FirmwareVersion => this.device.FirmwareVersion;

        public string Manufacturer => this.device.Manufacturer;

        public string ProductName => this.device.ProductName;

        public Functions Functions => this.device.Functions;

        #endregion

        #region Single Elements

        public bool IsPresent => this.device.IsPresent;

        public bool IsTXBusy => this.device.IsTXBusy;

        public string Name => this.device.Name;

        public bool IsBatteryLow => this.device.IsBatteryLow;

        public int? Battery => this.device.Battery;

        #endregion

        #region Visible switches

        public bool ShowSwitch => this.device.Switch != null;
        public bool ShowPowerMeter => this.device.PowerMeter != null;
        public bool ShowTemperature => this.device.Temperature != null;
        public bool ShowAlert => this.device.Alert != null;
        public bool ShowButtons => this.device.Buttons != null && this.device.Buttons.Count > 0;
        public bool ShowETSIUnitInfo => this.device.EtsiUnitInfo != null;
        public bool ShowSimpleOnOff => this.device.SimpleOnOff != null;
        public bool ShowLevelControl => this.device.LevelControl != null;
        public bool ShowColorControl => this.device.ColorControl != null;
        public bool ShowHkr => this.device.Hkr != null;

        #endregion

        #region Class Elements

        public SwitchViewModel Switch => this.device.Switch != null ? new SwitchViewModel(this.device.Switch) : null;
        public PowerMeterViewModel PowerMeter => this.device.PowerMeter != null ? new PowerMeterViewModel(this.device.PowerMeter) : null; 
        public TemperatureViewModel Temperature => this.device.Temperature != null ? new TemperatureViewModel(this.device.Temperature) : null;


        //public bool IsHANFUN => this.Functions.HasFlag(Functions.HANFUNDevice) || this.Functions.HasFlag(Functions.HANFUNUnit); 

        //public bool IsAlarm => this.Functions.HasFlag(Functions.Alarm); 

        //public bool IsHeater => this.Functions.HasFlag(Functions.Heater); 

        //public bool IsEnergy => this.Functions.HasFlag(Functions.Energy); 

        //public bool IsTemperature => this.Functions.HasFlag(Functions.Temperature);

        //public bool IsSwitch =>  this.Functions.HasFlag(Functions.Switch);

        //public bool IsRepeater => this.Functions.HasFlag(Functions.AVMDECTRepeater); 

        //public bool IsMicrophone => this.Functions.HasFlag(Functions.Microphone); 


        #endregion

        #region Temperature

        //public double? TemperatureCelsius => this.device.Temperature.Celsius.GetValueOrDefault(); //.HasValue ? this.device.Temperature.Celsius.Value / 10.0 : (double?)null ?? null;

        //public double? TemperatureOffset => this.device.Temperature.Offset.GetValueOrDefault(); // ? this.device.Temperature.Offset.Value / 10.0 : (double?)null;

        #endregion
    }
}
