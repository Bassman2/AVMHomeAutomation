using AVMHomeAutomation;
using AVMHomeAutomationDemo.Mvvm;
using System.Collections.Generic;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private HomeAutomation client;

        public MainViewModel()
        {
            this.client = new HomeAutomation("", "");

            this.Devices = this.client.GetDeviceListInfos().Devices;
        }

        public List<Device> Devices { get; private set; }

        private Device selectedDevice;
        public Device SelectedDevice
        {
            get { return this.selectedDevice; }
            set { this.selectedDevice = value; NotifyPropertyChanged(nameof(SelectedDevice)); }
        }
    }
}
