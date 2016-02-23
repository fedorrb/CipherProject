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
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rijndaelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threeFishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programForEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRandomBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.listLeft = new CipherProject.PanelListView();
            this.columnLName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.leftDrivePanel = new System.Windows.Forms.Panel();
            this.bottomLeftPanel = new System.Windows.Forms.Panel();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.listRight = new CipherProject.PanelListView();
            this.columnRName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRExt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bottomRightPanel = new System.Windows.Forms.Panel();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.rightDrivePanel = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.bottomLeftPanel.SuspendLayout();
            this.bottomRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(972, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rijndaelToolStripMenuItem,
            this.threeFishToolStripMenuItem,
            this.deleteSourceToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.programForEditToolStripMenuItem,
            this.addRandomBlockToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // rijndaelToolStripMenuItem
            // 
            this.rijndaelToolStripMenuItem.Name = "rijndaelToolStripMenuItem";
            this.rijndaelToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.rijndaelToolStripMenuItem.Text = "Rijndael";
            this.rijndaelToolStripMenuItem.Click += new System.EventHandler(this.rijndaelToolStripMenuItem_Click);
            // 
            // threeFishToolStripMenuItem
            // 
            this.threeFishToolStripMenuItem.Name = "threeFishToolStripMenuItem";
            this.threeFishToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.threeFishToolStripMenuItem.Text = "ThreeFish";
            this.threeFishToolStripMenuItem.Click += new System.EventHandler(this.threeFishToolStripMenuItem_Click);
            // 
            // deleteSourceToolStripMenuItem
            // 
            this.deleteSourceToolStripMenuItem.Name = "deleteSourceToolStripMenuItem";
            this.deleteSourceToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.deleteSourceToolStripMenuItem.Text = "DeleteSource";
            this.deleteSourceToolStripMenuItem.Click += new System.EventHandler(this.deleteSourceToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.changePasswordToolStripMenuItem.Text = "ChangePassword";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // programForEditToolStripMenuItem
            // 
            this.programForEditToolStripMenuItem.Name = "programForEditToolStripMenuItem";
            this.programForEditToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.programForEditToolStripMenuItem.Text = "Program for editing";
            this.programForEditToolStripMenuItem.Click += new System.EventHandler(this.programForEditToolStripMenuItem_Click);
            // 
            // addRandomBlockToolStripMenuItem
            // 
            this.addRandomBlockToolStripMenuItem.Name = "addRandomBlockToolStripMenuItem";
            this.addRandomBlockToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.addRandomBlockToolStripMenuItem.Text = "Add random block";
            this.addRandomBlockToolStripMenuItem.Click += new System.EventHandler(this.addRandomBlockToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
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
            this.buttonsPanel.Location = new System.Drawing.Point(0, 536);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(972, 30);
            this.buttonsPanel.TabIndex = 2;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.refreshBtn.Location = new System.Drawing.Point(680, 0);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(85, 30);
            this.refreshBtn.TabIndex = 7;
            this.refreshBtn.TabStop = false;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // decodingBtn
            // 
            this.decodingBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.decodingBtn.Location = new System.Drawing.Point(595, 0);
            this.decodingBtn.Name = "decodingBtn";
            this.decodingBtn.Size = new System.Drawing.Size(85, 30);
            this.decodingBtn.TabIndex = 6;
            this.decodingBtn.TabStop = false;
            this.decodingBtn.Text = "F10 Decrypt";
            this.decodingBtn.UseVisualStyleBackColor = true;
            this.decodingBtn.Click += new System.EventHandler(this.decodingBtn_Click);
            // 
            // encodingBtn
            // 
            this.encodingBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.encodingBtn.Location = new System.Drawing.Point(510, 0);
            this.encodingBtn.Name = "encodingBtn";
            this.encodingBtn.Size = new System.Drawing.Size(85, 30);
            this.encodingBtn.TabIndex = 5;
            this.encodingBtn.TabStop = false;
            this.encodingBtn.Text = "F9 Encrypt";
            this.encodingBtn.UseVisualStyleBackColor = true;
            this.encodingBtn.Click += new System.EventHandler(this.encodingBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteBtn.Location = new System.Drawing.Point(425, 0);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(85, 30);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.TabStop = false;
            this.deleteBtn.Text = "F8 Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // makeDirButton
            // 
            this.makeDirButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.makeDirButton.Location = new System.Drawing.Point(340, 0);
            this.makeDirButton.Name = "makeDirButton";
            this.makeDirButton.Size = new System.Drawing.Size(85, 30);
            this.makeDirButton.TabIndex = 3;
            this.makeDirButton.TabStop = false;
            this.makeDirButton.Text = "F7 MakeDir";
            this.makeDirButton.UseVisualStyleBackColor = true;
            this.makeDirButton.Click += new System.EventHandler(this.makeDirButton_Click);
            // 
            // moveBtn
            // 
            this.moveBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.moveBtn.Location = new System.Drawing.Point(255, 0);
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(85, 30);
            this.moveBtn.TabIndex = 2;
            this.moveBtn.TabStop = false;
            this.moveBtn.Text = "F6 Move";
            this.moveBtn.UseVisualStyleBackColor = true;
            this.moveBtn.Click += new System.EventHandler(this.moveBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.copyBtn.Location = new System.Drawing.Point(170, 0);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(85, 30);
            this.copyBtn.TabIndex = 1;
            this.copyBtn.TabStop = false;
            this.copyBtn.Text = "F5 Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.editBtn.Location = new System.Drawing.Point(85, 0);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(85, 30);
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
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(85, 30);
            this.viewBtn.TabIndex = 8;
            this.viewBtn.TabStop = false;
            this.viewBtn.Text = "F3 View";
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listLeft);
            this.splitContainer1.Panel1.Controls.Add(this.leftDrivePanel);
            this.splitContainer1.Panel1.Controls.Add(this.bottomLeftPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listRight);
            this.splitContainer1.Panel2.Controls.Add(this.bottomRightPanel);
            this.splitContainer1.Panel2.Controls.Add(this.rightDrivePanel);
            this.splitContainer1.Size = new System.Drawing.Size(972, 512);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.SizeChanged += new System.EventHandler(this.splitContainer1_SizeChanged);
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
            this.listLeft.FullRowSelect = true;
            this.listLeft.GridLines = true;
            this.listLeft.HideSelection = false;
            this.listLeft.Location = new System.Drawing.Point(0, 30);
            this.listLeft.Name = "listLeft";
            this.listLeft.newFolder = "";
            this.listLeft.pathToEditorProg = "";
            this.listLeft.Size = new System.Drawing.Size(486, 459);
            this.listLeft.TabIndex = 1;
            this.listLeft.UseCompatibleStateImageBehavior = false;
            this.listLeft.View = System.Windows.Forms.View.Details;
            this.listLeft.SelectedIndexChanged += new System.EventHandler(this.listLeft_SelectedIndexChanged);
            this.listLeft.Enter += new System.EventHandler(this.listLeft_Enter);
            this.listLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listLeft_KeyDown);
            // 
            // columnLName
            // 
            this.columnLName.Text = "Name";
            this.columnLName.Width = 241;
            // 
            // columnLExt
            // 
            this.columnLExt.Text = "Ext";
            this.columnLExt.Width = 50;
            // 
            // columnLDate
            // 
            this.columnLDate.Text = "Date";
            this.columnLDate.Width = 80;
            // 
            // columnLSize
            // 
            this.columnLSize.Text = "Size";
            this.columnLSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnLSize.Width = 85;
            // 
            // leftDrivePanel
            // 
            this.leftDrivePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftDrivePanel.Location = new System.Drawing.Point(0, 0);
            this.leftDrivePanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftDrivePanel.Name = "leftDrivePanel";
            this.leftDrivePanel.Size = new System.Drawing.Size(486, 30);
            this.leftDrivePanel.TabIndex = 0;
            // 
            // bottomLeftPanel
            // 
            this.bottomLeftPanel.Controls.Add(this.textBoxLeft);
            this.bottomLeftPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomLeftPanel.Location = new System.Drawing.Point(0, 489);
            this.bottomLeftPanel.Name = "bottomLeftPanel";
            this.bottomLeftPanel.Size = new System.Drawing.Size(486, 23);
            this.bottomLeftPanel.TabIndex = 2;
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(486, 20);
            this.textBoxLeft.TabIndex = 0;
            this.textBoxLeft.TabStop = false;
            // 
            // listRight
            // 
            this.listRight.bottomText = "";
            this.listRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRName,
            this.columnRExt,
            this.columnRDate,
            this.columnRSize});
            this.listRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRight.FullRowSelect = true;
            this.listRight.GridLines = true;
            this.listRight.HideSelection = false;
            this.listRight.Location = new System.Drawing.Point(0, 30);
            this.listRight.Name = "listRight";
            this.listRight.newFolder = "";
            this.listRight.pathToEditorProg = "";
            this.listRight.Size = new System.Drawing.Size(482, 459);
            this.listRight.TabIndex = 1;
            this.listRight.UseCompatibleStateImageBehavior = false;
            this.listRight.View = System.Windows.Forms.View.Details;
            this.listRight.SelectedIndexChanged += new System.EventHandler(this.listRight_SelectedIndexChanged);
            this.listRight.Enter += new System.EventHandler(this.listRight_Enter);
            this.listRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listRight_KeyDown);
            // 
            // columnRName
            // 
            this.columnRName.Text = "Name";
            this.columnRName.Width = 237;
            // 
            // columnRExt
            // 
            this.columnRExt.Text = "Ext";
            this.columnRExt.Width = 50;
            // 
            // columnRDate
            // 
            this.columnRDate.Text = "Date";
            this.columnRDate.Width = 80;
            // 
            // columnRSize
            // 
            this.columnRSize.Text = "Size";
            this.columnRSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnRSize.Width = 85;
            // 
            // bottomRightPanel
            // 
            this.bottomRightPanel.Controls.Add(this.textBoxRight);
            this.bottomRightPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomRightPanel.Location = new System.Drawing.Point(0, 489);
            this.bottomRightPanel.Name = "bottomRightPanel";
            this.bottomRightPanel.Size = new System.Drawing.Size(482, 23);
            this.bottomRightPanel.TabIndex = 2;
            // 
            // textBoxRight
            // 
            this.textBoxRight.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRight.Location = new System.Drawing.Point(0, 0);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(482, 20);
            this.textBoxRight.TabIndex = 0;
            this.textBoxRight.TabStop = false;
            // 
            // rightDrivePanel
            // 
            this.rightDrivePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightDrivePanel.Location = new System.Drawing.Point(0, 0);
            this.rightDrivePanel.Margin = new System.Windows.Forms.Padding(0);
            this.rightDrivePanel.Name = "rightDrivePanel";
            this.rightDrivePanel.Size = new System.Drawing.Size(482, 30);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 566);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonsPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(980, 600);
            this.Name = "CipherProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CipherProject";
            this.Load += new System.EventHandler(this.CipherProject_Load);
            this.Resize += new System.EventHandler(this.CipherProject_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.bottomLeftPanel.ResumeLayout(false);
            this.bottomLeftPanel.PerformLayout();
            this.bottomRightPanel.ResumeLayout(false);
            this.bottomRightPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rijndaelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeFishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
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
        private System.Windows.Forms.ColumnHeader columnLName;
        private System.Windows.Forms.ColumnHeader columnLExt;
        private System.Windows.Forms.ColumnHeader columnLDate;
        private System.Windows.Forms.ColumnHeader columnLSize;
        private System.Windows.Forms.ColumnHeader columnRName;
        private System.Windows.Forms.ColumnHeader columnRExt;
        private System.Windows.Forms.ColumnHeader columnRDate;
        private System.Windows.Forms.ColumnHeader columnRSize;
        private System.Windows.Forms.Panel bottomLeftPanel;
        private System.Windows.Forms.Panel bottomRightPanel;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxRight;
        private PanelListView listRight;
        private PanelListView listLeft;
        private System.Windows.Forms.Button makeDirButton;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button viewBtn;
        private System.Windows.Forms.ToolStripMenuItem programForEditToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem addRandomBlockToolStripMenuItem;
    }
}

