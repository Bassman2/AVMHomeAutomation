using AVMHomeAutomation;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMHomeAutomationDemo.ViewModel
{
    public class PowerMeterViewModel : ObservableObject
    {
        private PowerMeter powerMeter;

        public PowerMeterViewModel(PowerMeter powerMeter)
        {
            this.powerMeter = powerMeter;
        }

        public double Voltage => this.powerMeter.Voltage;
        public double Power => this.powerMeter.Power;
        public double Energy => this.powerMeter.Energy;

    }
}
