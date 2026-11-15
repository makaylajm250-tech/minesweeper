
using System;
using System.Windows.Forms;
using Minesweeper.BusinessLogic;
using Minesweeper.Models;
using System.Diagnostics;
using Minesweeper.DataAccess;

namespace MinesweeperGUI
{
    public partial class Form1 : Form
    {
        private readonly GameHistoryService _history;
        public Form1(GameHistoryService history)
        {
            InitializeComponent();

            // Configure board size.
            TbSize.Minimum = 5;
            TbSize.Maximum = 20;
            TbSize.Value = 10;

            // Configure bomb percentage.
            TbBombs.Minimum = 5;
            TbBombs.Maximum = 50;
            TbBombs.Value = 10;

            UpdateSelectionLabels();

            TbSize.Scroll += TrackBar_Scroll;
            TbBombs.Scroll += TrackBar_Scroll;
            btnPlay.Click += BtnPlay_Click;
            _history = history;

        }

        private void TrackBar_Scroll(object? sender, EventArgs e)
        {
            UpdateSelectionLabels();
        }

        private void UpdateSelectionLabels()
        {
            lblSize.Text = $"Size: {TbSize.Value} x {TbSize.Value}";
            lblPercentBombs.Text =
                $"Percent of Bombs: {TbBombs.Value}%";
        }

        private void BtnPlay_Click(object? sender, EventArgs e)
        {
            int size = TbSize.Value;
            int totalCells = size * size;

            int bombCount = (int)Math.Round(
                totalCells * (TbBombs.Value / 100.0));

            bombCount = Math.Max(1, bombCount);

            Board board = new Board(size, bombCount);

            BoardService boardService = new BoardService();
            boardService.SetupBombs(board);

            using (GameForm gameForm =
                new GameForm(board, boardService, _history))
            {
                gameForm.ShowDialog(this);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_history.HasUnsavedChanges)
                return;

            DialogResult choice = MessageBox.Show(
                "You have unsaved game history. Would you like to save before closing?",
                "Unsaved Game History",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (choice == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            if (choice == DialogResult.No)
                return;

            using SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                DefaultExt = "json",
                AddExtension = true,
                FileName = "GameHistory.json",
                Title = "Save Game History"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                _history.SaveHistory(dialog.FileName);

                MessageBox.Show(
                    "Game history saved successfully.",
                    "Save Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Could not save game history: {ex.Message}",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                e.Cancel = true;
            }
        }
    }
}





