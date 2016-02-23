using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CipherProject
{
    public partial class MakeDir : Form
    {
        public string nameDir {get; set;}

        public MakeDir()
        {
            InitializeComponent();
            nameDir = String.Empty;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
        }

        private void createDirBtn_Click(object sender, EventArgs e)
        {
            nameDir = textBox1.Text;
            nameDir.Trim();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(textBox1, true, true, false, true);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetterOrDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
                e.Handled = true;
        }
    }
}
