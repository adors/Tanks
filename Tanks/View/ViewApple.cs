using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MVC;
using Tanks.Properties;

namespace Tanks
{
    class ViewApple : ViewMapObject
    {
        public ViewApple(Panel map) : base(map)
        {
            picBox.Image = Resources.Apple;
            map.Controls.Add(picBox);
        }

    }
}
