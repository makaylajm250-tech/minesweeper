namespace MinesweeperGUI
{
    partial class FrmHistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvHistory = new DataGridView();
            mnuHistory = new MenuStrip();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            sortByNameToolStripMenuItem = new ToolStripMenuItem();
            sortByScoreToolStripMenuItem = new ToolStripMenuItem();
            sortByDateToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            mnuHistory.SuspendLayout();
            SuspendLayout();
            // 
            // dgvHistory
            // 
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Location = new Point(12, 74);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.RowHeadersWidth = 82;
            dgvHistory.Size = new Size(1266, 353);
            dgvHistory.TabIndex = 0;
            // 
            // mnuHistory
            // 
            mnuHistory.ImageScalingSize = new Size(32, 32);
            mnuHistory.Items.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, closeToolStripMenuItem, sortByNameToolStripMenuItem, sortByScoreToolStripMenuItem, sortByDateToolStripMenuItem });
            mnuHistory.Location = new Point(0, 0);
            mnuHistory.Name = "mnuHistory";
            mnuHistory.Size = new Size(1290, 42);
            mnuHistory.TabIndex = 1;
            mnuHistory.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(84, 38);
            saveToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(85, 38);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(92, 38);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // sortByNameToolStripMenuItem
            // 
            sortByNameToolStripMenuItem.Name = "sortByNameToolStripMenuItem";
            sortByNameToolStripMenuItem.Size = new Size(181, 38);
            sortByNameToolStripMenuItem.Text = "Sort by Name";
            sortByNameToolStripMenuItem.Click += sortByNameToolStripMenuItem_Click;
            // 
            // sortByScoreToolStripMenuItem
            // 
            sortByScoreToolStripMenuItem.Name = "sortByScoreToolStripMenuItem";
            sortByScoreToolStripMenuItem.Size = new Size(176, 38);
            sortByScoreToolStripMenuItem.Text = "Sort by Score";
            sortByScoreToolStripMenuItem.Click += sortByScoreToolStripMenuItem_Click;
            // 
            // sortByDateToolStripMenuItem
            // 
            sortByDateToolStripMenuItem.Name = "sortByDateToolStripMenuItem";
            sortByDateToolStripMenuItem.Size = new Size(167, 38);
            sortByDateToolStripMenuItem.Text = "Sort by Date";
            sortByDateToolStripMenuItem.Click += sortByDateToolStripMenuItem_Click;
            // 
            // FrmHistory
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1290, 450);
            Controls.Add(dgvHistory);
            Controls.Add(mnuHistory);
            MainMenuStrip = mnuHistory;
            Name = "FrmHistory";
            Text = "FrmHistory";
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            mnuHistory.ResumeLayout(false);
            mnuHistory.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHistory;
        private MenuStrip mnuHistory;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem sortByNameToolStripMenuItem;
        private ToolStripMenuItem sortByScoreToolStripMenuItem;
        private ToolStripMenuItem sortByDateToolStripMenuItem;
    }
}