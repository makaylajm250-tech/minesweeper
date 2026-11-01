
using System;
using System.Drawing;
using System.Windows.Forms;
using Minesweeper.BusinessLogic;
using Minesweeper.Models;

namespace MinesweeperGUI
{
    public partial class GameForm : Form
    {
        private Board _board;
        private readonly BoardService _boardService;
        private int _selectedRow = -1;
        private int _selectedColumn = -1;

        private Button[,] _cellButtons;

        public GameForm(Board board, BoardService boardService)
        {
            InitializeComponent();

            _board = board;
            _boardService = boardService;

            CreateBoardButtons();

            //adjust window size based on board size
            int boardWidth = _board.Size * 32;

            ClientSize = new Size(
                Math.Max(450, boardWidth + 60),
                Math.Max(350, boardWidth + 100));

            //Flag and restart event
            //btnFlagMode.Click += BtnFlagMode_Click;
            btnReveal.Click += BtnReveal_Click;
            btnRestart.Click += BtnRestart_Click;
        }


        private void CreateBoardButtons()
        {
            int size = _board.Size;

            tlpBoard.SuspendLayout();

            tlpBoard.Controls.Clear();
            tlpBoard.ColumnStyles.Clear();
            tlpBoard.RowStyles.Clear();

            tlpBoard.ColumnCount = size;
            tlpBoard.RowCount = size;

            // Make every column exactly 32 pixels wide.
            for (int i = 0; i < size; i++)
            {
                tlpBoard.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Absolute, 32));

                tlpBoard.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, 32));
            }

            _cellButtons = new Button[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    Button cellButton = new Button
                    {
                        Width = 30,
                        Height = 30,
                        Dock = DockStyle.None,
                        Anchor = AnchorStyles.None,
                        Margin = new Padding(1),
                        Padding = new Padding(0),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        Tag = (row, column)
                    };

                    cellButton.MouseUp += CellButton_MouseUp;

                    _cellButtons[row, column] = cellButton;

                    tlpBoard.Controls.Add(
                        cellButton, column, row);
                }
            }

            // Set the complete board dimensions.
            tlpBoard.Width = size * 32;
            tlpBoard.Height = size * 32;

            tlpBoard.ResumeLayout(true);
        }

        private void CellButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            Button button = (Button)sender;

            var position = ((int row, int column))button.Tag;

            _selectedRow = position.row;
            _selectedColumn = position.column;

            lblGameStatus.Text =
                $"Selected cell: Row {_selectedRow + 1}, Column {_selectedColumn + 1}";

            HighlightSelectedCell();
        }

        private void UpdateBoardDisplay()
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int column = 0; column < _board.Size; column++)
                {
                    Cell cell = _board.Cells[row, column];
                    Button button = _cellButtons[row, column];

                    if (cell.IsFlagged)
                    {
                        button.Text = "F";
                        button.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (cell.IsVisited)
                    {
                        button.Enabled = false;
                        button.BackColor = Color.LightGray;

                        if (cell.IsBomb)
                        {
                            button.Text = "*";
                            button.BackColor = Color.IndianRed;
                        }
                        else
                        {
                            button.Text = cell.NeighborBombs > 0
                                ? cell.NeighborBombs.ToString()
                                : "";
                        }
                    }
                    else
                    {
                        button.Text = "";
                        button.Enabled = true;
                        button.BackColor = SystemColors.Control;
                    }
                }
            }
        }

        private void CheckGameState()
        {
            GameState state =
                _boardService.DetermineGameState(_board);

            if (state == GameState.Lost)
            {
                RevealAllBombs();

                lblGameStatus.Text = "Game Over! You Lost!";

                MessageBox.Show(
                    "You hit a bomb! Game over.",
                    "Minesweeper");

                SetBoardEnabled(false);
            }
            else if (state == GameState.Won)
            {
                lblGameStatus.Text = "Congratulations! You Won!";

                MessageBox.Show(
                    "Congratulations! You won!",
                    "Minesweeper");

                SetBoardEnabled(false);
            }
        }

        private void RevealAllBombs()
        {
            for (int row = 0; row < _board.Size; row++)
            {
                for (int column = 0; column < _board.Size; column++)
                {
                    Cell cell = _board.Cells[row, column];

                    if (cell.IsBomb)
                    {
                        cell.IsVisited = true;
                    }
                }
            }

            UpdateBoardDisplay();
        }

        private void SetBoardEnabled(bool enabled)
        {
            foreach (Button button in _cellButtons)
            {
                button.Enabled = enabled;
            }
        }

        private void HighlightSelectedCell()
        {
            // Reset the previous selection.
            for (int row = 0; row < _board.Size; row++)
            {
                for (int column = 0; column < _board.Size; column++)
                {
                    Cell cell = _board.Cells[row, column];
                    Button button = _cellButtons[row, column];

                    if (cell.IsFlagged)
                    {
                        button.BackColor = Color.LightGoldenrodYellow;
                    }
                    else if (cell.IsVisited)
                    {
                        button.BackColor = Color.LightGray;
                    }
                    else
                    {
                        button.BackColor = SystemColors.Control;
                    }
                }
            }

            // Highlight the selected cell if it is still covered.
            if (_selectedRow >= 0 && _selectedColumn >= 0)
            {
                Cell selectedCell =
                    _board.Cells[_selectedRow, _selectedColumn];

                if (!selectedCell.IsVisited && !selectedCell.IsFlagged)
                {
                    _cellButtons[_selectedRow, _selectedColumn].BackColor =
                        Color.LightBlue;
                }
            }
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            _board = new Board(_board.Size, _board.BombCount);

            _boardService.SetupBombs(_board);

            _selectedRow = -1;
            _selectedColumn = -1;

            CreateBoardButtons();

            lblGameStatus.Text = "Game in progress";
        }

        private void BtnReveal_Click(object sender, EventArgs e)
        {
            if (_selectedRow == -1 || _selectedColumn == -1)
            {
                MessageBox.Show("Please select a cell first.");
                return;
            }

            _boardService.RevealCell(
                _board,
                _selectedRow,
                _selectedColumn);

            UpdateBoardDisplay();
            CheckGameState();
        }

        private void BtnFlagMode_Click(object sender, EventArgs e)
        {
            if (_selectedRow == -1 || _selectedColumn == -1)
            {
                MessageBox.Show("Please select a cell first.");
                return;
            }

            bool success = _boardService.ToggleFlag(
                _board,
                _selectedRow,
                _selectedColumn);

            if (!success)
            {
                MessageBox.Show(
                    "This cell cannot be flagged because it has already been revealed.");
                return;
            }

            UpdateBoardDisplay();
            HighlightSelectedCell();
        }
    }
}

