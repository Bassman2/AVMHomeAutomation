using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class SimpleOnOffViewModel : ObservableObject
    {
        private SimpleOnOff simpleOnOff;

        public SimpleOnOffViewModel(SimpleOnOff simpleOnOff)
        {
            this.simpleOnOff = simpleOnOff;
        }
    }
}
