using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// See https://www.intelligentliving.co/optical-illusion-black-white-color/

// Fruit picture: Krzysztof Golik [CC BY-SA 4.0 (https://creativecommons.org/licenses/by-sa/4.0)]
// https://commons.wikimedia.org/wiki/File:Colorful_fruits_01.jpg

using System.Drawing.Imaging;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_color_stripes_Form1:Form
  { 


        public howto_color_stripes_Form1()
        {
            InitializeComponent();
        }

        private enum AreaTypes
        {
            Stripes,
            DiagonalStripes,
            Dots,
            Text,
        }

        private void howto_color_stripes_Form1_Load(object sender, EventArgs e)
        {
            // Get the original image.
            Bitmap bm = Properties.Resources.fruit_small;

            // Make a monochrome copy of the image.
            Bitmap mono_bm = ToMonochrome(bm);

            int margin = picResult1.Left;
            picResult1.Image = PlaceColorAreas(mono_bm,
                bm, AreaTypes.Stripes, 10, 1);
            
            picResult2.Image = PlaceColorAreas(mono_bm,
                bm, AreaTypes.DiagonalStripes, 10, 1);
            picResult2.Location = new Point(
                picResult1.Right + margin, picResult1.Top);

            picResult3.Image = PlaceColorAreas(mono_bm,
                bm, AreaTypes.Dots, 10, 2);
            picResult3.Location = new Point(
                margin, picResult1.Bottom + margin);

            //picResult4.Image = PlaceColorAreas(mono_bm,
            //    bm, AreaTypes.Text, 10, 3);
            picResult4.Image = mono_bm;
            picResult4.Location = new Point(
                picResult3.Right + margin, picResult3.Top);

            ClientSize = new Size(
                picResult4.Right + margin,
                picResult4.Bottom + margin);
        }

        private string lorem_ipsum =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In lacinia massa enim, non eleifend augue luctus sed. Praesent tortor nisi, blandit vel semper vel, malesuada ultrices neque. Sed neque augue, laoreet sed quam a, sodales consequat libero. In euismod vulputate tortor, vel sodales ante ullamcorper commodo. Pellentesque eget nunc at nisi finibus auctor sit amet sit amet dui. Sed eget enim quis velit aliquam finibus eget at nisl. In hac habitasse platea dictumst. Interdum et malesuada fames ac ante ipsum primis in faucibus. Suspendisse libero nunc, mattis ac libero vitae, malesuada tincidunt ante. Curabitur enim metus, efficitur pharetra ex ac, molestie eleifend tellus. Duis sit amet magna augue. Ut et tempor lacus. Donec imperdiet magna nec quam congue mollis. Pellentesque arcu ipsum, interdum non erat euismod, sodales pharetra erat." +
            "Duis feugiat, urna quis fringilla eleifend, nibh ex condimentum velit, at pulvinar arcu ante sit amet sem. Nulla at posuere augue. Nunc tellus diam, egestas vitae ante id, congue pellentesque lorem. Nunc commodo id orci nec maximus. Quisque blandit congue rutrum. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin et cursus nisl, sollicitudin ultrices dolor. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae;" +
            "Sed hendrerit elementum metus, a gravida felis placerat vitae. Morbi viverra ante felis, id dictum nisi egestas eget. Sed auctor, nulla sed blandit rhoncus, elit erat efficitur massa, id suscipit eros ex eu lacus. Donec ligula ante, vestibulum quis laoreet vitae, placerat ac lectus. Pellentesque faucibus vulputate dolor id faucibus. Pellentesque quis erat in nisi blandit lobortis. Cras at efficitur elit. In commodo urna at turpis semper semper. Phasellus felis ligula, hendrerit ut enim et, vulputate volutpat ligula. Nullam aliquam, lacus ac consectetur blandit, justo nisi rhoncus felis, nec gravida felis mauris a lorem. Pellentesque blandit arcu justo, quis hendrerit turpis tristique vitae. Nam id urna eget ipsum tincidunt viverra. Etiam laoreet, risus quis vehicula lobortis, dui tortor cursus mi, viverra cursus dui leo et tortor. Suspendisse vehicula dignissim arcu. In vehicula neque enim, eget mollis elit mollis vel. Morbi a nunc congue, ullamcorper est id, auctor leo." +
            "Etiam mattis eu enim eu tempor. Fusce ut dolor hendrerit, consequat neque vel, tempus lacus. Vestibulum rutrum blandit risus vel bibendum. Maecenas tincidunt quis est sit amet volutpat. Praesent vulputate maximus diam viverra facilisis. Duis pretium arcu vitae enim maximus, ac gravida ex tincidunt. Aliquam ornare massa sed suscipit facilisis. Sed varius fermentum sem. Integer vitae magna sit amet felis lobortis egestas. Praesent tempor ultricies magna. Quisque eu lacus at orci hendrerit luctus in et justo. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec at cursus mi." +
            "Proin non tempor nibh, eu egestas justo. Etiam eu magna lorem. Fusce in est ex. Nulla aliquet feugiat ligula blandit hendrerit. Nullam euismod tellus sed lacus porttitor, accumsan iaculis lacus blandit. Vivamus cursus ante condimentum velit molestie fermentum. Maecenas molestie, sem nec imperdiet interdum, ante felis finibus lorem, et pellentesque nisi mauris luctus ante. In posuere ut sapien nec accumsan. Nulla arcu augue, accumsan sit amet turpis in, mollis congue velit. Nullam quis metus id dolor maximus laoreet. Suspendisse dignissim est eu hendrerit bibendum. Vestibulum molestie sapien et tortor condimentum interdum. Duis quis purus eros." +
            "Donec aliquet nunc eget ex aliquet cursus. Sed finibus nec tortor fermentum sodales. Duis auctor lacus id orci efficitur pharetra. In tempus, enim et lacinia venenatis, urna odio maximus massa, at tristique ligula justo eget sem. Sed mi arcu, porttitor at consequat ac, cursus quis purus. In hac habitasse platea dictumst. In sed semper turpis, eu consectetur dolor. Suspendisse accumsan, purus ut mollis elementum, magna eros elementum nulla, vel elementum erat metus vel arcu. Fusce molestie, arcu non malesuada finibus, sapien tortor facilisis sapien, vitae dictum nulla tellus id lacus. Cras eget elit auctor nibh semper dictum efficitur pharetra nibh. Duis porttitor ipsum sit amet ante gravida condimentum. Integer arcu sapien, semper nec arcu non, bibendum ullamcorper purus." +
            "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vivamus sodales id quam in ullamcorper. Nullam vulputate vitae diam euismod semper. Cras dignissim consequat sem id molestie. Phasellus velit tellus, finibus sed gravida non, sollicitudin sit amet elit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In rhoncus sapien nisl, a porttitor ipsum venenatis quis. Ut mollis magna eget imperdiet iaculis. Donec porttitor ac metus in consequat. Curabitur varius auctor arcu ac lobortis. Sed sem purus, sodales non consequat sit amet, tincidunt eget est. Phasellus gravida id lorem quis luctus. Sed sed porttitor enim, mattis condimentum turpis. Quisque pretium nunc erat, in dapibus elit aliquet ac. Nam euismod ligula eget nisi luctus, eu tincidunt leo convallis." +
            "In ac diam quam. Integer cursus diam enim, et convallis ipsum rutrum sit amet. Donec vulputate magna at porttitor imperdiet. Morbi ac elementum ligula. Nunc ac velit velit. Vestibulum nisi turpis, cursus sit amet imperdiet vulputate, elementum id velit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla pretium nisl sed arcu cursus, faucibus consequat felis tempus. Aliquam non nisl vulputate, volutpat dolor eget, viverra tellus. Donec tristique quam volutpat diam pretium viverra. Praesent mattis est sed metus cursus luctus. Proin condimentum elementum erat, et ullamcorper leo elementum non. Nunc ut suscipit turpis, sed finibus mauris. Maecenas lacinia semper est, sed auctor turpis feugiat eget. Nulla facilisi. Phasellus imperdiet orci id dictum placerat." +
            "Nullam elementum ultrices arcu non fermentum. Proin malesuada mauris sit amet quam tincidunt, a placerat nisl condimentum. Nullam ut neque gravida, ornare mauris ac, accumsan lorem. Integer pharetra quam quis feugiat facilisis. Donec pulvinar enim non efficitur euismod. Aliquam semper lacinia lacus vel accumsan. Ut cursus, nisi at maximus consectetur, justo metus egestas sem, eget dignissim eros nulla sed sem. Vestibulum ut tellus eu quam egestas blandit sed quis risus. Sed pharetra ante eget cursus laoreet. Vestibulum efficitur congue varius. Duis nec tincidunt metus. In fringilla in ex nec porta." +
            "Nulla elementum sed leo at vestibulum. Curabitur quis blandit urna. Maecenas elementum massa et dignissim dapibus. Nunc in nulla eget enim.";

        // Place areas of color on an image.
        private Bitmap PlaceColorAreas(Bitmap bm, Bitmap brush_bm, AreaTypes area_type,
            float spacing, float thickness)
        {
            // Make a monochrome copy of the image.
            Bitmap result = ToMonochrome(bm);

            // Draw colored stripes on the image.
            using (Graphics gr = Graphics.FromImage(result))
            {
                using (Brush brush = new TextureBrush(brush_bm))
                {
                    using (Pen pen = new Pen(brush, thickness))
                    {
                        int wid = brush_bm.Width;
                        int hgt = brush_bm.Height;

                        switch (area_type)
                        {
                            case AreaTypes.Stripes:
                                // Vertical and horizontal stripes.
                                for (float x = 0; x < wid; x += spacing)
                                    gr.DrawLine(pen, x, 0, x, hgt);
                                for (float y = 0; y < hgt; y += spacing)
                                    gr.DrawLine(pen, 0, y, wid, y);
                                break;

                            case AreaTypes.DiagonalStripes:
                                // Diagonal stripes.
                                wid *= 2;
                                hgt *= 2;
                                spacing *= (float)Math.Sqrt(2);
                                for (float i = 0; i < wid; i += spacing)
                                    gr.DrawLine(pen, i, 0, 0, i);
                                for (float i = -hgt; i < hgt; i += spacing)
                                    gr.DrawLine(pen, 0, i, hgt, i + hgt);
                                break;

                            case AreaTypes.Dots:
                                // Dots.
                                for (float x = -spacing / 2f; x < wid; x += spacing)
                                    for (float y = -spacing / 2f; y < hgt; y += spacing)
                                        gr.DrawEllipse(pen, x, y, thickness, thickness);
                                break;

                            case AreaTypes.Text:
                                // Text.
                                using (Font font = new Font("Arial", spacing))
                                {
                                    GraphicsUnit unit = GraphicsUnit.Pixel;
                                    gr.DrawString(lorem_ipsum, font, brush, brush_bm.GetBounds(ref unit));
                                }
                                break;
                        }
                    }
                }
            }
            return result;
        }

        // Convert an image to monochrome.
        // Use an ImageAttributes object to convert an image to monochrome in C#
        // http://csharphelper.com/blog/2014/10/use-an-imageattributes-object-to-convert-an-image-to-monochrome-in-c/
        private Bitmap ToMonochrome(Image image)
        {
            // Make the ColorMatrix.
            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                new float[] { 0, 0, 0, 1, 0},
                new float[] { 0, 0, 0, 0, 1}
            });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while
            // applying the new ColorMatrix.
            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
            return bm;
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
            this.picResult1 = new System.Windows.Forms.PictureBox();
            this.picResult2 = new System.Windows.Forms.PictureBox();
            this.picResult3 = new System.Windows.Forms.PictureBox();
            this.picResult4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picResult1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult4)).BeginInit();
            this.SuspendLayout();
            // 
            // picResult1
            // 
            this.picResult1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picResult1.Location = new System.Drawing.Point(12, 12);
            this.picResult1.Name = "picResult1";
            this.picResult1.Size = new System.Drawing.Size(100, 50);
            this.picResult1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResult1.TabIndex = 0;
            this.picResult1.TabStop = false;
            // 
            // picResult2
            // 
            this.picResult2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picResult2.Location = new System.Drawing.Point(248, 12);
            this.picResult2.Name = "picResult2";
            this.picResult2.Size = new System.Drawing.Size(100, 50);
            this.picResult2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResult2.TabIndex = 1;
            this.picResult2.TabStop = false;
            // 
            // picResult3
            // 
            this.picResult3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picResult3.Location = new System.Drawing.Point(12, 181);
            this.picResult3.Name = "picResult3";
            this.picResult3.Size = new System.Drawing.Size(100, 50);
            this.picResult3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResult3.TabIndex = 2;
            this.picResult3.TabStop = false;
            // 
            // picResult4
            // 
            this.picResult4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picResult4.Location = new System.Drawing.Point(248, 181);
            this.picResult4.Name = "picResult4";
            this.picResult4.Size = new System.Drawing.Size(100, 50);
            this.picResult4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picResult4.TabIndex = 3;
            this.picResult4.TabStop = false;
            // 
            // howto_color_stripes_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 387);
            this.Controls.Add(this.picResult4);
            this.Controls.Add(this.picResult3);
            this.Controls.Add(this.picResult2);
            this.Controls.Add(this.picResult1);
            this.Name = "howto_color_stripes_Form1";
            this.Text = "howto_color_stripes";
            this.Load += new System.EventHandler(this.howto_color_stripes_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picResult1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picResult1;
        private System.Windows.Forms.PictureBox picResult2;
        private System.Windows.Forms.PictureBox picResult3;
        private System.Windows.Forms.PictureBox picResult4;

    }
}

