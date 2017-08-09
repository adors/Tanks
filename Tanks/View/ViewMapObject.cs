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
    class ViewMapObject : View<MapObject>
    {
        protected PictureBox picBox = new PictureBox();
        Panel m;

        public ViewMapObject(Panel map)
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
            this.Model.Hited += new EventHandler(OnHited);
            OnPositionChanged(this, new EventArgs());

        }

        private void OnHited(object sender, EventArgs e)
        {
            ChangePicture();
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
        

        private void SetImage(Point p)
        {
            ChangePicture();
            this.picBox.Location = p;
        }

        protected virtual void ChangePicture() { }

        protected override void Update()
        {
            Show();
        }
    }
}
