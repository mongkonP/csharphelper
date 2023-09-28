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

using System.Reflection;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_color_samples_Window1.xaml
    /// </summary>
    public partial class howto_wpf_color_samples_Window1 : Window
    {
        public howto_wpf_color_samples_Window1()
        {
            InitializeComponent();
        }

        // List samples of the named colors.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var color_query =
                from PropertyInfo property in typeof(Colors).GetProperties()
                orderby property.Name
                //orderby ((Color)property.GetValue(null, null)).ToString()
                select new ColorInfo(
                    property.Name,
                    (Color)property.GetValue(null, null));
            lstColors.ItemsSource = color_query;
        }
    }
}
