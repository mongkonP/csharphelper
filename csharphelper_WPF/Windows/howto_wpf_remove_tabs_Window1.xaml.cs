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
    /// Interaction logic for howto_wpf_remove_tabs_Window1.xaml
    /// </summary>
    public partial class howto_wpf_remove_tabs_Window1 : Window
    {
        public howto_wpf_remove_tabs_Window1()
        {
            InitializeComponent();
        }

        // Add a tab to the TabControl.
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab_item = new TabItem();
            tab_item.AddHandler(
                Image.PreviewMouseDownEvent,
                new RoutedEventHandler(PreviewMouseDown_Handler));
            tabMain.Items.Add(tab_item);

            Grid grid = new Grid();
            grid.Width = 70;
            grid.Height = 30;

            Label label = new Label();
            label.Content = "New Tab";
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(label);

            Image image = new Image();
            
            image.HorizontalAlignment = HorizontalAlignment.Right;
            image.VerticalAlignment = VerticalAlignment.Top;
            image.Source = new BitmapImage(new Uri(
                "pack://application:,,,/howto_wpf_remove_tabs;component/Remove.png"));
            image.Stretch = Stretch.None;
            image.Cursor = Cursors.Cross;
            image.Width = 10;
            image.Height = 10;
            grid.Children.Add(image);

            tab_item.Header = grid;

            Label content = new Label();
            content.Content = "This is the new tab's content";
            tab_item.Content = content;
        }

        // Remove the clicked tab.
        // Parameter e is actually a MouseButtonEventArgs.
        private void PreviewMouseDown_Handler(object sender, RoutedEventArgs e)
        {
            TabItem_RemoveClicked(sender, e as MouseButtonEventArgs);
        }

        // Remove the clicked tab.
        private void TabItem_RemoveClicked(object sender, MouseButtonEventArgs e)
        {
            // Find the clicked Tab.
            TabItem tab_item = sender as TabItem;

            // Remove the TabItem.
            tabMain.Items.Remove(tab_item);

            e.Handled = true;
        }
    }
}
