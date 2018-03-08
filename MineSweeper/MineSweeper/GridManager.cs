using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MineSweeper
{
    class GridManager 
    {
        bool gameStarted = false;
        int ButtonWidth = 25;
        int ButtonHeight = 25;
        int DistanceY = 5;
        int DistanceX = 0;
        int start_x = 0;
        int start_y = 51;
        int mina = 0, id = 0;

        public GridManager(int xg, int yg, Form form, int mines)
        {
            for (int x = 0; x < xg; x++)
            {                                   //Estos 2 fors controlan el tamaño del grid
                for (int y = 0; y < yg; y++)
                {
                    Cell tmpButton = new Cell();
                    id++;
                    //Top = start_y + (y * ButtonHeight + DistanceY),
                    //Left = start_x + (x * ButtonWidth + DistanceX),
                    tmpButton.AutoSize = true;
                    tmpButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    tmpButton.Location = new Point(start_x + (x * ButtonWidth + DistanceX), start_y + (y * ButtonHeight + DistanceY));
                    tmpButton.MouseUp += new MouseEventHandler(button1_MouseUp);
                    //tmpButton.Click += new EventHandler(button_Left_Click);
                    tmpButton.Text = "?";
                    tmpButton.id = id;
                    
                    form.Controls.Add(tmpButton);
                    
                }
            }

         
        }


        public void mineGenerator(Form form, int buttons)
        {
            foreach (Control x in form.Controls)
            {
                if (x is Cell)
                {
                    for (int i = 0; i < buttons; i++)
                    {
                        ((Cell)x).isMine= true;
                    }

                }
            }
        }

        private int adjMines(int x, int y, int gridX, int gridY)
        {
            bool[,] mines = new bool[gridX, gridY];
            bool hasMine = mines[x, y];
            int mineCount = 0;
            for (int nx = x - 1; nx <= x + 1; nx++)
            {
                if (nx < 0 || nx >= gridX)
                    continue;  // Don't go out of bounds

                for (int ny = y - 1; ny <= y + 1; ny++)
                {
                    if (ny < 0 || ny >= gridY)
                        continue;  // Don't go out of bounds

                    if (nx == x && ny == y)
                        continue;  // Don't count the cell itself

                    if (mines[nx, ny])
                        mineCount += 1;
                }
            }
            return mineCount;
        }


        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            var btn = ((Cell)sender);
            switch (e.Button)
            {
                case MouseButtons.Left:
                    MessageBox.Show("ID: " + btn.id);
                    if(!gameStarted)
                    {
                        //Revelar botones normal
                        if(btn.isMine)
                        {
                            btn.BackgroundImage = Image.FromFile(@"Mine.png");
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                            btn.Text = "  ";
                            //btn.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        //GenerarMinas
                    }
                    break;

                case MouseButtons.Right:
                    if (!btn.isFlagged)
                    {
                        btn.BackgroundImage = Image.FromFile(@"flag.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Text = " ";
                        btn.isFlagged = true;
                    }
                    else
                    {
                        btn.BackgroundImage = null;
                        btn.Text = "?";
                        btn.isFlagged = false;
                    }
                    break;

            }
        }

        //public void FirstMove(int x, int y, Random rand)
        //{
        //    //For any board, take the user's first revealed panel + any neighbors of that panel to X depth, and mark them as unavailable for mine placement.
        //    var depth = 0.125 * Width; //12.5% (1/8th) of the board width becomes the depth of unavailable panels
        //    var neighbors = GetNeighbors(x, y, (int)depth); //Get all neighbors to specified depth
        //    neighbors.Add(GetPanel(x, y)); //Don't place a mine in the user's first move!

        //    //Select random panels from set of panels which are not excluded by the first-move rule
        //    var mineList = Panels.Except(neighbors).OrderBy(user => rand.Next());
        //    var mineSlots = mineList.Take(MineCount).ToList().Select(z => new { z.X, z.Y });

        //    //Place the mines
        //    foreach (var mineCoord in mineSlots)
        //    {
        //        Panels.Single(panel => panel.X == mineCoord.X && panel.Y == mineCoord.Y).IsMine = true;
        //    }

        //    //For every panel which is not a mine, determine and save the adjacent mines.
        //    foreach (var openPanel in Panels.Where(panel => !panel.IsMine))
        //    {
        //        var nearbyPanels = GetNeighbors(openPanel.X, openPanel.Y);
        //        openPanel.AdjacentMines = nearbyPanels.Count(z => z.IsMine);
        //    }
        //}



        //      var generateMines = function(grid, grid_x, grid_y, mine_count) {
        //  var mine_value = -(mine_count * 2), mine_x, mine_y;
        //      var m, n;

        //  for (var k=0; k<mine_count; k++) {
        //    while (true) {
        //      mine_x = Math.floor(Math.random() * grid_x);
        //      mine_y = Math.floor(Math.random() * grid_y);

        //      // TODO : add more randomness and strategies here

        //      if (0 <= grid[mine_x][mine_y]) {
        //        break;
        //      }
        //    }
        //    for (n=-1; n<2; n++) {
        //      for (m=-1; m<2; m++) {
        //        if (0 == n && 0 == m) {
        //          grid[mine_x][mine_y] = mine_value;
        //        } else if (_between(mine_x+n,0,grid_x-1) && _between(mine_y+m,0, grid_y-1)) {
        //          grid[mine_x + n][mine_y + m]++;
        //        }
        //      }
        //    }
        //  }

        //  return grid;
        //};


    }
}
