using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Input;

namespace howto_wpf_custom_commands
{
    public static class MyCommands
    {
        // The command objects.
        private static RoutedUICommand changeBackground;

        // Propetry to get the command objects.
        public static RoutedUICommand ChangeBackground { get { return changeBackground; } }

        // Constructor.
        static MyCommands()
        {
            // Create the Ctrl+B gesture.
            InputGestureCollection change_bg_gestures =
                new InputGestureCollection();
            change_bg_gestures.Add(
                new KeyGesture(Key.B, ModifierKeys.Control, "Ctrl+B"));

            // Make the ChangeBackground command object
            // giving it the Ctrl+B gesture.
            changeBackground = new RoutedUICommand(
                "Change the application's background color",
                "ChangeBackground",
                typeof(MyCommands), change_bg_gestures);
        }
    }
}
