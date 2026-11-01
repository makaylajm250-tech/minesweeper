
using System;
using System.Windows.Forms;
using Minesweeper.BusinessLogic;
using Minesweeper.Models;

namespace MinesweeperGUI
{
    public partial class Form1 : Form
    {
        public Form1()
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
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            UpdateSelectionLabels();
        }

        private void UpdateSelectionLabels()
        {
            lblSize.Text = $"Size: {TbSize.Value} x {TbSize.Value}";
            lblPercentBombs.Text =
                $"Percent of Bombs: {TbBombs.Value}%";
        }

        private void BtnPlay_Click(object sender, EventArgs e)
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
                new GameForm(board, boardService))
            {
                gameForm.ShowDialog(this);
            }
        }
    }
}





