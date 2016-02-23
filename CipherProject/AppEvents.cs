using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CipherProject
{
    public delegate void StringHandler(object sender, StringArg ar);
    public class StringArg : EventArgs //аргумент события
    {
        public string str;
        public StringArg(string s)
        {
            str = s;
        }
    }
    public class AppEvents //класс события
    {
        public event StringHandler evt;
        public void OnStringEvt(string s)
        {
            if (evt != null)
                evt(this, new StringArg(s));
        }
    }
}
