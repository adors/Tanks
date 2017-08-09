using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.View;

namespace Tanks
{
    public partial class MainGameForm : Form
    {
        FormStatistic f;
        public static int countWall = 0;
        private ViewGame viewGame;
        private ViewStatistic statView;
        Game game;
        public static string[] map = {
            "********************",
            "*..................*",
            "*..................*",
            "*...*************..*",
            "*.........*........*",
            "*.........*........*",
            "*...*..*.....*..*..*",
            "*...*..*.....*..*..*",
            "*...*..*******..*..*",
            "*...*...........*..*",
            "*...*...........*..*",
            "*...*.....*.....*..*",
            "*...*.....*.....*..*",
            "*...****..*..****..*",
            "*......*..*........*",
            "*......*..*........*",
            "*.........*..*.....*",
            "*.........*..*.....*",
            "*......*..*..*.....*",
            "********************"
        };

        public MainGameForm()
        {
            InitializeComponent();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            viewGame.Model.OnKeyPress(e.KeyCode);
        }


        private void OnScoreChanged(object sender, EventArgs e)
        {
            labelScore.Text = viewGame.Model.Score.ToString();
        }

        private void OnGameMOver(object sender, EventArgs e)
        {
            labelScore.Text = viewGame.Model.Score.ToString() + " You lose!";
        }

        private void OnGameMEnd(object sender, EventArgs e)
        {
            labelScore.Text = viewGame.Model.Score.ToString() + " You won!";
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (viewGame != null)
                viewGame.Model.GameOver();
            if (f != null)
            {
                f.Close();
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < map.Length; i++)
                for (int j = 0; j < map[0].Length; j++)
                    countWall += map[i][j] == '*' ? 1 : 0;

            if (p_Map.Controls.Count == 0)
            {
                StartForm sf = new StartForm();
                //sf.Show();
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    if (f != null)
                    {
                        f.Close();
                    }

                    p_Map.BackgroundImage = null;
                    viewGame = new ViewGame(p_Map);
                    game = new Game(timer, sf.Speed, sf.TankNumber, sf.AppleNumber);
                    viewGame.Model = game;
                    viewGame.Model.GameEndE += new EventHandler(OnGameMEnd);
                    viewGame.Model.GameOverE += new EventHandler(OnGameMOver);
                    viewGame.Model.ScoreChangedE += new EventHandler(OnScoreChanged);
                    viewGame.Model.Score = 0;
                    viewGame.Model.SubscribeKeyPress();
                    viewGame.Model.Start();
                }
            }
        }

        private void Statistic_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (p_Map.Controls.Count != 0)
                statView.Unsubscribe();
        }

        private void buttonStatistic_Click(object sender, EventArgs e)
        {
            if ((f == null || f.Visible == false) && p_Map.Controls.Count != 0)
            {
                f = new FormStatistic();
                f.Show();
                this.Focus();
                f.FormClosing += new FormClosingEventHandler(Statistic_FormClosing);
                statView = new ViewStatistic(f.dataGridViewStatistic);
                statView.Model = game;
            }
        }
    }
}
