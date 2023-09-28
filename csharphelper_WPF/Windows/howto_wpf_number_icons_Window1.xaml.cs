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

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for howto_wpf_number_icons_Window1.xaml
    /// </summary>
    public partial class howto_wpf_number_icons_Window1 : Window
    {
        public howto_wpf_number_icons_Window1()
        {
            InitializeComponent();
        }

        // Display the newly entered text.
        private void txtText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (runText != null) runText.Text = txtText.Text;
        }

        // Change the font size.
        private void txtFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (runText != null)
                    runText.FontSize = double.Parse(txtFontSize.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Update the rectangle's width.
        private void txtWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (grdText != null)
                    grdText.Width = double.Parse(txtWidth.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Update the rectangle's height.
        private void txtHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (grdText != null)
                    grdText.Height = double.Parse(txtHeight.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Save the image.
        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Make sure the window is big enough.
                this.SizeToContent = SizeToContent.WidthAndHeight;

                // Save the file.
                string filename = txtText.Text + ".png";
                SaveControlImage(grdText, filename);
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Save a control's image.
        private void SaveControlImage(FrameworkElement control, string filename)
        {
            // Get the size of the Visual and its descendants.
            Rect rect = VisualTreeHelper.GetDescendantBounds(control);

            // Make a DrawingVisual to make a screen
            // representation of the control.
            DrawingVisual dv = new DrawingVisual();

            // Fill a rectangle the same size as the control
            // with a brush containing images of the control.
            using (DrawingContext ctx = dv.RenderOpen())
            {
                VisualBrush brush = new VisualBrush(control);
                ctx.DrawRectangle(brush, null, new Rect(rect.Size));
            }

            // Make a bitmap and draw on it.
            int width = (int)control.ActualWidth;
            int height = (int)control.ActualHeight;
            RenderTargetBitmap rtb = new RenderTargetBitmap(
                width, height, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(dv);

            // Make a PNG encoder.
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            // Save the file.
            using (FileStream fs = new FileStream(filename,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                encoder.Save(fs);
            }
        }
    }
}
