using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper.Models
{
    public class Board
    {
        public int Size { get; }
        public int BombCount { get; }
        public Cell[,] Cells { get; }

        public Board(int size, int bombCount)
        {
            if (size < 1 || size > 100)
                throw new ArgumentOutOfRangeException(nameof(size));

            int cellCount = size * size;
            if (bombCount < 1 || bombCount > cellCount)
                throw new ArgumentOutOfRangeException(nameof(bombCount));

            Size = size;
            BombCount = bombCount;
            Cells = new Cell[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    Cells[row, column] = new Cell(row, column);
                }
            }
        }
    }
}
