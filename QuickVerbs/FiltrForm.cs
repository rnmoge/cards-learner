using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickVerbs
{
    public partial class frmCategory : Telerik.WinControls.UI.RadForm
    {
        private int category;

        public frmCategory()
        {
            InitializeComponent();
        }

        public frmCategory(int ACat): this()
        {
            category = ACat;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            radioButtonAll.Text = MainForm.sAll;
            radioButtonElementary.Text = MainForm.sElementary;
            radioButtonPreIntermediate.Text = MainForm.sPreIntermediate;
            radioButtonIntermediate.Text = MainForm.sIntermediate;
            radioButtonUpperIntermediate.Text = MainForm.sUpperIntermediate;
            radioButtonAdvanced.Text = MainForm.sAdvanced;

            switch (category)
            {
                case -1:
                    {
                        radioButtonAll.Checked = true;
                        break;
                    }
                case 0:
                    {
                        radioButtonElementary.Checked = true;
                        break;
                    }
                case 1:
                    {
                        radioButtonPreIntermediate.Checked = true;
                        break;
                    }
                case 2:
                    {
                        radioButtonIntermediate.Checked = true;
                        break;
                    }
                case 3:
                    {
                        radioButtonUpperIntermediate.Checked = true;
                        break;
                    }
                case 4:
                    {
                        radioButtonAdvanced.Checked = true;
                        break;
                    }
            }

        }
    }
}
