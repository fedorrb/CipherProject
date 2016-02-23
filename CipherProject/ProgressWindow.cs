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
    public partial class ProgressWindow : Form
    {
        public ProgressWindow()
        {
            InitializeComponent();
        }

        private void ProgressWindow_Load(object sender, EventArgs e)
        {
            label1.Text = StaticClass.nameOperation.ToString();
            progressBar1.Maximum = StaticClass.progressMax1;
            cancelBtn.Enabled = true;
            timer1.Enabled = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cancel process?", "Cancel?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                StaticClass.cancel = true;
                timer1.Enabled = false;
                cancelBtn.Enabled = false;
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = StaticClass.progressValue1;
            progressBar2.Maximum = StaticClass.progressMax2;
            progressBar2.Value = StaticClass.progressValue2;
            if(StaticClass.fileName != null)
                label2.Text = StaticClass.fileName;
        }
    }
}
