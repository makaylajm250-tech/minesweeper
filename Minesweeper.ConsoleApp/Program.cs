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

        //playable board settings
        int size = ReadBoardSize();
        int bombCount = ReadBombCount(size);

        //create and initialize board 
        Board board = new Board(size, bombCount);
        boardService.SetupBombs(board);
        boardService.CountNeighborBombs(board);

        GameState state = GameState.InProgress;

        // Main game loop
        while (state == GameState.InProgress)
        {
            Console.WriteLine();
            PrintBoard(board);

            int row = ReadCoordinate(
                $"Enter row (0-{size - 1}): ",
                size);

            int column = ReadCoordinate(
                $"Enter column (0-{size - 1}): ",
                size);

            char action = ReadAction();

            if (action == 'Q')
            {
                Console.WriteLine();
                Console.WriteLine("You chose to quit the game.");
                break;
            }

            bool actionSuccessful;

            if (action == 'V')
            {
                actionSuccessful = boardService.VisitCell(
                    board,
                    row,
                    column);

                if (!actionSuccessful)
                {
                    Console.WriteLine(
                        "That cell cannot be visited. It may already be visited or flagged.");
                }
            }
            else
            {
                actionSuccessful = boardService.ToggleFlag(
                    board,
                    row,
                    column);

                if (!actionSuccessful)
                {
                    Console.WriteLine(
                        "That cell cannot be flagged because it has already been visited.");
                }
            }

            state = boardService.DetermineGameState(board);
        }

        // Display final board
        Console.WriteLine();
        PrintBoard(board);

        // Display game result
        if (state == GameState.Won)
        {
            Console.WriteLine();
            Console.WriteLine("Congratulations! You won!");
        }
        else if (state == GameState.Lost)
        {
            Console.WriteLine();
            Console.WriteLine("Game over! You visited a bomb.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Game ended.");
        }

        // Display answers
        Console.WriteLine();
        Console.WriteLine("Answer key:");
        PrintAnswers(board);
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

    //new method for actual game 
    private static void PrintBoard(Board board)
    {
        int rowLabelWidth = (board.Size - 1).ToString().Length;

        PrintColumnLabels(board.Size, rowLabelWidth);

        PrintDivider(board.Size, rowLabelWidth);

        for(int row = 0; row < board.Size; row++)
        {
            Console.Write("{0," + rowLabelWidth + "} |", row);
            
            for(int column = 0; column < board.Size; column++)
            {
                Cell cell = board.Cells[row, column];

                char symbol;

                if (cell.IsFlagged && !cell.IsVisited)
                {
                    symbol = 'F';
                }
                else if(!cell.IsVisited)
                {
                    symbol = '?';
                }
                else if (cell.IsBomb)
                {
                    symbol = '.';
                }
                else
                {
                    symbol = (char)('0' + cell.NeighborBombs);
                }

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

    //parse so invaild input doesnt make game crash 
    private static int ReadBoardSize()
    {
        while(true)
        {
            Console.Write("Enter board size (2-100): ");

            string? input = Console.ReadLine();

            if(int.TryParse(input, out int size) && 
                size >= 2 && 
                size <= 100)
            {
                return size;
            }

            Console.WriteLine("Invailid board size. Please enter a number from 2 to 100.");
        }
    }

    private static int ReadBombCount(int size)
    {
        int maximumBombs = (size * size) - 1;

        while(true)
        {
            Console.Write($"Enter bomb count (1-{maximumBombs}): ");

            string? input = Console.ReadLine();

            if(int.TryParse(input, out int bombCount) 
                && bombCount >= 1 
                && bombCount <= maximumBombs)
            {
                return bombCount;
            }

            Console.WriteLine($"Invalid bomb count. Please enter a number from 1 to {maximumBombs}. ");
        }
    }

    private static int ReadCoordinate(string prompt, int size)
    {
        while(true)
        {
            Console.Write(prompt);

            string? input = Console.ReadLine();

            if(int.TryParse(input, out int coordinate) && 
                coordinate >= 0 &&
                coordinate < size)
            {
                return coordinate;
            }

            Console.WriteLine($"Invalid coordinate. Please enter a number from 0 to {size - 1}. ");
        }
    }

    private static char ReadAction()
    {
        while (true)
        {
            Console.Write("Enter action (V = Visit, F = Flag, Q = Quit): ");

            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                char action = char.ToUpper(input[0]);

                if (action == 'V' || action == 'F' || action == 'Q')
                {
                    return action;
                }
            }

            Console.WriteLine("Invalid action. Enter V, F, or Q.");
        }
    }





}//end of program 


