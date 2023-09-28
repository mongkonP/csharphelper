using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

 

using howto_user_draw_arc;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_user_draw_arc_Form1:Form
  { 


        public howto_user_draw_arc_Form1()
        {
            InitializeComponent();
        }
       
        // Radius of grab handles.
        private const int RADIUS = 3;

        // Used to draw new arcs.
        private Arc NewArc = null;
        private Point StartPoint;

        // Used to draw existing Arcs.
        private List<Arc> Arcs = new List<Arc>();

        // The Arc and part of the Arc that the mouse is over.
        private Arc ArcUnderMouse = null;
        private Arc.Part PartUnderMouse = Arc.Part.None;

        // The default new Arc draw cursor.
        private Cursor ArcCursor;

        // Load the Arc cursor.
        private void howto_user_draw_arc_Form1_Load(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap("arc_cursor.png");
            bm.MakeTransparent(Color.White);
            ArcCursor = MakeCursor(bm, 7, 6);
        }



        // Process MouseMove when the mouse is up.
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // See what the mouse is over.
            foreach (Arc arc in Arcs)
            {
                Arc.Part part = arc.ArcPartAtPoint(e.Location, RADIUS);
                if (part != Arc.Part.None)
                {
                    ArcUnderMouse = arc;
                    PartUnderMouse = part;

                    switch (part)
                    {
                        case Arc.Part.StartPoint:
                            picCanvas.Cursor = Cursors.Cross;
                            break;
                        case Arc.Part.EndPoint:
                            picCanvas.Cursor = Cursors.Cross;
                            break;
                        case Arc.Part.Body:
                            picCanvas.Cursor = Cursors.SizeAll;
                            break;
                    }
                    return;
                }
            }

            // We're not over any arc parts.
            ArcUnderMouse = null;
            PartUnderMouse = Arc.Part.None;
            picCanvas.Cursor = ArcCursor;
        }

        // Handle MouseDown.
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            // Install new arc event handlers
            // depending on what is under the mouse.
            switch (PartUnderMouse)
            {
                case Arc.Part.Body:
                    // Move the Arc.
                    StartPoint = e.Location;
                    picCanvas.MouseDown -= picCanvas_MouseDown;
                    picCanvas.MouseMove -= picCanvas_MouseMove;
                    picCanvas.MouseMove += MoveArc_MouseMove;
                    picCanvas.MouseUp += MoveArc_MouseUp;
                    break;
                case Arc.Part.StartPoint:
                    // Move the starting point.
                    picCanvas.MouseDown -= picCanvas_MouseDown;
                    picCanvas.MouseMove -= picCanvas_MouseMove;
                    picCanvas.MouseMove += MoveStartPoint_MouseMove;
                    picCanvas.MouseUp += MoveStartPoint_MouseUp;
                    break;
                case Arc.Part.EndPoint:
                    // Move the ending point.
                    picCanvas.MouseDown -= picCanvas_MouseDown;
                    picCanvas.MouseMove -= picCanvas_MouseMove;
                    picCanvas.MouseMove += MoveEndPoint_MouseMove;
                    picCanvas.MouseUp += MoveEndPoint_MouseUp;
                    break;
                case Arc.Part.None:
                default:
                    // Make a new Arc.
                    picCanvas.MouseDown -= picCanvas_MouseDown;
                    picCanvas.MouseMove -= picCanvas_MouseMove;
                    picCanvas.MouseMove += NewArc_MouseMove;
                    picCanvas.MouseUp += NewArc_MouseUp;
                    StartPoint = e.Location;
                    Rectangle bounds = new Rectangle(
                        StartPoint, new Size(0, 0));
                    NewArc = new Arc(bounds, 270, 90);
                    break;
            }
        }



#region Creating a New Arc

        // MouseMove while creating a new Arc.
        private void NewArc_MouseMove(object sender, MouseEventArgs e)
        {
            NewArc.Bounds = GetRectangle(StartPoint, e.Location);
            picCanvas.Refresh();
        }

        // MouseUp while creating a new Arc.
        private void NewArc_MouseUp(object sender, MouseEventArgs e)
        {
            // Add the new arc if it has non-zero width and height.
            if ((NewArc.Bounds.Width > 0) &&
                (NewArc.Bounds.Height > 0))
            {
                Arcs.Add(NewArc);
            }

            // Restore original event handlers.
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseMove -= NewArc_MouseMove;
            picCanvas.MouseUp -= NewArc_MouseUp;

            NewArc = null;
            picCanvas.Refresh();
        }

#endregion Creating a New Arc

#region Moving an Arc

        // MouseMove while moving an Arc.
        private void MoveArc_MouseMove(object sender, MouseEventArgs e)
        {
            int dx = e.Location.X - StartPoint.X;
            int dy = e.Location.Y - StartPoint.Y;
            ArcUnderMouse.Move(dx, dy);
            StartPoint = e.Location;
            picCanvas.Refresh();
        }

        // MouseUp while moving an Arc.
        private void MoveArc_MouseUp(object sender, MouseEventArgs e)
        {
            // Restore original event handlers.
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseMove -= MoveArc_MouseMove;
            picCanvas.MouseUp -= MoveArc_MouseUp;
        }

