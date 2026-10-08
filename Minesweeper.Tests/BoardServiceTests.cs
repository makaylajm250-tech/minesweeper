namespace Minesweeper.Tests
{
    using Minesweeper;
    using Minesweeper.BusinessLogic;
    using Minesweeper.Models;

    public class BoardServiceTests
    {

        //Test for construct a board 
        [Fact]
        public void Board_VailidArguments_CreatesRequestedGrid()
        {
            Board board = new Board(5, 3);

            Assert.Equal(5, board.Size);
            Assert.Equal(3, board.BombCount);
            Assert.Equal(5, board.Cells.GetLength(0));
            Assert.Equal(5, board.Cells.GetLength(1));
            Assert.NotNull(board.Cells[0, 0]);
        }

        //Test for random operation by its invariant 
        [Fact]
        public void SetupBombs_PlaceConfiguredBombCount()
        {
            Board board = new Board(8, 10);
            BoardService service = new BoardService();

            service.SetupBombs(board);

            int actualBombs = 0;
            for(int row = 0; row < board.Size; row++)
            {
                for(int column = 0; column < board.Size; column++)
                {
                    if(board.Cells[row, column].IsBomb)
                    {
                        actualBombs++;
                    }
              

                }
            }

            Assert.Equal(board.BombCount, actualBombs);

        }

        //Test for arrange a known Board 
        [Fact]
        public void CountNeighborBombs_KnownCornerBomb_CountNeighbors()
        {
            Board board = CreateBoardWithOneBomb();

            Assert.Equal(0, board.Cells[0,0].NeighborBombs);
            Assert.Equal(1, board.Cells[0,1].NeighborBombs);
            Assert.Equal(1, board.Cells[1,0].NeighborBombs);
            Assert.Equal(1, board.Cells[1,1].NeighborBombs);
            Assert.Equal(0, board.Cells[4,4].NeighborBombs);
        }

        private static Board CreateBoardWithOneBomb()
        {
            Board board = new Board(5, 1);
            board.Cells[0, 0].IsBomb = true;
            new BoardService().CountNeighborBombs(board);
            return board;
        }






    }
}
