
using Xunit;
using Minesweeper.Models;
using Minesweeper.BusinessLogic;

namespace Minesweeper.Tests
{
    public class BoardTests
    {
        //test that visitingg cell only shows that cell, no neighbors
        [Fact]
        public void NumberedCellRevealsOnlySelectedCell()
        {
            // Arrange: create a predictable 3x3 board.
            Board board = new Board(3, 1);
            BoardService service = new BoardService();

            // Place one bomb in the top-left corner.
            board.Cells[0, 0].IsBomb = true;

            // Calculate neighboring bomb counts.
            service.CountNeighborBombs(board);

            // Act: reveal a numbered cell next to the bomb.
            service.RevealCell(board, 0, 1);

            // Assert: the selected cell is revealed.
            Assert.True(board.Cells[0, 1].IsVisited);

            // The bomb itself was not revealed.
            Assert.False(board.Cells[0, 0].IsVisited);

            // A neighboring cell remains hidden.
            Assert.False(board.Cells[1, 1].IsVisited);

            // The selected cell should have one neighboring bomb.
            Assert.Equal(1, board.Cells[0, 1].NeighborBombs);
        }

        //empty cell starts flood and shows boundary cell but not bomb
        [Fact]
        public void EmptyRegionRevealsZerosAndNumberedBoundary()
        {
            // Arrange
            Board board = new Board(3, 1);
            BoardService service = new BoardService();

            // Place a known bomb in the corner.
            board.Cells[0, 0].IsBomb = true;

            // Calculate the number of neighboring bombs.
            service.CountNeighborBombs(board);

            // Act
            service.RevealCell(board, 2, 2);

            // Assert
            Assert.True(board.Cells[2, 2].IsVisited);
            Assert.True(board.Cells[1, 2].IsVisited);
            Assert.True(board.Cells[2, 1].IsVisited);
            Assert.True(board.Cells[1, 1].IsVisited);

            // The bomb itself should remain hidden.
            Assert.False(board.Cells[0, 0].IsVisited);

            // The numbered cell next to the bomb should be revealed
            // if flood fill reaches it.
            Assert.True(board.Cells[0, 1].IsVisited);
        }

        // flag cell, is visited stays false
        [Fact]
        public void FlaggedCellDoesNotRevealCell()
        {
            // Arrange
            Board board = new Board(3, 1);
            BoardService service = new BoardService();

            // Flag the cell we want to protect.
            board.Cells[1, 1].IsFlagged = true;

            // Act
            service.RevealCell(board, 1, 1);

            // Assert
            Assert.True(board.Cells[1, 1].IsFlagged);
            Assert.False(board.Cells[1, 1].IsVisited);
        }

        //clicking bomb means game state is lost
        [Fact]
        public void BombSetsGameStateToLost()
        {
            // Arrange
            Board board = new Board(3, 1);
            BoardService service = new BoardService();

            // Place a bomb at a known location.
            board.Cells[1, 1].IsBomb = true;

            // Calculate neighboring bomb counts.
            service.CountNeighborBombs(board);

            // Act
            service.RevealCell(board, 1, 1);
            var gameState = service.DetermineGameState(board);

            // Assert
            Assert.True(board.Cells[1, 1].IsVisited);
            Assert.Equal(GameState.Lost, gameState);
        }

    }
}
