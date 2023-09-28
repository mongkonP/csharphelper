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
    /// Interaction logic for howto_wpf_blinking_label_Window1.xaml
    /// </summary>
    public partial class howto_wpf_blinking_label_Window1 : Window
    {
        public howto_wpf_blinking_label_Window1()
        {
            InitializeComponent();
        }

        // Create a timer.
        private DispatcherTimer TheTimer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TheTimer = new DispatcherTimer();
            TheTimer.Tick += timer_Tick;
            TheTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            TheTimer.Start();
        }

        // The timer's Tick event.
        private bool BlinkOn = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (BlinkOn)
            {
                lblTimer.Foreground = Brushes.Black;
                lblTimer.Background = Brushes.White;
            }
            else
            {
                lblTimer.Foreground = Brushes.White;
                lblTimer.Background = Brushes.Black;
            }
            BlinkOn = !BlinkOn;
        }
    }
}
