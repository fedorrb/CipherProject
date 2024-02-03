namespace CipherProject
{
    partial class CipherProject
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CipherProject));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rijndaelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRandomBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.threeFishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programForEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonsPanel = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.decodingBtn = new System.Windows.Forms.Button();
            this.encodingBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.makeDirButton = new System.Windows.Forms.Button();
            this.moveBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.viewBtn = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listLeft = new CipherProject.PanelListView();
            this.columnLName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.leftDrivePanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listRight = new CipherProject.PanelListView();
            this.columnRName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.rightDrivePanel = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1332, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(74, 18);
            this.aboutToolStripMenuItem.Text = "About (F1)";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.versionToolStripMenuItem.Text = "About";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rijndaelToolStripMenuItem,
            this.addRandomBlockToolStripMenuItem,
            this.toolStripSeparator2,
            this.threeFishToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteSourceToolStripMenuItem,
            this.programForEditToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 18);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // rijndaelToolStripMenuItem
            // 
            this.rijndaelToolStripMenuItem.Name = "rijndaelToolStripMenuItem";
            this.rijndaelToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.rijndaelToolStripMenuItem.Text = "AES, RijnDael, key 256bit";
            this.rijndaelToolStripMenuItem.Click += new System.EventHandler(this.rijndaelToolStripMenuItem_Click);
            // 
            // addRandomBlockToolStripMenuItem
            // 
            this.addRandomBlockToolStripMenuItem.Name = "addRandomBlockToolStripMenuItem";
            this.addRandomBlockToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.addRandomBlockToolStripMenuItem.Text = "Invert first block";
            this.addRandomBlockToolStripMenuItem.Click += new System.EventHandler(this.addRandomBlockToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(222, 6);
            // 
            // threeFishToolStripMenuItem
            // 
            this.threeFishToolStripMenuItem.Name = "threeFishToolStripMenuItem";
            this.threeFishToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.threeFishToolStripMenuItem.Text = "Threefish, key 1024 bit";
            this.threeFishToolStripMenuItem.Click += new System.EventHandler(this.threeFishToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // deleteSourceToolStripMenuItem
            // 
            this.deleteSourceToolStripMenuItem.Name = "deleteSourceToolStripMenuItem";
            this.deleteSourceToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.deleteSourceToolStripMenuItem.Text = "Delete files after encrypt";
            this.deleteSourceToolStripMenuItem.Click += new System.EventHandler(this.deleteSourceToolStripMenuItem_Click);
            // 
            // programForEditToolStripMenuItem
            // 
            this.programForEditToolStripMenuItem.Name = "programForEditToolStripMenuItem";
            this.programForEditToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.programForEditToolStripMenuItem.Text = "External program for editing";
            this.programForEditToolStripMenuItem.Click += new System.EventHandler(this.programForEditToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(126, 19);
            this.changePasswordToolStripMenuItem.Text = "Clear password (F2)";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(66, 18);
            this.exitToolStripMenuItem.Text = "Exit (Esc)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Controls.Add(this.refreshBtn);
            this.buttonsPanel.Controls.Add(this.decodingBtn);
            this.buttonsPanel.Controls.Add(this.encodingBtn);
            this.buttonsPanel.Controls.Add(this.deleteBtn);
            this.buttonsPanel.Controls.Add(this.makeDirButton);
            this.buttonsPanel.Controls.Add(this.moveBtn);
            this.buttonsPanel.Controls.Add(this.copyBtn);
            this.buttonsPanel.Controls.Add(this.editBtn);
            this.buttonsPanel.Controls.Add(this.viewBtn);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonsPanel.Location = new System.Drawing.Point(0, 776);
            this.buttonsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(1332, 44);
            this.buttonsPanel.TabIndex = 2;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.refreshBtn.Location = new System.Drawing.Point(912, 0);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(4);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(114, 44);
            this.refreshBtn.TabIndex = 7;
            this.refreshBtn.TabStop = false;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // decodingBtn
            // 
            this.decodingBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.decodingBtn.Location = new System.Drawing.Point(798, 0);
            this.decodingBtn.Margin = new System.Windows.Forms.Padding(4);
            this.decodingBtn.Name = "decodingBtn";
            this.decodingBtn.Size = new System.Drawing.Size(114, 44);
            this.decodingBtn.TabIndex = 6;
            this.decodingBtn.TabStop = false;
            this.decodingBtn.Text = "F10 Decrypt";
            this.decodingBtn.UseVisualStyleBackColor = true;
            this.decodingBtn.Click += new System.EventHandler(this.decodingBtn_Click);
            // 
            // encodingBtn
            // 
            this.encodingBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.encodingBtn.Location = new System.Drawing.Point(684, 0);
            this.encodingBtn.Margin = new System.Windows.Forms.Padding(4);
            this.encodingBtn.Name = "encodingBtn";
            this.encodingBtn.Size = new System.Drawing.Size(114, 44);
            this.encodingBtn.TabIndex = 5;
            this.encodingBtn.TabStop = false;
            this.encodingBtn.Text = "F9 Encrypt";
            this.encodingBtn.UseVisualStyleBackColor = true;
            this.encodingBtn.Click += new System.EventHandler(this.encodingBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteBtn.Location = new System.Drawing.Point(570, 0);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(114, 44);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.TabStop = false;
            this.deleteBtn.Text = "F8 Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // makeDirButton
            // 
            this.makeDirButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.makeDirButton.Location = new System.Drawing.Point(456, 0);
            this.makeDirButton.Margin = new System.Windows.Forms.Padding(4);
            this.makeDirButton.Name = "makeDirButton";
            this.makeDirButton.Size = new System.Drawing.Size(114, 44);
            this.makeDirButton.TabIndex = 3;
            this.makeDirButton.TabStop = false;
            this.makeDirButton.Text = "F7 MakeDir";
            this.makeDirButton.UseVisualStyleBackColor = true;
            this.makeDirButton.Click += new System.EventHandler(this.makeDirButton_Click);
            // 
            // moveBtn
            // 
            this.moveBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.moveBtn.Location = new System.Drawing.Point(342, 0);
            this.moveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(114, 44);
            this.moveBtn.TabIndex = 2;
            this.moveBtn.TabStop = false;
            this.moveBtn.Text = "F6 Move";
            this.moveBtn.UseVisualStyleBackColor = true;
            this.moveBtn.Click += new System.EventHandler(this.moveBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.copyBtn.Location = new System.Drawing.Point(228, 0);
            this.copyBtn.Margin = new System.Windows.Forms.Padding(4);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(114, 44);
            this.copyBtn.TabIndex = 1;
            this.copyBtn.TabStop = false;
            this.copyBtn.Text = "F5 Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.editBtn.Location = new System.Drawing.Point(114, 0);
            this.editBtn.Margin = new System.Windows.Forms.Padding(4);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(114, 44);
            this.editBtn.TabIndex = 9;
            this.editBtn.TabStop = false;
            this.editBtn.Text = "F4 Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // viewBtn
            // 
            this.viewBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.viewBtn.Location = new System.Drawing.Point(0, 0);
            this.viewBtn.Margin = new System.Windows.Forms.Padding(4);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(114, 44);
            this.viewBtn.TabIndex = 8;
            this.viewBtn.TabStop = false;
            this.viewBtn.Text = "F3 View";
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.leftDrivePanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.rightDrivePanel);
            this.splitContainer1.Size = new System.Drawing.Size(1332, 751);
            this.splitContainer1.SplitterDistance = 666;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.SizeChanged += new System.EventHandler(this.splitContainer1_SizeChanged);
            // 
            // panel4
            // 
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.listLeft);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(666, 684);
            this.panel4.TabIndex = 5;
            // 
            // listLeft
            // 
            this.listLeft.bottomText = "";
            this.listLeft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnLName,
            this.columnLExt,
            this.columnLDate,
            this.columnLSize});
            this.listLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLeft.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listLeft.ForeColor = System.Drawing.Color.Black;
            this.listLeft.FullRowSelect = true;
            this.listLeft.GridLines = true;
            this.listLeft.HideSelection = false;
            this.listLeft.Location = new System.Drawing.Point(0, 0);
            this.listLeft.Margin = new System.Windows.Forms.Padding(4);
            this.listLeft.Name = "listLeft";
            this.listLeft.newFolder = "";
            this.listLeft.pathToEditorProg = "";
            this.listLeft.Size = new System.Drawing.Size(666, 684);
            this.listLeft.TabIndex = 2;
            this.listLeft.UseCompatibleStateImageBehavior = false;
            this.listLeft.View = System.Windows.Forms.View.Details;
            this.listLeft.SelectedIndexChanged += new System.EventHandler(this.listLeft_SelectedIndexChanged);
            this.listLeft.Enter += new System.EventHandler(this.listLeft_Enter);
            this.listLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listLeft_KeyDown);
            // 
            // columnLName
            // 
            this.columnLName.Text = "Name";
            this.columnLName.Width = 361;
            // 
            // columnLExt
            // 
            this.columnLExt.Text = "Ext";
            this.columnLExt.Width = 50;
            // 
            // columnLDate
            // 
            this.columnLDate.Text = "Date";
            this.columnLDate.Width = 95;
            // 
            // columnLSize
            // 
            this.columnLSize.Text = "Size";
            this.columnLSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnLSize.Width = 130;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.textBoxLeft);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(666, 23);
            this.panel3.TabIndex = 4;
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxLeft.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLeft.ForeColor = System.Drawing.Color.Black;
            this.textBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.textBoxLeft.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.ReadOnly = true;
            this.textBoxLeft.Size = new System.Drawing.Size(666, 23);
            this.textBoxLeft.TabIndex = 4;
            this.textBoxLeft.TabStop = false;
            // 
            // leftDrivePanel
            // 
            this.leftDrivePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftDrivePanel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftDrivePanel.ForeColor = System.Drawing.Color.DarkBlue;
            this.leftDrivePanel.Location = new System.Drawing.Point(0, 0);
            this.leftDrivePanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftDrivePanel.Name = "leftDrivePanel";
            this.leftDrivePanel.Size = new System.Drawing.Size(666, 44);
            this.leftDrivePanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.listRight);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(661, 684);
            this.panel2.TabIndex = 5;
            // 
            // listRight
            // 
            this.listRight.BackColor = System.Drawing.SystemColors.Window;
            this.listRight.bottomText = "";
            this.listRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRName,
            this.columnRExt,
            this.columnRDate,
            this.columnRSize});
            this.listRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRight.Font = new System.Drawing.Font("Calibri", 11F);
            this.listRight.ForeColor = System.Drawing.Color.Black;
            this.listRight.FullRowSelect = true;
            this.listRight.GridLines = true;
            this.listRight.HideSelection = false;
            this.listRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listRight.Location = new System.Drawing.Point(0, 0);
            this.listRight.Margin = new System.Windows.Forms.Padding(4);
            this.listRight.Name = "listRight";
            this.listRight.newFolder = "";
            this.listRight.pathToEditorProg = "";
            this.listRight.Size = new System.Drawing.Size(661, 684);
            this.listRight.TabIndex = 2;
            this.listRight.TileSize = new System.Drawing.Size(50, 50);
            this.listRight.UseCompatibleStateImageBehavior = false;
            this.listRight.View = System.Windows.Forms.View.Details;
            this.listRight.SelectedIndexChanged += new System.EventHandler(this.listRight_SelectedIndexChanged);
            this.listRight.Enter += new System.EventHandler(this.listRight_Enter);
            this.listRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listRight_KeyDown);
            // 
            // columnRName
            // 
            this.columnRName.Text = "Name";
            this.columnRName.Width = 356;
            // 
            // columnRExt
            // 
            this.columnRExt.Text = "Ext";
            this.columnRExt.Width = 50;
            // 
            // columnRDate
            // 
            this.columnRDate.Text = "Date";
            this.columnRDate.Width = 95;
            // 
            // columnRSize
            // 
            this.columnRSize.Text = "Size";
            this.columnRSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnRSize.Width = 130;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.textBoxRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 23);
            this.panel1.TabIndex = 4;
            // 
            // textBoxRight
            // 
            this.textBoxRight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxRight.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRight.ForeColor = System.Drawing.Color.Black;
            this.textBoxRight.Location = new System.Drawing.Point(0, 0);
            this.textBoxRight.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.ReadOnly = true;
            this.textBoxRight.Size = new System.Drawing.Size(661, 23);
            this.textBoxRight.TabIndex = 4;
            this.textBoxRight.TabStop = false;
            // 
            // rightDrivePanel
            // 
            this.rightDrivePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightDrivePanel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightDrivePanel.ForeColor = System.Drawing.Color.DarkBlue;
            this.rightDrivePanel.Location = new System.Drawing.Point(0, 0);
            this.rightDrivePanel.Margin = new System.Windows.Forms.Padding(0);
            this.rightDrivePanel.Name = "rightDrivePanel";
            this.rightDrivePanel.Size = new System.Drawing.Size(661, 44);
            this.rightDrivePanel.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CipherProject";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // CipherProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 820);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1301, 859);
            this.Name = "CipherProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EncryptEasy";
            this.Load += new System.EventHandler(this.CipherProject_Load);
            this.SizeChanged += new System.EventHandler(this.CipherProject_SizeChanged);
            this.Resize += new System.EventHandler(this.CipherProject_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rijndaelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeFishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel buttonsPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel leftDrivePanel;
        private System.Windows.Forms.Panel rightDrivePanel;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button decodingBtn;
        private System.Windows.Forms.Button encodingBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button moveBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button makeDirButton;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button viewBtn;
        private System.Windows.Forms.ToolStripMenuItem programForEditToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem addRandomBlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private CipherProject.PanelListView listLeft;
        private System.Windows.Forms.ColumnHeader columnLName;
        private System.Windows.Forms.ColumnHeader columnLExt;
        private System.Windows.Forms.ColumnHeader columnLDate;
        private System.Windows.Forms.ColumnHeader columnLSize;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.Panel panel2;
        private CipherProject.PanelListView listRight;
        private System.Windows.Forms.ColumnHeader columnRName;
        private System.Windows.Forms.ColumnHeader columnRExt;
        private System.Windows.Forms.ColumnHeader columnRDate;
        private System.Windows.Forms.ColumnHeader columnRSize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxRight;
    }
}

