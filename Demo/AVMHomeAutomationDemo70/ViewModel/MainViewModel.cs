using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVMAppBase.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace AVMHomeAutomationDemo.ViewModel
{
    public partial class MainViewModel : AppViewModel
    {
        public MainViewModel()
        {
            OnRefresh();
        }

        //[RelayCommand]
        protected override void OnRefresh()
        {
            using var client = new HomeAutomation("Demo", "Demo-1234");

            this.DeviceList = client.GetDeviceListInfos();
            XmlDocument devicesXml = client.GetDeviceListInfosXml();
            this.Devices = this.DeviceList.Devices.Select(d => new DeviceViewModel(d, devicesXml)).ToList();
            this.SelectedDevice = this.Devices.FirstOrDefault();

            this.TemplateList = client.GetTemplateListInfos();
            XmlDocument templatesXml = client.GetTemplateListInfosXml();
            this.Templates = this.TemplateList.Templates.Select(t => new TemplateViewModel(t, this.Devices, templatesXml)).ToList();
            this.SelectedTemplate = this.Templates.FirstOrDefault();

            try
            {
                this.TriggerList = client.GetTriggerListInfos();
                XmlDocument triggersXml = client.GetTriggerListInfosXml();
                this.Triggers = this.TriggerList.Triggers.Select(t => new TriggerViewModel(t, triggersXml)).ToList();
                this.SelectedTrigger = this.Triggers.FirstOrDefault();
            }
            catch (AggregateException)
            { }
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

        [ObservableProperty]
        public TriggerList triggerList;

        [ObservableProperty]
        public List<TriggerViewModel> triggers;

        [ObservableProperty]
        private TriggerViewModel selectedTrigger;

    }
}
