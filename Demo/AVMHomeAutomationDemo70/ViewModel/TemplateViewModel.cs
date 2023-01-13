using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class TemplateViewModel : ObservableObject
    {
        private readonly Template template;

        public TemplateViewModel(Template template)
        {
            this.template = template;
        }

        public string Identifier => this.template.Identifier;

        public string Id => this.template.Id;

        public Functions Functions => this.template.Functions;


        public string Name => this.template.Name;
    }
}
