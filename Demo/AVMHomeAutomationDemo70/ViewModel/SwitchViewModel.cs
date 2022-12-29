using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class SwitchViewModel : ObservableObject
    {
        private Switch sw;

        public SwitchViewModel(Switch sw)
        {
            this.sw = sw;
        }

        public string State => this.sw.State;
        public string Mode => this.sw.Mode;
        public string Lock => this.sw.Lock;
        public string DeviceLock => this.sw.DeviceLock;
    }
}
