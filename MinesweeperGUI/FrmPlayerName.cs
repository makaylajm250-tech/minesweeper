using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinesweeperGUI
{
    public partial class FrmPlayerName : Form
    {
        public FrmPlayerName()
        {
            InitializeComponent();
        }

        public string PlayerName { get; private set; }

        private void BtnOK_ClickEH(object? sender, EventArgs e)
        {
            string name = txtPlayerName.Text.Trim();

            if (name.Length < 1 || name.Length > 50)
            {
                MessageBox.Show("Enter a name between 1 and 50 characters.");
                txtPlayerName.Focus();
                return;
            }

            PlayerName = name;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_ClickEH(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
