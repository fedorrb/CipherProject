using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml;
using System.IO;

namespace CipherProject
{
    public class UserLogin
    {
        private bool isLogin;
        private string sUserPass;
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public UserLogin()
        {
            sUserPass = String.Empty;
            isLogin = true;// false;
        }
        /// <summary>
        /// истина если пользователь и пароль совпали
        /// после изменения пользователя вызвать Validate()
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            return(isLogin); 
        }
        /// <summary>
        /// функция проверяет правильность пароля
        /// </summary>
        public void Validate()
        {
            isLogin = true;
        }
        /// <summary>
        /// запомнить введенный пароль
        /// </summary>
        /// <param name="p">пароль</param>
        public void SetPass(string p)
        {
            sUserPass = p;
        }
    }
}
