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

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_global_commands_SecondaryWindow.xaml
    /// </summary>
    public partial class howto_wpf_global_commands_SecondaryWindow : Window
    {
        public howto_wpf_global_commands_SecondaryWindow()
        {
            InitializeComponent();
        }

        public Window1 MainWindow;

        private void ToggleAllow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AllowChangeBackground =
                !MainWindow.AllowChangeBackground;
        }
    }
}
