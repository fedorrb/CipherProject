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
        private const int BLOCK_SIZE = 131072;
        //
        private int currentPosition; // текущая позиция в файле
        private int maxPosition; // текущая позиция в файле
        private Decoder decoder;
        private string decoderName;

        public ViewForm()
        {
            InitializeComponent();
            viewFileName = String.Empty;
            nameDecoder = new List<string>();
            decoderList = new List<Decoder>();
            InitDecoderList();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            CreateButtons();
            currentPosition = 0;
            maxPosition = GetMaxPosition(viewFileName);
            vScrollBar1.Maximum = (int)maxPosition;
            if (maxPosition == 0)
                vScrollBar1.Visible = false;
            else
                vScrollBar1.Visible = true;

            // Подписка на событие прокрутки колеса мыши
            textBoxView.MouseWheel += richTextBox1_MouseWheel;
            decoder = decoderList[0];
            decoderName = nameDecoder[0];
            // Отображение части файла
            dViewFile();
        }

        private void richTextBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Обработка события прокрутки колеса мыши
            int pos = textBoxView.GetLineFromCharIndex(textBoxView.SelectionStart);
            if (e.Delta < 0)
            {
                NextPosition();
            }
            else
            {
                PrevPosition();
            }
        }

        private void NextPosition()
        {
            if (vScrollBar1.Value < maxPosition)
                vScrollBar1.Value++;
        }

        private void PrevPosition()
        {
            if (vScrollBar1.Value > 0)
                vScrollBar1.Value--;
        }

        /// <summary>
        /// список названий декодеров
        /// </summary>
        private void InitNameDecoder()
        {
            nameDecoder.Clear();
            nameDecoder.Add("utf-8");
            nameDecoder.Add("us-ascii");
            nameDecoder.Add("windows-1250");
            nameDecoder.Add("windows-1251");
            nameDecoder.Add("windows-1252");
            nameDecoder.Add("windows-1253");
            nameDecoder.Add("windows-1254");
            nameDecoder.Add("windows-1255");
            nameDecoder.Add("windows-1256");
            nameDecoder.Add("windows-1257");
            nameDecoder.Add("windows-1258");
            nameDecoder.Add("ibm850");
            nameDecoder.Add("cp866");
            nameDecoder.Add("big5");
            nameDecoder.Add("shift_jis");
            nameDecoder.Add("koi8-u");

            // Create two different encodings.
            //Encoding unicode = Encoding.Unicode;
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
        /// Обработка кликов
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e"></param>
        private void ButtonsClick(object sender, EventArgs e)
        {
            Button b = (Button)(sender);
            decoder = Encoding.GetEncoding(b.Text.ToString()).GetDecoder();
            decoderName = b.Text.ToString();
            dViewFile();
            textBoxView.Focus();
        }
        /// <summary>
        /// нарисовать кнопки, добавить кнопки
        /// и определить событие Click
        /// </summary>
        private void CreateButtons()
        {
            DecoderButtonsPanel.Controls.Clear();
            int buttonWidth = DecoderButtonsPanel.Width - 5;
            int buttonHeight = 35;
            nameDecoder.Reverse();
            int y = 0;
            foreach (string dcoderName in nameDecoder)
            {
                Button bt1 = new Button();
                bt1.Size = new Size(buttonWidth, buttonHeight);
                bt1.Location = new Point(1, y * buttonHeight);
                bt1.TabStop = false;
                bt1.FlatStyle = FlatStyle.Flat;
                bt1.Text = dcoderName;
                bt1.Click += ButtonsClick;
                bt1.Dock = DockStyle.Top;
                DecoderButtonsPanel.Controls.Add(bt1);
                y++;
            }
            nameDecoder.Reverse();
        }

        public void dViewFile()
        {
            textBoxView.Clear();
            List<string> strArr = new List<string>();
            int position = currentPosition * BLOCK_SIZE;

            if (File.Exists(viewFileName))
            {
                int sizeArray = BLOCK_SIZE;
                try
                {
                    FileStream aFile = new FileStream(viewFileName, FileMode.Open, FileAccess.Read);
                    byte[] byData = new byte[sizeArray];
                    char[] charData = new char[sizeArray];
                    aFile.Seek(position, SeekOrigin.Begin);
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
                    if (sim > 0)
                        strArr.Add(sb.ToString());
                    textBoxView.Lines = strArr.ToArray();
                    textBoxView.Select(0, 0);//снять выделение
                    toolStripStatusLabel1.Text = decoderName;
                    toolStripStatusLabel2.Text = viewFileName;
                }
                catch
                {
                    return;
                }
            }
        }

        // Метод для определения кодировки текстового файла
        private Encoding GetFileEncoding(string filePath)
        {
            // Читаем первые несколько байт файла для определения кодировки
            byte[] buffer = new byte[4];
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                fileStream.Read(buffer, 0, 4);
            }

            // Проверяем кодировки по сигнатурам байтов
            if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
            {
                return Encoding.UTF8; // UTF-8
            }
            else if (buffer[0] == 0xff && buffer[1] == 0xfe)
            {
                return Encoding.Unicode; // UTF-16 (LE)
            }
            else if (buffer[0] == 0xfe && buffer[1] == 0xff)
            {
                return Encoding.BigEndianUnicode; // UTF-16 (BE)
            }
            else
            {
                return Encoding.Default; // Остальные кодировки
            }
        }

        private int GetMaxPosition(string filePath)
        {
            FileStream instream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            int maxPosition = (int)(instream.Length / BLOCK_SIZE);
            instream.Close();
            return maxPosition;
        }

        private void ViewForm_KeyDown(object sender, KeyEventArgs e)
        {
            int oldPos = currentPosition;
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F)
            {
                DialogResult result = fontDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Font font = fontDialog1.Font;
                    this.textBoxView.Font = font;
                }
            }
            if (e.KeyCode == Keys.PageDown)
            {
                if(maxPosition > 0)
                {
                    if(currentPosition != maxPosition)
                    {
                        NextPosition();
                        //MoveCursorToStart();
                        e.Handled = true;
                    }
                }
            }
            if (e.KeyCode == Keys.PageUp)
            {
                if (maxPosition > 0)
                {
                    if (currentPosition != 0)
                    {
                        PrevPosition();
                        //MoveCursorToEnd();
                        e.Handled = true;
                    }
                }
            }
        }

        private bool CursorOnFirstLine()
        {
            int currentLine = textBoxView.GetLineFromCharIndex(textBoxView.SelectionStart);
            if (currentLine > 0)
                return false;
            else
                return true;
        }

        private bool CursorOnLastLine()
        {
            int currentLine = textBoxView.GetLineFromCharIndex(textBoxView.SelectionStart);
            int lineStartIndex = textBoxView.Lines.Length;

            if (currentLine == lineStartIndex)
                return true;
            else
                return false;
        }

        // Перемещение курсора в начало текста
        private void MoveCursorToStart()
        {
            textBoxView.SelectionStart = 0;
            textBoxView.ScrollToCaret();
        }

        // Перемещение курсора в конец текста
        private void MoveCursorToEnd()
        {
            textBoxView.SelectionStart = textBoxView.Text.Length;
            textBoxView.ScrollToCaret();
        }

        private void textBoxView_VScroll(object sender, EventArgs e)
        {
            // При прокрутке RichTextBox обновляем отображение
            currentPosition = vScrollBar1.Value;
                dViewFile();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
            {
                currentPosition = vScrollBar1.Value;
                dViewFile();
            }
        }

        private void textBoxView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                NextPosition();
            }
        }

    }
}
