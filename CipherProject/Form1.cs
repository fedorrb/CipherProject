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
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;

namespace CipherProject
{
    public partial class CipherProject : Form
    {
        public enum FileType
        {
            File,
            Directory,
            Unknown
        }

        private stPath stPathFiles;//пути для зашифрованных и расшифрованных файлов
        private UserLogin userLogin = new UserLogin();//экземпляр класса аутентификации пользователя
        private string sPass; //пароль через событие
        private DriveButtons driveButtons; //кнопки дисков
        private enum NameListView { left, right }
        private NameListView activeListView;
        private string fileNameBefore;
        // константа для создания формы без кнопки закрытия
        //private const int CS_NOCLOSE = 0x200;
        // Переопределение параметров создания формы.
        // Убрать кнопку закрытия окна.
        /*
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_NOCLOSE;
                return cp;
            }
        }
        */
        ToolTip tips;

        public CipherProject()
        {
            InitializeComponent();

            listLeft.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            listLeft.ForeColor = System.Drawing.Color.Black;
            listRight.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            listRight.ForeColor = System.Drawing.Color.Black;

            ResizeActionButton();
            stPathFiles = new stPath();
            stPathFiles.LoadIniFile();
            listLeft.SetSortOrder(stPathFiles.SortOrderLeft);
            listRight.SetSortOrder(stPathFiles.SortOrderRight);
            listLeft.pathToEditorProg = stPathFiles.ProgForEditing;
            listRight.pathToEditorProg = stPathFiles.ProgForEditing;
            driveButtons = new DriveButtons(leftDrivePanel, rightDrivePanel);
            driveButtons.DrawButtonDrive();
            AddEventButtonDrive();
            CheckMenuItem();
            ActiveControl = listLeft;
            tips = new ToolTip();
            fileNameBefore = String.Empty;
            listLeft.LabelEdit = true;
            listRight.LabelEdit = true;
            AddEventListView();
            ClearPassword();
        }

        private void CheckMenuItem()
        {
            if (stPathFiles.CryptoAlgoritm == 0)
            {
                rijndaelToolStripMenuItem.Checked = true;
                threeFishToolStripMenuItem.Checked = false;
            }
            else
            {
                rijndaelToolStripMenuItem.Checked = false;
                threeFishToolStripMenuItem.Checked = true;
            }
            if (stPathFiles.SignDelete == 0)
            {
                deleteSourceToolStripMenuItem.Checked = false;
            }
            else
            {
                deleteSourceToolStripMenuItem.Checked = true;
            }

            addRandomBlockToolStripMenuItem.Checked = true;
            stPathFiles.AddRandomBlock = 1;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitProgram();
        }

        private void ExitProgram()
        {
            ClearPassword();
            DialogResult result = MessageBox.Show("Exit the program?", "Exit?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                stPathFiles.SortOrderLeft = listLeft.GetSortOrder();
                stPathFiles.SortOrderRight = listRight.GetSortOrder();
                stPathFiles.OldLeftDir = listLeft.bottomText;
                stPathFiles.OldRightDir = listRight.bottomText;
                stPathFiles.SaveIniFile();
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aboutme aboutMe = new Aboutme();
            aboutMe.ShowDialog();
        }

        private void splitContainer1_SizeChanged(object sender, EventArgs e)
        {
            if (splitContainer1.Size.Width > 100 && driveButtons != null)
            {
                splitContainer1.SplitterDistance = splitContainer1.Size.Width / 2;
                driveButtons.ResizeButton();
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (splitContainer1.Size.Width > 100)
            {
                splitContainer1.SplitterDistance = splitContainer1.Size.Width / 2;
            }
        }

        private void CipherProject_Load(object sender, EventArgs e)
        {
            sPass = String.Empty;
            this.Activate();
            this.buttonsPanel.Enabled = true;
            this.splitContainer1.Enabled = true;
            if (stPathFiles.OldLeftDir.Length > 0)
            {
                listLeft.bottomText = stPathFiles.OldLeftDir;
                listLeft.newFolder = stPathFiles.OldLeftDir;
                listLeft.RefillList();
            }
            else
                listLeft.FillList();
            if (stPathFiles.OldRightDir.Length > 0)
            {
                listRight.bottomText = stPathFiles.OldRightDir;
                listRight.newFolder = stPathFiles.OldRightDir;
                listRight.RefillList();
            }
            else
                listRight.FillList();
        }

        private void ShowLoginForm()
        {
            sPass = String.Empty;//password
            LoginForm loginForm = new LoginForm();//создание новой формы аутентификации
            loginForm.GetUserLogin(userLogin);//вызов метода и передача ему экземпляра класса userLogin
            loginForm.evt.evt += delegate(object o, StringArg ar) //используем анонимный делегат для упрощения кода
            {
                //событие срабатывает после закрытия окна аутентификации
                if (ar.str != null)
                {
                    this.Activate();
                    sPass = ar.str;//получить пароль
                    ar.str = String.Empty;//очистка
                    menuStrip1.Items[2].Enabled = true;
                }
            };
            //показать форму аутентификации
            loginForm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userLogin.IsLogin())//если имя и пароль соответствуют то разрешаем работу
            {
                //
            }
        }

        private void rijndaelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stPathFiles.CryptoAlgoritm = 0;
            rijndaelToolStripMenuItem.Checked = true;
            threeFishToolStripMenuItem.Checked = false;
        }

