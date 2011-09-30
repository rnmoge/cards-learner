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
    public partial class InsertVerbs : Telerik.WinControls.UI.RadForm
    {
        MainForm mainForm;
        private dbFacade df = new dbFacade();

        public Dictionary<string, int> dfull = new Dictionary<string, int>();
        public Dictionary<string, int> dc = new Dictionary<string, int>();
        public DataTable dt = new DataTable();
        //--------------------------------------------------------------------------
        public InsertVerbs(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }
        //--------------------------------------------------------------------------
        private void InsertVerbs_Load(object sender, EventArgs e)
        {
            dt = df.FetchAll("Verbs", "FirstForm, ID");
  
            for (int i = 0; i < mainForm.radGridView.RowCount; i++)
            {
                dfull.Add(mainForm.radGridView.Rows[i].Cells[0].Value.ToString(), int.Parse(mainForm.radGridView.Rows[i].Cells[18].Value.ToString()));
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dfull.ContainsKey(dt.Rows[i][0].ToString()))
                {
                    radListControlVerbs.Items.Add(dt.Rows[i][0].ToString());
                    dc.Add(dt.Rows[i][0].ToString(), int.Parse(dt.Rows[i][1].ToString()));
                }
            }
        }
        //--------------------------------------------------------------------------
        private void toolStripMenuItemSelect_Click(object sender, EventArgs e)
        {
            radListControlVerbs.SelectAll();
        }
        //--------------------------------------------------------------------------
        private void toolStripMenuItemDeselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < radListControlVerbs.Items.Count; i++)
            {
                radListControlVerbs.Items[i].Selected = false;
            }
        }
        //--------------------------------------------------------------------------
    }
}
