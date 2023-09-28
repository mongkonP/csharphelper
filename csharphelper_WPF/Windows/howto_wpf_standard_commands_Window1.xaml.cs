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
    /// Interaction logic for howto_wpf_standard_commands_Window1.xaml
    /// </summary>
    public partial class howto_wpf_standard_commands_Window1 : Window
    {
        public howto_wpf_standard_commands_Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Bind the New command to its event handlers.
            CommandBinding new_binding =
                new CommandBinding(ApplicationCommands.New);
            new_binding.Executed += NewBinding_Executed;
            new_binding.CanExecute += NewBinding_CanExecute;
            this.CommandBindings.Add(new_binding);
        }

        // The ApplicationCommands.New command was invoked.
        private void NewBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Create a new document", "New");
        }

        private void OpenBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open a document", "Open");
        }

        // Determine whether the New command is allowed.
        private void NewBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!IsLoaded) return;
            e.CanExecute = chkAllowNew.IsChecked.Value;
        }

        // Determine whether the Open command is allowed.
        private void OpenBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!IsLoaded) return;
            e.CanExecute = chkAllowOpen.IsChecked.Value;
        }
    }
}
