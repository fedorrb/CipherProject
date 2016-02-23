using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CipherProject
{
    public class stPath
    {
        public int SortOrderLeft { get; set; }//порядок сортировки файлов
        public int SortOrderRight { get; set; }//порядок сортировки файлов
        public int CryptoAlgoritm { get; set; }//алгоритм шифрования
        public int SignDelete { get; set; }//признак удаления исходных файлов
        public string OldLeftDir { get; set; }//последняя папка левой панели
        public string OldRightDir { get; set; }//последняя папка правой панели
        public string ProgForEditing { get; set; }//программа для редактирования
        public int AddRandomBlock { get; set; }//добавлять ли блок случайных данных

        public stPath()
        {
            SortOrderLeft = 0;//по имени файла
            SortOrderRight = 0;//по имени файла
            CryptoAlgoritm = 0; //rijndael
            SignDelete = 0;
            OldLeftDir = String.Empty;
            OldRightDir = String.Empty;
            ProgForEditing = String.Empty;
        }
        /// <summary>
        /// Чтение файла конфигурации
        /// </summary>
        public void LoadIniFile()
        {
            string path = String.Empty;
            path = System.IO.Directory.GetCurrentDirectory();
            path += @"\cipher.ini";
            int elements = 0;
            if (System.IO.File.Exists(path))
            {
                try
                {
                    string[] allLines = System.IO.File.ReadAllLines(path);
                    elements = allLines.Length;
                    switch (elements)
                    {
                        case 7:
                            ProgForEditing = allLines[6];
                            goto case 6;
                        case 6:
                            OldRightDir = allLines[5];
                            goto case 5;
                        case 5:
                            OldLeftDir = allLines[4];
                            goto case 4;
                        case 4:
                            SignDelete = int.Parse(allLines[3]);
                            goto case 3;
                        case 3:
                            CryptoAlgoritm = int.Parse(allLines[2]);
                            goto case 2;
                        case 2:
                            SortOrderRight = int.Parse(allLines[1]);
                            goto case 1;
                        case 1:
                            SortOrderLeft = int.Parse(allLines[0]);
                            break;
                        case 0:
                            break;
                        default:
                            break;
                    }
                    /*
                    SortOrderLeft = int.Parse(allLines[0]);
                    SortOrderRight = int.Parse(allLines[1]);
                    CryptoAlgoritm = int.Parse(allLines[2]);
                    SignDelete = int.Parse(allLines[3]);
                    OldLeftDir = allLines[4];
                    OldRightDir = allLines[5];
                    ProgForEditing = allLines[6];
                     */
                }
                catch
                {
                    SortOrderLeft = 0;
                    SortOrderRight = 0;
                    CryptoAlgoritm = 0;
                    SignDelete = 0;
                    OldLeftDir = String.Empty;
                    OldRightDir = String.Empty;
                    ProgForEditing = String.Empty;
                }
            }
            else
            {
                SortOrderLeft = 0;
                SortOrderRight = 0;
                CryptoAlgoritm = 0;
                SignDelete = 0;
                OldLeftDir = String.Empty;
                OldRightDir = String.Empty;
                ProgForEditing = String.Empty;
            }

            if (SortOrderLeft > 3 || SortOrderLeft < 0)
                SortOrderLeft = 0;
            if (SortOrderRight > 3 || SortOrderRight < 0)
                SortOrderRight = 0;
            if (CryptoAlgoritm > 2 || CryptoAlgoritm < 0)
                CryptoAlgoritm = 0;
            if (SignDelete > 1 || SignDelete < 0)
                SignDelete = 0;
            if (Directory.Exists(OldLeftDir) == false)
            {
                OldLeftDir = String.Empty;
            }
            if (Directory.Exists(OldRightDir) == false)
            {
                OldRightDir = String.Empty;
            }
            if (File.Exists(ProgForEditing) == false)
            {
                ProgForEditing = String.Empty;
            }
        }

        /// <summary>
        /// Запись файла конфигурации
        /// </summary>
        public void SaveIniFile()
        {
            string[] s = { SortOrderLeft.ToString(),
                             SortOrderRight.ToString(),
                             CryptoAlgoritm.ToString(),
                             SignDelete.ToString(),
                             OldLeftDir,
                             OldRightDir,
                             ProgForEditing
                         };
            string path = String.Empty;
            path = Application.StartupPath;
            path += @"\cipher.ini";
            System.IO.File.WriteAllLines(path, s);
        }
    }
}
