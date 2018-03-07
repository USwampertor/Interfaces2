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

        

        //public void mineGenerator(Form form, int buttons)
        //{
        //    foreach (Control x in form.Controls)
        //    {
        //        if (x is Button)
        //        {
        //            for(int i =0; i< buttons; i++)
        //            {
        //                //x.
        //            }

        //            ((Button)x).Text = "M";
        //        }
        //    }
        //}

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
