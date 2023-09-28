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

using System.Diagnostics;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_tunnel_bubble_Window1.xaml
    /// </summary>
    public partial class howto_wpf_tunnel_bubble_Window1 : Window
    {
        public howto_wpf_tunnel_bubble_Window1()
        {
            InitializeComponent();
        }

        private void grdButtons_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = chkHandleInGridClick.IsChecked.Value;
            ShowMethodName();
        }

        private void grdButtons_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // This is the first event in the series. Clear the result TextBox.
            txtResults.Clear();

            e.Handled = chkHandleInGridPreview.IsChecked.Value;
            ShowMethodName();
        }

        private void spButtons_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = chkHandleInStackPanelClick.IsChecked.Value;
            ShowMethodName();
        }

        private void spButtons_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = chkHandleInStackPanelPreview.IsChecked.Value;
            ShowMethodName();
        }

        private void Button1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = chkHandleInButtonPreview.IsChecked.Value;
            ShowMethodName();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = chkHandleInButtonClick.IsChecked.Value;
            ShowMethodName();
        }

        private void Button2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = chkHandleInButtonPreview.IsChecked.Value;
            ShowMethodName();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = chkHandleInButtonClick.IsChecked.Value;
            ShowMethodName();
        }

        private void Button3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = chkHandleInButtonPreview.IsChecked.Value;
            ShowMethodName();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = chkHandleInButtonClick.IsChecked.Value;
            ShowMethodName();
        }

        // Record the name of the method that called this one.
        private void ShowMethodName()
        {
            txtResults.AppendText(
                new StackTrace(1).GetFrame(0).GetMethod().Name + '\n');
        }
    }
}
