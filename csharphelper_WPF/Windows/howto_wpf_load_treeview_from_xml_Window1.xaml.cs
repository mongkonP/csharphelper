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

using System.Xml;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_load_treeview_from_xml_Window1.xaml
    /// </summary>
    public partial class howto_wpf_load_treeview_from_xml_Window1 : Window
    {
        public howto_wpf_load_treeview_from_xml_Window1()
        {
            InitializeComponent();
        }

        // Use an XmlDocuument to load flowers.xml.
        private void btnLoadFlowers_Click(object sender, RoutedEventArgs e)
        {
            // Get the file's location.
            string filename = System.AppDomain.CurrentDomain.BaseDirectory;
            filename = System.IO.Path.GetFullPath(filename) + "flowers.xml";

            // Read the file into an XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            // Make an XmlDataProvider that uses the XmlDocument.
            XmlDataProvider provider = new XmlDataProvider();
            provider.Document = doc;
            provider.XPath = "./*";

            // Make the TreeView display the XmlDataProvider's data.
            trvItems.DataContext = provider;
        }

        // Use an XmlDataProvider's Source property to load cars.xml.
        private void btnLoadCars_Click(object sender, RoutedEventArgs e)
        {
            // Get the file's location.
            string filename = System.AppDomain.CurrentDomain.BaseDirectory;
            filename = System.IO.Path.GetFullPath(filename) + "cars.xml";

            // Make an XmlDataProvider that uses the file.
            XmlDataProvider provider = new XmlDataProvider();
            provider.Source = new Uri(filename, UriKind.Absolute);
            provider.XPath = "./*";

            // Make the TreeView display the XmlDataProvider's data.
            trvItems.DataContext = provider;
        }
    }
}
