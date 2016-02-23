using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Security;
using System.Security.Principal;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;//для запуска файлов
using System.Threading;

using System.Security.Permissions;
using System.Security.AccessControl;

namespace CipherProject
{
    class FileOperation
    {
        public int signDelete { get; set; }
        public string pathFrom { get; set; }
        public string pathTo { get; set; }
        public int progressMax { get; set; }
        public int progressPosition { get; set; }
        public int addRandomBlock { get; set; }
        private DateTime fileDateCreation;
        private DateTime fileDateLastModify;
        private DateTime fileDateLastAccess;

        public delegate void CopyFileDelegate(object obj);

        private ProgressWindow progressWindow;

        private FileOperation()
        {
            signDelete = 0;
            pathFrom = String.Empty;
            pathTo = String.Empty;
            progressMax = 0;
            progressPosition = 0;
            fileDateCreation = DateTime.Now;
            fileDateLastModify = DateTime.Now;
            fileDateLastAccess = DateTime.Now;
        }
        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="pathfrom">исходная папка</param>
        /// <param name="pathto">целевая папка</param>
        /// <param name="signdelete">признак удаления исходного файла</param>
        public FileOperation(string pathfrom, string pathto, int signdelete, int addrandom)
        {
            signDelete = signdelete;
            pathFrom = pathfrom;
            pathTo = pathto;
            progressMax = 0;
            progressPosition = 0;
            addRandomBlock = addrandom;
            fileDateCreation = DateTime.Now;
            fileDateLastModify = DateTime.Now;
            fileDateLastAccess = DateTime.Now;
        }
        #region Common Operation
        public void GetFileDates(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            this.fileDateCreation = fi.CreationTime;
            this.fileDateLastModify = fi.LastWriteTime;
            this.fileDateLastAccess = fi.LastAccessTime;
        }
        public void SetFileDates(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            fi.CreationTime = this.fileDateCreation;
            fi.LastWriteTime = this.fileDateLastModify;
            fi.LastAccessTime = this.fileDateLastAccess;
        }
        /// <summary>
        /// проход по всем подпапкам заданной папки
        /// </summary>
        /// <param name="sourceFolder">исходная папка</param>
        /// <param name="destFolder">целевая папка</param>
        public void CopyDirectoryTree(string sourceFolder, string destFolder, string papka)
        {
            sourceFolder = sourceFolder + papka + "\\";
            destFolder = destFolder + papka;
            //создать папку
            if (!System.IO.Directory.Exists(destFolder))
            {
                System.IO.Directory.CreateDirectory(destFolder);
            }
            destFolder = destFolder + "\\";
            //получить список файлов
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(sourceFolder);
            FileInfo[] files = di.GetFiles();
            //скопировать файлы с перезаписью
            foreach (var item in files)
            {
                try
                {
                    File.Copy(sourceFolder + item.Name.ToString(),
                        destFolder + item.Name.ToString(), true);
                }
                catch (IOException)
                {
                    MessageBox.Show("IOException error");                    
                    StaticClass.cancel = true;
                    break;
                }
            }
            //получить список каталогов
            System.IO.DirectoryInfo[] folders = di.GetDirectories();
            //Рекурсия!!!
            foreach (var item in folders)
            {
                if(StaticClass.cancel == false)
                    CopyDirectoryTree(sourceFolder, destFolder, item.Name.ToString());
            }

        }
        /// <summary>
        /// копирование одного файла
        /// </summary>
        /// <param name="inFile">исходный файл</param>
        /// <param name="outFile">целевой файл</param>
        public void CopyFile(string inFile, string outFile)
        {
            StaticClass.progressMax2 = StaticClass.progressMax1;
            StaticClass.progressValue2 = StaticClass.progressValue1;
            if (System.IO.File.Exists(outFile) == false)
            {
                System.IO.File.Copy(inFile, outFile);
            }
            else
            {
                DialogResult result = MessageBox.Show("Файл существует, перезаписать?", "Перезаписать?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    //System.IO.File.Delete(outFile);
                    //DeleteFile(outFile);
                    System.IO.File.Copy(inFile, outFile, true);
                }
            }
        }

