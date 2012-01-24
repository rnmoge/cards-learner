using System;
using System.Data;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Drawing;
using System.Collections.Generic;

namespace QuickVerbs
{
    /// <summary>
    /// example form
    /// </summary>
    //TODO: в версии 2
    //1. Добавить оставшиеся глаголы
    //2. Разные цветовые схемы
    //3. Картинки (?)
    //4. Расписание
    //5. Возможность создавать уровни
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        const string sCategory = "Уровень: {0}";
        const string sVerbs = "Глаголов: {0}";
        const string sPronoun = "English ({0})";
        const string sCatNumber = "CategoryNumber = {0}";

        private dbFacade df = new dbFacade();
        public dbFacade Df
        {
            get { return df; }
            set { df = value; }
        }

        public DataTable dt = new DataTable();
        public DataTable dtc = new DataTable();
        public DataTable query = new DataTable();
        public DataView dv;
        private int category = 1;

        public int Category
        {
            get { return category; }
            set { category = value; }
        }

        private string categoryName;
        private bool firstStart = true;
        private bool timerOut = true;

        public bool TimerOut
        {
            get { return timerOut; }
            set { timerOut = value; }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        ///    
        //--------------------------------------------------------------------------
        public MainForm()
        {
            InitializeComponent();
            this.radGridView.TableElement.RowHeight = 50;
            radCheckBoxElementPanel.Checked = Properties.Settings.Default.ShowPanel;
            radCheckBoxElementPanel_Click(null, null);
        }
        //--------------------------------------------------------------------------
        private void MainForm_Load(object sender, EventArgs e)
        {
            notifyIcon.ShowBalloonTip(1);
            if (firstStart == true)
            {
                Hide();
                ThemeResolutionService.ApplyThemeToControlTree(this, "Desert");
            }

            FillData();

            if (firstStart == true)
            {
                timerLesson.Interval = Properties.Settings.Default.Period * 3600000;
                timerLesson_Tick(timerLesson, null);
                timerLesson.Enabled = true;
                firstStart = false;
            }

        }
        //--------------------------------------------------------------------------
        private void FillData()
        {

            category = Properties.Settings.Default.CurrentLevel;
            categoryName = Properties.Settings.Default.CurrentLevelName;

            dt = df.FetchAll("CurrentVerbs", "FirstForm, FirstFormSound, SecondForm, SecondFormSound, ThirdForm, ThirdFormSound, Translate, CategoryNumber, CategoryName, Closed, Example1, ExampleSound1, Example2, ExampleSound2, Example3, ExampleSound3, RightAnswers, ID, ID_Verb");
            dv = new DataView(dt);

            dv.RowFilter = String.Format(sCatNumber, category);

            radGridView.DataSource = null;
            radGridView.DataSource = dv;
            radLabelElementVerbCount.Text = String.Format(sVerbs, dv.Count);
            radGridView.Columns[0].Width = 120;
            radGridView.Columns[0].HeaderText = "Infinitive";
            radGridView.Columns[1].IsVisible = false;
            radGridView.Columns[2].Width = 120;
            radGridView.Columns[2].HeaderText = "Past";
            radGridView.Columns[3].IsVisible = false;
            radGridView.Columns[4].Width = 120;
            radGridView.Columns[4].HeaderText = "Past Participle";
            radGridView.Columns[5].IsVisible = false;
            radGridView.Columns[6].Width = 150;
            radGridView.Columns[6].HeaderText = "Перевод";
            radGridView.Columns[7].Width = 95;
            radGridView.Columns[7].HeaderText = "Категория";
            radGridView.Columns[7].IsVisible = false;
            radGridView.Columns[8].Width = 95;
            radGridView.Columns[8].HeaderText = "Категория";
            radGridView.Columns[8].IsVisible = false;
            radGridView.Columns[9].Width = 54;
            radGridView.Columns[9].HeaderText = "Выучен";
            radGridView.Columns[10].IsVisible = false;
            radGridView.Columns[11].IsVisible = false;
            radGridView.Columns[12].IsVisible = false;
            radGridView.Columns[13].IsVisible = false;
            radGridView.Columns[14].IsVisible = false;
            radGridView.Columns[15].IsVisible = false;
            radGridView.Columns[16].IsVisible = false;
            radGridView.Columns[17].IsVisible = false;
            radGridView.Columns[18].IsVisible = false;

            if (radGridView.RowCount <= 0)
            {
                radPanelBarRight.Enabled = false;
                radLabelExample1.Text = String.Empty;
                radLabelExample2.Text = String.Empty;
                radLabelExample3.Text = String.Empty;
                radTextBoxInfinitive.Text = String.Empty;
                radTextBoxPast.Text = String.Empty;
                radTextBoxPastParticiple.Text = String.Empty;
                radTextBoxTranslate.Text = String.Empty;
                radCheckBoxChecked.Text = String.Empty;
                contextMenuStripGrid.Enabled = false;
            }
            else
            {
                contextMenuStripGrid.Enabled = true;
                radPanelBarRight.Enabled = true;
            }

            radGridView.Focus();
            radGridView.Select();

            radButtonElementCategories.Text = String.Format(sCategory, categoryName);

            if (Properties.Settings.Default.Pronoun == 0)
            {
                radLabelElementEnglish.Text = String.Format(sPronoun, "US");
                radLabelElementEnglish.ImageIndex = 0;
            }
            else if (Properties.Settings.Default.Pronoun == 1)
            {
                radLabelElementEnglish.Text = String.Format(sPronoun, "BR");
                radLabelElementEnglish.ImageIndex = 1;
            }

            bool en = (radGridView.Rows.Count > 0);

            radButtonEdit.Enabled = en;
            radButtonDelete.Enabled = en;
            toolStripMenuItemEdit.Enabled = en;
            toolStripMenuItemDelete.Enabled = en;
            toolStripMenuItemDeleteAll.Enabled = en;

        }
        //--------------------------------------------------------------------------
        private void radMenuItemExit_Click(object sender, EventArgs e)
        {
            QuickVerbsClose();
        }
        //--------------------------------------------------------------------------
        //private void OnRadMenuItemChangeTheme_Click(object sender, EventArgs e)
        //{
        //    RadMenuItem menuItem = (RadMenuItem)sender;

        //    foreach (RadMenuItem sibling in menuItem.HierarchyParent.Items)
        //    {
        //        sibling.IsChecked = false;
        //    }

        //    menuItem.IsChecked = true;

        //    string themeName = (string)(menuItem).Tag;
        //    ChangeThemeName(this, themeName);
        //}
        //--------------------------------------------------------------------------
        //private void ChangeThemeName(Control control, string themeName)
        //{
        //    IComponentTreeHandler radControl = control as IComponentTreeHandler;
        //    if (radControl != null)
        //    {
        //        radControl.ThemeName = themeName;
        //    }

        //    foreach (Control child in control.Controls)
        //    {
        //        ChangeThemeName(child, themeName);
        //    }
        //}
        //--------------------------------------------------------------------------
        private void radMenuItemAbout_Click(object sender, EventArgs e)
        {
            ShowAbout(FormStartPosition.CenterParent);
        }
        //--------------------------------------------------------------------------
        private void ShowAbout(FormStartPosition sp)
        {
            RadAboutBox mb = new RadAboutBox();
            mb.StartPosition = sp;
            mb.ThemeName = this.ThemeName;
            mb.ShowDialog();
        }
        //--------------------------------------------------------------------------
        private void radCheckBoxElementPanel_Click(object sender, EventArgs e)
        {
            radGridView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left);
            try
            {
                this.MinimumSize = new Size(0, 0);

                if (firstStart)
                {
                    if (!Properties.Settings.Default.ShowPanel)
                    {
                        this.Width = this.Width - radPanelBarRight.Width - 12;
                        radPanelBarRight.Visible = false;
                    }
                    this.MinimumSize = new Size(this.Width, this.Height);
                    return;
                }

                if (!radCheckBoxElementPanel.Checked)
                {
                    radPanelBarRight.Visible = true;
                    Width = Width + radPanelBarRight.Width + 12;
                }
                else
                {
                    radPanelBarRight.Visible = false;
                    Width = Width - radPanelBarRight.Width - 12;
                }
                this.MinimumSize = new Size(this.Width, this.Height);
            }
            finally
            {
                radGridView.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            }
        }
        //--------------------------------------------------------------------------
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.ShowPanel = radCheckBoxElementPanel.Checked;
            Properties.Settings.Default.Save();
        }
        //--------------------------------------------------------------------------
        private void radGridView_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            ResetProgressBar();

            radLabelExample1.Text = radGridView.CurrentRow.Cells[10].Value.ToString();
            radLabelExample2.Text = radGridView.CurrentRow.Cells[12].Value.ToString();
            radLabelExample3.Text = radGridView.CurrentRow.Cells[14].Value.ToString();

            radTextBoxInfinitive.Text = radGridView.CurrentRow.Cells[0].Value.ToString();
            radTextBoxPast.Text = radGridView.CurrentRow.Cells[2].Value.ToString();
            radTextBoxPastParticiple.Text = radGridView.CurrentRow.Cells[4].Value.ToString();
            radTextBoxTranslate.Text = radGridView.CurrentRow.Cells[6].Value.ToString();

            if ((radGridView.CurrentRow.Cells[9].Value == null) ||
                (radGridView.CurrentRow.Cells[9].Value.ToString() == String.Empty))
                radCheckBoxChecked.Checked = false;
            else
                radCheckBoxChecked.Checked = (bool)radGridView.CurrentRow.Cells[9].Value;
        }
        //--------------------------------------------------------------------------
        private void radComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetProgressBar();
        }
        //--------------------------------------------------------------------------
        private void radCheckBoxChecked_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            ResetProgressBar();
        }
        //--------------------------------------------------------------------------
        private void SaveData(bool all, bool set)
        {
            ResetProgressBar();

            this.radProgressBarElement.Value1 = 20;

            ParametersCollection pc = new ParametersCollection();

            Parameter p1 = new Parameter();
            p1.ColumnName = "Closed";
            p1.DbType = DbType.Byte;
            p1.Value = set;
            pc.Add(p1);

            this.radProgressBarElement.Value1 = 40;

            Parameter p2 = new Parameter();
            p2.ColumnName = "RightAnswers";
            p2.DbType = DbType.Int32;
            if (set)
                p2.Value = Properties.Settings.Default.RightAnswers;
            else
                p2.Value = 0;
            pc.Add(p2);

            this.radProgressBarElement.Value1 = 60;

            object[] paramobj = new object[1];

            if (all)
                paramobj[0] = String.Format("ID_Category = '{0}'", category);
            else
            {
                if (radGridView.SelectedRows.Count <= 1)
                {
                    paramobj[0] = String.Format("ID = '{0}'", radGridView.CurrentRow.Cells[17].Value.ToString());
                }
                else
                {
                    string ids = String.Empty;
                    for (int i = 0; i < radGridView.SelectedRows.Count; i++)
                    {
                        ids += String.Format ("{0}, ", radGridView.SelectedRows[i].Cells[17].Value.ToString());
                    }
                    ids = ids.Substring(0, ids.Length - 2);

                    paramobj[0] = String.Format("ID IN ({0})", ids);
                }
            }

            df.Update("Verb_Category", pc, paramobj, "AND");

            this.radProgressBarElement.Value1 = 80;

            int cr = radGridView.CurrentRow.Index;

            FillData();

            if (radGridView.Rows.Count > 0)
                radGridView.Rows[cr].IsCurrent = true;

            this.radProgressBarElement.Value1 = 100;
        }
        //--------------------------------------------------------------------------
        private void ResetProgressBar()
        {
            if (this.radProgressBarElement.Value1 >= this.radProgressBarElement.Maximum)
                this.radProgressBarElement.Value1 = this.radProgressBarElement.Minimum;
        }
        //--------------------------------------------------------------------------
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }
        //--------------------------------------------------------------------------
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
        //--------------------------------------------------------------------------
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
        //--------------------------------------------------------------------------
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ShowSettings(FormStartPosition.CenterScreen))
                FillData();
        }
        //--------------------------------------------------------------------------
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ShowAbout(FormStartPosition.CenterScreen);
        }
        //--------------------------------------------------------------------------
        private void QuickVerbsClose()
        {
            if (MessageBox.Show("Выйти из QuickVerbs приложения?", "QuickVerbs", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Properties.Settings.Default.ShowPanel = radCheckBoxElementPanel.Checked;
                Properties.Settings.Default.Save();

                notifyIcon.Dispose();
                Application.Exit();
            }
        }
        //--------------------------------------------------------------------------
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            QuickVerbsClose();
        }
        //--------------------------------------------------------------------------
        private void radMenuItemSettings_Click(object sender, EventArgs e)
        {
            if (ShowSettings(FormStartPosition.CenterParent))
            {
                FillData();
            }
        }
        //--------------------------------------------------------------------------
        private bool ShowSettings(FormStartPosition sp)
        {
            SettingsForm sf = new SettingsForm(this);
            sf.StartPosition = sp;
            sf.ThemeName = this.ThemeName;
            return (sf.ShowDialog(this) == DialogResult.OK);
        }
        //--------------------------------------------------------------------------
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radGridView.SelectAll();
        }
        //--------------------------------------------------------------------------
        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < radGridView.Rows.Count; i++)
            {
                radGridView.Rows[i].IsSelected = false;
            }
        }
        //--------------------------------------------------------------------------
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall:
                    // The user perfromed an action that caused your code to call Application.Exit.
                    // You could go either way here but I'd suggest that you shouldn't be calling Application.Exit
                    // if you don't actually want the application to exit.  In that case close the main form instead.
                    e.Cancel = false;
                    break;
                case CloseReason.FormOwnerClosing:
                    // This form is a modeless dialogue, which you shouldn't be minimising to the system tray anyway.
                    e.Cancel = false;
                    break;
                case CloseReason.MdiFormClosing:
                    // This form is an MDI child form, which you shouldn't be minimising to the system tray anyway.
                    e.Cancel = false;
                    break;
                case CloseReason.None:
                    // If the reason can't be determined then something funky is going on so I'd suggest you let the form close.
                    e.Cancel = false;
                    break;
                case CloseReason.TaskManagerClosing:
                    // The user pressed the End Task button on the Applications tab (NOT the Processes tab) of the Task Manager.
                    // You could go either way here too.  It really depends on your app and if you don't want the user to be able to exit
                    // this way.  I'd suggest letting the form close but there would definitely be legitimate reasons for preventing it.
                    e.Cancel = false;
                    break;
                case CloseReason.UserClosing:
                    // The user clicked the Close button on the title bar, pressed Alt+F4, selected Close from the
                    // system menu or performed some action that caused your code to call the form's Close method.
                    // Don't let the form close.
                    e.Cancel = true;
                    this.Visible = false;
                    notifyIcon.Visible = true;
                    Hide();
                    break;
                case CloseReason.WindowsShutDown:
                    // Windows is shutting down.
                    // Definitely let the form close or you'll prevent Windows shutting down normally.
                    e.Cancel = false;
                    break;
            }
        }
        //--------------------------------------------------------------------------
        private void pictureBoxInfinitive_MouseUp(object sender, MouseEventArgs e)
        {
            Media.Player.GetPlayer().Play("abide1.mp3");
        }
        //--------------------------------------------------------------------------
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Media.Player.GetPlayer().Play("abide2.mp3");
        }
        //--------------------------------------------------------------------------
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            Media.Player.GetPlayer().Play("abide3.mp3");
        }
        //--------------------------------------------------------------------------
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        //--------------------------------------------------------------------------
        private void pictureBox_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        //--------------------------------------------------------------------------
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (ShowInTaskbar == false)
                ShowInTaskbar = true;
        }
        //--------------------------------------------------------------------------
        private void radButtonElementCategories_Click(object sender, EventArgs e)
        {
            if (ShowSettings(FormStartPosition.CenterParent))
            {
                FillData();
            }
        }
        //--------------------------------------------------------------------------
        private void AddVerbs()
        {
            InsertVerbs ivf = new InsertVerbs(this);
            if (ivf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (ivf.radListControlVerbs.SelectedItems.Count > 0)
                {
                    ResetProgressBar();

                    radProgressBarElement.Value1 = 0;

                    ParametersCollection pc = new ParametersCollection();

                    Parameter p1 = new Parameter();
                    p1.ColumnName = "ID_Verb";
                    p1.DbType = DbType.Int32;
                    pc.Add(p1);

                    Parameter p2 = new Parameter();
                    p2.ColumnName = "ID_Category";
                    p2.DbType = DbType.Int32;
                    pc.Add(p2);

                    radProgressBarElement.Value1 = 20;

                    string ids = String.Empty;

                    for (int i = 0; i < ivf.radListControlVerbs.SelectedItems.Count; i++)
                    {
                        ids += String.Format("{0}, ", ivf.dc[ivf.radListControlVerbs.SelectedItems[i].Text]);
                    }
                    ids = ids.Substring(0, ids.Length - 2);

                    radProgressBarElement.Value1 = 40;

                    string sqlSelect = String.Format("SELECT ID, {0} FROM Verbs WHERE ID IN ({1})", category, ids); 

                    df.Insert("Verb_Category", pc, sqlSelect);

                    radProgressBarElement.Value1 = 60;

                    int cr = 0;
                    if (radGridView.RowCount > 0)
                        cr = radGridView.CurrentRow.Index;

                    radProgressBarElement.Value1 = 80;

                    FillData();

                    if (radGridView.Rows.Count > 0)
                        radGridView.Rows[cr].IsCurrent = true;

                    radProgressBarElement.Value1 = 100;
                }
            }
        }
        //--------------------------------------------------------------------------
        private void radButtonNew_Click(object sender, EventArgs e)
        {
            AddVerbs();
        }
        //--------------------------------------------------------------------------
        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            AddVerbs();
        }
        //--------------------------------------------------------------------------    
        private void EditVerb()
        {
            EditVerbs evf = new EditVerbs(this);
            if (evf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveData(false, evf.radRadioButtonCheck.IsChecked);
            }
        }
        //--------------------------------------------------------------------------       
        private void radButtonEdit_Click(object sender, EventArgs e)
        {
            EditVerb();
        }
        //--------------------------------------------------------------------------  
        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            EditVerb();
        }
        //--------------------------------------------------------------------------  
        private void radGridView_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            EditVerb();
        }
        //--------------------------------------------------------------------------
        private void DeleteVerb()
        {
            string msg = String.Empty;
            string delSQL = String.Empty;
            int cr = 0;

            if (radGridView.SelectedRows.Count <= 1)
                msg = String.Format("Исключить глагол {0} из уровня {1}?", radGridView.CurrentRow.Cells[0].Value.ToString()[0].ToString().ToUpper() + radGridView.CurrentRow.Cells[0].Value.ToString().Substring(1, radGridView.CurrentRow.Cells[0].Value.ToString().Length - 1), categoryName);
            else
                msg = String.Format("Исключить выбранные глаголы из уровня {0}?", categoryName);

            if (MessageBox.Show(msg, "Удаление", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (radGridView.SelectedRows.Count <= 1)
                {
                    delSQL = String.Format("WHERE ID = '{0}'", radGridView.CurrentRow.Cells[17].Value.ToString());
                    cr = radGridView.CurrentRow.Index;
                }
                else
                {
                    string ids = String.Empty;

                    for (int i = 0; i < radGridView.SelectedRows.Count; i++)
                    {
                        ids += String.Format("{0}, ", radGridView.SelectedRows[i].Cells[17].Value.ToString());
                    }
                    ids = ids.Substring(0, ids.Length - 2);

                    delSQL = String.Format("WHERE ID IN ({0})", ids);

                    cr = radGridView.SelectedRows[0].Index;

                }

                df.Delete("Verb_Category", delSQL);
                FillData();

                if (radGridView.Rows.Count > 0)
                    radGridView.Rows[cr].IsCurrent = true;
            }
        }

        //--------------------------------------------------------------------------
        private void radButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteVerb();
        }
        //--------------------------------------------------------------------------   
        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            DeleteVerb();
        }
        //--------------------------------------------------------------------------    
        private void RestoreVerbs()
        {
            if (MessageBox.Show((String.Format("Восстановить уровень {0} с глаголами по умолчанию?", categoryName)), "Восстановление по умолчанию", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.radProgressBarElement.Value1 = 50;
                
                df.Query(String.Format("DELETE FROM Verb_Category WHERE ID_Category = {0}", category), String.Format("INSERT INTO Verb_Category (ID, ID_Verb, ID_Category, Closed, RightAnswers) SELECT ID, ID_Verb, ID_Category, Closed, RightAnswers FROM Verb_Category_Default WHERE ID_Category = {0}", category));
                
                this.radProgressBarElement.Value1 = 70;

                FillData();

                this.radProgressBarElement.Value1 = 100;
            }
        }
        //--------------------------------------------------------------------------
        private void radButtonRestore_Click(object sender, EventArgs e)
        {
            RestoreVerbs();
        }
        //--------------------------------------------------------------------------
        private void toolStripMenuItemRestore_Click(object sender, EventArgs e)
        {
            RestoreVerbs();
        }
        //--------------------------------------------------------------------------
        public void timerLesson_Tick(object sender, EventArgs e)
        {
            if (timerOut)
            {
                LessonForm lf = new LessonForm(this);
                lf.Owner = this;
                lf.Show();
            }
            timerOut = true;
        }
        //--------------------------------------------------------------------------
    }
}