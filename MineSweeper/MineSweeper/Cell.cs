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
        public int id, adjMine;
        public bool isMine, revealed, isFlagged;

        public Cell()
        {
        }

        public int getID()
        {
            return id;

        }

    }


   
}
