using AVMHomeAutomation;
using AVMHomeAutomationDemo.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private HomeAutomation client;

        public MainViewModel()
        {
            this.client = new HomeAutomation("", "ente51");

            this.Devices = this.client.GetDeviceListInfos().Devices.Select(d => new DeviceViewModel(d)).ToList();
            this.SelectedDevice = this.Devices.FirstOrDefault();
        }

        public List<DeviceViewModel> Devices { get; private set; }

        private DeviceViewModel selectedDevice;
        public DeviceViewModel SelectedDevice
        {
            get { return this.selectedDevice; }
            set { this.selectedDevice = value; NotifyPropertyChanged(nameof(SelectedDevice)); }
        }
    }
}
