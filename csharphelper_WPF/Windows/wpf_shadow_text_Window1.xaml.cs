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

using System.Windows.Media.Effects;
using Microsoft.Win32;
using System.IO;

 

namespace csharphelper.Windows_Cs 

{
    /// <summary>
    /// Interaction logic for wpf_shadow_text_Window1.xaml
    /// </summary>
    public partial class wpf_shadow_text_Window1 : Window
    {
        public wpf_shadow_text_Window1()
        {
            InitializeComponent();
        }

        // The text and shadow colors.
        private SolidColorBrush TextBrush = Brushes.Black;
        private SolidColorBrush ShadowBrush = Brushes.Black;

        // Build the Font Weight combo box.
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Build the weight combo box.
            cboWeight.Items.Add(FontWeights.Thin);
            cboWeight.Items.Add(FontWeights.ExtraLight);
            cboWeight.Items.Add(FontWeights.Light);
            cboWeight.Items.Add(FontWeights.Regular);
            cboWeight.Items.Add(FontWeights.Medium);
            cboWeight.Items.Add(FontWeights.SemiBold);
            cboWeight.Items.Add(FontWeights.Bold);
            cboWeight.Items.Add(FontWeights.ExtraBold);
            cboWeight.Items.Add(FontWeights.Black);
            cboWeight.Items.Add(FontWeights.ExtraBlack);
            cboWeight.SelectedIndex = 3;
        }

        // Display the sample text.
        private void ShowText()
        {
            if (!this.IsLoaded) return;

            try
            {
                lblResult.Content = txtText.Text;
                lblResult.FontFamily = new FontFamily(txtFont.Text);
                lblResult.FontSize = int.Parse(txtFontSize.Text);
                lblResult.FontWeight = (FontWeight)cboWeight.SelectedItem;
                lblResult.Foreground = TextBrush;

                DropShadowBitmapEffect effect =
                    lblResult.BitmapEffect as DropShadowBitmapEffect;
                effect.Color = ShadowBrush.Color;
            }
            catch
            {
            }
        }

        private void txtFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowText();
        }

        private void txtText_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowText();
        }

        private void txtFont_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowText();
        }

        private void txtWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowText();
        }

        private void cboWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowText();
        }

        private void TextColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            TextBrush = (SolidColorBrush)canvas.Background;
            ShowText();
        }

        private void ShadowColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            ShadowBrush = (SolidColorBrush)canvas.Background;
            ShowText();
        }

        // Save the grdText control's image.
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = txtText.Text;        // Default name.
            dlg.DefaultExt = ".png";            // Default extension.
            dlg.Filter = "PNG Files|*.png|All files|*.*";
            dlg.FilterIndex = 0;
            
            // Display the dialog.
            if (dlg.ShowDialog() == true)
            {
                SaveControlImage(grdText, dlg.FileName);
            }
        }

        // Save a control's image.
        private void SaveControlImage(FrameworkElement control,
            string filename)
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
