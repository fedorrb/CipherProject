using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;
using System.Security.Principal;
using System.Threading;

namespace CipherProject
{
    public partial class LoginForm : Form
    {
        private string masOfSimvol;

        public UserLogin uLogin;

        public AppEvents evt = new AppEvents(); //событие

        private const int CS_NOCLOSE = 0x200;
        /// <summary>
        /// Переопределение параметров создания формы.
        /// Убрать кнопку закрытия окна.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                return cp;
            }
        }

        public LoginForm()
        {
            InitializeComponent();
            uLogin = new UserLogin();
            masOfSimvol = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefgijklmnopqrstuvwxyz1234567890" +  
                @"`~!@#$%^*()_+|-=\[]{};:'/?.,<>";
        }

        public void GetUserLogin(UserLogin ul)
        {
            uLogin = ul;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uLogin.SetPass("");
            evt.OnStringEvt(""); //вызов события
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uLogin.SetPass(textBox2.Text);
            //событие возвращает значение из LoginForm в Form1
            evt.OnStringEvt(textBox3.Text); //вызов события
            this.Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl(textBox2, true, true, false, true);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CreateButtons();
        }
        /// <summary>
        /// Обработка кликов на кнопки с символами
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e"></param>
        private void ButtonsClick(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            Button b = (Button)(sender);
            textBox3.Text += b.Text.ToString();
        }
        /// <summary>
        /// нарисовать кнопки с символами, добавить кнопки
        /// на panel1 и определить событие Click
        /// </summary>
        private void CreateButtons()
        {
            for (int i = 161; i < 190; i++)
            {
                char specialChar = Convert.ToChar(i);
                masOfSimvol = specialChar.ToString() + masOfSimvol;
            }
            int k = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 12; j++)
                {
                    if (masOfSimvol.Length - 1 < k)
                    {
                        k = masOfSimvol.Length - 1;
                        break;
                    }
                    Button bt1 = new Button();
                    bt1.Size = new Size(39, 35);
                    bt1.Location = new Point(j * 39, i * 35);
                    bt1.TabStop = false;
                    bt1.FlatStyle = FlatStyle.Standard;
                    bt1.Text = masOfSimvol[k].ToString();
                    bt1.Click += ButtonsClick;
                    panel1.Controls.Add(bt1);
                    k++;
                }
        }
    }
}
