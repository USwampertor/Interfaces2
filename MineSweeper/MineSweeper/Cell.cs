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
        public bool isMine, isRevealed, isFlagged, isBlank;

        public Cell()
        {
            isMine = false;
            adjMine = 0;
        }

        public int getID()
        {
            return id;
        }

        public int getAdjMine()
        {
            return adjMine;
        }

        //public void cascade(Form board, int column)
        //{
        //    foreach (Control y in board.Controls)
        //    {
        //        if (y is Cell)
        //        {
        //            foreach (Control x in board.Controls)
        //            {
        //                if (x is Cell)
        //                {
        //                    if ((((Cell)y).id - column - 1) == ((Cell)x).id)
        //                    {
        //                        if (((Cell)x).isMine)
        //                        {
        //                            ((Cell)y).adjMine++;
        //                        }
        //                    }
        //                    if ((((Cell)y).id - column) == ((Cell)x).id)
        //                    {
        //                        if (((Cell)x).isMine)
        //                        {
        //                            ((Cell)y).adjMine++;
        //                        }
        //                    }
        //                    if ((((Cell)y).id - column + 1) == ((Cell)x).id)
        //                    {
        //                        if (((Cell)x).isMine)
        //                        {
        //                            ((Cell)y).adjMine++;
        //                        }
        //                    }
        //                    if ((((Cell)y).id - 1) == ((Cell)x).id)
        //                    {
        //                        if (((Cell)x).isMine)
        //                        {
        //                            ((Cell)y).adjMine++;
        //                        }
        //                    }
        //                    if ((((Cell)y).id + 1) == ((Cell)x).id)
        //                    {
        //                        if (((Cell)x).isMine)
        //                        {
        //                            ((Cell)y).adjMine++;
        //                        }
        //                    }
        //                    if ((((Cell)y).id + column - 1) == ((Cell)x).id)
        //                    {
        //                        if (((Cell)x).isMine)
        //                        {
        //                            ((Cell)y).adjMine++;
        //                        }
        //                    }
        //                    if ((((Cell)y).id + column) == ((Cell)x).id)
        //                    {
        //                        if (((Cell)x).isMine)
        //                        {
        //                            ((Cell)y).adjMine++;
        //                        }
        //                    }
        //                    if ((((Cell)y).id + column + 1) == ((Cell)x).id)
        //                    {
        //                        if (((Cell)x).isMine)
        //                        {
        //                            ((Cell)y).adjMine++;
        //                        }
        //                    }
        //                }
        //                if (((Cell)y).adjMine == 0)
        //                {
        //                    ((Cell)y).isBlank = true;
        //                }
        //            }
        //        }
        //    }
        //}

    }
}
