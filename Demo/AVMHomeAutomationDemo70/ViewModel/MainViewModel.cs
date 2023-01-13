using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;

namespace AVMHomeAutomationDemo.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            OnRefresh();
        }

        [RelayCommand]
        public void OnRefresh()
        {
            using HomeAutomation client = new HomeAutomation("Demo", "Demo-1234");

            this.Devices = client.GetDeviceListInfos().Devices.Select(d => new DeviceViewModel(d)).ToList();
            this.SelectedDevice = this.Devices.FirstOrDefault();

            this.Templates = client.GetTemplateListInfos().Templates.Select(t => new TemplateViewModel(t)).ToList();
            this.selectedTemplate = this.Templates.FirstOrDefault();
        }

        [ObservableProperty]
        public List<DeviceViewModel> devices;

        [ObservableProperty]
        private DeviceViewModel selectedDevice;

        [ObservableProperty]
        public List<TemplateViewModel> templates;

        [ObservableProperty]
        private TemplateViewModel selectedTemplate;

    }
}
