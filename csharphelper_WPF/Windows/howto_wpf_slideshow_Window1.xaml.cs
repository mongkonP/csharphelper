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

using System.IO;
using System.Windows.Media.Animation;
using System.Windows.Threading;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_slideshow_Window1.xaml
    /// </summary>
    public partial class howto_wpf_slideshow_Window1 : Window
    {
        public howto_wpf_slideshow_Window1()
        {
            InitializeComponent();
        }

        private List<BitmapImage> Images = new List<BitmapImage>();
        private int ImageNumber = 0;
        private DispatcherTimer PictureTimer = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DirectoryInfo dir_info = new DirectoryInfo(Environment.CurrentDirectory);
            foreach (FileInfo file_info in dir_info.GetFiles())
            {
                if ((file_info.Extension.ToLower() == ".jpg") ||
                    (file_info.Extension.ToLower() == ".png"))
                {
                    Images.Add(new BitmapImage(new Uri(file_info.FullName)));
                }
            }

            // Display the first image.
            imgPicture.Source = Images[0];

            // Install a timer to show each image.
            PictureTimer.Interval = TimeSpan.FromSeconds(3);
            PictureTimer.Tick += Tick;
            PictureTimer.Start();
        }

        // Display the next image.
        private void Tick(object sender, System.EventArgs e)
        {
            ImageNumber = (ImageNumber + 1) % Images.Count;
            ShowNextImage(imgPicture);
        }

        private void ShowNextImage(Image img)
        {
            const double transition_time = 0.9;
            Storyboard sb = new Storyboard();

            // ***************************
            // Animate Opacity 1.0 --> 0.0
            // ***************************
            DoubleAnimation fade_out = new DoubleAnimation(1.0, 0.0,
                TimeSpan.FromSeconds(transition_time));
            fade_out.BeginTime = TimeSpan.FromSeconds(0);

            // Use the Storyboard to set the target property.
            Storyboard.SetTarget(fade_out, img);
            Storyboard.SetTargetProperty(fade_out,
                new PropertyPath(Image.OpacityProperty));

            // Add the animation to the StoryBoard.
            sb.Children.Add(fade_out);


            // *********************************
            // Animate displaying the new image.
            // *********************************
            ObjectAnimationUsingKeyFrames new_image_animation =
                new ObjectAnimationUsingKeyFrames();
            // Start after the first animation has finisheed.
            new_image_animation.BeginTime = TimeSpan.FromSeconds(transition_time);

            // Add a key frame to the animation.
            // It should be at time 0 after the animation begins.
            DiscreteObjectKeyFrame new_image_frame =
                new DiscreteObjectKeyFrame(Images[ImageNumber], TimeSpan.Zero);
            new_image_animation.KeyFrames.Add(new_image_frame);

            // Use the Storyboard to set the target property.
            Storyboard.SetTarget(new_image_animation, img);
            Storyboard.SetTargetProperty(new_image_animation,
                new PropertyPath(Image.SourceProperty));

            // Add the animation to the StoryBoard.
            sb.Children.Add(new_image_animation);


            // ***************************
            // Animate Opacity 0.0 --> 1.0
            // ***************************
            // Start when the first animation ends.
            DoubleAnimation fade_in = new DoubleAnimation(0.0, 1.0,
                TimeSpan.FromSeconds(transition_time));
            fade_in.BeginTime = TimeSpan.FromSeconds(transition_time);

            // Use the Storyboard to set the target property.
            Storyboard.SetTarget(fade_in, img);
            Storyboard.SetTargetProperty(fade_in,
                new PropertyPath(Image.OpacityProperty));

            // Add the animation to the StoryBoard.
            sb.Children.Add(fade_in);

            // Start the storyboard on the img control.
            sb.Begin(img);
        }
    }
}
