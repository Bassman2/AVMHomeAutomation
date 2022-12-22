using AVMHomeAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVMHomeAutomationTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] list = null;

            using (HomeAutomation client = new HomeAutomation("", ""))
            {
                list = client.GetSwitchListAsync().Result;

                var x = client.GetDeviceListInfosAsync().Result;
            }
        }
    }
}
