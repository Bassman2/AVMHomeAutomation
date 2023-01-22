using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class TriggerViewModel : ObservableObject
    {
        private readonly Trigger trigger;

        public TriggerViewModel(Trigger trigger)
        {
            this.trigger = trigger;
        }

        public string Identifier => this.trigger.Identifier;

        public bool IsActive => this.trigger.Active == 1;

        public string Name => this.trigger.Name;

        
    }
}
