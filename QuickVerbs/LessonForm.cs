using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Management;

namespace QuickVerbs
{
    public partial class LessonForm : Telerik.WinControls.UI.RadForm
    {
        MainForm mainForm;
        //--------------------------------------------------------------------------
        public LessonForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            mainForm.timerLesson.Enabled = false;

            Point p = new Point();

            p = Properties.Settings.Default.LessonPos;
            if ((p.X == -1) && (p.Y == -1))
            {
                p.X = SystemInformation.PrimaryMonitorSize.Width - this.Width - 10;
                p.Y = SystemInformation.PrimaryMonitorSize.Height - this.Height - 40;
            }

           this.Location = p;

            if (Properties.Settings.Default.LessonVerbs == 1)
            {
                radButtonNext.Visible = false;
            }
        }
        //--------------------------------------------------------------------------
        private void CloseLessons()
        {
            mainForm.TimerOut = false;
            mainForm.timerLesson.Interval = Properties.Settings.Default.Period * 3600000;
            mainForm.timerLesson.Enabled = true;

            Properties.Settings.Default.LessonPos = this.Location;
        }
        //--------------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------------------------------------------
        private void LessonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseLessons();
            e.Cancel = false;
        }
        //--------------------------------------------------------------------------
        private void btnCheck_Click(object sender, EventArgs e)
        {
            //TODO: иконку вставить
            //Обсудить как тут лучше
        }
        //--------------------------------------------------------------------------
    }
}
