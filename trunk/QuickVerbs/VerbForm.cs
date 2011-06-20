using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuickVerbs
{
    public partial class MainForm1 : Form
    {
        List<Verbs> vl = new List<Verbs>();

        public MainForm1()
        {
            InitializeComponent();
            vl.Add(new Verbs(Verbs.A11, Verbs.A12, Verbs.A13, Verbs.A14, 0, true));
            vl.Add(new Verbs(Verbs.A21, Verbs.A22, Verbs.A23, Verbs.A24, 0, true));
            vl.Add(new Verbs(Verbs.A31, Verbs.A32, Verbs.A33, Verbs.A34, 0, true));

            radGridView.DataSource = vl;
            
        }
    }
}
