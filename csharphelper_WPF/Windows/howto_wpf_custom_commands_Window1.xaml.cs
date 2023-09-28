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
    /// Interaction logic for howto_wpf_custom_commands_Window1.xaml
    /// </summary>
    public partial class howto_wpf_custom_commands_Window1 : Window
    {
        public howto_wpf_custom_commands_Window1()
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

            // **********
            // Foreground
            // **********
            // Create the Ctrl+F gesture.
            InputGestureCollection change_fg_gestures =
                new InputGestureCollection();
            change_fg_gestures.Add(
                new KeyGesture(Key.F, ModifierKeys.Control, "Ctrl+F"));

            // Create the ChangeForeground command.
            RoutedUICommand change_fg_command =
                new RoutedUICommand(
                    "Change the application's foreground color.",
                    "ChangeForeground",
                    typeof(howto_wpf_custom_commands_Window1),
                    change_fg_gestures);

            // Bind the ChangeForeground command to its event handlers
            CommandBinding change_fg_binding = new CommandBinding(change_fg_command);
            change_fg_binding.CanExecute += change_fg_CanExecute;
            change_fg_binding.Executed += change_fg_Executed;
            this.CommandBindings.Add(change_fg_binding);

            // Set Command properties for ChangeForeground controls.
            mnuChangeForeground.Command = change_fg_command;
            btnChangeForeground.Command = change_fg_command;
            btnForeground.Command = change_fg_command;

            // **********
            // Background
            // **********
            // Create the ChangeBackground command.
            RoutedUICommand change_bg_command = MyCommands.ChangeBackground;

            // Bind the ChangeBackground command to its event handlers
            CommandBinding change_bg_binding = new CommandBinding(change_bg_command);
            change_bg_binding.CanExecute += change_bg_CanExecute;
            change_bg_binding.Executed += change_bg_Executed;
            this.CommandBindings.Add(change_bg_binding);

            // Set Command properties for Execute controls.
            mnuChangeBackground.Command = change_bg_command;
            btnChangeBackground.Command = change_bg_command;
            btnBackground.Command = change_bg_command;
        }

        // A command was invoked.
        private void NewBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Create a new document", "New");
        }

        private void OpenBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open a document", "Open");
        }

        private Brush fg_brush1 = new SolidColorBrush(Colors.Blue);
        private Brush fg_brush2 = new SolidColorBrush(Colors.Green);
        private void change_fg_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Brush brush;
            if (Foreground == fg_brush2)
                brush = fg_brush1;
            else
                brush = fg_brush2;
            Foreground = brush;
            foreach (Control control in grdMain.Children)
            {
                control.Foreground = brush;
            }
        }

        private Brush bg_brush1 = new SolidColorBrush(Colors.LightBlue);
        private Brush bg_brush2 = new SolidColorBrush(Colors.LightGreen);
        void change_bg_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Brush brush;
            if (Background == bg_brush2)
                brush = bg_brush1;
            else
                brush = bg_brush2;
            Background = brush;
        }

        // Determine which commands are allowed.
        private void NewBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!IsLoaded) return;
            e.CanExecute = chkAllowNew.IsChecked.Value;
        }

        private void OpenBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!IsLoaded) return;
            e.CanExecute = chkAllowOpen.IsChecked.Value;
        }

        private void change_fg_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!IsLoaded) return;
            e.CanExecute = chkAllowForeground.IsChecked.Value;
        }

        private void change_bg_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!IsLoaded) return;
            e.CanExecute = chkAllowBackground.IsChecked.Value;
        }
    }
}
