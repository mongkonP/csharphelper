
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Text;

  namespace  howto_shaded_ellipse

 { 

[ToolboxBitmap(typeof(ShadedEllipse), "ShadedEllipseTool.bmp")]
    public class ShadedEllipse : Control
    {
        #region template code
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion template code

        public ShadedEllipse()
        {
            InitializeComponent();

            // Set initial properties.
            Font = new Font("Times New Roman", 12, FontStyle.Bold);
            BackColor = Color.Green;
        }

        private ContentAlignment _TextAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// Determines the position of the text within the control.
        /// </summary>
        [Description("Determines the position of the text within the control.")]
        public ContentAlignment TextAlign
        {
            get { return _TextAlign; }
            set { _TextAlign = value; Refresh(); }
        }

        // Redraw.
        protected override void OnTextChanged(System.EventArgs e)
        {
            Refresh();
        }

        // Draw the control.
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw smoothly.
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            // Make an elliptical clipping region.
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(ClientRectangle);
            Region clipping_region = new Region(path);
            Region = clipping_region;

            // Draw the background.
            using (Brush br = new LinearGradientBrush(
                new Point(0, 0),
                new Point(ClientSize.Width, ClientSize.Height),
                Color.White, BackColor))
            {
                e.Graphics.FillEllipse(br, ClientRectangle);
                using (Pen pen = new Pen(BackColor, 4))
                {
                    e.Graphics.DrawEllipse(pen, ClientRectangle);
                }
            }

            // Draw the text.
            using (StringFormat string_format = new StringFormat())
            {
                SetStringFormatFromContentAlignment(TextAlign, string_format);
                using (Brush br = new SolidBrush(ForeColor))
                {
                    e.Graphics.DrawString(Text, Font, br, ClientRectangle, string_format);
                }
            }
        }

        // Set the StringFormat's alignment properties
        // appropriately for this ContentAlignment value.
        private void SetStringFormatFromContentAlignment(ContentAlignment text_align, StringFormat string_format)
        {
            // Set the horizontal alignment.
            switch (TextAlign)
            {
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopRight:
                    string_format.LineAlignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomRight:
                    string_format.LineAlignment = StringAlignment.Far;
                    break;
                default:
                    string_format.LineAlignment = StringAlignment.Center;
                    break;
            }

            // Set the vertical alignment.
            switch (TextAlign)
            {
                case ContentAlignment.BottomLeft:
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                    string_format.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                    string_format.Alignment = StringAlignment.Far;
                    break;
                default:
                    string_format.Alignment = StringAlignment.Center;
                    break;
            }
        }
    }

}