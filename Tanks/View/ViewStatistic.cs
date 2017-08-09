using MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks.View
{
    class ViewStatistic : View<Game>
    {
        DataGridView dgv;
        private int tankCount;
        private int appleCount;

        public ViewStatistic()
        {
        }

        public ViewStatistic(DataGridView d)
        {
            dgv = d;
        }

        protected override void Update()
        {
            tankCount = Model.CountTank;
            appleCount = Model.CountApple;

            Model.Kolobok.PositionChanged += new EventHandler(OnPositionChanged);
            Model.Kolobok.Died += new EventHandler(OnDied);

            for (int i = 0; i < Model.Tanks.Count; i++)
            {
                Model.Tanks[i].PositionChanged += new EventHandler(OnPositionChanged);
                Model.Tanks[i].Died += new EventHandler(OnDied);

            }
            for (int i = 0; i < Model.Apples.Count; i++)
            {
                Model.Apples[i].PositionChanged += new EventHandler(OnPositionChanged);
                Model.Apples[i].Died += new EventHandler(OnDied);
            }

            dgv.Rows.Add();
            dgv.Rows[0].Cells[0].Value = "Kolobok";
            for (int i = 0; i < tankCount; i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i + 1].Cells[0].Value = "Tank " + (i + 1).ToString();
                dgv.Rows[1 + i].Cells[1].Value = "Dead";
                dgv.Rows[1 + i].Cells[2].Value = "Dead";
            }
            for (int i = 0; i < appleCount; i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i + 1 + tankCount].Cells[0].Value = "Apple " + (i + 1).ToString();
                dgv.Rows[i + 1 + tankCount].Cells[1].Value = Model.Apples[i].Position.X;
                dgv.Rows[i + 1 + tankCount].Cells[2].Value = Model.Apples[i].Position.Y;
            }
        }

        public void OnPositionChanged(object sender, EventArgs e)
        {
            if (sender is Kolobok)
            {
                dgv.Rows[0].Cells[1].Value = ((Kolobok)sender).Position.X;
                dgv.Rows[0].Cells[2].Value = ((Kolobok)sender).Position.Y;
            }

            if (sender is Tank)
            {
                dgv.Rows[1 + ((Tank)sender).ID].Cells[1].Value = ((Tank)sender).Position.X;
                dgv.Rows[1 + ((Tank)sender).ID].Cells[2].Value = ((Tank)sender).Position.Y;
            }

            if (sender is Apple)
            {
                dgv.Rows[1 + tankCount + ((Apple)sender).ID].Cells[1].Value = ((Apple)sender).Position.X;
                dgv.Rows[1 + tankCount + ((Apple)sender).ID].Cells[2].Value = ((Apple)sender).Position.Y;
            }
        }

        internal void Unsubscribe()
        {
            Model.Kolobok.PositionChanged -= new EventHandler(OnPositionChanged);
            Model.Kolobok.Died -= new EventHandler(OnDied);

            for (int i = 0; i < Model.Tanks.Count; i++)
            {
                Model.Tanks[i].PositionChanged -= new EventHandler(OnPositionChanged);
                Model.Tanks[i].Died -= new EventHandler(OnDied);

            }
            for (int i = 0; i < Model.Apples.Count; i++)
            {
                Model.Apples[i].PositionChanged -= new EventHandler(OnPositionChanged);
                Model.Apples[i].Died -= new EventHandler(OnDied);
            }
        }

        public void OnDied(object sender, EventArgs e)
        {
            if (sender is Kolobok)
            {
                dgv.Rows[0].Cells[1].Value = "Dead";
                dgv.Rows[0].Cells[2].Value = "Dead";
            }

            if (sender is Tank)
            {
                dgv.Rows[1 + ((Tank)sender).ID].Cells[1].Value = "Dead";
                dgv.Rows[1 + ((Tank)sender).ID].Cells[2].Value = "Dead";
            }

            if (sender is Apple)
            {
                dgv.Rows[1 + tankCount + ((Apple)sender).ID].Cells[1].Value = "Dead";
                dgv.Rows[1 + tankCount + ((Apple)sender).ID].Cells[2].Value = "Dead";
            }
        }
    }
}
