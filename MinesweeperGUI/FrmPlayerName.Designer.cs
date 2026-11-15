namespace MinesweeperGUI
{
    partial class FrmPlayerName
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
            lblPlayerName = new Label();
            txtPlayerName = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblPlayerName
            // 
            lblPlayerName.AutoSize = true;
            lblPlayerName.Location = new Point(27, 27);
            lblPlayerName.Name = "lblPlayerName";
            lblPlayerName.Size = new Size(154, 32);
            lblPlayerName.TabIndex = 0;
            lblPlayerName.Text = "Player Name:";
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(203, 24);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(257, 39);
            txtPlayerName.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(524, 20);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(111, 46);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOK_ClickEH;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(641, 20);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 46);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_ClickEH;
            // 
            // FrmPlayerName
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtPlayerName);
            Controls.Add(lblPlayerName);
            Name = "FrmPlayerName";
            Text = "FrmPlayerName";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayerName;
        private TextBox txtPlayerName;
        private Button btnOK;
        private Button btnCancel;
    }
}