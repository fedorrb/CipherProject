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
            isLogin = false;
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
            //пароль для входа
            string hash;//хэш в виде строки
            string salt;//строка набор символов и пароль
            byte[] mas; //массив байтов для вычисления хэша
            salt = @"y8#?u5kNhw" + sUserPass;
            byte[] saltedPwBytes1 = Encoding.UTF8.GetBytes(salt);//сформировать массив байтов из соли(набор символов + пароль) (UTF8,UNICODE)
            WhirlpoolManaged wm = new WhirlpoolManaged(); //создание новой спиральной хэш функции
            mas = wm.ComputeHash(saltedPwBytes1);//получить спиральную хэш функцию в виде массива байтов
            hash = Convert.ToBase64String(mas); //преобразовать в строку
            //чтение файла ключа и сравнение содержимого в hash и файле
            if (hash == GetHashKeyFile())
            {
                isLogin = true;
                string path = String.Empty;
                path = System.IO.Directory.GetCurrentDirectory();
                path += @"\key1.txt";
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);//удалить key1.txt
                }
            }
            else
                isLogin = false;
            sUserPass = String.Empty;
            hash = String.Empty;
            saltedPwBytes1 = Encoding.UTF8.GetBytes("");
            mas = wm.ComputeHash(saltedPwBytes1);
        }
        /// <summary>
        /// получение данных из файла
        /// значение хэша по паролю пользователя
        /// </summary>
        private string GetHashKeyFile()
        {
            string str = String.Empty;
            string path = String.Empty;
            path = System.IO.Directory.GetCurrentDirectory();
            path += @"\key.txt";
            if(System.IO.File.Exists(path))
            {
                try
                {
                    //string[] allLines = System.IO.File.ReadAllLines(path);
                    str = System.IO.File.ReadAllText(path);
                    return (str);
                }
                catch
                {
                    return (str);
                }
            }
            else
            {
                return (str);
            }
        }
        /// <summary>
        /// запись в файл ключа
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public void SaveHashKeyFile(string s)
        {
            //пароль для входа
            string hash;//хэш в виде строки
            string salt;//строка набор символов и пароль
            byte[] mas; //массив байтов для вычисления хэша
            salt = @"y8#?u5kNhw" + s;
            byte[] saltedPwBytes1 = Encoding.UTF8.GetBytes(salt);//сформировать массив байтов из соли(набор символов + пароль) (UTF8,UNICODE)
            WhirlpoolManaged wm = new WhirlpoolManaged(); //создание новой спиральной хэш функции
            mas = wm.ComputeHash(saltedPwBytes1);//получить спиральную хэш функцию в виде массива байтов
            hash = Convert.ToBase64String(mas); //преобразовать в строку

            string path = String.Empty;
            string path1 = String.Empty;
            string path2 = String.Empty;
            path = System.IO.Directory.GetCurrentDirectory();
            path1 = path + @"\key.txt";
            path2 = path + @"\key1.txt";
            if (System.IO.File.Exists(path1))
            {
                //переименовать файл
                System.IO.File.Copy(path1, path2, true);
            }
            System.IO.File.WriteAllText(path1, hash);
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
