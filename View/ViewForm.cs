using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class ViewForm : Form
    {
        private PackmanController packmanController;
        ViewMap view;
        public ViewForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            packmanController = new PackmanController(4 - speedBar.Value, tankBar.Value, appleBar.Value);
            view = new ViewMap(picBox, packmanController.Game);
            packmanController.onTimer += view.UpdateMap;
            packmanController.Game.onOver += Over;
            packmanController.Game.onScore += ShowScore;
            btnStart.Enabled = false;
            btnStart.Visible = false;
            speedBar.Enabled = false;
            appleBar.Enabled = false;
            tankBar.Enabled = false;
        }

        public void ShowScore()
        {
            label1.Text = "Очки: " + packmanController.Game.Score;
        }

        private void Over()
        {
            packmanController.Stop();
            MessageBox.Show("GAME OVER!");
            btnStart.Enabled = true;
            btnStart.Visible = true;
            speedBar.Enabled = true;
            appleBar.Enabled = true;
            tankBar.Enabled = true;
        }

        private void ViewForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    packmanController.TravelPackman = 1;
                    break;
                case Keys.Down:
                    packmanController.TravelPackman = 2;
                    break;
                case Keys.Left:
                    packmanController.TravelPackman = 3;
                    break;
                case Keys.Right:
                    packmanController.TravelPackman = 4;
                    break;
                case Keys.Space:
                    packmanController.Shot();
                    break;
                case Keys.ShiftKey:
                    GetForm();
                    break;
            }
        }

        private void GetForm()
        {
            packmanController.Stop();
            StatForm sf = new StatForm(packmanController);
            sf.Show();
        }

        private void speedBar_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Скорость игры: " + speedBar.Value;
        }

        private void tankBar_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Число танков: " + tankBar.Value;
        }

        private void appleBar_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Число яблок: " + appleBar.Value;
        }

        private void ViewForm_Shown(object sender, EventArgs e)
        { 
            label2.Text = "Скорость игры: " + speedBar.Value;
            label3.Text = "Число танков: " + tankBar.Value;
            label4.Text = "Число яблок: " + appleBar.Value;
        }
    }
}
