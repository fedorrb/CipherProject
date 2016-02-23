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
    public partial class Pass : Form
    {
        public Pass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                UserLogin ul = new UserLogin();
                ul.SaveHashKeyFile(textBox1.Text);
            }
            this.Close();
        }
    }
}
