﻿using System;
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
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Explosion.wav");
        Form tableroporquemevalemadreelingles;
        Button Face;
        bool gameStarted, gameLost, gameWon;
        int ButtonWidth = 25;
        int ButtonHeight = 25;
        int DistanceY = 5;
        int DistanceX = 0;
        int start_x = 0;
        int start_y = 74;
        int mina = 0, id = 0;
        int cellCount;
        int mineCount;
        int mineTotal;
        int flagCount;
        int revealedCount;
        int columnCount;
        int fileCount;
        int firstCell;

        public GridManager(int xg, int yg, Form form, int mines, Button face)
        {
            tableroporquemevalemadreelingles = form;
            Face = face;
            //Face.BackgroundImage = Image.FromFile(@"Happy.png");
            //Face.BackgroundImageLayout = ImageLayout.Stretch;
            resetBoard(mines);
            for (int y = 0; y < yg; y++)
            {                                   //Estos 2 fors controlan el tamaño del grid
                for (int x = 0; x < xg; x++)
                {
                    Cell tmpButton = new Cell();
                    id++;
                    tmpButton.AutoSize = true;
                    tmpButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    tmpButton.Location = new Point(start_x + (x * ButtonWidth + DistanceX), start_y + (y * ButtonHeight + DistanceY));
                    tmpButton.MouseUp += new MouseEventHandler(button1_MouseUp);
                    tmpButton.MouseDown += new MouseEventHandler(button1_MouseDown);
                    //tmpButton.Click += new EventHandler(button_Left_Click);
                    tmpButton.Text = "?";
                    tmpButton.id = id;
                    
                    form.Controls.Add(tmpButton);
                    
                }
            }
            Cell defaultsize = new Cell();
           
            fileCount = yg;
            columnCount = xg;
            cellCount = xg * yg;
        }


        public void mineGenerator(int buttons)
        {
            Random rand = new Random();

            List<int> ListaMinas = new List<int>();
            ListaMinas =  RandomGen();

            int esminaalv;
            foreach (Control x in tableroporquemevalemadreelingles.Controls)
            {
                esminaalv = rand.Next(1, 30) % 2;
                if (x is Cell)
                {
                    for (int i = 0; i < ListaMinas.Count(); i++)
                    {
                        //if (mineCount < mineTotal)
                        //{
                        if (ListaMinas[i] == ((Cell)x).id && ListaMinas[i] != firstCell)
                        {
                            if (ListaMinas[i] != firstCell)
                                i++;

                            ((Cell)x).isMine = true;
                            mineCount++;
                            
                        }
                    //}
                    }
                }
            }
        }


        List<int> RandomGen()
        {
            List<int> posiblesCeldas = new List<int>();

            for (int i = 0; i < cellCount; i++)
            {
                posiblesCeldas.Add(i);
            }

            List<int> celdasMinadas = new List<int>();

            Random rnd = new Random();

            for (int i = 0; i < mineTotal; i++)
            {
                int indice = rnd.Next(posiblesCeldas.Count);

                int value = posiblesCeldas[indice];

                posiblesCeldas.Remove(value);
                celdasMinadas.Add(value);
            }

            return celdasMinadas;
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
            firstCell = btn.id;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    //MessageBox.Show("ID: " + btn.id);
                    if (gameStarted)
                    {
                        //Revelar botones normal
                        revealCells(btn);
                        if (gameLost)
                        {
                            foreach (Control x in tableroporquemevalemadreelingles.Controls)
                            {
                                if (x is Cell)
                                {
                                    //for (int i = 0; i < buttons; i++)
                                    //{
                                    revealCells((Cell)x);
                                    //}
                                }
                            }

                            Face.BackgroundImage = Image.FromFile(@"Ded.png");
                            Face.BackgroundImageLayout = ImageLayout.Stretch;
                            ((Form1)tableroporquemevalemadreelingles).StopTime();
                            ((Form1)tableroporquemevalemadreelingles).timeLabel.Text = "00:00";

                            MessageBox.Show("GAME OVER");
                            clearBoard();
                        }
                        Face.BackgroundImage = Image.FromFile(@"Happy.png");
                        Face.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        //GenerarMinas
                        mineGenerator(cellCount);
                        //while(btn.isMine)
                        //{
                        //    mineGenerator(cellCount);
                        //}
                        //btn.cascade(tableroporquemevalemadreelingles, columnCount);
                        CascadaMeValeVergaEstaEnEspanolFuckGringos();
                        gameStarted = true;
                        revealCells(btn);
                    }
                    Face.BackgroundImage = Image.FromFile(@"Happy.png");
                    Face.BackgroundImageLayout = ImageLayout.Stretch;
                    if (flagCount == mineCount && revealedCount == cellCount - mineCount)
                    {
                        wonGame();
                    }
                    Face.BackgroundImage = Image.FromFile(@"Happy.png");
                    Face.BackgroundImageLayout = ImageLayout.Stretch;
                    break;

                case MouseButtons.Right:
                    if (!btn.isFlagged && !btn.isRevealed)
                    {
                        btn.BackgroundImage = Image.FromFile(@"NotPushy.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Text = " ";
                        btn.isFlagged = true;
                        if (btn.isFlagged && btn.isMine)
                        {
                            flagCount++;
                            if (flagCount == mineCount && revealedCount == cellCount-mineCount)
                            {
                                wonGame();
                            }
                        }
                    }
                    else
                    {
                        if (btn.isRevealed)
                        {
                            revealCells(btn);
                           

                        }
                        else
                        {
                            btn.BackgroundImage = null;
                            btn.Text = "?";
                            btn.isFlagged = false;
                            if (btn.isMine)
                            {
                                flagCount--;
                            }
                        }
                    }
                    break;
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
                    Face.BackgroundImage = Image.FromFile(@"worried.png");
                    Face.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void revealCells(Cell btn)
        {
            if (!btn.isFlagged)
            {
                if (btn.isMine && !btn.isRevealed)
                {
                    btn.BackgroundImage = Image.FromFile(@"AtomicMine.png");
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Text = "  ";
                    player.Play();

                    //btn.BackColor = Color.Red;

                    gameLost = true;
                    btn.isFlagged = false;
                    btn.isRevealed = true;

                }
                if (!btn.isBlank && !btn.isMine)
                {
                    int adjacentMines = btn.adjMine;
                    btn.Text = adjacentMines.ToString();
                    btn.ForeColor = Color.Purple;
                    btn.isFlagged = false;
                    btn.isRevealed = true;
                }
                if (btn.isBlank)
                {
                    btn.Text = " ";
                    btn.ForeColor = Color.Purple;
                    btn.isFlagged = false;
                    btn.isRevealed = true;
                    Face.BackgroundImage = Image.FromFile(@"Happy.png");
                    Face.BackgroundImageLayout = ImageLayout.Stretch;

                    cascade(btn);

                }
                revealedCount++;
            }
        }

        public void clearBoard()
        {
            while (cellCount > 0)
            {
                foreach (Control x in tableroporquemevalemadreelingles.Controls)
                {
                    if (x is Cell)
                    {
                        tableroporquemevalemadreelingles.Controls.Remove((Cell)x);
                        cellCount--;
                    }
                }
            }
            tableroporquemevalemadreelingles.AutoSize = true;
            tableroporquemevalemadreelingles.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }


        public void resetBoard(int mines)
        {
            gameStarted = false;
            gameLost = false;
            gameWon = false;
            mineCount = 0;
            mineTotal = mines;
            flagCount = 0;
            revealedCount = 0;
        }

        public void CascadaMeValeVergaEstaEnEspanolFuckGringos()
        {
            foreach(Control y in tableroporquemevalemadreelingles.Controls)
            {
                if(y is Cell)
                {
                    foreach (Control x in tableroporquemevalemadreelingles.Controls)
                    {
                        if (x is Cell)
                        {
                            if((((Cell)y).id - columnCount) > 0)
                            {
                                if (((((Cell)y).id - columnCount - 1) == ((Cell)x).id) && (((Cell)y).id % columnCount) != 1)
                                {
                                    if (((Cell)x).isMine)
                                    {
                                        ((Cell)y).adjMine++;
                                    }
                                }
                                if ((((Cell)y).id - columnCount) == ((Cell)x).id)
                                {
                                    if (((Cell)x).isMine)
                                    {
                                        ((Cell)y).adjMine++;
                                    }
                                }
                                if (((((Cell)y).id - columnCount + 1) == ((Cell)x).id) && (((Cell)y).id % columnCount) != 0)
                                {
                                    if (((Cell)x).isMine)
                                    {
                                        ((Cell)y).adjMine++;
                                    }
                                }
                            }
                            if (((((Cell)y).id - 1) == ((Cell)x).id) && (((Cell)y).id % columnCount) != 1)
                            {
                                if (((Cell)x).isMine)
                                {
                                    ((Cell)y).adjMine++;
                                }
                            }
                            if (((((Cell)y).id + 1) == ((Cell)x).id) && (((Cell)y).id % columnCount) != 0)
                            {
                                if (((Cell)x).isMine)
                                {
                                    ((Cell)y).adjMine++;
                                }
                            }
                            if((((Cell)y).id + columnCount)<=cellCount)
                            {
                                if (((((Cell)y).id + columnCount - 1) == ((Cell)x).id) && (((Cell)y).id % columnCount) != 1)
                                {
                                    if (((Cell)x).isMine)
                                    {
                                        ((Cell)y).adjMine++;
                                    }
                                }
                                if ((((Cell)y).id + columnCount) == ((Cell)x).id)
                                {
                                    if (((Cell)x).isMine)
                                    {
                                        ((Cell)y).adjMine++;
                                    }
                                }
                                if (((((Cell)y).id + columnCount + 1) == ((Cell)x).id) && (((Cell)y).id % columnCount) != 0)
                                {
                                    if (((Cell)x).isMine)
                                    {
                                        ((Cell)y).adjMine++;
                                    }
                                }
                            }
                        }
                        if (((Cell)y).adjMine == 0)
                        {
                            ((Cell)y).isBlank = true;
                        }
                        else
                        {
                            ((Cell)y).isBlank = false;
                        }
                    }
                }
            }
        }

        public void cascade(Cell btn)
        {
            foreach (Control x in tableroporquemevalemadreelingles.Controls)
            {
                if (x is Cell)
                {
                    if ((btn.id - columnCount) > 0)
                    {
                        if (((btn.id - columnCount - 1) == ((Cell)x).id) && (btn.id % columnCount) != 1)
                        {
                            if ((((Cell)x).isBlank && !((Cell)x).isRevealed) || (!((Cell)x).isMine && !((Cell)x).isRevealed))
                            {
                                //((Cell)x).Text = " ";
                                //((Cell)x).ForeColor = Color.Purple;
                                //((Cell)x).isFlagged = false;
                                //((Cell)x).isRevealed = true;
                                //cascade(((Cell)x));
                                revealCells(((Cell)x));
                            }
                        }
                        if ((btn.id - columnCount) == ((Cell)x).id)
                        {
                            if ((((Cell)x).isBlank && !((Cell)x).isRevealed) || (!((Cell)x).isMine && !((Cell)x).isRevealed))
                            {
                                //((Cell)x).Text = " ";
                                //((Cell)x).ForeColor = Color.Purple;
                                //((Cell)x).isFlagged = false;
                                //((Cell)x).isRevealed = true;
                                //cascade(((Cell)x));
                                revealCells(((Cell)x));
                            }
                        }
                        if (((btn.id - columnCount + 1) == ((Cell)x).id) && (btn.id % columnCount) != 0)
                        {
                            if ((((Cell)x).isBlank && !((Cell)x).isRevealed) || (!((Cell)x).isMine && !((Cell)x).isRevealed))
                            {
                                //((Cell)x).Text = " ";
                                //((Cell)x).ForeColor = Color.Purple;
                                //((Cell)x).isFlagged = false;
                                //((Cell)x).isRevealed = true;
                                //cascade(((Cell)x));
                                revealCells(((Cell)x));
                            }
                        }
                    }
                    if (((btn.id - 1) == ((Cell)x).id) && (btn.id % columnCount) != 1)
                    {
                        if ((((Cell)x).isBlank && !((Cell)x).isRevealed) || (!((Cell)x).isMine && !((Cell)x).isRevealed))
                        {
                            //((Cell)x).Text = " ";
                            //((Cell)x).ForeColor = Color.Purple;
                            //((Cell)x).isFlagged = false;
                            //((Cell)x).isRevealed = true;
                            //cascade(((Cell)x));
                            revealCells(((Cell)x));
                        }
                    }
                    if (((btn.id + 1) == ((Cell)x).id) && (btn.id % columnCount) != 0)
                    {
                        if ((((Cell)x).isBlank && !((Cell)x).isRevealed) || (!((Cell)x).isMine && !((Cell)x).isRevealed))
                        {
                            //((Cell)x).Text = " ";
                            //((Cell)x).ForeColor = Color.Purple;
                            //((Cell)x).isFlagged = false;
                            //((Cell)x).isRevealed = true;
                            //cascade(((Cell)x));
                            revealCells(((Cell)x));
                        }
                    }
                    if ((btn.id + columnCount) <= cellCount)
                    {
                        if (((btn.id + columnCount - 1) == ((Cell)x).id) && (btn.id % columnCount) != 1)
                        {
                            if ((((Cell)x).isBlank && !((Cell)x).isRevealed) || (!((Cell)x).isMine && !((Cell)x).isRevealed))
                            {
                                //((Cell)x).Text = " ";
                                //((Cell)x).ForeColor = Color.Purple;
                                //((Cell)x).isFlagged = false;
                                //((Cell)x).isRevealed = true;
                                //cascade(((Cell)x));
                                revealCells(((Cell)x));
                            }
                        }
                        if ((btn.id + columnCount) == ((Cell)x).id)
                        {
                            if ((((Cell)x).isBlank && !((Cell)x).isRevealed) || (!((Cell)x).isMine && !((Cell)x).isRevealed))
                            {
                                //((Cell)x).Text = " ";
                                //((Cell)x).ForeColor = Color.Purple;
                                //((Cell)x).isFlagged = false;
                                //((Cell)x).isRevealed = true;
                                //cascade(((Cell)x));
                                revealCells(((Cell)x));
                            }
                        }
                        if (((btn.id + columnCount + 1) == ((Cell)x).id) && (btn.id % columnCount) != 0)
                        {
                            if ((((Cell)x).isBlank && !((Cell)x).isRevealed) || (!((Cell)x).isMine && !((Cell)x).isRevealed))
                            {
                                //((Cell)x).Text = " ";
                                //((Cell)x).ForeColor = Color.Purple;
                                //((Cell)x).isFlagged = false;
                                //((Cell)x).isRevealed = true;
                                //cascade(((Cell)x));
                                revealCells(((Cell)x));
                            }
                        }
                    }
                }
            }
        }

        void wonGame()
        {
            Face.BackgroundImage = Image.FromFile(@"Victory.png");
            Face.BackgroundImageLayout = ImageLayout.Stretch;

            MessageBox.Show("Ganaste.");

            clearBoard();
            ((Form1)tableroporquemevalemadreelingles).StopTime();
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
