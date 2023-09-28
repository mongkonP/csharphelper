using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_serialize_images_Form1:Form
  { 


        public howto_serialize_images_Form1()
        {
            InitializeComponent();
        }

        private void howto_serialize_images_Form1_Load(object sender, EventArgs e)
        {
            // Add the files to a list.
            List<Image> input_images = new List<Image>();
            input_images.Add((Bitmap)picSource1.Image);
            input_images.Add((Bitmap)picSource2.Image);
            input_images.Add((Bitmap)picSource3.Image);

            // Serialize.
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, input_images);
                bytes = ms.ToArray();
            }

            // Display the serialization bytes.
            txtHex.Text = BitConverter.ToString(
                bytes, 0).Replace('-', ' ');
            txtHex.Select(0, 0);

            // Deserialize.
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                BinaryFormatter formattter = new BinaryFormatter();
                List<Image> output_images =
                    (List<Image>)formattter.Deserialize(ms);
                picDest1.Image = output_images[0];
                picDest2.Image = output_images[1];
                picDest3.Image = output_images[2];
            }
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
            this.txtHex = new System.Windows.Forms.TextBox();
            this.picDest3 = new System.Windows.Forms.PictureBox();
            this.picDest2 = new System.Windows.Forms.PictureBox();
            this.picDest1 = new System.Windows.Forms.PictureBox();
            this.picSource3 = new System.Windows.Forms.PictureBox();
            this.picSource2 = new System.Windows.Forms.PictureBox();
            this.picSource1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDest3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHex
            // 
            this.txtHex.Location = new System.Drawing.Point(12, 218);
            this.txtHex.Multiline = true;
            this.txtHex.Name = "txtHex";
            this.txtHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHex.Size = new System.Drawing.Size(494, 91);
            this.txtHex.TabIndex = 7;
            // 
            // picDest3
            // 
            this.picDest3.Location = new System.Drawing.Point(345, 315);
            this.picDest3.Name = "picDest3";
            this.picDest3.Size = new System.Drawing.Size(161, 200);
            this.picDest3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDest3.TabIndex = 5;
            this.picDest3.TabStop = false;
            // 
            // picDest2
            // 
            this.picDest2.Location = new System.Drawing.Point(176, 315);
            this.picDest2.Name = "picDest2";
            this.picDest2.Size = new System.Drawing.Size(163, 200);
            this.picDest2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDest2.TabIndex = 4;
            this.picDest2.TabStop = false;
            // 
            // picDest1
            // 
            this.picDest1.Location = new System.Drawing.Point(12, 315);
            this.picDest1.Name = "picDest1";
            this.picDest1.Size = new System.Drawing.Size(158, 200);
            this.picDest1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDest1.TabIndex = 3;
            this.picDest1.TabStop = false;
            // 
            // picSource3
            // 
            this.picSource3.Image = Properties.Resources.interview_puzzles_dissected;
            this.picSource3.Location = new System.Drawing.Point(345, 12);
            this.picSource3.Name = "picSource3";
            this.picSource3.Size = new System.Drawing.Size(161, 200);
            this.picSource3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource3.TabIndex = 2;
            this.picSource3.TabStop = false;
            // 
            // picSource2
            // 
            this.picSource2.Image = Properties.Resources.wpf3d;
            this.picSource2.Location = new System.Drawing.Point(176, 12);
            this.picSource2.Name = "picSource2";
            this.picSource2.Size = new System.Drawing.Size(163, 200);
            this.picSource2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource2.TabIndex = 1;
            this.picSource2.TabStop = false;
            // 
            // picSource1
            // 
            this.picSource1.Image = Properties.Resources.essential_algorithms2e;
            this.picSource1.Location = new System.Drawing.Point(12, 12);
            this.picSource1.Name = "picSource1";
            this.picSource1.Size = new System.Drawing.Size(158, 200);
            this.picSource1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSource1.TabIndex = 0;
            this.picSource1.TabStop = false;
            // 
            // howto_serialize_images_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 527);
            this.Controls.Add(this.txtHex);
            this.Controls.Add(this.picDest3);
            this.Controls.Add(this.picDest2);
            this.Controls.Add(this.picDest1);
            this.Controls.Add(this.picSource3);
            this.Controls.Add(this.picSource2);
            this.Controls.Add(this.picSource1);
            this.Name = "howto_serialize_images_Form1";
            this.Text = "howto_serialize_images";
            this.Load += new System.EventHandler(this.howto_serialize_images_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDest3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDest2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSource1;
        private System.Windows.Forms.PictureBox picSource2;
        private System.Windows.Forms.PictureBox picSource3;
        private System.Windows.Forms.PictureBox picDest3;
        private System.Windows.Forms.PictureBox picDest2;
        private System.Windows.Forms.PictureBox picDest1;
        private System.Windows.Forms.TextBox txtHex;
    }
}

