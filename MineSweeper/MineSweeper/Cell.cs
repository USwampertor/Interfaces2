using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MineSweeper
{
     class Cell: Button
    {
        public int posX, posY;
        public bool isMine, revealed, flagged;

        public Cell()
        {
            this.Width = posX;
            this.Height = posY;
        }

    }
}
