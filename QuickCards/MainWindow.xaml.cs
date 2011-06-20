using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;

namespace QuickCards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.NotifyIcon ni;
        Timer tm = new Timer();
        //--------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();

            ni = new System.Windows.Forms.NotifyIcon();
            //TODO: посмотреть, что бы не bin
            System.Drawing.Icon ic = new System.Drawing.Icon("QuickCards.ico");
            ni.Icon = ic;
            ni.DoubleClick +=
                delegate(object sender, EventArgs args)
                {
                    this.Show();
                };
            ni.Visible = true;

            tm.Interval = 1000;
            tm.Tick +=
                delegate(object sender, EventArgs args)
                {
                    VocabularyWindow vf = new VocabularyWindow();
                    //TODO: Посчитать
                    vf.Top = 790;
                    vf.Left = 1085;
                    vf.Show();
                    //TODO: сделать алгоритм показа
                    tm.Enabled = false;
                };
            tm.Enabled = true;
        }
        //--------------------------------------------------------------------------
        protected override void OnStateChanged(EventArgs e)
        {
            //if (WindowState == WindowState.Minimized)
            //    this.Hide();

            base.OnStateChanged(e);
        }
        //--------------------------------------------------------------------------
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //TODO: в другое место
            ni.Visible = false;
            System.Windows.Application.Current.Shutdown();
        }
        //--------------------------------------------------------------------------
    }
}