        private void threeFishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stPathFiles.CryptoAlgoritm = 1;
            rijndaelToolStripMenuItem.Checked = false;
            threeFishToolStripMenuItem.Checked = true;
        }
        /// <summary>
        /// установка признака удаления исходного файла
        /// </summary>
        private void deleteSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deleteSourceToolStripMenuItem.Checked == true)
            {
                deleteSourceToolStripMenuItem.Checked = false;
                stPathFiles.SignDelete = 0;
            }
            else
            {
                deleteSourceToolStripMenuItem.Checked = true;
                stPathFiles.SignDelete = 1;
            }
        }
        #region DriveButtonsEvents
        // обработка событий для кнопок дисков
        private void AddEventButtonDrive()
        {
            foreach (Button btn in leftDrivePanel.Controls)
            {
                btn.MouseClick += DriveButtonsLeft_MouseClick;
                btn.MouseHover += DriveButtons_MouseHover;
            }
            foreach (Button btn in rightDrivePanel.Controls)
            {
                btn.MouseClick += DriveButtonsRight_MouseClick;
                btn.MouseHover += DriveButtons_MouseHover;
            }
        }
        private void DriveButtonsLeft_MouseClick(object sender, MouseEventArgs e)
        {
            Button b = (Button)(sender);
            listLeft.newFolder = b.Text.ToString();
            listLeft.bottomText = b.Text.ToString();
            listLeft.RefillList();
            textBoxLeft.Text = listLeft.bottomText;
        }
        private void DriveButtonsRight_MouseClick(object sender, MouseEventArgs e)
        {
            Button b = (Button)(sender);
            listRight.newFolder = b.Text.ToString();
            listRight.bottomText = b.Text.ToString();
            listRight.RefillList();
            textBoxRight.Text = listRight.bottomText;
        }
        private void DriveButtons_MouseHover(object sender, EventArgs e)
        {
            // Выводим информацию о диске
            Button b = (Button)(sender);
            System.IO.DriveInfo drv = new System.IO.DriveInfo(b.Text.ToString());
            StringBuilder diskInfo = new StringBuilder();
            diskInfo.AppendLine("Drive: " + drv.Name);
            diskInfo.AppendLine("DriveType: " + drv.DriveType.ToString());
            diskInfo.AppendLine("File system: " + drv.DriveFormat.ToString());
            long freeSpaceMB = (long)(drv.AvailableFreeSpace / (1024 * 1024));
            if (freeSpaceMB < 8192)
            {
                diskInfo.AppendLine("Free disk space: " + freeSpaceMB.ToString() + " MB");
            }
            else
            {
                long freeSpaceGb = (long)(freeSpaceMB / 1024);
                diskInfo.AppendLine("Free disk space: " + freeSpaceGb.ToString() + " GB");
            }

            tips.SetToolTip((Button)sender, diskInfo.ToString());
        }
        #endregion

        #region PanelListViewEvent
        //добавить обработку событий
        private void AddEventListView()
        {
            listRight.BeforeLabelEdit += listView_BeforeLabelEdit;
            listLeft.BeforeLabelEdit += listView_BeforeLabelEdit;
            listRight.AfterLabelEdit += listView_AfterLabelEdit;
            listLeft.AfterLabelEdit += listView_AfterLabelEdit;
        }
        //запомнить имя
        private void listView_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            var plv = (PanelListView)sender;
            if (GetFileType(plv.bottomText + plv.FocusedItem.SubItems[0].Text) == FileType.File)
            {
                fileNameBefore = plv.Items[e.Item].SubItems[0].Text;
            }
        }
        //переименовать файл
        private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (activeListView == NameListView.left)
            {
                listLeft.GetCursorOnFile();
            }
            else
            {
                listRight.GetCursorOnFile();
            }
            if (e.Label != null)
            {
                FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);

                var plv = (PanelListView)sender;
                if (fileNameBefore != "")
                {
                    try
                    {
                        fo.MoveFile(plv.bottomText + fileNameBefore, plv.bottomText + e.Label.ToString());
                    }
                    catch
                    {
                        e.CancelEdit = true;
                    }
                }
                fileNameBefore = String.Empty;
            }
            if (activeListView == NameListView.left)
            {
                listLeft.RefillList();
                listLeft.SetCursorOnFile();
            }
            else
            {
                listRight.RefillList();
                listRight.SetCursorOnFile();
            }
        }
        #endregion

        private void listLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ExitProgram();
            }
            if (e.KeyCode == Keys.F9)
            {
                if (CheckPass())
                {
                    listRight.GetCursorOnFile();
                    listLeft.GetCursorOnFile();
                    FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.EncryptListFiles(listLeft.GetSelectedFiles(), sPass, stPathFiles.CryptoAlgoritm);
                    listRight.RefillList();
                    listLeft.RefillList();
                    listRight.SetCursorOnFile();
                    listLeft.SetCursorOnFile();
                }
                else
                {
                    MessageBox.Show("This operatins needs a password.", "Encrypting canceled!");
                }
            }
            if (e.KeyCode == Keys.F10)
            {
                if (CheckPass())
                {
                    listRight.GetCursorOnFile();
                    listLeft.GetCursorOnFile();
                    FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.DecryptListFiles(listLeft.GetSelectedFiles(), sPass);
                    listRight.RefillList();
                    listLeft.RefillList();
                    listRight.SetCursorOnFile();
                    listLeft.SetCursorOnFile();
                }
                else
                {
                    MessageBox.Show("This operatins needs a password.", "Decrypting canceled!");
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                listRight.GetCursorOnFile();
                listLeft.GetCursorOnFile();
                FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.CopyListFiles(listLeft.GetSelectedFiles(), listLeft.GetSelectedDirectories());
                listRight.RefillList();
                listLeft.RefillList();
                listRight.SetCursorOnFile();
                listLeft.SetCursorOnFile();
            }
            if (e.KeyCode == Keys.F6)
            {
                listRight.GetCursorOnFile();
                listLeft.GetCursorOnFile();
                FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.MoveListFiles(listLeft.GetSelectedFiles(), listLeft.GetSelectedDirectories());
                listRight.RefillList();
                listLeft.RefillList();
                listRight.SetCursorOnFile();
                listLeft.SetCursorOnFile();
            }
            if (e.KeyCode == Keys.F7)
            {
                string nameNewDir = GetNameNewDir();
                if (nameNewDir.Length > 0)
                {
                    FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.MakeDir(nameNewDir);
                    listRight.RefillList();
                    listLeft.RefillList();
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                listRight.GetCursorOnFile();
                listLeft.GetCursorOnFile();
                listRight.RefillList();
                listLeft.RefillList();
                listRight.SetCursorOnFile();
                listLeft.SetCursorOnFile();
            }
            if (e.KeyCode == Keys.F2)
            {
                ClearPassword();
            }
            if(e.KeyCode == Keys.F1)
            {
                Aboutme aboutMe = new Aboutme();
                aboutMe.ShowDialog();
            }
        }

        private void listRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ExitProgram();
            }
            if (e.KeyCode == Keys.F9)
            {
                if (CheckPass())
                {
                    listLeft.GetCursorOnFile();
                    listRight.GetCursorOnFile();
                    FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.EncryptListFiles(listRight.GetSelectedFiles(), sPass, stPathFiles.CryptoAlgoritm);
                    listLeft.RefillList();
                    listRight.RefillList();
                    listLeft.SetCursorOnFile();
                    listRight.SetCursorOnFile();
                }
                else
                {
                    MessageBox.Show("This operatins needs a password.", "Encrypting canceled!");
                }
            }
            if (e.KeyCode == Keys.F10)
            {
                if (CheckPass())
                {
                    listLeft.GetCursorOnFile();
                    listRight.GetCursorOnFile();
                    FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.DecryptListFiles(listRight.GetSelectedFiles(), sPass);
                    listLeft.RefillList();
                    listRight.RefillList();
                    listLeft.SetCursorOnFile();
                    listRight.SetCursorOnFile();
                }
                else
                {
                    MessageBox.Show("This operatins needs a password.", "Decrypting canceled!");
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                listLeft.GetCursorOnFile();
                listRight.GetCursorOnFile();
                FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.CopyListFiles(listRight.GetSelectedFiles(), listRight.GetSelectedDirectories());
                listLeft.RefillList();
                listRight.RefillList();
                listLeft.SetCursorOnFile();
                listRight.SetCursorOnFile();
            }
            if (e.KeyCode == Keys.F6)
            {
                listLeft.GetCursorOnFile();
                listRight.GetCursorOnFile();
                FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.MoveListFiles(listRight.GetSelectedFiles(), listRight.GetSelectedDirectories());
                listLeft.RefillList();
                listRight.RefillList();
                listLeft.SetCursorOnFile();
                listRight.SetCursorOnFile();
            }
            if (e.KeyCode == Keys.F7)
            {
                string nameNewDir = GetNameNewDir();
                if (nameNewDir.Length > 0)
                {
                    FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.MakeDir(nameNewDir);
                    listLeft.RefillList();
                    listRight.RefillList();
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                listLeft.GetCursorOnFile();
                listRight.GetCursorOnFile();
                listLeft.RefillList();
                listRight.RefillList();
                listLeft.SetCursorOnFile();
                listRight.SetCursorOnFile();
            }
            if (e.KeyCode == Keys.F2)
            {
                ClearPassword();
            }
            if (e.KeyCode == Keys.F1)
            {
                Aboutme aboutMe = new Aboutme();
                aboutMe.ShowDialog();
            }
        }
        private void listLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxLeft.Text = listLeft.bottomText.ToString();
        }

        private void listRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxRight.Text = listRight.bottomText.ToString();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            if (activeListView == NameListView.left)
            {
                listRight.GetCursorOnFile();
                listLeft.GetCursorOnFile();
                FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.CopyListFiles(listLeft.GetSelectedFiles(), listLeft.GetSelectedDirectories());
                listRight.RefillList();
                listLeft.RefillList();
                listRight.SetCursorOnFile();
                listLeft.SetCursorOnFile();
            }
            else
            {
                listLeft.GetCursorOnFile();
                listRight.GetCursorOnFile();
                FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.CopyListFiles(listRight.GetSelectedFiles(), listRight.GetSelectedDirectories());
                listLeft.RefillList();
                listRight.RefillList();
                listLeft.SetCursorOnFile();
                listRight.SetCursorOnFile();
            }
        }
        
        private void moveBtn_Click(object sender, EventArgs e)
        {
            if (activeListView == NameListView.left)
            {
                listRight.GetCursorOnFile();
                listLeft.GetCursorOnFile();
                FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.MoveListFiles(listLeft.GetSelectedFiles(), listLeft.GetSelectedDirectories());
                listRight.RefillList();
                listLeft.RefillList();
                listRight.SetCursorOnFile();
                listLeft.SetCursorOnFile();
            }
            else
            {
                listLeft.GetCursorOnFile();
                listRight.GetCursorOnFile();
                FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.MoveListFiles(listRight.GetSelectedFiles(), listRight.GetSelectedDirectories());
                listLeft.RefillList();
                listRight.RefillList();
                listLeft.SetCursorOnFile();
                listRight.SetCursorOnFile();
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (activeListView == NameListView.left)
            {
                listRight.GetCursorOnFile();
                listLeft.GetCursorOnFile();
                FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.DeleteListFiles(listLeft.GetSelectedFiles(), listLeft.GetSelectedDirectories());
                listRight.RefillList();
                listLeft.RefillList();
                listRight.SetCursorOnFile();
                listLeft.SetCursorOnFile();
            }
            else
            {
                listLeft.GetCursorOnFile();
                listRight.GetCursorOnFile();
                FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.DeleteListFiles(listRight.GetSelectedFiles(), listRight.GetSelectedDirectories());
                listLeft.RefillList();
                listRight.RefillList();
                listLeft.SetCursorOnFile();
                listRight.SetCursorOnFile();
            }
        }
        
        private void encodingBtn_Click(object sender, EventArgs e)
        {
            if (CheckPass())
            {
                if (activeListView == NameListView.left)
                {
                    listRight.GetCursorOnFile();
                    listLeft.GetCursorOnFile();
                    FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.EncryptListFiles(listLeft.GetSelectedFiles(), sPass, stPathFiles.CryptoAlgoritm);
                    listRight.RefillList();
                    listLeft.RefillList();
                    listRight.SetCursorOnFile();
                    listLeft.SetCursorOnFile();
                }
                else
                {
                    listLeft.GetCursorOnFile();
                    listRight.GetCursorOnFile();
                    FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.EncryptListFiles(listRight.GetSelectedFiles(), sPass, stPathFiles.CryptoAlgoritm);
                    listLeft.RefillList();
                    listRight.RefillList();
                    listLeft.SetCursorOnFile();
                    listRight.SetCursorOnFile();
                }
            }
            else
            {
                MessageBox.Show("This operatins needs a password.", "Encrypting canceled!");
            }
        }
        
        private void decodingBtn_Click(object sender, EventArgs e)
        {
            if (CheckPass())
            {
                if (activeListView == NameListView.left)
                {
                    listRight.GetCursorOnFile();
                    listLeft.GetCursorOnFile();
                    FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.DecryptListFiles(listLeft.GetSelectedFiles(), sPass);
                    listRight.RefillList();
                    listLeft.RefillList();
                    listRight.SetCursorOnFile();
                    listLeft.SetCursorOnFile();
                }
                else
                {
                    listLeft.GetCursorOnFile();
                    listRight.GetCursorOnFile();
                    FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.DecryptListFiles(listRight.GetSelectedFiles(), sPass);
                    listLeft.RefillList();
                    listRight.RefillList();
                    listLeft.SetCursorOnFile();
                    listRight.SetCursorOnFile();
                }
            }
            else
            {
                MessageBox.Show("This operatins needs a password.", "Decrypting canceled!");
            }
        }
        
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            listLeft.GetCursorOnFile();
            listRight.GetCursorOnFile();
            driveButtons.DrawButtonDrive();
            AddEventButtonDrive();
            listLeft.RefillList();
            listRight.RefillList();
            listLeft.SetCursorOnFile();
            listRight.SetCursorOnFile();
        }

        private void listLeft_Enter(object sender, EventArgs e)
        {
            activeListView = NameListView.left;
        }

        private void listRight_Enter(object sender, EventArgs e)
        {
            activeListView = NameListView.right;
        }

        private void makeDirButton_Click(object sender, EventArgs e)
        {
            string nameNewDir = GetNameNewDir();
            if (nameNewDir.Length > 0)
            {
                if (activeListView == NameListView.left)
                {
                    FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.MakeDir(nameNewDir);
                    listRight.RefillList();
                    listLeft.RefillList();
                }
                else
                {
                    FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                    fo.MakeDir(nameNewDir);
                    listLeft.RefillList();
                    listRight.RefillList();
                }
            }
        }
        /// <summary>
        /// получить название создаваемой папки
        /// </summary>
        /// <returns>имя папки</returns>
        private static string GetNameNewDir()
        {
            string nameDir = String.Empty;
            MakeDir makeDir = new MakeDir();
            if (makeDir.ShowDialog() == DialogResult.OK)
                nameDir = makeDir.nameDir;
            makeDir.Close();
            return nameDir;
        }
        /// <summary>
        /// выбрать программу для редактирования
        /// </summary>
        private void programForEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectEditor selectProg = new SelectEditor
            {
                pathToEditor = stPathFiles.ProgForEditing
            };
            if (selectProg.ShowDialog() == DialogResult.OK)
            {
                stPathFiles.ProgForEditing = selectProg.pathToEditor;
                listLeft.pathToEditorProg = stPathFiles.ProgForEditing;
                listRight.pathToEditorProg = stPathFiles.ProgForEditing;
            }            
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (activeListView == NameListView.left)
            {
                FileOperation fo = new FileOperation(listLeft.bottomText, listRight.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.EditFile(listLeft.pathToEditorProg, listLeft.GetFocusedFile());
            }
            else
            {
                FileOperation fo = new FileOperation(listRight.bottomText, listLeft.bottomText, stPathFiles.SignDelete, stPathFiles.AddRandomBlock);
                fo.EditFile(listRight.pathToEditorProg, listRight.GetFocusedFile());
            }
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            if (activeListView == NameListView.left)
            {
                ViewForm viewForm = new ViewForm
                {
                    viewFileName = listLeft.GetFocusedFile()
                };
                viewForm.Show();
            }
            else
            {
                ViewForm viewForm = new ViewForm
                {
                    viewFileName = listRight.GetFocusedFile()
                };
                viewForm.Show();
            }
        }
        /// <summary>
        /// спрятать в трей
        /// </summary>
        private void CipherProject_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }
        /// <summary>
        /// восстановить из трея
        /// </summary>
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// обработка пункта меню
        /// </summary>
        private void addRandomBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addRandomBlockToolStripMenuItem.Checked == true)
            {
                addRandomBlockToolStripMenuItem.Checked = false;
                stPathFiles.AddRandomBlock = 0;
            }
            else
            {
                addRandomBlockToolStripMenuItem.Checked = true;
                stPathFiles.AddRandomBlock = 1;
            }
        }
        /// <summary>
        /// обновить содержимое PanelListView
        /// </summary>
        public void RefillListView()
        {
            if (activeListView == NameListView.left)
            {
                listRight.RefillList();
                listLeft.RefillList();
            }
            else
            {
                listLeft.RefillList();
                listRight.RefillList();
            }
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutToolStripMenuItem_Click(sender, e);
        }


        public void ResizeActionButton()
        {
            int posX = 0;
            int buttonSizeX = buttonsPanel.Size.Width / buttonsPanel.Controls.Count;
            foreach (Control btn in buttonsPanel.Controls)
            {
                if (btn.GetType() == typeof(Button))
                {
                    btn.Size = new Size(buttonSizeX, buttonsPanel.Size.Height);
                    btn.Location = new Point(posX, 0);
                    posX += buttonSizeX;
                }
            }
        }

        private void CipherProject_SizeChanged(object sender, EventArgs e)
        {
            ResizeActionButton();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPassword();
        }

        private void ClearPassword()
        {
            if (sPass != null)
            {
                sPass = String.Empty;
            }
            else
            {
                sPass = String.Empty;
            }
            menuStrip1.Items[2].Enabled = false;
        }

        private bool CheckPass()
        {
            bool result = false;
            if (sPass == null)
                sPass = String.Empty;
            if (sPass.Length == 0)
            {
                ShowLoginForm();
            }
            if (sPass.Length != 0)
            {
                result = true;
            }
            return result;
        }

        public static FileType GetFileType(string path)
        {
            if (File.Exists(path))
            {
                return FileType.File;
            }
            else if (Directory.Exists(path))
            {
                return FileType.Directory;
            }
            else
            {
                return FileType.Unknown;
            }
        }

        private void changePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ClearPassword();
        }
    }
}
