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

        public Cell(bool isAlive)
        {
            this._isAlive = isAlive;
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
