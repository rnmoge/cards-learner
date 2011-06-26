using System;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Drawing;

namespace QuickVerbs
{
    public partial class SettingsForm : Telerik.WinControls.UI.RadForm
    {
        MainForm mainForm;

        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            radComboBoxCategory.SelectedIndex = Properties.Settings.Default.CurrentLevel - 1;
            radComboBoxPeriod.SelectedIndex = Properties.Settings.Default.Period;
            radSpinEditorCountRightAnswers.Value = Properties.Settings.Default.RightAnswers;
            radSpinEditorCountVerbs.Value = Properties.Settings.Default.LessonVerbs;
            radComboBoxPronoun.SelectedIndex = Properties.Settings.Default.Pronoun;
            radComboBoxPronoun.ImageList = mainForm.imageList;
            radComboBoxItemUSA.ImageIndex = 0;
            radComboBoxItemUK.ImageIndex = 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CurrentLevel = radComboBoxCategory.SelectedIndex + 1;
            Properties.Settings.Default.Period = radComboBoxPeriod.SelectedIndex;
            Properties.Settings.Default.RightAnswers = (int)radSpinEditorCountRightAnswers.Value;
            Properties.Settings.Default.LessonVerbs = (int)radSpinEditorCountVerbs.Value;
            Properties.Settings.Default.Pronoun = (byte)radComboBoxPronoun.SelectedIndex;
            Properties.Settings.Default.CurrentLevelName = radComboBoxCategory.Text;

            Properties.Settings.Default.Save();
        }
    }
}
