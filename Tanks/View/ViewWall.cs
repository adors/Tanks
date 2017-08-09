using System;
using System.Collections.Generic;
using System.Text;
using MVC;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Tanks.Properties;
namespace Tanks
{
    class ViewWall : ViewMapObject
    {
        public ViewWall(Panel map) : base(map)
        {
            picBox.Image = Resources.Wall; ;
        }


    }
}
