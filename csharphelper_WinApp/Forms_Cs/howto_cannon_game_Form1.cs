// #define DEBUGGING

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_cannon_game_Form1:Form
  { 


        public howto_cannon_game_Form1()
        {
            InitializeComponent();
        }

        // http://hyperphysics.phy-astr.gsu.edu/hbase/traj.html#tra4
        // Distance: 2 * V^2 * Sin(T) * Cos(T) / g = V^2 * Sin(2*T) / g

        private const int XMAX = 500;
        private const int YMAX = 500;

        private const int HOUSE_HGT = 10;
        private const int HOUSE_WID = 14;
        private const int OVERHANG = 4;
        private const int CANNON_LEN = 20;
        private const int CANNON_HGT = 7;

        private int HouseX, HouseY;
        private double Theta, BulletX, BulletY, Vx, Vy;

        private const int TICKS_PER_SECOND = 10;

        // Acceleration in meters per tick squared.
        private const double YAcceleration =
            9.8 / (TICKS_PER_SECOND * TICKS_PER_SECOND);

        // Initialize.
        private void howto_cannon_game_Form1_Load(object sender, EventArgs e)
        {
            tmrMoveShot.Enabled = false;
            tmrMoveShot.Interval = 1000 / TICKS_PER_SECOND;
            MoveHouse();

            DrawField(picCanvas.CreateGraphics());
        }

        // Launch a cannonball.
        private void btnShoot_Click(object sender, EventArgs e)
        {
            // Redraw.
            using (Graphics gr = picCanvas.CreateGraphics())
            {
                DrawField(gr);
            }

            // Get the speed.
            float speed;
            try
            {
                speed = float.Parse(txtSpeed.Text);
            }
            catch
            {
                MessageBox.Show("Invalid speed", "Invalid Speed",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (speed < 1)
            {
                MessageBox.Show("Speed must be at least 1 mps",
                    "Invalid Speed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Get the speed components in meters per tick.
            Vx = speed * Math.Cos(Theta) / TICKS_PER_SECOND;
            Vy = -speed * Math.Sin(Theta) / TICKS_PER_SECOND;   // Negative to go up.

            // Disable UI elements.
            btnShoot.Enabled = false;
            txtDegrees.Enabled = false;
            txtSpeed.Enabled = false;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

#if DEBUGGING
            // Draw the location where the cannon ball
            // should pass the Y position where it started.
            // Distance = 2 * V^2 * Sin(T) * Cos(T) / g = V^2 * Sin(2*T) / g
            gr.DrawEllipse(Pens.Blue,
                (float)(BulletX + 2 * speed * speed * Math.Sin(Theta) * Math.Cos(Theta) / 9.8),
                (float)(BulletY), CANNON_HGT, CANNON_HGT);
#endif

            // Start moving the cannon ball.
            tmrMoveShot.Enabled = true;
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawField(e.Graphics);
        }

        // Draw the field.
        private void DrawField(Graphics gr)
        {
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gr.Clear(picCanvas.BackColor);

            // Draw the house.
            Point[] pts = new Point[7];
            pts[0] = new Point(HouseX, HouseY);
            pts[1] = new Point(pts[0].X, pts[0].Y - HOUSE_HGT);
            pts[2] = new Point(pts[1].X - OVERHANG, pts[1].Y);
            pts[3] = new Point(pts[2].X + OVERHANG + HOUSE_WID / 2, pts[2].Y - OVERHANG - HOUSE_WID / 2);
            pts[4] = new Point(pts[3].X + OVERHANG + HOUSE_WID / 2, pts[2].Y);
            pts[5] = new Point(pts[4].X - OVERHANG, pts[1].Y);
            pts[6] = new Point(pts[5].X, pts[0].Y);
            gr.FillPolygon(Brushes.White, pts);
            gr.DrawPolygon(Pens.Blue, pts);

            // Draw the cannon.
            try
            {
                Theta = double.Parse(txtDegrees.Text) * Math.PI / 180;
            }
            catch
            {
                Theta = 0;
            }
            if (Theta > Math.PI / 2) Theta = Math.PI / 2;
            if (Theta < 0) Theta = 0;

            int cx = 10 + CANNON_HGT / 2;
            int cy = YMAX - 10 - CANNON_HGT / 2;

            pts = new Point[4];
            pts[0] = new Point(
                cx - (int)(CANNON_HGT * Math.Cos(Math.PI / 2 - Theta) / 2),
                cy - (int)(CANNON_HGT * Math.Sin(Math.PI / 2 - Theta) / 2));
            pts[1] = new Point(
                pts[0].X + (int)(CANNON_LEN * Math.Cos(Theta)),
                (int)(pts[0].Y - CANNON_LEN * Math.Sin(Theta)));
            pts[2] = new Point(
                pts[1].X + (int)(CANNON_HGT * Math.Cos(Math.PI / 2 - Theta)),
                pts[1].Y + (int)(CANNON_HGT * Math.Sin(Math.PI / 2 - Theta)));
            pts[3] = new Point(
                pts[2].X - (int)(CANNON_LEN * Math.Cos(Theta)),
                pts[2].Y + (int)(CANNON_LEN * Math.Sin(Theta)));
            gr.FillPolygon(Brushes.Gray, pts);
            gr.DrawPolygon(Pens.Black, pts);

            gr.FillPie(Brushes.Black,
                cx - CANNON_HGT,
                (float)(cy - CANNON_HGT / 2),
                CANNON_HGT * 2, CANNON_HGT * 2, 180, 180);

            BulletX = pts[1].X + CANNON_HGT * Math.Cos(Math.PI / 2 - Theta) / 2 + CANNON_HGT * Math.Cos(Theta) * 0.6;
            BulletY = pts[1].Y - CANNON_HGT * Math.Sin(Math.PI / 2 - Theta) / 2 - CANNON_HGT * Math.Sin(Theta) * 0.6;
        }

        private void MoveHouse()
        {
            Random rnd = new Random();
            HouseX = rnd.Next((XMAX * 2) / 3, (int)(XMAX - HOUSE_WID - OVERHANG));
            HouseY = rnd.Next((YMAX * 3) / 4, YMAX - 3);
        }

        private void tmrMoveShot_Tick(object sender, EventArgs e)
        {
            // Erase the cannon ball's previous position.
            using (Graphics gr = picCanvas.CreateGraphics())
            {
                using (Brush br = new SolidBrush(picCanvas.BackColor))
                {
                    gr.FillEllipse(br, (float)(BulletX), (float)(BulletY),
                        CANNON_HGT, CANNON_HGT);
                }

                // Move the cannon ball.
                Vy += YAcceleration;
                BulletX += Vx;
                BulletY += Vy;

                // Draw the new cannon ball.
                gr.FillEllipse(Brushes.Black,
                    (float)(BulletX), (float)(BulletY),
                    CANNON_HGT, CANNON_HGT);

                // See if we should stop.
                if ((BulletY > picCanvas.ClientRectangle.Height) ||
                    (BulletX > picCanvas.ClientRectangle.Width))
                {
                    // Stop running.
                    tmrMoveShot.Enabled = false;

                    // Re-enable UI elements.
                    btnShoot.Enabled = true;
                    txtDegrees.Enabled = true;
                    txtSpeed.Enabled = true;
                    Cursor = Cursors.Default;
                }
            }
        }

        private void txtDegrees_TextChanged(object sender, EventArgs e)
        {
            DrawField(picCanvas.CreateGraphics());
        }

        private void txtSpeed_TextChanged(object sender, EventArgs e)
        {
            DrawField(picCanvas.CreateGraphics());
        }
    

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
            this.components = new System.ComponentModel.Container();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.tmrMoveShot = new System.Windows.Forms.Timer(this.components);
            this.btnShoot = new System.Windows.Forms.Button();
            this.Label1_1 = new System.Windows.Forms.Label();
            this.Label1_0 = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.txtDegrees = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.SystemColors.Control;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Default;
            this.picCanvas.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picCanvas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picCanvas.Location = new System.Drawing.Point(1, 50);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.picCanvas.Size = new System.Drawing.Size(493, 491);
            this.picCanvas.TabIndex = 23;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            // 
            // tmrMoveShot
            // 
            this.tmrMoveShot.Tick += new System.EventHandler(this.tmrMoveShot_Tick);
            // 
            // btnShoot
            // 
            this.btnShoot.BackColor = System.Drawing.SystemColors.Control;
            this.btnShoot.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnShoot.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShoot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShoot.Location = new System.Drawing.Point(138, 11);
            this.btnShoot.Name = "btnShoot";
            this.btnShoot.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnShoot.Size = new System.Drawing.Size(49, 25);
            this.btnShoot.TabIndex = 22;
            this.btnShoot.Text = "Shoot";
            this.btnShoot.UseVisualStyleBackColor = false;
            this.btnShoot.Click += new System.EventHandler(this.btnShoot_Click);
            // 
            // Label1_1
            // 
            this.Label1_1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1_1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1_1.Location = new System.Drawing.Point(2, 30);
            this.Label1_1.Name = "Label1_1";
            this.Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1_1.Size = new System.Drawing.Size(81, 17);
            this.Label1_1.TabIndex = 20;
            this.Label1_1.Text = "Speed (m/s)";
            // 
            // Label1_0
            // 
            this.Label1_0.BackColor = System.Drawing.SystemColors.Control;
            this.Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1_0.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1_0.Location = new System.Drawing.Point(2, 4);
            this.Label1_0.Name = "Label1_0";
            this.Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1_0.Size = new System.Drawing.Size(88, 17);
            this.Label1_0.TabIndex = 18;
            this.Label1_0.Text = "Angle (degrees)";
            // 
            // txtSpeed
            // 
            this.txtSpeed.AcceptsReturn = true;
            this.txtSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.txtSpeed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSpeed.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpeed.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSpeed.Location = new System.Drawing.Point(96, 27);
            this.txtSpeed.MaxLength = 0;
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSpeed.Size = new System.Drawing.Size(33, 20);
            this.txtSpeed.TabIndex = 21;
            this.txtSpeed.Text = "50";
            this.txtSpeed.TextChanged += new System.EventHandler(this.txtSpeed_TextChanged);
            // 
            // txtDegrees
            // 
            this.txtDegrees.AcceptsReturn = true;
            this.txtDegrees.BackColor = System.Drawing.SystemColors.Window;
            this.txtDegrees.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDegrees.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDegrees.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDegrees.Location = new System.Drawing.Point(96, 1);
            this.txtDegrees.MaxLength = 0;
            this.txtDegrees.Name = "txtDegrees";
            this.txtDegrees.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDegrees.Size = new System.Drawing.Size(33, 20);
            this.txtDegrees.TabIndex = 19;
            this.txtDegrees.Text = "45";
            this.txtDegrees.TextChanged += new System.EventHandler(this.txtDegrees_TextChanged);
            // 
            // howto_cannon_game_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 543);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.btnShoot);
            this.Controls.Add(this.Label1_1);
            this.Controls.Add(this.Label1_0);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.txtDegrees);
            this.Name = "howto_cannon_game_Form1";
            this.Text = "howto_cannon_game";
            this.Load += new System.EventHandler(this.howto_cannon_game_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picCanvas;
        internal System.Windows.Forms.Timer tmrMoveShot;
        public System.Windows.Forms.Button btnShoot;
        public System.Windows.Forms.Label Label1_1;
        public System.Windows.Forms.Label Label1_0;
        public System.Windows.Forms.TextBox txtSpeed;
        public System.Windows.Forms.TextBox txtDegrees;
    }
}

