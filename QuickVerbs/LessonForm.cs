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
        public DataTable dt = new DataTable();
        int VerbLessonCount = 1;

        //--------------------------------------------------------------------------
        public LessonForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            mainForm.timerLesson.Enabled = false;

            VerbLessonCount = Properties.Settings.Default.LessonVerbs;

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
        private void LessonForm_Load(object sender, EventArgs e)
        {
            dt = mainForm.Df.FetchAll("CurrentVerbs", String.Format("WHERE CategoryNumber = {0} AND Closed = \"false\"", mainForm.Category), "FirstForm, FirstFormSound, SecondForm, SecondFormSound, ThirdForm, ThirdFormSound, Translate, CategoryNumber, CategoryName, Closed, Example1, ExampleSound1, Example2, ExampleSound2, Example3, ExampleSound3, RightAnswers, ID, ID_Verb, StudyLevel");

            //TODO: если не будет вообще - то вывести, что уровень выучен и вопроc о переводе на новый уровень

            List<int> inxexist = new List<int>();
            //Продолжение
            //DataRow[] dr1 = new DataRow[VerbLessonCount];
            //dr1 = dt.Select("StudyLevel > 0");

            DataRow[] dr2 = dt.Select("StudyLevel = 0");

            //Сколько глаголов нужно подгрузить
            //TODO:
            int newCount = VerbLessonCount - 0; //dr1.Length;

            //Новые
            //DataRow[] dr0 = new DataRow[newCount];

            Random rn = new Random(dr2.Length-1);

            //if (dr1.Length < VerbLessonCount)
            //{
             //   for (int i = 0; i < newCount; i++)
            //    {
                    //TODO:
            //        int inx = rn.Next();

           //         dr0[i] = dr2[inx];
           //         inxexist.Add(inx);
            //    }
          //  }

            radTextBoxPastParticiple.Text = dr2[0][0].ToString();
            radTextBoxInfinitive.Text = dr2[0][2].ToString();
            radTextBoxPast.Text = dr2[0][4].ToString();
            radLabelExample1.Text = dr2[0][10].ToString();
            radLabelExample2.Text = dr2[0][12].ToString();
            radLabelExample3.Text = dr2[0][14].ToString();

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
