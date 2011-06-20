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
using System.Windows.Shapes;

namespace QuickCards
{
    /// <summary>
    /// Interaction logic for VocabularyForm.xaml
    /// </summary>
    public partial class VocabularyWindow : Window
    {
        //--------------------------------------------------------------------------
        public VocabularyWindow()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------
        private void imagePlay_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Media.Player.GetPlayer().Play("parrot.mp3");
        }
        //--------------------------------------------------------------------------
        private void imagePlay_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }
        //--------------------------------------------------------------------------
        private void imagePlay_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }
        //--------------------------------------------------------------------------
    }
}
