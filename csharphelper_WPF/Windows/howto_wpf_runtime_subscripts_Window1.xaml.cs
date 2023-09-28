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
    /// Interaction logic for howto_wpf_runtime_subscripts_Window1.xaml
    /// </summary>
    public partial class howto_wpf_runtime_subscripts_Window1 : Window
    {
        public howto_wpf_runtime_subscripts_Window1()
        {
            InitializeComponent();
        }

        // Create equations with subscripts and superscripts.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtWater.FontSize = 16;
            txtWater.Text = "";

            txtWater.Inlines.Add("2H");
            txtWater.Inlines.Add(SubscriptRun("2", 10));
            txtWater.Inlines.Add(" + O");
            txtWater.Inlines.Add(SubscriptRun("2", 10));
            txtWater.Inlines.Add(" = 2H");
            txtWater.Inlines.Add(SubscriptRun("2", 10));
            txtWater.Inlines.Add("O");

            txtPythagoras.FontSize = 16;
            txtPythagoras.Text = "";

            txtPythagoras.Inlines.Add("3");
            txtPythagoras.Inlines.Add(SuperscriptRun("2", 10));
            txtPythagoras.Inlines.Add(" + 4");
            txtPythagoras.Inlines.Add(SuperscriptRun("2", 10));
            txtPythagoras.Inlines.Add(" = 5");
            txtPythagoras.Inlines.Add(SuperscriptRun("2", 10));
        }

        // Make a subscript run.
        private Run SubscriptRun(string text, int font_size)
        {
            Run run = new Run(text);
            run.FontSize = font_size;
            run.BaselineAlignment = BaselineAlignment.Subscript;
            return run;
        }

        // Make a superscript run.
        private Run SuperscriptRun(string text, int font_size)
        {
            Run run = new Run(text);
            run.FontSize = font_size;
            run.BaselineAlignment = BaselineAlignment.Superscript;
            return run;
        }
    }
}
