using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class LevelControlViewModel : ObservableObject
    {
        private LevelControl levelControl;

        public LevelControlViewModel(LevelControl levelControl)
        {
            this.levelControl = levelControl;
        }
    }
}
