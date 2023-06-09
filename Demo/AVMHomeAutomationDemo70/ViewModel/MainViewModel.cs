using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;
using MVVMAppBase.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace AVMHomeAutomationDemo.ViewModel
{
    public partial class MainViewModel : AppViewModel
    {
        public MainViewModel()
        {
            //OnRefresh();
        }

        public override async Task OnStartup()
        {
            using var client = new HomeAutomation("Demo", "Demo-1234");
            await Task.WhenAll(
                Task.Run(async () => 
                {
                    XmlDocument xmlDocument = await client.GetDeviceListInfosXmlAsync();
                    DeviceList deviceList = await client.GetDeviceListInfosAsync();
                    this.Version = deviceList.Version;
                    this.FirmwareVersion = deviceList.FirmwareVersion;
                    this.Devices = deviceList.Devices.Select(d => new DeviceViewModel(d, xmlDocument)).ToList();
                }),
                //client.GetDeviceListInfosAsync().ContinueWith(items => 
                //{
                //    this.Version = items.Result.Version;
                //    this.FirmwareVersion = items.Result.FirmwareVersion;
                //    this.Devices = items.Result?.Devices.Select(d => new DeviceViewModel(d, null)).ToList();
                //    //this.DeviceList = items.Result; this.Devices = items.Result
                //}),
                client.GetTemplateListInfosAsync().ContinueWith(items => this.TemplateList = items.Result)
                );
            //this.DeviceList = await client.GetDeviceListInfosAsync();
            //XmlDocument devicesXml = client.GetDeviceListInfosXml();
            //this.Devices = this.DeviceList.Devices.Select(d => new DeviceViewModel(d, devicesXml)).ToList();
            //this.SelectedDevice = this.Devices.FirstOrDefault();

            //this.TemplateList = client.GetTemplateListInfos();
            //XmlDocument templatesXml = client.GetTemplateListInfosXml();
            //this.Templates = this.TemplateList.Templates.Select(t => new TemplateViewModel(t, this.Devices, templatesXml)).ToList();
            //this.SelectedTemplate = this.Templates.FirstOrDefault();

            //try
            //{
            //    this.TriggerList = client.GetTriggerListInfos();
            //    XmlDocument triggersXml = client.GetTriggerListInfosXml();
            //    this.Triggers = this.TriggerList.Triggers.Select(t => new TriggerViewModel(t, triggersXml)).ToList();
            //    this.SelectedTrigger = this.Triggers.FirstOrDefault();
            //}
            //catch (AggregateException)
            //{ }
        }

        //[RelayCommand]
        protected override void OnRefresh()
        {
            //Task.Run(async () =>
            //{
            //    using var client = new HomeAutomation("Demo", "Demo-1234");
            //    //this.DeviceList = await client.GetDeviceListInfosAsync();
            //    //XmlDocument devicesXml = client.GetDeviceListInfosXml();
            //    //this.Devices = this.DeviceList.Devices.Select(d => new DeviceViewModel(d, devicesXml)).ToList();
            //    //this.SelectedDevice = this.Devices.FirstOrDefault();

            //    //this.TemplateList = client.GetTemplateListInfos();
            //    //XmlDocument templatesXml = client.GetTemplateListInfosXml();
            //    //this.Templates = this.TemplateList.Templates.Select(t => new TemplateViewModel(t, this.Devices, templatesXml)).ToList();
            //    //this.SelectedTemplate = this.Templates.FirstOrDefault();

            //    //try
            //    //{
            //    //    this.TriggerList = client.GetTriggerListInfos();
            //    //    XmlDocument triggersXml = client.GetTriggerListInfosXml();
            //    //    this.Triggers = this.TriggerList.Triggers.Select(t => new TriggerViewModel(t, triggersXml)).ToList();
            //    //    this.SelectedTrigger = this.Triggers.FirstOrDefault();
            //    //}
            //    //catch (AggregateException)
            //    //{ }

            //});
            

            //this.DeviceList = await client.GetDeviceListInfosAsync();
            //XmlDocument devicesXml = client.GetDeviceListInfosXml();
            //this.Devices = this.DeviceList.Devices.Select(d => new DeviceViewModel(d, devicesXml)).ToList();
            //this.SelectedDevice = this.Devices.FirstOrDefault();

            //this.TemplateList = client.GetTemplateListInfos();
            //XmlDocument templatesXml = client.GetTemplateListInfosXml();
            //this.Templates = this.TemplateList.Templates.Select(t => new TemplateViewModel(t, this.Devices, templatesXml)).ToList();
            //this.SelectedTemplate = this.Templates.FirstOrDefault();

            //try
            //{
            //    this.TriggerList = client.GetTriggerListInfos();
            //    XmlDocument triggersXml = client.GetTriggerListInfosXml();
            //    this.Triggers = this.TriggerList.Triggers.Select(t => new TriggerViewModel(t, triggersXml)).ToList();
            //    this.SelectedTrigger = this.Triggers.FirstOrDefault();
            //}
            //catch (AggregateException)
            //{ }
        }

        [ObservableProperty]
        public string version;

        [ObservableProperty]
        public string firmwareVersion;

        //[ObservableProperty]
        //public DeviceList deviceList;

        [ObservableProperty]
        public List<DeviceViewModel> devices;

        //[ObservableProperty]
        //private DeviceViewModel selectedDevice;

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
