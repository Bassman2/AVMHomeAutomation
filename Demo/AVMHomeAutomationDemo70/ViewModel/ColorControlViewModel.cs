using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class ColorControlViewModel : ObservableObject
    {
        private ColorControl colorControl;

        public ColorControlViewModel(ColorControl colorControl)
        {
            this.colorControl = colorControl;
        }
    }
}
