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
        
            public void gridGenerator(int xg, int yg, Form form)
        {
            int gameWidth, gameHeight;
            int ButtonWidth = 40;
            int ButtonHeight = 40;
            int Distance = 20;
            int start_x = 20;
            int start_y = 20;

            for ( int x = 0; x < xg; x++)
            {                                   //Estos 2 fors controlan el tamaño del grid
                for (int y = 0; y < yg; y++)
                {
                    Button tmpButton = new Button();
                    tmpButton.Top = start_x + (x * ButtonHeight + Distance);
                    tmpButton.Left = start_y + (y * ButtonWidth + Distance);
                    tmpButton.Width = ButtonWidth;
                    tmpButton.Height = ButtonHeight;
                    tmpButton.Text = "?";
                    // Possible add Buttonclick event etc..
                    form.Controls.Add(tmpButton);
                }

            }
        }


        private void GridManager_Load(object sender, EventArgs e)
        {

        }
    }
}
