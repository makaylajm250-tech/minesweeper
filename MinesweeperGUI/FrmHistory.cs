using Minesweeper.BusinessLogic;
using Minesweeper.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class FrmHistory : Form
    {
        private readonly GameHistoryService history;
        public FrmHistory(GameHistoryService history)
        {
            InitializeComponent();
            this.history = history;
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvHistory.DataSource = null;
            dgvHistory.DataSource = history.GetResults();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "JSON files (*.json)|*.json";
            dialog.Title = "Save Game History";
            dialog.FileName = "GameHistory.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    history.SaveHistory(dialog.FileName);

                    MessageBox.Show("Game history saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving history: " + ex.Message);
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "JSON files (*.json)|*.json";
            dialog.Title = "Load Game History";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    history.LoadHistory(dialog.FileName);
                    RefreshGrid();

                    MessageBox.Show("Game history loaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading history: " + ex.Message);
                }
            }
            if (history.HasUnsavedChanges)
            {
                DialogResult choice = MessageBox.Show(
                    "Loading another history file will replace your unsaved results. Continue?",
                    "Unsaved Game History",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (choice != DialogResult.Yes)
                    return;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sortByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history.SortByName();
            RefreshGrid();
        }

        private void sortByScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history.SortByScore();
            RefreshGrid();
        }

        private void sortByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            history.SortByDate();
            RefreshGrid();
        }
    }
}
