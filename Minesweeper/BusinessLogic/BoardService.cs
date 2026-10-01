using Minesweeper.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Minesweeper.BusinessLogic
{
    public class BoardService
    {
        //Clear existing bombs and place new bombs at random and unique spots (using HashSet)
        public void SetupBombs(Board board)
        {
            int cellCount = board.Size * board.Size;

            HashSet<int> bombLocations = new HashSet<int>();

            // Clear existing bombs.
            for (int row = 0; row < board.Size; row++)
            {
                for (int column = 0; column < board.Size; column++)
                {
                    board.Cells[row, column].IsBomb = false;
                    board.Cells[row, column].NeighborBombs = 0;
                    board.Cells[row, column].IsVisited = false;
                    board.Cells[row, column].IsFlagged = false;
                }
            }

            // Generate unique random bomb locations.
            while (bombLocations.Count < board.BombCount)
            {
                int location = Random.Shared.Next(cellCount);
            
                bombLocations.Add(location);
            }
            
            // Convert each location into a row and column.
            foreach (int location in bombLocations)
            {
                int row = location / board.Size;
                int column = location % board.Size;

                board.Cells[row, column].IsBomb = true;
            }
        }

        //calculate the # of bombs surrounding/adjacent to safe cells
        public void CountNeighborBombs(Board board)
        {
            for (int row = 0; row < board.Size; row++)
            {
                for (int column = 0; column < board.Size; column++)
                {
                    Cell cell = board.Cells[row, column];

                    // Reset the count.
                    cell.NeighborBombs = 0;

                    // Bomb cells do not receive neighbor counts.
                    if (cell.IsBomb)
                    {
                        continue;
                    }

                    // Check the eight neighboring positions.
                    for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
                    {
                        for (
                            int columnOffset = -1;
                            columnOffset <= 1;
                            columnOffset++)
                        {
                            // Skip the current cell.
                            if (rowOffset == 0 && columnOffset == 0)
                            {
                                continue;
                            }

                            int neighborRow = row + rowOffset;
                            int neighborColumn = column + columnOffset;

                            // Make sure the neighbor is inside the board.
                            if (neighborRow >= 0 &&
                                neighborRow < board.Size &&
                                neighborColumn >= 0 &&
                                neighborColumn < board.Size)
                            {
                                if (board.Cells[neighborRow, neighborColumn].IsBomb)
                                {
                                    cell.NeighborBombs++;
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool VisitCell(Board board, int row, int column)
        {
            if(board == null)
            {
                return false;
            }

            if (row < 0 || row >= board.Size || column < 0 || column >= board.Size)
            {
                return false;
            }

            Cell cell = board.Cells[row, column];

            if(cell.IsVisited || cell.IsFlagged)
            {
                return false;
            }

            cell.IsVisited = true;
            return true;

        }

        public bool ToggleFlag(Board board, int row, int column)
        {
            if(board == null)
            {
                return false;
            }

            if(row < 0 || row >= board.Size || column < 0 || column >= board.Size)
            {
                return false;
            }

            Cell cell = board.Cells[row, column];

            if(cell.IsVisited)
            {
                return false;
            }

            cell.IsFlagged = !cell.IsFlagged;
            return true;
        }

        public GameState DetermineGameState(Board board)
        {
            // is cell had boomb and is visited, return loss
            if(board == null)
            {
                return GameState.InProgress;
            }

            for(int row = 0; row < board.Size; row++)
            {
                for(int column = 0; column < board.Size; column++)
                {
                    Cell cell = board.Cells[row, column];

                    if(cell.IsBomb && cell.IsVisited)
                    {
                        return GameState.Lost;
                    }
                }          
            }

            //if cell is not visited and safe, return in progress
            for(int row = 0; row < board.Size; row++)
            {
                for(int column = 0; column < board.Size; column++)
                {
                    Cell cell = board.Cells[row, column];

                    if(!cell.IsBomb && !cell.IsVisited)
                    {
                        return GameState.InProgress;
                    }
                }
            }

            // if all cells visited and safe, return win
            return GameState.Won;
        }




    }//end of class 
}
