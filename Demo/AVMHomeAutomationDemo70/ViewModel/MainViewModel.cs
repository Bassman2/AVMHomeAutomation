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
            using var client = new HomeAutomation("Demo", "Demo-1234");

            this.DeviceList = client.GetDeviceListInfos();
            this.Devices = this.DeviceList.Devices.Select(d => new DeviceViewModel(d)).ToList();
            this.SelectedDevice = this.Devices.FirstOrDefault();

            this.TemplateList = client.GetTemplateListInfos();
            this.Templates = this.TemplateList.Templates.Select(t => new TemplateViewModel(t, this.Devices)).ToList();
            this.selectedTemplate = this.Templates.FirstOrDefault();
        }

        [ObservableProperty]
        public DeviceList deviceList;

        [ObservableProperty]
        public List<DeviceViewModel> devices;

        [ObservableProperty]
        private DeviceViewModel selectedDevice;

        [ObservableProperty]
        public TemplateList templateList;

        [ObservableProperty]
        public List<TemplateViewModel> templates;

        [ObservableProperty]
        private TemplateViewModel selectedTemplate;

    }
}
