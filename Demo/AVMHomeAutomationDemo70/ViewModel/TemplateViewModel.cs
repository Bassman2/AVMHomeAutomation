using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class TemplateViewModel : ObservableObject
    {
        private readonly Template template;

        public TemplateViewModel(Template template, List<DeviceViewModel> devices, XmlDocument templatesXml)
        {
            this.template = template;
            this.Devices = template.Devices.Select(i => devices.Single(d => d.Identifier == i.Identifier)).ToList();

            StringWriter strWriter = new();
            XmlTextWriter xmlWriter = new(strWriter) { Formatting = Formatting.Indented };
            templatesXml.SelectSingleNode($"/templatelist/template[@id='{template.Id}']")?.WriteTo(xmlWriter);
            this.Text = strWriter.ToString();
        }

        public string Text { get; }

        public string Identifier => this.template.Identifier;

        public string Id => this.template.Id;

        public Functions Functions => this.template.Functions;


        public string Name => this.template.Name;

        
        public List<DeviceViewModel> Devices { get; } 
    }
}
