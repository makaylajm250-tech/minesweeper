using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper.Models
{
    //public class so that console app can access it through DLL
    public class Cell
    {
        /// <summary>
        /// Creates a cell at the specified row and column.
        /// </summary>
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        /// <summary>
        /// Gets the row of the cell.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Gets the column of the cell.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Gets or sets whether this cell contains a bomb.
        /// </summary>
        public bool IsBomb { get; set; }

        /// <summary>
        /// Gets or sets the number of bombs in neighboring cells.
        /// </summary>
        public int NeighborBombs { get; set; }

    }
}
