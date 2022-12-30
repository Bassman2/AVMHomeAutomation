using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class AlertViewModel : ObservableObject
    {
        private Alert alert;

        public AlertViewModel(Alert alert)
        {
            this.alert = alert;
        }
    }
}
