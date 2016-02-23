using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace CipherProject
{
    public class ZipStorerInterface : ZipStorer
    {
        private List<FileArhiv> listFileArhiv;
        //private List<PathArhiv> listPathArhiv;

        public ZipStorerInterface()
        {
            listFileArhiv = new List<FileArhiv>();
          //  listPathArhiv = new List<PathArhiv>();
        }

        public List<FileArhiv> GetFilesFromZip(string zipFile, string pathInZip)
        {
            ZipStorer zip = ZipStorer.Open(zipFile, FileAccess.Read);
            List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();
            listFileArhiv.Clear();
            foreach (ZipStorer.ZipFileEntry entry in dir)
            {
                FileArhiv fa = new FileArhiv();
                fa.fileName = entry.FilenameInZip;
                fa.GetFileExt();
                fa.zipSizeFile = entry.CompressedSize.ToString();
                fa.unzipSizeFile = entry.FileSize.ToString();
                listFileArhiv.Add(fa);
            }
            zip.Close();
            return (listFileArhiv);
        }
        /*
        public List<PathArhiv> GetPathsFromZip(string zipFile, string pathInZip)
        {
            return (listPathArhiv);
        }
         */ 

        public void UnzipFiles(List<string> filesToUnzip, string path)
        {
        }

        public void ZipFiles(List<string> filesToZip, string path)
        {
        }


    }
}
