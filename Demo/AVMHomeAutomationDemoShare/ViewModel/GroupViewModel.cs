using AVMHomeAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AVMHomeAutomationDemo.ViewModel
{
    public partial class GroupViewModel : DeviceViewModel
    {
        private readonly Group group;

        public GroupViewModel(Device device, XmlDocument devicesXml) : base(device, devicesXml)
        {
            this.group = device as Group;
        }
    }
}
