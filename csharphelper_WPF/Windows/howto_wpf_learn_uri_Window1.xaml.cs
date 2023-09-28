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

// To add the image to the project:
//  1. Use Project > Add Existing Item to add the item.
//  2. Select the file in Solution Explorer and verify that its
//      Build Action is Resource.
//  3. Set the Image control's Source to the name of the file
//      as in csharp_prog_ref.png.

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_learn_uri_Window1.xaml
    /// </summary>
    public partial class howto_wpf_learn_uri_Window1 : Window
    {
        public howto_wpf_learn_uri_Window1()
        {
            InitializeComponent();
        }

        // Display the Image control's URI.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUri.Text = imgBook.Source.ToString();
        }
    }
}
