using AVMHomeAutomation;
using AVMHomeAutomationDemo.Mvvm;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class DeviceViewModel : BaseViewModel
    {
        private Device device;

        public DeviceViewModel(Device device)
        {
            this.device = device;
        }

        #region Device

        public string Identifier
        {
            get
            {
                return this.device.Identifier;
            }
        }

        public string Id 
        {
            get
            {
                return this.device.Id;
            }
        }

        public string FirmwareVersion
        {
            get
            {
                return this.device.FirmwareVersion;
            }
        }


        public string Manufacturer
        {
            get
            {
                return this.device.Manufacturer;
            }
        }


        public string ProductName
        {
            get
            {
                return this.device.ProductName;
            }
        }


        public Functions Functions
        {
            get
            {
                return this.device.Functions;
            }
        }

        public bool IsHANFUN { get { return this.Functions.HasFlag(Functions.HANFUNDevice) || this.Functions.HasFlag(Functions.HANFUNUnit); } }

        public bool IsAlarm { get { return this.Functions.HasFlag(Functions.Alarm); } }

        public bool IsHeater { get { return this.Functions.HasFlag(Functions.Heater); } }

        public bool IsEnergy { get { return this.Functions.HasFlag(Functions.Energy); } }

        public bool IsTemperature { get { return this.Functions.HasFlag(Functions.Temperature); } }

        public bool IsSwitch { get { return this.Functions.HasFlag(Functions.Switch); } }

        public bool IsRepeater { get { return this.Functions.HasFlag(Functions.Repeater); } }

        public bool IsMicrophone { get { return this.Functions.HasFlag(Functions.Microphone); } }

        public bool IsPresent
        {
            get
            {
                return this.device.IsPresent;
            }
        }

        public string Name
        {
            get
            {
                return this.device.Name;
            }
        }

        #endregion

        #region Temperature

        public double? TemperatureCelsius
        {
            get
            {
                return this.device.Temperature.Celsius.HasValue ? this.device.Temperature.Celsius.Value / 10.0 : (double?)null;
            }
        }

        public double? TemperatureOffset
        {
            get
            {
                return this.device.Temperature.Offset.HasValue ? this.device.Temperature.Offset.Value / 10.0 : (double?)null;
            }
        }

        #endregion
    }
}