#endregion Moving an Arc

#region Moving a Starting Point

        // MouseMove while moving a starting point.
        private void MoveStartPoint_MouseMove(object sender, MouseEventArgs e)
        {
            ArcUnderMouse.MoveStartPoint(e.Location);
            picCanvas.Refresh();
        }

        // MouseUp while moving a starting point.
        private void MoveStartPoint_MouseUp(object sender, MouseEventArgs e)
        {
            // Restore original event handlers.
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseMove -= MoveStartPoint_MouseMove;
            picCanvas.MouseUp -= MoveStartPoint_MouseUp;
        }

#endregion Moving a Starting Point

#region Moving an Ending Point

        // MouseMove while moving a Ending point.
        private void MoveEndPoint_MouseMove(object sender, MouseEventArgs e)
        {
            ArcUnderMouse.MoveEndPoint(e.Location);
            picCanvas.Refresh();
        }

        // MouseUp while moving a Ending point.
        private void MoveEndPoint_MouseUp(object sender, MouseEventArgs e)
        {
            // Restore original event handlers.
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseMove -= MoveEndPoint_MouseMove;
            picCanvas.MouseUp -= MoveEndPoint_MouseUp;
        }

#endregion Moving an Ending Point

        // Draw any arcs.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw existing arcs.
            Color color = Color.FromArgb(
                Color.LightBlue.R,
                Color.LightBlue.G,
                Color.LightBlue.B,
                128);
            using (Pen pen = new Pen(color, 5))
            {
                foreach (Arc arc in Arcs)
                {
                    arc.Draw(e.Graphics, null, Pens.Black);
                }
            }

            // Draw existing arc end points.
            foreach (Arc arc in Arcs)
            {
                arc.DrawEndPoints(e.Graphics,
                    Brushes.White, Pens.Black, RADIUS);
            }

            // Draw the arc in progress (if any).
            if (NewArc != null)
            {
                using (Pen pen = new Pen(Color.Blue))
                {
                    // Use a dashed pen.
                    pen.DashPattern = new float[] { 5, 5 };

                    // Draw the arc in blue.
                    NewArc.Draw(e.Graphics, null, pen);

                    // Draw the bounding rectangle in green.
                    pen.Color = Color.Green;
                    e.Graphics.DrawRectangle(pen,
                        NewArc.Bounds.X, NewArc.Bounds.Y,
                        NewArc.Bounds.Width, NewArc.Bounds.Height);
                }
            }
        }

        // Return a Rectangle defined by the start and end points.
        private RectangleF GetRectangle(Point start_point, Point end_point)
        {
            return new RectangleF(
                Math.Min(start_point.X, end_point.X),
                Math.Min(start_point.Y, end_point.Y),
                Math.Abs(start_point.X - end_point.X),
                Math.Abs(start_point.Y - end_point.Y));
        }

#region Custom Cursors

        [StructLayout(LayoutKind.Sequential)]
        struct ICONINFO
        {
            public bool fIcon;         // Specifies whether this structure defines an icon or a cursor. A value of TRUE specifies
            // an icon; FALSE specifies a cursor.
            public Int32 xHotspot;     // Specifies the x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot
            // spot is always in the center of the icon, and this member is ignored.
            public Int32 yHotspot;     // Specifies the y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot
            // spot is always in the center of the icon, and this member is ignored.
            public IntPtr hbmMask;     // (HBITMAP) Specifies the icon bitmask bitmap. If this structure defines a black and white icon,
            // this bitmask is formatted so that the upper half is the icon AND bitmask and the lower half is
            // the icon XOR bitmask. Under this condition, the height should be an even multiple of two. If
            // this structure defines a color icon, this mask only defines the AND bitmask of the icon.
            public IntPtr hbmColor;    // (HBITMAP) Handle to the icon color bitmap. This member can be optional if this
            // structure defines a black and white icon. The AND bitmask of hbmMask is applied with the SRCAND
            // flag to the destination; subsequently, the color bitmap is applied (using XOR) to the
            // destination by using the SRCINVERT flag.
        }

        [DllImport("user32.dll")]
        static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

        [DllImport("user32.dll")]
        static extern IntPtr CreateIconIndirect([In] ref ICONINFO piconinfo);

        // Create a cursor from a bitmap.
        public static Cursor MakeCursor(Bitmap bmp, int hot_x, int hot_y)
        {
            // Initialize the cursor information.
            ICONINFO icon_info = new ICONINFO();
            IntPtr h_icon = bmp.GetHicon();
            GetIconInfo(h_icon, out icon_info);
            icon_info.xHotspot = hot_x;
            icon_info.yHotspot = hot_y;
            icon_info.fIcon = false;    // Cursor, not icon.

            // Create the cursor.
            IntPtr h_cursor = CreateIconIndirect(ref icon_info);
            return new Cursor(h_cursor);
        }

#endregion Custom Cursors
    

/// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(260, 237);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // howto_user_draw_arc_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.picCanvas);
            this.Name = "howto_user_draw_arc_Form1";
            this.Text = "howto_user_draw_arc";
            this.Load += new System.EventHandler(this.howto_user_draw_arc_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
    }
}

