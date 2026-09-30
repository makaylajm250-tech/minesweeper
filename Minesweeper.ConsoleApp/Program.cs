using Minesweeper;
using Minesweeper.BusinessLogic;
using Minesweeper.Models;

namespace Minesweeper.ConsoleApp;

    public class Program
    {
    private const int CellWidth = 3;

    static void Main(string[] args)
    {

        //from activity 1 
        Greeter greeter = new Greeter("Makayla Martinez.\n");
        Console.WriteLine(greeter.Introduce());

        BoardService boardService = new BoardService();
        Board smallestBoard = new Board(size: 2, bombCount: 3);
        Board smallBoard = new Board(size: 9, bombCount: 10);
        Board largeBoard = new Board(size: 25, bombCount: 35);
        PrepareAndPrintBoard(
            $"{smallestBoard.Size} x {smallestBoard.Size} board with {smallestBoard.BombCount} bombs",
            smallestBoard,
            boardService);
        PrepareAndPrintBoard(
            $"{smallBoard.Size} x {smallBoard.Size} board with {smallBoard.BombCount} bombs",
            smallBoard,
            boardService);
        PrepareAndPrintBoard(
            $"{largeBoard.Size} x {largeBoard.Size} board with {largeBoard.BombCount} bombs",
            largeBoard,
            boardService);
    }
    private static void PrepareAndPrintBoard(string label, Board board, BoardService boardService)
    {
        boardService.SetupBombs(board);
        boardService.CountNeighborBombs(board);

        Console.WriteLine(label);

        PrintAnswers(board);

        Console.WriteLine();
    }

    private static void PrintAnswers(Board board)
    {
        int rowLabelWidth = (board.Size - 1).ToString().Length;

        PrintColumnLabels(board.Size, rowLabelWidth);

        PrintDivider(board.Size, rowLabelWidth);

        for (int row = 0; row < board.Size; row++)
        {
            Console.Write(
                "{0," + rowLabelWidth + "} |",
                row);

            for (int column = 0; column < board.Size; column++)
            {
                Cell cell = board.Cells[row, column];

                char symbol = GetCellSymbol(cell);

                Console.Write($" {symbol} |");
            }

            Console.WriteLine();

            PrintDivider(board.Size, rowLabelWidth);
        }
    }

    private static void PrintColumnLabels(int size, int rowLabelWidth)
    {
        Console.Write(
            new string(' ', rowLabelWidth + 2));

        for (int column = 0; column < size; column++)
        {
            Console.Write($"{column,CellWidth} ");
        }

        Console.WriteLine();
    }

    private static void PrintDivider(int size, int rowLabelWidth)
    {
        Console.Write(
            new string(' ', rowLabelWidth + 1));

        Console.Write("+");

        for (int column = 0; column < size; column++)
        {
            Console.Write(
                new string('-', CellWidth));

            Console.Write("+");
        }

        Console.WriteLine();
    }

    private static char GetCellSymbol(Cell cell)
    {
        // Bomb.
        if (cell.IsBomb)
        {
            return 'B';
        }

        // Safe cell with zero neighboring bombs.
        if (cell.NeighborBombs == 0)
        {
            return '.';
        }

        // Safe cell with 1-8 neighboring bombs.
        return (char)('0' + cell.NeighborBombs);
    }
}


