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

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_runtime_menus_Window1.xaml
    /// </summary>
    public partial class howto_wpf_runtime_menus_Window1 : Window
    {
        public howto_wpf_runtime_menus_Window1()
        {
            InitializeComponent();
        }

        private void btnMakeMenus_Click(object sender, RoutedEventArgs e)
        {
            // Make the main menu.
            Menu mainMenu = new Menu();
            grdContent.Children.Add(mainMenu);
            mainMenu.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            mainMenu.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            // Make the File menu.
            MenuItem fileMenuItem = new MenuItem();
            fileMenuItem.Header = "_File";
            mainMenu.Items.Add(fileMenuItem);

            // Make the File menu's open item.
            MenuItem openMenuItem = new MenuItem();
            fileMenuItem.Items.Add(openMenuItem);
            openMenuItem.Header = "_Open";
            openMenuItem.Click += openMenuItem_Click;

            // Give the Open item a tooltip.
            ToolTip openToolTip = new ToolTip();
            openMenuItem.ToolTip = openToolTip;
            openToolTip.Content = "Open a new file";

            // Make the File menu's exit item.
            MenuItem exitMenuItem = new MenuItem();
            fileMenuItem.Items.Add(exitMenuItem);
            exitMenuItem.Header = "E_xit";
            exitMenuItem.Click += exitMenuItem_Click;

            // Give the Exit item a tooltip.
            ToolTip exitToolTip = new ToolTip();
            exitMenuItem.ToolTip = exitToolTip;
            exitToolTip.Content = "End the program";
        }

        private void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open a new file here");
        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Goodbye!");
            this.Close();
        }
    }
}
