using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class HkrViewModel : ObservableObject
    {
        private Hkr hkr;

        public HkrViewModel(Hkr hkr)
        {
            this.hkr = hkr;
        }
    }
}
