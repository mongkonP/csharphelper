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
    /// Interaction logic for howto_wpf_add_tabs_Window1.xaml
    /// </summary>
    public partial class howto_wpf_add_tabs_Window1 : Window
    {
        public howto_wpf_add_tabs_Window1()
        {
            InitializeComponent();
        }

        // Add a tab to the TabControl.
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab_item = new TabItem();
            tabMain.Items.Add(tab_item);

            Label label = new Label();
            label.Content = "New Tab";
            tab_item.Header = label;

            Label content = new Label();
            content.Content = "This is the new tab's content";
            tab_item.Content = content;
        }
    }
}
