using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CipherProject
{
    class DriveButtons
    {
        private Panel leftDrivePanel;
        private Panel rightDrivePanel;
        private int buttonSizeX;
        private Point buttonPosition;
        /// <summary>
        /// получить список готовых дисков
        /// </summary>
        /// <returns>список дисков ("c:\","d:\"...)</returns>
        private List<string> GetReadyDriveButtons()
        {
            System.IO.DriveInfo dri;
            //получить список логических дисков
            List<string> listLogicalDrive;
            List<string> listReadyDrive;
            listLogicalDrive = System.IO.Directory.GetLogicalDrives().ToList();
            listReadyDrive = new List<string>(listLogicalDrive);
            foreach (string disk in listLogicalDrive)
            {
                dri = new System.IO.DriveInfo(disk);
                if (dri.IsReady == false)
                {
                    listReadyDrive.Remove(disk);
                }
            }
            return listReadyDrive;
        }
        /// <summary>
        /// не используется
        /// </summary>
        private DriveButtons()
        {
            leftDrivePanel = new Panel();
            rightDrivePanel = new Panel();
            buttonSizeX = 35;
            buttonPosition = new Point(0, 0);
        }
        /// <summary>
        /// конструктор для панели
        /// </summary>
        /// <param name="pnlLeft">левая панель</param>
        /// <param name="pnlRight">правая панель</param>
        public DriveButtons(Panel pnlLeft, Panel pnlRight)
        {
            leftDrivePanel = pnlLeft;
            rightDrivePanel = pnlRight;
            buttonSizeX = 35;
            buttonPosition = new Point(0, 0);
        }
        /// <summary>
        /// максимальное кол-во кнопок
        /// </summary>
        private void GetSizeXButtons(int countDisk)
        {
            buttonSizeX = leftDrivePanel.Size.Width / countDisk;
        }
        /// <summary>
        /// нарисовать кнопки дисков
        /// </summary>
        public void DrawButtonDrive()
        {
            leftDrivePanel.Controls.Clear();
            rightDrivePanel.Controls.Clear();
            int posX = 0;

            List<string> strLogicalDrive = GetReadyDriveButtons();
            GetSizeXButtons(strLogicalDrive.Count);
            foreach (string disk in strLogicalDrive)
            {
                Button bt1 = new Button();
                SetButtonProperties(posX, disk, bt1);
                leftDrivePanel.Controls.Add(bt1);
                Button bt2 = new Button();
                SetButtonProperties(posX, disk, bt2);
                rightDrivePanel.Controls.Add(bt2);
                posX += buttonSizeX;
            }
        }
        /// <summary>
        /// свойства кнопки
        /// </summary>
        /// <param name="posX">координата х</param>
        /// <param name="disk">текстовое название диска</param>
        /// <param name="btn">имя кнопки</param>
        private void SetButtonProperties(int posX, string disk, Button btn)
        {
            btn.Size = new Size(buttonSizeX, leftDrivePanel.Size.Height);
            btn.Location = new Point(posX, 0);
            btn.TabStop = false;
            btn.Text = disk;
            //btn.Font = new Font(FontFamily.GenericSansSerif, leftDrivePanel.Size.Height / 4);
        }

        public void ResizeButton()
        {
            int posX = 0;
            buttonSizeX = leftDrivePanel.Size.Width / leftDrivePanel.Controls.Count;
            foreach (Control btn in leftDrivePanel.Controls)
            {
                if (btn.GetType() == typeof(Button))
                {
                    btn.Size = new Size(buttonSizeX, leftDrivePanel.Size.Height);
                    btn.Location = new Point(posX, 0);
                    posX += buttonSizeX;
                }
            }
            posX = 0;
            foreach (Control btn in rightDrivePanel.Controls)
            {
                if (btn.GetType() == typeof(Button))
                {
                    btn.Size = new Size(buttonSizeX, leftDrivePanel.Size.Height);
                    btn.Location = new Point(posX, 0);
                    posX += buttonSizeX;
                }
            }
        }
    }
}
