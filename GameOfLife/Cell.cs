using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    class Cell
    {

        bool _isAlive;
        int row, col;

        public Cell(bool isAlive, int row, int col)
        {
            this._isAlive = isAlive;
            this.row = row;
            this.col = col;
        }

        public bool isAlive
        {
            get
            {
                return _isAlive;
            }
            set
            {
                _isAlive = value;
            }
        }
    }
}
