namespace MinesweeperGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPlayMinesweeper = new Label();
            lblSize = new Label();
            lblPercentBombs = new Label();
            btnPlay = new Button();
            TbSize = new TrackBar();
            TbBombs = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)TbSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TbBombs).BeginInit();
            SuspendLayout();
            // 
            // lblPlayMinesweeper
            // 
            lblPlayMinesweeper.AutoSize = true;
            lblPlayMinesweeper.Location = new Point(39, 35);
            lblPlayMinesweeper.Name = "lblPlayMinesweeper";
            lblPlayMinesweeper.Size = new Size(207, 32);
            lblPlayMinesweeper.TabIndex = 0;
            lblPlayMinesweeper.Text = "Play Minesweeper";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(39, 113);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(57, 32);
            lblSize.TabIndex = 3;
            lblSize.Text = "Size";
            // 
            // lblPercentBombs
            // 
            lblPercentBombs.AutoSize = true;
            lblPercentBombs.Location = new Point(39, 298);
            lblPercentBombs.Name = "lblPercentBombs";
            lblPercentBombs.Size = new Size(202, 32);
            lblPercentBombs.TabIndex = 4;
            lblPercentBombs.Text = "Percent of Bombs";
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(235, 469);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(150, 46);
            btnPlay.TabIndex = 7;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // TbSize
            // 
            TbSize.Location = new Point(39, 163);
            TbSize.Name = "TbSize";
            TbSize.Size = new Size(572, 90);
            TbSize.TabIndex = 8;
            // 
            // TbBombs
            // 
            TbBombs.Location = new Point(39, 353);
            TbBombs.Name = "TbBombs";
            TbBombs.Size = new Size(572, 90);
            TbBombs.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 549);
            Controls.Add(TbBombs);
            Controls.Add(TbSize);
            Controls.Add(btnPlay);
            Controls.Add(lblPercentBombs);
            Controls.Add(lblSize);
            Controls.Add(lblPlayMinesweeper);
            Name = "Form1";
            Text = "Start a new Game ";
            ((System.ComponentModel.ISupportInitialize)TbSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)TbBombs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayMinesweeper;
        private HScrollBar hScrollBar1;
        private Label lblSize;
        private Label lblPercentBombs;
        private Button btnPlay;
        private TrackBar TbSize;
        private TrackBar TbBombs;
    }
}
