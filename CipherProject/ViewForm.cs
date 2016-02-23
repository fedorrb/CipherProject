using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CipherProject
{
    public partial class ViewForm : Form
    {
        public string viewFileName { get; set; }
        private List<string> nameDecoder;
        private List<Decoder> decoderList;
        private int decoderPosition;

        public ViewForm()
        {
            InitializeComponent();
            viewFileName = String.Empty;
            nameDecoder = new List<string>();
            decoderList = new List<Decoder>();
            decoderPosition = 0;
            InitDecoderList();
        }
        /// <summary>
        /// показать файл
        /// </summary>
        private void ShowViewFile()
        {
            ViewFile(textBoxView, decoderList[decoderPosition]);
        }
        /// <summary>
        /// подготовить список декодеров текста
        /// </summary>
        private void InitDecoderList()
        {
            InitNameDecoder();
            decoderList.Clear();
            foreach (string dec in nameDecoder)
            {
                Decoder decoder = Encoding.GetEncoding(dec).GetDecoder();
                decoderList.Add(decoder);
            }
        }
        /// <summary>
        /// список названий декодеров
        /// </summary>
        private void InitNameDecoder()
        {
            nameDecoder.Clear();
            nameDecoder.Add("windows-1251");
            nameDecoder.Add("koi8-r");
            nameDecoder.Add("utf-8");
            nameDecoder.Add("IBM855");
            nameDecoder.Add("cp866");
            nameDecoder.Add("IBM880");
            nameDecoder.Add("koi8-u");
            nameDecoder.Add("utf-7");
            nameDecoder.Add("utf-32");
            nameDecoder.Add("x-mac-ukrainian");
            nameDecoder.Add("x-mac-cyrillic");
            nameDecoder.Add("utf-16");
        }

        public void ViewFile(TextBox txtBox, Decoder decoder)
        {
            textBoxView.Text = "";
            List<string> strArr = new List<string>();

            if (File.Exists(viewFileName))
            {
                int sizeArray = 1048576;
                try
                {
                    FileStream aFile = new FileStream(viewFileName, FileMode.Open);
                    //sizeArray = Convert.ToInt32(aFile.Length);
                    byte[] byData = new byte[sizeArray];
                    char[] charData = new char[sizeArray];
                    aFile.Seek(0, SeekOrigin.Begin);
                    aFile.Read(byData, 0, sizeArray);
                    aFile.Close();

                    Array.Clear(charData, 0, sizeArray);
                    decoder.GetChars(byData, 0, byData.Length, charData, 0);
                    int simmbolInLine = 128;//кол-во символов в строке
                    int sim = 0;
                    StringBuilder sb = new StringBuilder();
                    foreach (char ch in charData)
                    {
                        Application.DoEvents();
                        //формировать строку заданной длины или до символа новой строки
                        if (ch != '\r' && ch != '\n' && ch != '\0')
                        {
                            sb.Append(ch);
                            sim++;
                        }
                        
                        if (sim >= simmbolInLine || ch == '\n')// || ch == '\0')
                        {
                            strArr.Add(sb.ToString());
                            sb.Clear();
                            sim = 0;
                        }

                    }
                    if(sim > 0)
                        strArr.Add(sb.ToString());
                    textBoxView.Lines = strArr.ToArray();
                    textBoxView.Select(0, 0);//снять выделение
                    toolStripStatusLabel1.Text = nameDecoder[decoderPosition].ToString();
                    toolStripStatusLabel2.Text = viewFileName;
                }
                catch
                {
                    return;
                }
            }
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NextCharSet();
        }
        /// <summary>
        /// следующий набор символов
        /// </summary>
        private void NextCharSet()
        {
            decoderPosition++;
            if (decoderPosition >= decoderList.Count)
            {
                decoderPosition = 0;
            }
            ShowViewFile();
        }

        private void prevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrevCharSet();
        }
        /// <summary>
        /// предыдущий набор символов
        /// </summary>
        private void PrevCharSet()
        {
            decoderPosition--;
            if (decoderPosition < 0)
            {
                decoderPosition = decoderList.Count - 1;
            }
            ShowViewFile();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            ShowViewFile();
        }

        private void ViewForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.KeyCode == Keys.F3)
            {
                NextCharSet();
            }
            if (e.KeyCode == Keys.F4)
            {
                PrevCharSet();
            }

        }
    }
}
