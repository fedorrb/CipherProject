using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CipherProject
{
    /// <summary>
    /// класс хранящий свойства файла
    /// </summary>
    public class FileArhiv
    {
        public string fileName;
        public string fileExt;
        public string unzipSizeFile;
        public string zipSizeFile;
        public string fileDate;

        public FileArhiv()
        {
            fileName = String.Empty;
            fileExt = String.Empty;
            unzipSizeFile = String.Empty;
            zipSizeFile = String.Empty;
            fileDate = String.Empty;
        }
        /// <summary>
        /// получить расширение файла из полного имени в архиве
        /// </summary>
        /// <returns>расширение файла</returns>
        public string GetFileExt()
        {
            char[] delimeters = new char [] {'.'};
            string [] splitstring = fileName.Split(delimeters);
            if (fileName.Contains(delimeters[0]))
            {
                fileExt = splitstring[splitstring.Length - 1];
            }
            else
            {
                fileExt = String.Empty;
            }
            return fileExt;
        }
    }

    /// <summary>
    /// класс для хранения списка файлов в папке
    /// </summary>
    public class LeafList
    {
        public int id { get; private set; }
        public int idParent { get; private set; }
        public string pathName { get; private set; }
        private List<FileArhiv> filesInPath;

        public LeafList(int id, int idParent, string pathName)
        {
            this.id = id;
            this.idParent = idParent;
            this.pathName = pathName;
            filesInPath = new List<FileArhiv>();
        }

        public void AddFile(FileArhiv fa)
        {
            filesInPath.Add(fa);
        }

        public List<FileArhiv> GetFilesInPath()
        {
            return (filesInPath);
        }
    }
    /// <summary>
    /// таблица списка папок с файлами
    /// </summary>
    public class TreeList
    {
        private List<LeafList> treeArhiv;
        public TreeList(List<string> fullPath)
        {
            treeArhiv = new List<LeafList>();
            foreach (string fp in fullPath)
            {
                string[] splitstring = fp.Split('/');

            }
        }
    }
}
