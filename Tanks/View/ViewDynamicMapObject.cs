using System;
using System.Collections.Generic;
using System.Text;
using MVC;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using Tanks.Properties;
namespace Tanks
{
    class ViewDynamicMapObject : View<DynamicMapObject>
    {
        protected PictureBox picBox = new PictureBox();
        Panel m;

        public ViewDynamicMapObject(Panel map)
        {
            m = map;
            m.Controls.Add(picBox);
            picBox.Height = Model.Height;
            picBox.Width = Model.Width;
        }

        public void Subscribe()
        {
            this.Model.PositionChanged += new EventHandler(OnPositionChanged);
            this.Model.Died += new EventHandler(OnDied);
            OnPositionChanged(this, new EventArgs());

        }

        private void OnDied(object sender, EventArgs e)
        {
            m.Controls.Remove(picBox);
        }

        private void Unsubscribe()
        {
            this.Model.PositionChanged -= new EventHandler(OnPositionChanged);
        }

        private void OnPositionChanged(object sender, EventArgs e)
        {
            Show();
        }
        
        private void Show()
        {
            SetImage(Model.Position);
        }
        delegate void SetImageCallback(Point p);

        private void SetImage(Point p)
        {
            if (this.picBox.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(SetImage);
                picBox.Invoke(d, new object[] { Model.Position });
            }
            else
            {
                ChangePicture();
                this.picBox.Location = p;
            }
        }

        protected virtual void ChangePicture() { }
        
        protected override void Update()
        {
            Show();
        }
    }
}
