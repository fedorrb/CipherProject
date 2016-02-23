using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CipherProject
{
    public class ObjectCopyFiles
    {
        public List<string> fileList;
        public List<string> dirList;
        public string pathFrom { get; set; }
        public string pathTo { get; set; }

        public ObjectCopyFiles()
        {
            fileList = new List<string>();
            dirList = new List<string>();
            pathFrom = "";
            pathTo = "";
        }
    }
}
