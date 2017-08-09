using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class StartForm : Form
    {
        private int tankNumber;
        private int appleNumber;
        private int speed;

        public int TankNumber
        {
            get { return tankNumber; }
        }

        public int AppleNumber
        {
            get { return appleNumber; }
        }

        public int Speed
        {
            get { return speed; }
        }

        public StartForm()
        {
            InitializeComponent();
        }

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            tankNumber = (int)numericUpDownTanks.Value;
            appleNumber = (int)numericUpDownApples.Value;
            speed = (int)numericUpDownSpeed.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
