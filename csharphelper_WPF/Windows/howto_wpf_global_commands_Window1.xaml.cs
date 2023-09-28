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
    /// Interaction logic for howto_wpf_global_commands_Window1.xaml
    /// </summary>
    public partial class howto_wpf_global_commands_Window1 : Window
    {
        public howto_wpf_global_commands_Window1()
        {
            InitializeComponent();

            Application.Current.ShutdownMode =
                ShutdownMode.OnMainWindowClose;
        }

        // A boolean indicating whether changes are allowed.
        public bool AllowChangeBackground = true;

        // The other windows.
        private SecondaryWindow Secondary;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create the Ctrl+B gesture.
            InputGestureCollection change_bg_gestures =
                new InputGestureCollection();
            change_bg_gestures.Add(
                new KeyGesture(Key.B, ModifierKeys.Control, "Ctrl+B"));

            // Create the ChangeBackground command.
            RoutedUICommand change_bg_command =
                new RoutedUICommand(
                    "Change the application's background color.",
                    "ChangeBackground",
                    typeof(Window),
                    change_bg_gestures);

            // Bind the ChangeBackground command to its event handlers
            CommandBinding change_bg_binding =
                new CommandBinding(change_bg_command);
            change_bg_binding.CanExecute += change_bg_CanExecute;
            change_bg_binding.Executed += change_bg_Executed;
            this.CommandBindings.Add(change_bg_binding);

            // Set Command properties for ChangeBackground controls.
            btnChangeBackground.Command = change_bg_command;

            // Display a secondary window.
            Secondary = new SecondaryWindow();
            Secondary.MainWindow = this;
            Secondary.btnChangeBackground.Command = change_bg_command;
            Secondary.CommandBindings.Add(change_bg_binding);
            Secondary.Show();
        }

        private void ToggleAllow_Click(object sender, RoutedEventArgs e)
        {
            AllowChangeBackground = !AllowChangeBackground;
        }

        private void change_bg_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (!IsLoaded) return;
            e.CanExecute = AllowChangeBackground;
        }

        private Brush brush1 = Brushes.LightBlue;
        private Brush brush2 = Brushes.LightGreen;
        void change_bg_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Brush brush;
            if (Background == brush2) brush = brush1;
            else brush = brush2;

            Background = brush;
            Secondary.Background = brush;
        }
    }
}
