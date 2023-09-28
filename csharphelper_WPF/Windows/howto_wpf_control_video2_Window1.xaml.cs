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
    /// Interaction logic for howto_wpf_control_video2_Window1.xaml
    /// </summary>
    public partial class howto_wpf_control_video2_Window1 : Window
    {
        public howto_wpf_control_video2_Window1()
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

        private void minionPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            sbarPosition.Minimum = 0;
            sbarPosition.Maximum = minionPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            sbarPosition.Visibility = Visibility.Visible;
        }

        // Show the play position in the ScrollBar and TextBox.
        private void ShowPosition()
        {
            sbarPosition.Value = minionPlayer.Position.TotalSeconds;
            txtPosition.Text = minionPlayer.Position.TotalSeconds.ToString("0.0");
        }

        // Enable and disable appropriate buttons.
        private void EnableButtons(bool is_playing)
        {
            btnPlay.IsEnabled = !is_playing;
            btnPause.IsEnabled = is_playing;
            timerVideoTime.IsEnabled = is_playing;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Play();
            EnableButtons(true);
        }
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Pause();
            EnableButtons(false);
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Stop();
            EnableButtons(false);
            ShowPosition();
        }
        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            minionPlayer.Stop();
            minionPlayer.Play();
            EnableButtons(true);
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

        private void sbarPosition_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            TimeSpan timespan = TimeSpan.FromSeconds(sbarPosition.Value);
            minionPlayer.Position = timespan;
            ShowPosition();
        }

        // Pause before the user moves the scroll bar.
        private void sbarPosition_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            minionPlayer.Pause();
            EnableButtons(false);
        }
    }
}