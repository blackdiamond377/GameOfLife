using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Life
    {
        const bool ALIVE = true, DEAD = false;
        
        Cell[,] board;
        public Life(int rows, int cols, Cell[,] startstate = null)
        {
            if(startstate == null)
            {
                board = new Cell[rows, cols];
                for(int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        board[i, j] = new Cell(ALIVE);
                    }
                }
            }
        }
    }
}
