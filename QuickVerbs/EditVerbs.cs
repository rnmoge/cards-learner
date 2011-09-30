using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace QuickVerbs
{
    public partial class EditVerbs : Telerik.WinControls.UI.RadForm
    {
        private dbFacade df = new dbFacade();
        //--------------------------------------------------------------------------
        public EditVerbs(MainForm mainForm)
        {
            InitializeComponent();

            if (mainForm.radGridView.SelectedRows.Count <= 1)
            {
                this.Text = String.Format("Глагол '{0}'", mainForm.radGridView.CurrentRow.Cells[0].Value.ToString());

                if ((mainForm.radGridView.CurrentRow.Cells[9].Value == null) ||
                    (mainForm.radGridView.CurrentRow.Cells[9].Value.ToString() == String.Empty))
                {
                    radRadioButtonUncheck.IsChecked = true;
                }
                else
                {
                    radRadioButtonCheck.IsChecked = (bool)mainForm.radGridView.CurrentRow.Cells[9].Value;
                    radRadioButtonUncheck.IsChecked = !radRadioButtonCheck.IsChecked;
                }
            }
            else
                this.Text = "Мультивыбор" ;
        }     
        //--------------------------------------------------------------------------
    }
}
