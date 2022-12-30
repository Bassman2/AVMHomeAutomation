using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class ButtonsViewModel : ObservableObject
    {
        private List<Button> buttons;

        public ButtonsViewModel(List<Button> buttons)
        {
            this.buttons = buttons;
        }
    }
}
