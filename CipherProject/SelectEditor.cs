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
    public partial class SelectEditor : Form
    {
        public string pathToEditor;

        public SelectEditor()
        {
            InitializeComponent();
            pathToEditor = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pathToEditor = textBox1.Text;
        }

        private void SelectEditor_Load(object sender, EventArgs e)
        {
            textBox1.Text = pathToEditor;
        }
    }
}
