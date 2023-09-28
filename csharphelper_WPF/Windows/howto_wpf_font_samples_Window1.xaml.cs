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
    /// Interaction logic for howto_wpf_font_samples_Window1.xaml
    /// </summary>
    public partial class howto_wpf_font_samples_Window1 : Window
    {
        public howto_wpf_font_samples_Window1()
        {
            InitializeComponent();
        }

        // Display samples of the text in the available fonts.
        private void btnShowSamples_Click(object sender, RoutedEventArgs e)
        {
            lblFontName.Content = null;
            string sample = txtSample.Text;
            lstSamples.Items.Clear();
            foreach (FontFamily family in Fonts.SystemFontFamilies)
            {
                Label label = new Label();
                label.Content = sample;
                label.FontFamily = family;
                label.FontSize = sliSize.Value;
                lstSamples.Items.Add(label);
            }
        }

        // Display the name of the clicked font.
        private void lstSamples_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Label label = lstSamples.SelectedItem as Label;
            if (label == null)
                lblFontName.Content = null;
            else
                lblFontName.Content = label.FontFamily.ToString();
        }
    }
}
