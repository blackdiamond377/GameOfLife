using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Life
    {
        const bool ALIVE = true, DEAD = false;
        Cell[,] _board;

        public Life(int rows, int cols, Cell[,] startstate = null)
        {
            if (startstate == null)
            {
                _board = new Cell[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        _board[i, j] = new Cell(ALIVE, i, j);
                    }
                }
            }
            else
            {
                _board = startstate;
            }
        }

        public Cell[,] board
        {
            get
            {
                return _board;
            }
        }

        public void updateBoard()
        {
            foreach (Cell cell in _board)
            {
                int numNeighbors = getNumNeighbors(cell.row, cell.col);
                if (numNeighbors > 3 || numNeighbors < 2)
                {
                    cell.isAlive = DEAD;
                }
                else if (numNeighbors == 3)
                {
                    cell.isAlive = ALIVE;
                }
                else
                {
                    cell.isAlive = cell.isAlive;
                }
            }

            foreach (Cell cell in _board)
            {
                cell.update();
            }
        }

        private int getNumNeighbors(int _row, int _col)
        {
            int numAlive = 0;
            int rOffset = _row,
                cOffset = _col;
            for (int i = -1; i < 2; i++)
            {
                int row = i + rOffset;
                if (row < 0) row = _board.GetLength(0) - 1; // wraps for -1
                else if (row >= _board.GetLength(0)) row = 0;

                for (int j = -1; j < 2; j++)
                {
                    int col = j + cOffset;
                    if (col < 0) col = _board.GetLength(1) - 1;
                    else if (col >= _board.GetLength(1)) col = 0;

                    if (!(i == 0 && j == 0) && _board[row,col].isAlive) // The center cell isn't its own neighbor
                    {
                        numAlive++;
                    }
                }
            }

            return numAlive;
        }
    }
}
