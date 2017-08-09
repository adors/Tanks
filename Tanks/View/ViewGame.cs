using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using Tanks.MVC;
using MVC;
using System.Windows.Forms;
using Tanks.View;
using System.Linq;

namespace Tanks
{
    class ViewGame : View<Game>
    {
        List<ViewTank> viewTanks = new List<ViewTank>();
        ViewKolobok viewKolobok;
        List<ViewWall> viewWalls = new List<ViewWall>();
        List<ViewApple> viewApples = new List<ViewApple>();
        List<ViewRocket> viewRockets = new List<ViewRocket>();
        Panel panelMap;

        public ViewGame(Panel panelMap)
        {
            this.panelMap = panelMap;
        }

        private void OnRocketCreated(object sender, EventArgs e)
        {
            ViewRocket viewRocketTemp = new ViewRocket(panelMap);

            viewRocketTemp.Model = Model.Rockets.Last();
            viewRocketTemp.Model.MapSize = new Point(panelMap.Width, panelMap.Height);
            viewRocketTemp.Subscribe();
            viewRockets.Add(viewRocketTemp);

        }

        protected override void Update()
        {
            Refresh();
            Model.RocketCreatedE += new EventHandler(OnRocketCreated);
        }

        private void Refresh()
        {
            int tankCount = Model.Tanks.Count;
            int appleCount = Model.Apples.Count;
            int wallCount = Model.Walls.Count;

            viewTanks = new List<ViewTank>();
            viewWalls = new List<ViewWall>();
            viewApples = new List<ViewApple>();


            viewKolobok = new ViewKolobok(panelMap);
            viewKolobok.Model = Model.Kolobok;
            viewKolobok.Model.MapSize = new Point(panelMap.Width, panelMap.Height);
            viewKolobok.Subscribe();

            for (int i = 0; i < tankCount; i++)
            {
                ViewTank viewTanktemp = new ViewTank(panelMap);
                viewTanktemp.Model = Model.Tanks[i];
                viewTanktemp.Model.MapSize = new Point(panelMap.Width, panelMap.Height);
                viewTanktemp.Subscribe();
                viewTanks.Add(viewTanktemp);
            }
            for (int i = 0; i < wallCount; i++)
            {
                ViewWall viewWalltemp = new ViewWall(panelMap);
                viewWalltemp.Model = Model.Walls[i];
                viewWalltemp.Model.MapSize = new Point(panelMap.Width, panelMap.Height);
                viewWalltemp.Subscribe();
                viewWalls.Add(viewWalltemp);
            }
            for (int i = 0; i < appleCount; i++)
            {
                ViewApple viewAppletemp = new ViewApple(panelMap);
                viewAppletemp.Model = Model.Apples[i];
                viewAppletemp.Model.MapSize = new Point(panelMap.Width, panelMap.Height);
                viewAppletemp.Subscribe();
                viewApples.Add(viewAppletemp);
            }
        }
    }
}
