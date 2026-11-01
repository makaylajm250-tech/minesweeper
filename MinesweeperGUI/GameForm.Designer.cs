namespace MinesweeperGUI
{
    partial class GameForm
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
            pnlBoard = new Panel();
            btnReveal = new Button();
            btnRestart = new Button();
            btnFlagMode = new Button();
            lblGameStatus = new Label();
            tlpBoard = new TableLayoutPanel();
            pnlBoard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBoard
            // 
            pnlBoard.AutoScroll = true;
            pnlBoard.Controls.Add(btnReveal);
            pnlBoard.Controls.Add(btnRestart);
            pnlBoard.Controls.Add(btnFlagMode);
            pnlBoard.Controls.Add(lblGameStatus);
            pnlBoard.Dock = DockStyle.Fill;
            pnlBoard.Location = new Point(0, 0);
            pnlBoard.Name = "pnlBoard";
            pnlBoard.Size = new Size(993, 973);
            pnlBoard.TabIndex = 0;
            pnlBoard.Click += BtnReveal_Click;
            // 
            // btnReveal
            // 
            btnReveal.BackColor = Color.CornflowerBlue;
            btnReveal.ForeColor = Color.MidnightBlue;
            btnReveal.Location = new Point(12, 522);
            btnReveal.Name = "btnReveal";
            btnReveal.Size = new Size(149, 54);
            btnReveal.TabIndex = 3;
            btnReveal.Text = "Vist Cell";
            btnReveal.UseVisualStyleBackColor = false;
            // 
            // btnRestart
            // 
            btnRestart.BackColor = Color.CornflowerBlue;
            btnRestart.ForeColor = Color.MidnightBlue;
            btnRestart.Location = new Point(374, 522);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(138, 54);
            btnRestart.TabIndex = 2;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = false;
            btnRestart.Click += BtnRestart_Click;
            // 
            // btnFlagMode
            // 
            btnFlagMode.BackColor = Color.CornflowerBlue;
            btnFlagMode.ForeColor = Color.MidnightBlue;
            btnFlagMode.Location = new Point(193, 522);
            btnFlagMode.Name = "btnFlagMode";
            btnFlagMode.Size = new Size(156, 54);
            btnFlagMode.TabIndex = 1;
            btnFlagMode.Text = "Flag Cell";
            btnFlagMode.UseVisualStyleBackColor = false;
            btnFlagMode.Click += BtnFlagMode_Click;
            // 
            // lblGameStatus
            // 
            lblGameStatus.AutoSize = true;
            lblGameStatus.Dock = DockStyle.Top;
            lblGameStatus.Location = new Point(0, 0);
            lblGameStatus.Name = "lblGameStatus";
            lblGameStatus.Size = new Size(190, 32);
            lblGameStatus.TabIndex = 0;
            lblGameStatus.Text = "Game in process";
            lblGameStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlpBoard
            // 
            tlpBoard.AutoSize = true;
            tlpBoard.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpBoard.BackColor = SystemColors.Control;
            tlpBoard.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpBoard.ColumnCount = 2;
            tlpBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBoard.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpBoard.Location = new Point(10, 40);
            tlpBoard.Margin = new Padding(0);
            tlpBoard.Name = "tlpBoard";
            tlpBoard.RowCount = 2;
            tlpBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpBoard.Size = new Size(3, 3);
            tlpBoard.TabIndex = 1;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 973);
            Controls.Add(tlpBoard);
            Controls.Add(pnlBoard);
            Name = "GameForm";
            Text = "GameForm";
            pnlBoard.ResumeLayout(false);
            pnlBoard.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlBoard;
        private TableLayoutPanel tlpBoard;
        private Label lblGameStatus;
        private Button btnRestart;
        private Button btnFlagMode;
        private Button btnReveal;
    }
}