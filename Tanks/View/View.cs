using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Tanks;
namespace MVC
{
    public abstract class View<P> where P : new()
    {
        private P model = new P();

        public P Model
        {
            get { return model; }
            set
            {
                model = value;
                Update();
            }
        }
        protected abstract void Update();
    }
}
