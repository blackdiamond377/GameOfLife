using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    public class Cell
    {

        bool _isAlive, _willAlive,
             _updated;
        int _row, _col;

        public Cell(bool isAlive, int row, int col)
        {
            this._isAlive = isAlive;
            this._row = row;
            this._col = col;
        }

        public bool isAlive
        {
            get
            {
                return _isAlive;
            }
            set
            {
                if (!_updated) _updated = true;
                _willAlive = value;
            }
        }

        public void update()
        {
            if (_updated)
            {
                _isAlive = _willAlive;
                _updated = false;
            }
            else
            {
                throw new Exception(String.Format("You didn't update cell {0}{1} before updating", _row, _col));
            }
        }

        public int row
        {
            get
            {
                return _row;
            }
        }

        public int col
        {
            get
            {
                return _col;
            }
        }

        public override string ToString()
        {
            if (_isAlive) return "x";
            return " ";
        }
    }
}
