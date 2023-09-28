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

using System.Windows.Threading;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_progressbar_Window1.xaml
    /// </summary>
    public partial class howto_wpf_progressbar_Window1 : Window
    {
        public howto_wpf_progressbar_Window1()
        {
            InitializeComponent();
        }

        // The timer.
        private DispatcherTimer Timer = null;

        // Progress parameters.
        private const double ProgressMinimum = 0;
        private const double ProgressMaximum = 100;
        private const double ProgressStep = 4;
        private double ProgressValue = ProgressMinimum;

        // Create the timer.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
        }

        // Start a timer.
        private void goButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressValue = ProgressMinimum;
            Timer.Start();
        }

        // Simulate a task's progress.
        private void Timer_Tick(object sender, EventArgs e)
        {
            ProgressValue += ProgressStep;
            if (ProgressValue > ProgressMaximum)
            {
                ProgressValue = ProgressMinimum;
                Timer.Stop();
            }

            // Show the progress.
            double fraction = (ProgressValue - ProgressMinimum) /
                (ProgressMaximum - ProgressMinimum);
            progBgLabel.Width = progBorder.Width * fraction;

            progLabel.Content = ProgressValue.ToString() + "%";
        }
    }
}
