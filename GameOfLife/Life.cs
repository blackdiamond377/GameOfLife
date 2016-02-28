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
            if (startstate == null)
            {
                board = new Cell[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        board[i, j] = new Cell(ALIVE, i, j);
                    }
                }
            }
        }

        public void updateBoard()
        {
            foreach (Cell cell in board)
            {
                int numNeighbors = getNumNeighbors(cell.row, cell.col);
                if (numNeighbors < 2)
                {
                    cell.isAlive = DEAD;
                }
                else if (numNeighbors > 3)
                {
                    cell.isAlive = DEAD;
                }
                else
                {
                    cell.isAlive = ALIVE;
                }
            }

            foreach (Cell cell in board)
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
                for (int j = -1; j < 2; j++)
                {
                    int col = j + cOffset;
                    if (row < 0) row = board.GetLength(0) + row; // wraps for -1
                    if (!(i == 0 && j == 0)) // The center cell isn't its own neighbor
                    {
                        if (col < 0) col = board.GetLength(1) + col;
                        if (board[row, col].isAlive) numAlive++;
                    }
                }
            }

            return numAlive;
        }
    }
}
