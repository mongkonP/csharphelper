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
    /// Interaction logic for howto_wpf_render_dashed_lines_Window1.xaml
    /// </summary>
    public partial class howto_wpf_render_dashed_lines_Window1 : Window
    {
        public howto_wpf_render_dashed_lines_Window1()
        {
            InitializeComponent();
        }

        // At design time:
        //      Set the window's Background to Transparent.
        //      Name the content control grdMain.
        protected override void OnRender(DrawingContext drawingContext)
        {
            // Clear the background.
            Rect bg_rect = new Rect(0, 0, this.ActualWidth, this.ActualHeight);
            drawingContext.DrawRectangle(Brushes.White, null, bg_rect);

            // Get the X coordinates to draw.
            const double line_thickness = 5;
            const double dy = 4 * line_thickness;
            Point point1 = new Point(10, 10);
            Point point2 = new Point(
                grdMain.ActualWidth - 2 * point1.X, point1.Y);

            // Draw some sample lines.
            Pen solid_pen = new Pen(Brushes.Blue, line_thickness);
            drawingContext.DrawLine(solid_pen, point1, point2);
            point1.Y += dy;
            point2.Y += dy;

            Pen dashed_pen = new Pen(Brushes.Blue, line_thickness);
            dashed_pen.DashStyle = DashStyles.Dash;
            drawingContext.DrawLine(dashed_pen, point1, point2);
            point1.Y += dy;
            point2.Y += dy;

            Pen dotteded_pen = new Pen(Brushes.Blue, line_thickness);
            dotteded_pen.DashStyle = DashStyles.Dot;
            drawingContext.DrawLine(dotteded_pen, point1, point2);
            point1.Y += dy;
            point2.Y += dy;

            Pen dashdoted_pen = new Pen(Brushes.Blue, line_thickness);
            dashdoted_pen.DashStyle = DashStyles.DashDot;
            drawingContext.DrawLine(dashdoted_pen, point1, point2);
            point1.Y += dy;
            point2.Y += dy;

            Pen dashdotdot_pen = new Pen(Brushes.Blue, line_thickness);
            dashdotdot_pen.DashStyle = DashStyles.DashDotDot;
            drawingContext.DrawLine(dashdotdot_pen, point1, point2);
            point1.Y += dy;
            point2.Y += dy;

            Pen custom1_pen = new Pen(Brushes.Green, line_thickness);
            DashStyle dash_style1 = new DashStyle(
                new double[] { 5, 5 }, 0);
            custom1_pen.DashStyle = dash_style1;
            drawingContext.DrawLine(custom1_pen, point1, point2);
            point1.Y += dy;
            point2.Y += dy;

            Pen custom2_pen = new Pen(Brushes.Green, line_thickness);
            DashStyle dash_style2 = new DashStyle(
                new double[] { 10, 2 }, 0);
            custom2_pen.DashStyle = dash_style2;
            drawingContext.DrawLine(custom2_pen, point1, point2);
            point1.Y += dy;
            point2.Y += dy;

            Pen custom3_pen = new Pen(Brushes.Green, line_thickness);
            DashStyle dash_style3 = new DashStyle(
                new double[] { 3, 2, 3, 2, 0, 2}, 0);
            custom3_pen.DashStyle = dash_style3;
            drawingContext.DrawLine(custom3_pen, point1, point2);
            point1.Y += dy;
            point2.Y += dy;
        }
    }
}
