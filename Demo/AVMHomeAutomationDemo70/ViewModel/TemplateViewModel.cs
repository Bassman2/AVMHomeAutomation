using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class TemplateViewModel : ObservableObject
    {
        private readonly Template template;

        public TemplateViewModel(Template template, List<DeviceViewModel> devices)
        {
            this.template = template;
            this.Devices = template.Devices.Select(i => devices.Single(d => d.Identifier == i.Identifier)).ToList();
        }

        public string Identifier => this.template.Identifier;

        public string Id => this.template.Id;

        public Functions Functions => this.template.Functions;


        public string Name => this.template.Name;

        
        public List<DeviceViewModel> Devices { get; } 
    }
}
