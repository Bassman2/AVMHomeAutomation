using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace AVMHomeAutomationDemo.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private HomeAutomation client;

        public MainViewModel()
        {
            this.client = new HomeAutomation("", "");

            this.Devices = this.client.GetDeviceListInfos().Devices.Select(d => new DeviceViewModel(d)).ToList();
            this.SelectedDevice = this.Devices.FirstOrDefault();
        }

        public List<DeviceViewModel> Devices { get; }

        [ObservableProperty]
        private DeviceViewModel selectedDevice;
        
    }
}
