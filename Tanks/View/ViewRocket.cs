using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks.View
{
    class ViewRocket : ViewDynamicMapObject
    {
        public ViewRocket(Panel map) : base(map)
        {
            picBox.Image = Resources.Rocket;
            map.Controls.Add(picBox);
        }
    }
}
