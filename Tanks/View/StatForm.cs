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
    public partial class StatForm : Form
    {   
        
        PackmanController packmanController;
        public StatForm(PackmanController pc)
        {
            InitializeComponent();
            packmanController = pc;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            packmanController.Start();
            Close();
        }

        private void StatForm_Shown(object sender, EventArgs e)
        {
            dataGridView.Rows.Add(packmanController.Game.Kolobok.ToString(), packmanController.Game.Kolobok.X, packmanController.Game.Kolobok.Y);
            foreach (var item in packmanController.Game.Tanks)
            {
                dataGridView.Rows.Add(item.ToString(), item.X, item.Y);
            }
            foreach (var item in packmanController.Game.Apples)
            {
                dataGridView.Rows.Add(item.ToString(), item.X, item.Y);
            }
            foreach (var item in packmanController.Game.Bullets)
            {
                dataGridView.Rows.Add(item.ToString(), item.X, item.Y);
            }
            foreach (var item in packmanController.Game.Monoliths)
            {
                dataGridView.Rows.Add(item.ToString(), item.X, item.Y);
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
