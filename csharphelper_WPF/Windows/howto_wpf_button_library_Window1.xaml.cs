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

// At design time, open Solution Explorer and set the media
// file's "Copy to Output Directory" property to "Copy if Newer."

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_button_library_Window1.xaml
    /// </summary>
    public partial class howto_wpf_button_library_Window1 : Window
    {
        public howto_wpf_button_library_Window1()
        {
            InitializeComponent();
        }

        // A timer to display the video's location.
        private DispatcherTimer timerVideoTime;

        // Create the timer and otherwise get ready.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(0.1);
            timerVideoTime.Tick += new EventHandler(timer_Tick);
            minionPlayer.Stop();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Play();
            btnPlay.IsEnabled = false;
            btnPause.IsEnabled = true;
            timerVideoTime.IsEnabled = true;
        }
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Pause();
            btnPlay.IsEnabled = true;
            btnPause.IsEnabled = false;
            timerVideoTime.IsEnabled = false;
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Stop();
            btnPlay.IsEnabled = true;
            btnPause.IsEnabled = false;
            timerVideoTime.IsEnabled = false;
            ShowPosition();
        }
        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Stop();
            minionPlayer.Play();
            btnPlay.IsEnabled = false;
            btnPause.IsEnabled = true;
            timerVideoTime.IsEnabled = true;
        }
        private void btnFaster_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.SpeedRatio *= 1.5;
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Position += TimeSpan.FromSeconds(10);
            ShowPosition();
        }
        private void btnSlower_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.SpeedRatio /= 1.5;
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Position -= TimeSpan.FromSeconds(10);
            ShowPosition();
        }

        private void ShowPosition()
        {
            sbarPosition.Value = minionPlayer.Position.TotalSeconds;
            txtPosition.Text = minionPlayer.Position.TotalSeconds.ToString("0.0");
        }

        private void minionPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            sbarPosition.Minimum = 0;
            sbarPosition.Maximum = minionPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            sbarPosition.Visibility = Visibility.Visible;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ShowPosition();
        }

        private void btnSetPosition_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timespan = TimeSpan.FromSeconds(double.Parse(txtPosition.Text));
            minionPlayer.Position = timespan;
            ShowPosition();
        }
    }
}