        public void CopyListFilesThreading(object obj)
        {
            ObjectCopyFiles objCopyFiles = (ObjectCopyFiles)obj;
            CopyListFiles(objCopyFiles.fileList, objCopyFiles.dirList);
        }

        /// <summary>
        /// скопировать список файлов
        /// </summary>
        /// <param name="fileList">список файлов</param>
        public void CopyListFiles(List<string> fileList, List<string> directoryList)
        {
            ObjectCopyFiles ocf = new ObjectCopyFiles();
            ocf.fileList.AddRange(fileList);
            if (fileList.Count > 0)
            {
                StaticClass.cancel = false;
                StaticClass.progressValue1 = 0;
                StaticClass.progressValue2 = 0;
                StaticClass.nameOperation = "Copying files...";
                StaticClass.progressMax1 = fileList.Count;
                progressWindow = new ProgressWindow();
                progressWindow.Show();

                string inFileFullName;//имя и путь
                string outFileFullName;//имя и путь
                //проход по переданным файлам
                foreach (string inFile in fileList)
                {
                    StaticClass.fileName = inFile;
                    inFileFullName = pathFrom + inFile;
                    if (System.IO.File.Exists(inFileFullName))
                    {
                        outFileFullName = pathTo + inFile;
                        CopyFile(inFileFullName, outFileFullName);
                    }
                    StaticClass.progressValue1++; 
                    Application.DoEvents();
                    if (StaticClass.cancel == true)
                        break;
                }
                progressWindow.Close();
            }
            if (directoryList.Count > 0)
            {
                StaticClass.cancel = false;
                StaticClass.progressValue1 = 0;
                StaticClass.progressValue2 = 0;
                StaticClass.nameOperation = "Copying directories...";
                StaticClass.progressMax1 = directoryList.Count;
                progressWindow = new ProgressWindow();
                progressWindow.Show();

                string inDirFullName;//имя и путь
                string outDirFullName;//имя и путь
                //проход по переданным файлам
                foreach (string inDir in directoryList)
                {
                    StaticClass.fileName = inDir;
                    inDirFullName = pathFrom + inDir + "\\";
                    outDirFullName = pathTo + inDir + "\\";
                    if (!(outDirFullName.Contains(inDirFullName)))
                        CopyDirectoryTree(pathFrom, pathTo, inDir);

                    StaticClass.progressValue1++;
                    Application.DoEvents();
                    if (StaticClass.cancel == true)
                        break;
                }
                progressWindow.Close();
            }
        }
        /// <summary>
        /// перемещение папки
        /// </summary>
        /// <param name="inDirectory">откуда</param>
        /// <param name="outDirectory">куда</param>
        public void MoveDirectory(string sourceDirectory, string destDirectory)
        {
            if (Directory.Exists(sourceDirectory))
            {
                DialogResult result = MessageBox.Show("Переместить папку " + sourceDirectory + " ?", "Переместить?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (Directory.Exists(destDirectory))
                    {
                        MessageBox.Show("Папка " + destDirectory + " уже существует");
                    }
                    else
                    {
                        Directory.Move(sourceDirectory, destDirectory);
                    }
                }
            }
        }
        /// <summary>
        /// перенос одного файла
        /// </summary>
        /// <param name="inFile">исходный файл</param>
        /// <param name="outFile">целевой файл</param>
        public void MoveFile(string inFile, string outFile)
        {
            if (System.IO.File.Exists(outFile) == false)
            {
                System.IO.File.Move(inFile, outFile);
            }
            else
            {
                DialogResult result = MessageBox.Show("Файл существует, перезаписать?", "Перезаписать?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    //System.IO.File.Delete(outFile);
                    try
                    {
                        DeleteFile(outFile);
                        System.IO.File.Move(inFile, outFile);
                    }
                    catch
                    {
                    }
                }
            }
        }
        /// <summary>
        /// Перенос файлов  и папок по списку
        /// </summary>
        /// <param name="fileList">список файлов</param>
        /// <param name="directoryList">список папок</param>
        public void MoveListFiles(List<string> fileList, List<string> directoryList)
        {
            if (fileList.Count > 0)
            {
                StaticClass.cancel = false;
                StaticClass.progressValue1 = 0;
                StaticClass.progressValue2 = 0;
                StaticClass.nameOperation = "Move files...";
                StaticClass.progressMax1 = fileList.Count;
                progressWindow = new ProgressWindow();
                progressWindow.Show();

                string inFileFullName;//полное имя
                string outFileFullName;
                foreach (string inFile in fileList)
                {
                    StaticClass.fileName = inFile;
                    inFileFullName = pathFrom + inFile;
                    if (System.IO.File.Exists(inFileFullName))
                    {
                        outFileFullName = pathTo + inFile;
                        MoveFile(inFileFullName, outFileFullName);
                    }
                    StaticClass.progressValue1++;
                    Application.DoEvents();
                    if (StaticClass.cancel == true)
                        break;
                }
                progressWindow.Close();
            }
            //
            if (directoryList.Count > 0)
            {
                StaticClass.cancel = false;
                StaticClass.progressValue1 = 0;
                StaticClass.progressValue2 = 0;
                StaticClass.nameOperation = "Move directories...";
                StaticClass.progressMax1 = directoryList.Count;
                progressWindow = new ProgressWindow();
                progressWindow.Show();

                string inDirFullName;//полное имя
                string outDirFullName;
                foreach (string srcFolder in directoryList)
                {
                    StaticClass.fileName = srcFolder;
                    inDirFullName = pathFrom + srcFolder + "\\";
                    outDirFullName = pathTo + srcFolder + "\\";

                    MoveDirectory(inDirFullName, outDirFullName);

                    StaticClass.progressValue1++;
                    Application.DoEvents();
                    if (StaticClass.cancel == true)
                        break;
                }
                progressWindow.Close();
            }
        }
        /// <summary>
        /// удаление одной папки со всеми подпапками с подтверждением
        /// </summary>
        /// <param name="nameDirectory">имя папки</param>
        public void DeleteDirectory(string nameDirectory)
        {
            if (System.IO.Directory.Exists(nameDirectory))
            {
                DialogResult result = MessageBox.Show("Удалить папку " + nameDirectory + " и все вложенные папки?", "Удалить?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    string curDir = Directory.GetCurrentDirectory();
                    if(curDir.Contains(nameDirectory))
                    {
                        curDir = nameDirectory.Remove(nameDirectory.LastIndexOf(@"\"));
                    }

                    try
                    {
                        System.IO.Directory.SetCurrentDirectory(System.IO.Path.GetDirectoryName(curDir));
                        System.IO.Directory.Delete(nameDirectory, true);
                    }
                    catch
                    {
                    }
                }
            }
        }
        /// <summary>
        /// удаление одного файла без подтверждения
        /// </summary>
        /// <param name="inFile">файл</param>
        public void DeleteFile(string inFile)
        {
            if (System.IO.File.Exists(inFile))
            {
                try
                {
                    System.IO.File.Delete(inFile);
                }
                catch (System.UnauthorizedAccessException)
                {
                    File.SetAttributes(inFile, File.GetAttributes(inFile) & ~(FileAttributes.Hidden |
                        FileAttributes.ReadOnly | FileAttributes.System));
                    System.IO.File.Delete(inFile);
                }
            }
        }
        /// <summary>
        /// удалить файлы и папки по списку
        /// </summary>
        /// <param name="fileList">список файлов</param>
        public void DeleteListFiles(List<string> fileList, List<string> directoryList)
        {
            if (fileList.Count > 0)
            {
                string inFileFullName;//полное имя
                DialogResult result = MessageBox.Show("Удалить выбранные файлы?", "Удалить?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    foreach (string inFile in fileList)
                    {
                        inFileFullName = pathFrom + inFile;
                        try
                        {
                            DeleteFile(inFileFullName);
                        }
                        catch
                        {
                        }
                        Application.DoEvents();
                    }
                }
            }
            //удаление папок
            if (directoryList.Count > 0)
            {
                string directoryFullName;
                foreach (string dir in directoryList)
                {
                    directoryFullName = pathFrom + dir;
                    try
                    {
                        DeleteDirectory(directoryFullName);
                    }
                    catch
                    {
                    }
                    Application.DoEvents();
                }
            }
        }
        /// <summary>
        /// выполнить файл
        /// </summary>
        /// <param name="inFile">полное имя файла</param>
        public void RunFile(string inFile)
        {
            if (System.IO.File.Exists(inFile))
            {
                try
                {
                    System.IO.Directory.SetCurrentDirectory(System.IO.Path.GetDirectoryName(inFile));
                    ProcessStartInfo PInfo = new ProcessStartInfo();
                    PInfo.FileName = inFile;
                    PInfo.UseShellExecute = true;
                    Process p = Process.Start(PInfo);
                }
                catch
                {
                    //
                }
            }
        }
        /// <summary>
        /// редактирование файла внешней программой
        /// </summary>
        /// <param name="progEditor">путь к программе-редактору</param>
        /// <param name="fileForEdit">путь к файлу для редактирования</param>
        public void EditFile(string progEditor, string fileForEdit)
        {
            if (File.Exists(progEditor))
            {
                if (File.Exists(fileForEdit))
                {
                    Process procEditFile = new Process();
                    procEditFile.StartInfo.FileName = progEditor;
                    procEditFile.StartInfo.Arguments = fileForEdit;
                    procEditFile.Start();
                }
            }
        }
        /// <summary>
        /// создать папку
        /// </summary>
        /// <param name="nameNewDir">имя папки без пути и слэшей</param>
        public void MakeDir(string nameNewDir)
        {
            try
            {
                System.IO.Directory.CreateDirectory(pathFrom + nameNewDir);
            }
            catch
            {
                MessageBox.Show("Something wrong");
            }
        }

        #endregion
        #region Encrypt Decrypt
        private void EncryptFileRijndael(string inFileFullName, string hash, string inFile)
        {
            //Использован пример Алексея Остапенко RSDN Magazine
            //Запомнить дату создания файла
            GetFileDates(inFileFullName);
            string inFileName;          //имя без полного пути
            string outFile;             //зашифрованный файл
            RijndaelManaged alg;        //выбор алгоритма шифрования
            alg = new RijndaelManaged();//экземпляр класса симметричного шифрования
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(hash, null); //класс, позволяющий генерировать ключи на базе паролей
            pdb.HashName = "SHA512";    //будем использовать SHA512
            alg.KeySize = 256;          //устанавливаем размер ключа
            alg.Key = pdb.GetBytes(alg.KeySize >> 3); //получаем ключ из пароля
            alg.Mode = CipherMode.CBC;  //используем режим CBC
            alg.IV = new Byte[alg.BlockSize >> 3]; //и пустой инициализационный вектор
            ICryptoTransform tr = alg.CreateEncryptor(); //создаем encryptor
            inFileName = inFile;        //получить имя файла и расширение
            if (addRandomBlock == 0)
            {
                inFileName += ".enc";
            }
            else
            {
                inFileName += ".rjn";
            }
            outFile = pathTo + inFileName;

            System.Security.AccessControl.DirectorySecurity sec = System.IO.Directory.GetAccessControl(pathTo);
            FileSystemAccessRule accRule = new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow);
            sec.AddAccessRule(accRule);

            FileStream instream = new FileStream(inFileFullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream outstream = new FileStream(outFile, FileMode.Create, FileAccess.Write, FileShare.None);
            int buflen = ((2 << 16) / alg.BlockSize) * alg.BlockSize;
            byte[] inbuf = new byte[buflen];
            byte[] outbuf = new byte[buflen];
            int len = 0;
            int enclen = 0;
            //найти размер файла
            long lengthFile = instream.Length;
            //найти кол-во проходов для данного файла
            int prohod = (int)(lengthFile / buflen);
            prohod++;
            //progress bar
            StaticClass.progressMax2 = prohod;
            StaticClass.progressValue2 = 0;
            while ((len = instream.Read(inbuf, 0, buflen)) == buflen)
            {
                if ((StaticClass.progressValue2 == 0) && (addRandomBlock == 1))
                {
                    Array.Reverse(inbuf,0,65000);
                }
                enclen = tr.TransformBlock(inbuf, 0, buflen, outbuf, 0); //собственно шифруем
                outstream.Write(outbuf, 0, enclen);
                StaticClass.progressValue2++;
                Application.DoEvents();
            }
            instream.Close();
            if ((StaticClass.progressValue2 == 0) && (addRandomBlock == 1))
            {
                Array.Reverse(inbuf);
                outbuf = tr.TransformFinalBlock(inbuf, inbuf.Length - len, len); //шифруем финальный блок
            }
            else
            {
                outbuf = tr.TransformFinalBlock(inbuf, 0, len); //шифруем финальный блок
            }
            outstream.Write(outbuf, 0, outbuf.Length);
            outstream.Close();
            if (signDelete == 1)
                System.IO.File.Delete(inFileFullName);
            alg.Clear();
            //сохранить дату создания файла
            if (System.IO.File.Exists(outFile))
            {
                SetFileDates(outFile);
            }
        }

        private void EncryptFileThreeFish(string inFileFullName, string hash, string inFile)
        {
            //Запомнить дату создания файла
            GetFileDates(inFileFullName);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(hash, null); //класс, позволяющий генерировать ключи на базе паролей
            pdb.HashName = "SHA512";            //будем использовать SHA512
            string inFileName = String.Empty;   //имя без полного пути
            string outFile = String.Empty;      //зашифрованный файл
            Threefish alg_threefish;
            alg_threefish = new Threefish();
            alg_threefish.KeySize = 1024;       //устанавливаем размер ключа
            alg_threefish.BlockSize = 1024;
            alg_threefish.Key = pdb.GetBytes(alg_threefish.KeySize >> 3); //получаем ключ из пароля
            alg_threefish.Mode = CipherMode.CBC;//используем режим CBC
            alg_threefish.Padding = PaddingMode.ANSIX923;
            alg_threefish.IV = new Byte[alg_threefish.BlockSize >> 3]; //и пустой инициализационный вектор
            int buflen = ((2 << 16) / alg_threefish.BlockSize) * alg_threefish.BlockSize;
            long lengthFile = 0L;//размер файла
            int prohod = 0;
            byte[] inbuf = new byte[buflen];
            byte[] outbuf = new byte[buflen];
            int len = 0;
            int enclen = 0;
            inFileName = inFile;                //получить имя файла и расширение
            inFileName += ".trf";
            outFile = pathTo + inFileName;
            FileStream instream = new FileStream(inFileFullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream outstream = new FileStream(outFile, FileMode.Create, FileAccess.Write, FileShare.None);
            ICryptoTransform tr = alg_threefish.CreateEncryptor(alg_threefish.Key, alg_threefish.IV); //создаем encryptor
            //найти размер файла
            lengthFile = instream.Length;
            //найти кол-во проходов для данного файла
            prohod = (int)(lengthFile / buflen);
            prohod++;
            StaticClass.progressMax2 = prohod;
            StaticClass.progressValue2 = 0;

            while ((len = instream.Read(inbuf, 0, buflen)) == buflen)
            {
                enclen = tr.TransformBlock(inbuf, 0, buflen, outbuf, 0); //собственно шифруем
                outstream.Write(outbuf, 0, enclen);
                StaticClass.progressValue2++;
                Application.DoEvents();
            }
            if (len > 0)
            {
                outbuf = tr.TransformFinalBlock(inbuf, 0, len); //шифруем финальный блок
                outstream.Write(outbuf, 0, outbuf.Length);
            }
            StaticClass.progressValue2++;
            Application.DoEvents();
            instream.Close();
            outstream.Close();
            instream = null;
            outstream = null;
            alg_threefish.Clear();
            alg_threefish = null;
            if (signDelete == 1)
                System.IO.File.Delete(inFileFullName);
            //сохранить дату создания файла
            if (System.IO.File.Exists(outFile))
            {
                SetFileDates(outFile);
            }
        }
        /// <summary>
        /// зашифровать файлы по списку
        /// </summary>
        /// <param name="selectedFiles">список файлов</param>
        /// <param name="sPass">пароль</param>
        /// <param name="cryptoAlg">номер алгоритма</param>
        public void EncryptListFiles(List<string> selectedFiles, string sPass, int cryptoAlg)
        {
            if (selectedFiles.Count > 0)
            {
                StaticClass.cancel = false;
                StaticClass.progressValue1 = 0;
                StaticClass.progressValue2 = 0;
                StaticClass.nameOperation = "Encrypting...";
                StaticClass.progressMax1 = selectedFiles.Count;
                progressWindow = new ProgressWindow();
                progressWindow.Show();

                string inFileFullName;//полное имя
                string h; //хэш
                string hash;//хэш в виде строки
                byte[] mas; //массив байтов для вычисления хэша
                byte[] saltedPwBytes1 = Encoding.UTF8.GetBytes(sPass);//сформировать массив байтов из пароля (UTF8,UNICODE)
                WhirlpoolManaged wm = new WhirlpoolManaged(); //создание новой спиральной хэш функции
                mas = wm.ComputeHash(saltedPwBytes1);//получить спиральную хэш функцию в виде массива байтов
                hash = Convert.ToBase64String(mas); //преобразовать в строку
                h = hash;
                if (h.Length > 50)//есть пароль
                {
                    //выбрать часть хэша для пароля или придумать что то более хитрое
                    h = h.Substring(32, 16); //пароль для шифрования
                    //проход по выбранным файлам
                    foreach (string inFile in selectedFiles)
                    {
                        inFileFullName = pathFrom + inFile;
                        if (System.IO.File.Exists(inFileFullName))
                        {
                            StaticClass.fileName = inFile;
                            if (cryptoAlg == 0)
                            {
                                EncryptFileRijndael(inFileFullName, h, inFile);
                            }
                            if (cryptoAlg == 1)
                            {
                                EncryptFileThreeFish(inFileFullName, h, inFile);
                            }
                            StaticClass.progressValue1++;
                            Application.DoEvents();
                        }
                        if (StaticClass.cancel == true)
                            break;
                    }
                }
                h = ")1c[t!$3y@h4BkaG=[swuji<";
                progressWindow.Close();
            }
        }
        //***************************************************************************
        private void DecryptFileRijndael(string inFileFullName, string hash, string inFile)
        {
            //Запомнить дату создания файла
            GetFileDates(inFileFullName);
            RijndaelManaged alg;//выбор алгоритма шифрования
            alg = new RijndaelManaged();//экземпляр класса симметричного шифрования
            string inFileName = String.Empty;//имя без полного пути
            string outFile = String.Empty;//разшифрованный файл
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(hash, null);
            pdb.HashName = "SHA512";
            alg.KeySize = 256;
            alg.Key = pdb.GetBytes(alg.KeySize >> 3);
            alg.Mode = CipherMode.CBC;
            alg.IV = new Byte[alg.BlockSize >> 3];
            ICryptoTransform tr = alg.CreateDecryptor();
            inFileName = System.IO.Path.GetFileNameWithoutExtension(inFile);//получить имя файла без расширения *.enc
            outFile = pathTo + inFileName;
            FileStream instream = new FileStream(inFileFullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream outstream = new FileStream(outFile, FileMode.Create, FileAccess.Write, FileShare.None);
            int buflen = ((2 << 16) / alg.BlockSize) * alg.BlockSize;
            byte[] inbuf = new byte[buflen];
            byte[] outbuf = new byte[buflen];
            //найти размер файла
            long lengthFile = instream.Length;
            //найти кол-во проходов для данного файла
            int prohod = (int)(lengthFile / buflen);
            prohod++;
            //progress bar
            StaticClass.progressMax2 = prohod;
            StaticClass.progressValue2 = 0;
            int len = 0;
            int declen = 0;
            try
            {
                while ((len = instream.Read(inbuf, 0, buflen)) == buflen)
                {
                    declen = tr.TransformBlock(inbuf, 0, buflen, outbuf, 0);
                    if ((StaticClass.progressValue2 == 0) && (addRandomBlock == 1))
                    {
                        Array.Reverse(outbuf,0,65000);
                    }
                    outstream.Write(outbuf, 0, declen);
                    StaticClass.progressValue2++;
                    Application.DoEvents();
                }
                outbuf = tr.TransformFinalBlock(inbuf, 0, len);
                if ((StaticClass.progressValue2 == 0) && (addRandomBlock == 1))
                {
                    Array.Reverse(outbuf);
                }
                outstream.Write(outbuf, 0, outbuf.Length);
                StaticClass.progressValue2++;
                Application.DoEvents();
            }
            catch
            {
                alg.Clear();
                instream.Close();
                outstream.Close();
                System.IO.File.Delete(outFile);
                MessageBox.Show("Файл зашифрован другим паролем", "Ошибка", MessageBoxButtons.OK);
            }
            finally
            {
                alg.Clear();
                instream.Close();
                outstream.Close();
            }
            //сохранить дату создания файла
            if (System.IO.File.Exists(outFile))
            {
                SetFileDates(outFile);
            }
        }

        private void DecryptFileThreeFish(string inFileFullName, string hash, string inFile)
        {
            //Запомнить дату создания файла
            GetFileDates(inFileFullName);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(hash, null);
            pdb.HashName = "SHA512";
            string inFileName = String.Empty;//имя без полного пути
            string outFile = String.Empty;//разшифрованный файл
            long lengthFile = 0L;//размер файла
            int prohod = 0;
            int newArraySize = 0;
            int len = 0;
            int declen = 0;
            Threefish alg_threefish;
            alg_threefish = new Threefish();
            alg_threefish.KeySize = 1024;
            alg_threefish.BlockSize = 1024;
            alg_threefish.Key = pdb.GetBytes(alg_threefish.KeySize >> 3);
            alg_threefish.Mode = CipherMode.CBC;
            alg_threefish.Padding = PaddingMode.ANSIX923;
            alg_threefish.IV = new Byte[alg_threefish.BlockSize >> 3];
            int buflen = ((2 << 16) / alg_threefish.BlockSize) * alg_threefish.BlockSize;
            byte[] inbuf = new byte[buflen];
            byte[] outbuf = new byte[buflen];
            //получить имя файла без расширения *.trf
            inFileName = System.IO.Path.GetFileNameWithoutExtension(inFile);
            //дописать в outFile
            outFile = pathTo + inFileName;
            FileStream instream = new FileStream(inFileFullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream outstream = new FileStream(outFile, FileMode.Create, FileAccess.Write, FileShare.None);
            //найти размер файла
            lengthFile = instream.Length;
            //найти кол-во проходов для данного файла
            prohod = (int)(lengthFile / buflen);
            prohod++;
            if ((lengthFile % buflen) > 0)
                prohod++;
            StaticClass.progressMax2 = prohod;
            StaticClass.progressValue2 = 0;
            bool zero_ok = true;
            ICryptoTransform tr = alg_threefish.CreateDecryptor(alg_threefish.Key, alg_threefish.IV);
            try
            {
                prohod--;
                while ((len = instream.Read(inbuf, 0, buflen)) == buflen)
                {
                    declen = tr.TransformBlock(inbuf, 0, buflen, outbuf, 0);
                    prohod--;
                    if (prohod > 0)
                        outstream.Write(outbuf, 0, declen);//не записывать последний блок
                    StaticClass.progressValue2++;
                    Application.DoEvents();
                }
                //
                if (len > 0)
                {
                    outbuf = tr.TransformFinalBlock(inbuf, 0, len);
                }
                //определить размер последнего блока
                newArraySize = outbuf.Length - outbuf[outbuf.Length - 1];
                if (newArraySize > 0)
                {
                    //проверить количество нулей (на 1 меньше значения последнего байта)
                    for (int i = newArraySize; i < outbuf.Length - 1; i++)
                    {
                        if (outbuf[i] != 0)
                        {
                            zero_ok = false;
                            break;
                        }
                    }
                    //изменить размер последнего блока (обрезать)
                    if (zero_ok == true)
                        Array.Resize(ref outbuf, outbuf.Length - outbuf[outbuf.Length - 1]);
                }
                outstream.Write(outbuf, 0, outbuf.Length);//записать последний блок
                StaticClass.progressValue2++;
                Application.DoEvents();
            }
            catch
            {
                instream.Close();
                outstream.Close();
                instream = null;
                outstream = null;
                alg_threefish.Clear();
                alg_threefish = null;
                System.IO.File.Delete(outFile);
                MessageBox.Show("Файл зашифрован другим паролем", "Ошибка", MessageBoxButtons.OK);
            }
            finally
            {
                instream.Close();
                outstream.Close();
                instream = null;
                outstream = null;
                alg_threefish.Clear();
                alg_threefish = null;
            }
            //сохранить дату создания файла
            if (System.IO.File.Exists(outFile))
            {
                SetFileDates(outFile);
            }
        }

        public void DecryptListFiles(List<string> selectedFiles, string sPass)
        {
            if (selectedFiles.Count > 0)
            {
                StaticClass.cancel = false;
                StaticClass.progressValue1 = 0;
                StaticClass.progressValue2 = 0;
                StaticClass.nameOperation = "Decrypting...";
                StaticClass.progressMax1 = selectedFiles.Count;
                progressWindow = new ProgressWindow();
                progressWindow.Show();

                string inFileFullName;//полное имя
                string h; //хэш
                string hash;//хэш в виде строки
                byte[] mas; //массив байтов для вычисления хэша
                byte[] saltedPwBytes1 = Encoding.UTF8.GetBytes(sPass);//сформировать массив байтов из пароля (UTF8,UNICODE)
                WhirlpoolManaged wm = new WhirlpoolManaged(); //создание новой спиральной хэш функции
                mas = wm.ComputeHash(saltedPwBytes1);//получить спиральную хэш функцию в виде массива байтов
                hash = Convert.ToBase64String(mas); //преобразовать в строку
                h = hash;
                if (h.Length > 50)//есть пароль
                {
                    //выбрать часть хэша для пароля или придумать что то более хитрое
                    h = h.Substring(32, 16); //пароль для шифрования
                    foreach (string inFile in selectedFiles)
                    {
                        inFileFullName = pathFrom + inFile;
                        if (System.IO.File.Exists(inFileFullName))
                        {
                            StaticClass.fileName = inFile;
                            if (System.IO.Path.GetExtension(inFileFullName) == ".trf")
                            {
                                DecryptFileThreeFish(inFileFullName, h, inFile);
                            }
                            if (System.IO.Path.GetExtension(inFileFullName) == ".enc")
                            {
                                addRandomBlock = 0;
                                DecryptFileRijndael(inFileFullName, h, inFile);
                            }
                            if (System.IO.Path.GetExtension(inFileFullName) == ".rjn")
                            {
                                addRandomBlock = 1;
                                DecryptFileRijndael(inFileFullName, h, inFile);
                                addRandomBlock = 0;
                            }
                            StaticClass.progressValue1++;
                            Application.DoEvents();
                        }
                        if (StaticClass.cancel == true)
                            break;
                    }
                }
                h = ")1c[t!$3y@h4BkaG=[swuji<";
                progressWindow.Close();
            }
        }
        #endregion
    }
}
