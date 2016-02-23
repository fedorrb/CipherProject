using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CipherProject
{
    public partial class CipherProject : Form
    {
        public class PanelListView : ListView
        {
            public string bottomText { get; set; }//текст внизу панели
            public string newFolder { get; set; }//имя новой папки
            public string pathToEditorProg { get; set; }//путь к программе для редактирования
            private List<string> selectedFiles;
            private List<string> selectedDirectories;
            private int sortOrder;
            private enum SortDirection { ascending, descending }
            private SortDirection sortDirection;
            private Font newFont; //шрифт для выделенных файлов
            private Font oldFont;
            private Color newColor;//цвет для отсортированной колонки
            private Color oldColor;
            private Color oldBackColor; //цвет фона в системе
            private string position;
            private int widthColumnName;
            private int widthColumnExt;
            private int widthColumnDate;
            private int widthColumnSize;
            private int cursorOnFileIndex; //номер файла в списке под курсором
            private string cursorOnFileName;//имя файла в списке под курсором
            private List<string> selFiles;//копия списка выбраных файлов
            //********** конструктор ***************
            public PanelListView()
            {
                widthColumnName = 240;
                widthColumnExt = 50;
                widthColumnDate = 80;
                widthColumnSize = 85;
                sortOrder = 0;
                bottomText = String.Empty;
                newFolder = String.Empty;
                position = String.Empty;
                pathToEditorProg = String.Empty;
                selectedFiles = new List<string>();
                selectedDirectories = new List<string>();
                oldFont = this.Font;
                newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);
                oldColor = this.ForeColor;
                newColor = Color.Indigo;//DarkGreen;
                oldBackColor = SystemColors.Window;
                this.DoubleClick += listView_DoubleClick;
                this.ColumnClick += listView_ColumnClick;
                this.MouseClick += listView_MouseClick;
                this.KeyDown += listView_KeyDown;
                this.SizeChanged += listView_SizeChanged;
                ResizeColumns();
                sortDirection = SortDirection.ascending;
                selFiles = new List<string>();
            }
            #region Fields Metods
            //**************************************
            /// <summary>
            /// получить список выбранных файлов
            /// </summary>
            /// <returns>List</returns>
            public List<string> GetSelectedFiles()
            {
                selFiles.Clear();
                if (selectedFiles.Count == 0)
                {
                    if (this.FocusedItem.SubItems[0].Text.ToUpper().Equals
                        (this.FocusedItem.SubItems[0].Text) == false)
                    {
                        selectedFiles.Add(this.FocusedItem.SubItems[0].Text);
                    }
                }
                selFiles.AddRange(selectedFiles);
                return (selFiles);
            }
            //**************************************
            /// <summary>
            /// получить список выбранных папок
            /// </summary>
            /// <returns>список папок</returns>
            public List<string> GetSelectedDirectories()
            {
                if (selectedDirectories.Count == 0)
                {
                    if (!(this.FocusedItem.SubItems[0].Text.EndsWith("\\...")))
                    {
                        if (this.FocusedItem.SubItems[0].Text.ToUpper().Equals
                            (this.FocusedItem.SubItems[0].Text) == true)
                        {
                            selectedDirectories.Add(this.FocusedItem.SubItems[0].Text);
                        }
                    }
                }
                return (selectedDirectories);
            }
            //**************************************
            /// <summary>
            /// получить имя файла и его номер под курсором в списке
            /// </summary>
            public void GetCursorOnFile()
            {
                if (this.FocusedItem != null)
                {
                    cursorOnFileName = this.FocusedItem.SubItems[0].Text;
                    cursorOnFileIndex = this.FocusedItem.Index;
                }
                else
                {
                    cursorOnFileName = String.Empty;
                    cursorOnFileIndex = 0;
                }
            }
            /// <summary>
            /// установить курсор по имени файла,
            /// а если нет, то по индексу
            /// </summary>
            public void SetCursorOnFile()
            {
                if (this.Items.Count > 0 && cursorOnFileIndex > 0)
                {
                    //по имени файла
                    int i = 0;
                    string listViewItemText;
                    if (cursorOnFileName.Length > 0)
                    {
                        for (i = 0; i < this.Items.Count; i++)
                        {
                            listViewItemText = this.Items[i].SubItems[0].Text;
                            if (cursorOnFileName.CompareTo(listViewItemText) == 0)
                                break;
                        }
                    }
                    if (i < 0 || i >= this.Items.Count)
                        i = 0;
                    //по индексу
                    if (i == 0)
                    {
                        if (cursorOnFileIndex >= this.Items.Count)
                            cursorOnFileIndex = this.Items.Count - 1;
                        this.Items[0].Selected = false;
                        this.Items[0].Focused = false;
                        this.Items[cursorOnFileIndex].Selected = true;
                        this.Items[cursorOnFileIndex].Focused = true;
                        this.LabelEdit = true;
                    }
                    else
                    {
                        this.Items[0].Selected = false;
                        this.Items[0].Focused = false;
                        this.Items[i].Selected = true;
                        this.Items[i].Focused = true;
                    }
                }
                cursorOnFileIndex = 0;
                cursorOnFileName = String.Empty;
            }
            /// <summary>
            /// получить полное имя файла под курсором
            /// </summary>
            /// <returns></returns>
            public string GetFocusedFile()
            {
                if (this.FocusedItem != null)
                {
                    if (this.FocusedItem.SubItems[0].Text.ToUpper().Equals
                        (this.FocusedItem.SubItems[0].Text) == false)
                    {
                        return (bottomText + this.FocusedItem.SubItems[0].Text);
                    }
                    else
                        return "";
                }
                return "";
            }
            //**************************************
            public int GetSortOrder()
            {
                return (sortOrder);
            }
            //**************************************
            public void SetSortOrder(int order)
            {
                if (order < 0 || order > 3)
                    sortOrder = 0;
                else
                    sortOrder = order;
            }
            #endregion
            #region ListView Metods
            /// <summary>
            /// заполнить ListView списком дисков
            /// </summary>
            private void DriveToList()
            {
                this.BeginUpdate();
                this.Items.Clear();
                System.IO.DriveInfo dri;
                string[] strLogicalDrive = System.IO.Directory.GetLogicalDrives();
                foreach (string disk in strLogicalDrive)
                {
                    dri = new System.IO.DriveInfo(disk);
                    if (dri.IsReady) //добавить только готовые диски
                        this.Items.Add(disk);
                }
                this.EndUpdate();
            }
            /// <summary>
            /// заполнить ListView списком папок
            /// </summary>
            private void FoldersToList()
            {
                System.IO.FileAttributes fileattr;
                if (System.IO.Directory.Exists(newFolder))
                {
                    this.BeginUpdate();
                    this.Items.Clear();
                    //получить список каталогов
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(newFolder);
                    System.IO.DirectoryInfo[] folders = di.GetDirectories();
                    //отсортировать по имени
                    var querySortDirectories =
                        from d in folders
                        orderby d.FullName
                        select d;

                    this.Items.Add(@"\...");
                    ListViewItem lvi = new ListViewItem();
                    foreach (var item in querySortDirectories)
                    {
                        fileattr = item.Attributes;
                        //добавить папки в список кроме скрытых
                        if ((fileattr & System.IO.FileAttributes.Hidden) != System.IO.FileAttributes.Hidden)
                        {
                            lvi = this.Items.Add(item.ToString().ToUpper());
                            if (sortOrder == 0)
                                lvi.ForeColor = newColor;
                        }
                    }
                    this.EndUpdate();
                }
            }
            /// <summary>
            /// заполнить ListView списком файлов
            /// </summary>
            private void FilesToList()
            {
                if (System.IO.Directory.Exists(newFolder))
                {
                    this.BeginUpdate();
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(newFolder);
                    //получить список файлов
                    IOrderedEnumerable<FileInfo> fiArrSorted;
                    FileInfo[] fiArr = di.GetFiles();
                    //отсортировать список
                    switch (sortOrder)
                    {
                        case 0:
                            if (sortDirection == SortDirection.ascending)
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.Name
                                    select f;
                            }
                            else
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.Name descending
                                    select f;
                            }
                            break;
                        case 1:
                            if (sortDirection == SortDirection.ascending)
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.Extension
                                    select f;
                            }
                            else
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.Extension descending
                                    select f;
                            }
                            break;
                        case 2:
                            if (sortDirection == SortDirection.ascending)
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.LastWriteTimeUtc descending
                                    select f;
                            }
                            else
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.LastWriteTimeUtc
                                    select f;
                            }
                            break;
                        case 3:
                            if (sortDirection == SortDirection.ascending)
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.Length descending
                                    select f;
                            }
                            else
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.Length
                                    select f;
                            }
                            break;
                        default:
                            if (sortDirection == SortDirection.ascending)
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.Name
                                    select f;
                            }
                            else
                            {
                                fiArrSorted =
                                    from f in fiArr
                                    orderby f.Name descending
                                    select f;
                            }
                            break;
                    }
                    //добавить отсортированный список в листвью
                    System.IO.FileAttributes fileattr;
                    ListViewItem lvi = new ListViewItem();
                    foreach (var item in fiArrSorted)
                    {
                        fileattr = item.Attributes;
                        if ((fileattr & System.IO.FileAttributes.Hidden) != System.IO.FileAttributes.Hidden)
                        {
                            //lvi = this1.Items.Add(item.FullName.ToLower());
                            lvi = this.Items.Add(item.Name.ToLower());
                            if(sortOrder == 0)
                                lvi.ForeColor = newColor;
                            lvi.UseItemStyleForSubItems = false;
                            if(sortOrder == 1)
                                lvi.SubItems.Add(item.Extension.ToString().ToLower(), newColor, oldBackColor, Font);
                            else
                                lvi.SubItems.Add(item.Extension.ToString().ToLower());
                            if(sortOrder == 2)
                                lvi.SubItems.Add(item.LastWriteTime.ToShortDateString(), newColor, oldBackColor, Font);
                            else
                                lvi.SubItems.Add(item.LastWriteTime.ToShortDateString());
                            if(sortOrder == 3)
                                lvi.SubItems.Add(item.Length.ToString().ToLower(), newColor, oldBackColor, Font);
                            else
                                lvi.SubItems.Add(item.Length.ToString().ToLower());
                        }
                    }
                    this.EndUpdate();
                }
            }
            /// <summary>
            /// выделить жирным выбранные файлы
            /// </summary>
            private void BoldSelectedFiles()
            {
                //если есть выбранные файлы
                if (selectedFiles.Count > 0)
                {
                    ListViewItem lvi = new ListViewItem();
                    //находим выбранные файлы в listView1 и выделяемих жирным
                    foreach (var item in selectedFiles)
                    {
                        lvi = this.FindItemWithText(item);
                        //добавить проверку
                        lvi.UseItemStyleForSubItems = false;
                        lvi.Font = newFont;
                    }
                }
            }
            /// <summary>
            /// установить курсор на нужном элементе в listView
            /// вызывается после выбора \...
            /// </summary>
            private void SetPosition()
            {
                this.Focus();
                if (this.Items.Count > 0)
                {
                    //this.Items[0].Selected = true;
                    //this.Items[0].Focused = true;
                    //выбрать элемент
                    this.Focus();
                    int i = 0;
                    string listViewItemText;
                    if (position.Length > 0)
                    {
                        for (i = 0; i < this.Items.Count; i++)
                        {
                            listViewItemText = this.Items[i].SubItems[0].Text;
                            if (position.CompareTo(listViewItemText) == 0)
                                break;
                        }
                    }
                    if (i < 0 || i >= this.Items.Count)
                    {
                        i = 0;
                    }
                    else
                    {
                        this.Items[i].Selected = true;
                        this.Items[i].Focused = true;
                    }
                }
                position = String.Empty;
            }
            /// <summary>
            /// отсортировать файлы в ListView
            /// </summary>
            public void SortList()
            {
                this.Items.Clear();
                FoldersToList();
                FilesToList();
                BoldSelectedFiles();
                SetPosition();
            }
            /// <summary>
            /// получить название папки для отображения
            /// </summary>
            private void GetNewPathListView()
            {
                position = String.Empty;
                string focusedStr;
                if (this.Items.Count == 0)
                {
                    newFolder = String.Empty;
                }

                if (this.FocusedItem != null)
                    focusedStr = this.FocusedItem.SubItems[0].Text.ToString();
                else
                    focusedStr = String.Empty;

                if (focusedStr.EndsWith(@"\...")) //переход влево
                    if (bottomText.Length == 3)
                    {
                        newFolder = String.Empty;
                        bottomText = String.Empty;
                    }
                    else
                    {
                        newFolder = bottomText.Remove(bottomText.LastIndexOf(@"\"));
                        position = newFolder.Substring(newFolder.LastIndexOf(@"\") + 1);
                        newFolder = newFolder.Remove(newFolder.LastIndexOf(@"\") + 1);
                    }
                else //переход вправо
                {
                    if (bottomText.Length < 3)
                        newFolder = focusedStr;
                    else if (bottomText.Length == 3 && focusedStr == String.Empty)
                        newFolder = bottomText;
                    else
                        newFolder = bottomText + focusedStr + "\\";
                }
            }
            /// <summary>
            /// заполнить ListView
            /// </summary>
            public void FillList()
            {
                selectedFiles.Clear();
                selectedDirectories.Clear();
                GetNewPathListView();
                if (newFolder.Length < 3)
                    DriveToList();
                else
                {
                    FoldersToList();
                    FilesToList();
                }
                if (System.IO.Directory.Exists(newFolder))
                {
                    bottomText = newFolder;
                }
                SetPosition();
            }
            /// <summary>
            /// обновить содержимое listView
            /// </summary>
            public void RefillList()
            {
                selectedFiles.Clear();
                selectedDirectories.Clear();
                if ((newFolder.Length < 3) || (Directory.Exists(newFolder) == false))
                {
                    newFolder = String.Empty;
                    bottomText = String.Empty;
                    DriveToList();
                }
                else
                {
                    FoldersToList();
                    FilesToList();
                }
                if (System.IO.Directory.Exists(newFolder))
                {
                    bottomText = newFolder;
                }
                SetPosition();
            }

            #endregion
            #region Events
            //**************************************
            private void listView_DoubleClick(object sender, EventArgs e)
            {
                if (this.FocusedItem != null)
                    if (this.FocusedItem.SubItems[0].Text.ToUpper().Equals
                        (this.FocusedItem.SubItems[0].Text) == false)
                    {
                        //выполнить файл
                        FileOperation fo = new FileOperation(this.bottomText, this.bottomText, 0, 0);
                        fo.RunFile(bottomText + this.FocusedItem.SubItems[0].Text);
                    }
                    else
                    {
                        FillList();
                    }
            }
            //**************************************
            private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
            {
                //отсортировать по колонке
                GetCursorOnFile();
                if (this.sortOrder == e.Column)
                {
                    if (sortDirection == SortDirection.ascending)
                    {
                        sortDirection = SortDirection.descending;
                    }
                    else
                    {
                        sortDirection = SortDirection.ascending;
                    }
                }
                else
                {
                    sortDirection = SortDirection.ascending;
                }
                this.sortOrder = e.Column;
                if (this.bottomText.Length > 2)
                {
                    SortList();
                }
                SetCursorOnFile();
            }
            //**************************************
            private void listView_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.FocusedItem.UseItemStyleForSubItems = false;
                    if (this.FocusedItem.Font == newFont)
                    {
                        //удалить файл из списка выбанных файлов
                        selectedFiles.Remove(this.FocusedItem.SubItems[0].Text);
                        this.FocusedItem.Font = oldFont;
                    }
                    else
                    {
                        //добавить выделенный файл в список
                        selectedFiles.Add(this.FocusedItem.SubItems[0].Text);
                        //перерисовать жирным шрифтом
                        this.FocusedItem.Font = newFont;
                    }
                }
            }
            //**************************************
            private void listView_KeyDown(object sender, KeyEventArgs e)
            {
                int listView1Pos = 0;
                //выделить/отменить выделение
                if (e.KeyCode == Keys.Insert)
                {
                    this.FocusedItem.UseItemStyleForSubItems = false;
                    if (this.FocusedItem.Font == newFont)
                    {
                        //удалить файл из списка выбанных файлов
                        selectedFiles.Remove(this.FocusedItem.SubItems[0].Text);
                        selectedDirectories.Remove(this.FocusedItem.SubItems[0].Text);
                        this.FocusedItem.SubItems[0].Font = oldFont;
                    }
                    else
                    {
                        if (!(this.FocusedItem.SubItems[0].Text.EndsWith("\\...")))
                        {
                            if (this.FocusedItem.SubItems[0].Text.ToUpper().Equals
                                (this.FocusedItem.SubItems[0].Text) == false) //this is a file
                            {
                                //добавить выделенный файл в список
                                selectedFiles.Add(this.FocusedItem.SubItems[0].Text);
                            }
                            else //it is a directory
                            {
                                selectedDirectories.Add(this.FocusedItem.SubItems[0].Text);
                            }
                            //перерисовать жирным шрифтом
                            this.FocusedItem.SubItems[0].Font = newFont;
                        }
                    }
                    listView1Pos = this.Items.IndexOf(this.FocusedItem) + 1;
                    if (listView1Pos < (this.Items.Count))
                    {
                        this.Items[listView1Pos - 1].Selected = false;
                        this.Items[listView1Pos - 1].Focused = false;
                        this.Items[listView1Pos].Selected = true;
                        this.Items[listView1Pos].Focused = true;
                    }
                }
                //отменить выделение
                if (e.KeyCode == Keys.Subtract)
                {
                    //newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
                    for (int i = 0; i < this.Items.Count; i++)
                        this.Items[i].SubItems[0].Font = oldFont;
                    selectedFiles.Clear();
                    selectedDirectories.Clear();
                }
                //выделить все файлы
                if (e.KeyCode == Keys.Add)
                {
                    selectedFiles.Clear();
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i].SubItems[0].Text.EndsWith("\\")) continue;
                        if (this.Items[i].SubItems[0].Text.ToUpper().Equals
                            (this.Items[i].SubItems[0].Text) == false)
                        {
                            this.Items[i].SubItems[0].Font = newFont;
                            selectedFiles.Add(this.Items[i].SubItems[0].Text);
                        }
                    }
                }
                //выделить все зашифрованные файлы
                if (e.KeyCode == Keys.Multiply)
                {
                    selectedFiles.Clear();
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i].SubItems[0].Text.EndsWith("\\")) continue;
                        if (this.Items[i].SubItems[0].Text.ToUpper().Equals
                                (this.Items[i].SubItems[0].Text) == false)
                            if ((this.Items[i].SubItems[0].Text.EndsWith("enc")) ||
                                (this.Items[i].SubItems[0].Text.EndsWith("rjn")) ||
                                (this.Items[i].SubItems[0].Text.EndsWith("trf")))
                            {
                                this.Items[i].SubItems[0].Font = newFont;
                                selectedFiles.Add(this.Items[i].SubItems[0].Text);
                            }
                            else
                            {
                                this.Items[i].SubItems[0].Font = oldFont;
                            }
                    }
                }
                //выделить все не зашифрованные файлы
                if (e.KeyCode == Keys.Divide)
                {
                    selectedFiles.Clear();
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        if (this.Items[i].SubItems[0].Text.EndsWith("\\")) continue;
                        if (this.Items[i].SubItems[0].Text.ToUpper().Equals
                            (this.Items[i].SubItems[0].Text) == false)
                            if ((this.Items[i].SubItems[0].Text.EndsWith("enc")) ||
                                (this.Items[i].SubItems[0].Text.EndsWith("rjn")) ||
                                (this.Items[i].SubItems[0].Text.EndsWith("trf")))
                            {
                                this.Items[i].SubItems[0].Font = oldFont;
                                continue;
                            }
                            else
                            {
                                this.Items[i].SubItems[0].Font = newFont;
                                selectedFiles.Add(this.Items[i].SubItems[0].Text);
                            }
                    }
                }
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    if (this.FocusedItem != null)
                        if (this.FocusedItem.SubItems[0].Text.ToUpper().Equals
                            (this.FocusedItem.SubItems[0].Text) == false)
                        {
                            //выполнить файл
                            /*
                            FileInfo fi = new FileInfo(bottomText + this.FocusedItem.SubItems[0].Text);
                            if (fi.Extension == ".zip")
                            {
                                ZipStorer zip = ZipStorer.Open(bottomText + this.FocusedItem.SubItems[0].Text, FileAccess.Read);
                                List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();
                                this.BeginUpdate();
                                this.Items.Clear();
                                foreach (ZipStorer.ZipFileEntry entry in dir)
                                {
                                    this.Items.Add(entry.FilenameInZip);
                                }
                                this.EndUpdate();
                                zip.Close();
                            }
                            else
                            {
                             */
                            FileOperation fo = new FileOperation(this.bottomText, this.bottomText, 0, 0);
                                fo.RunFile(bottomText + this.FocusedItem.SubItems[0].Text);
                            //}

                        }
                        else
                            FillList();
                }
                if (e.KeyCode == Keys.F3)
                {
                    if (this.FocusedItem != null)
                        if (this.FocusedItem.SubItems[0].Text.ToUpper().Equals
                            (this.FocusedItem.SubItems[0].Text) == false)
                        {
                            //просмотр файла
                            ViewForm viewForm = new ViewForm();
                            viewForm.viewFileName = bottomText + this.FocusedItem.SubItems[0].Text;
                            viewForm.Show();
                        }
                }
                if (e.KeyCode == Keys.F4)
                {
                    if (this.FocusedItem != null)
                        if (this.FocusedItem.SubItems[0].Text.ToUpper().Equals
                            (this.FocusedItem.SubItems[0].Text) == false)
                        {
                            //редактировать файл
                            FileOperation fo = new FileOperation(this.bottomText, this.bottomText, 0, 0);
                            fo.EditFile(pathToEditorProg, bottomText + this.FocusedItem.SubItems[0].Text);
                        }
                }
                if (e.KeyCode == Keys.F8 || e.KeyCode == Keys.Delete)
                {
                    GetCursorOnFile();
                    if (selectedFiles.Count == 0)
                    {
                        if (this.FocusedItem.SubItems[0].Text.ToUpper().Equals
                            (this.FocusedItem.SubItems[0].Text) == false)
                        {
                            selectedFiles.Add(this.FocusedItem.SubItems[0].Text);
                        }
                        else
                        {
                            if (!(this.FocusedItem.SubItems[0].Text.EndsWith("\\...")))
                            {
                                if (selectedDirectories.Count == 0)
                                    selectedDirectories.Add(this.FocusedItem.SubItems[0].Text);
                            }
                        }
                    }
                    FileOperation fo = new FileOperation(this.bottomText, this.bottomText, 1, 0);
                    fo.DeleteListFiles(selectedFiles, selectedDirectories);
                    //RefillList();
                    //сначала нахожу родительскую форму
                    Control parent = this;
                    while (parent != null && parent.GetType() != typeof(CipherProject))
                    {
                        parent = GetParentControl(parent);
                    }
                    //обновить PanelListView
                    if (parent != null)
                    {
                        var b = (CipherProject)parent;
                        b.RefillListView();
                    }
                    else
                    {
                        RefillList();
                    }
                    /*
                     * для примера пусть останется
                    //найти PanelListView и вызвать RefillList
                    FindAnotherPanelListView(parent);
                    */
                    SetCursorOnFile();
                }
            }
            /// <summary>
            /// найти родительскую форму
            /// </summary>
            private Control GetParentControl(Control ctrl)
            {
                return ctrl.Parent;
            }
            /// <summary>
            /// функция для нахождения PanelListView
            /// не используется
            /// </summary>
            private void FindAnotherPanelListView(Control parent)
            {
                if (parent != null)
                {
                    if (parent.GetType() == typeof(PanelListView))
                    {
                        var b = (PanelListView)parent;
                        b.RefillList();
                    }
                    foreach (Control ctrl in parent.Controls)
                    {
                        FindAnotherPanelListView(ctrl); //рекурсия
                    }
                }
            }
            /// <summary>
            /// установка ширины колонок
            /// </summary>
            private void listView_SizeChanged(object sender, EventArgs e)
            {
                ResizeColumns();
            }

            private void ResizeColumns()
            {
                int sumWidthColumns;
                sumWidthColumns = widthColumnName + widthColumnExt + widthColumnDate + widthColumnSize;
                if (this.Size.Width > sumWidthColumns)
                {
                    this.Columns[1].Width = 50;
                    this.Columns[2].Width = 80;
                    this.Columns[3].Width = 85;
                    this.Columns[0].Width = this.Size.Width - 30 -
                        (widthColumnExt + widthColumnDate + widthColumnSize);
                }
            }
            #endregion
        }
    }
}
