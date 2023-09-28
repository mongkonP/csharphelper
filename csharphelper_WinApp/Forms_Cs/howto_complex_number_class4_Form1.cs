using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_complex_number_class4;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_complex_number_class4_Form1:Form
  { 


        public howto_complex_number_class4_Form1()
        {
            InitializeComponent();
        }

        // Perform sample calculations.
        private void btnGo_Click(object sender, EventArgs e)
        {
            Complex A = Complex.Parse(txtA.Text);
            Complex B = Complex.Parse(txtB.Text);
            double R = double.Parse(txtReal.Text);

            txtAplusR.Text = (A + R).ToString();
            txtRplusA.Text = (R + A).ToString();
            txtAtimesR.Text = (A * R).ToString();
            txtRtimesA.Text = (R * A).ToString();
            txtAminusR.Text = (A - R).ToString();
            txtRminusA.Text = (R - A).ToString();

            txtAdividedbyR.Text = (A / R).ToString("0.0000");
            Complex check2 = (A / R) * R;
            txtCheck2.Text = check2.ToString();

            txtRdividedbyA.Text = (R / A).ToString("0.0000");
            Complex check3 = (R / A) * A;
            txtCheck3.Text = check3.ToString();

            Complex converted = (Complex)R;
            txtCast.Text = converted.ToString();
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
            this.txtCast = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCheck3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRdividedbyA = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCheck2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtAdividedbyR = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRminusA = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAminusR = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAplusR = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRtimesA = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAtimesR = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRplusA = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtCast
            // 
            this.txtCast.Location = new System.Drawing.Point(376, 207);
            this.txtCast.Name = "txtCast";
            this.txtCast.ReadOnly = true;
            this.txtCast.Size = new System.Drawing.Size(115, 20);
            this.txtCast.TabIndex = 167;
            this.txtCast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(260, 208);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(110, 17);
            this.label20.TabIndex = 168;
            this.label20.Text = "Cast Real";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCheck3
            // 
            this.txtCheck3.Location = new System.Drawing.Point(376, 181);
            this.txtCheck3.Name = "txtCheck3";
            this.txtCheck3.ReadOnly = true;
            this.txtCheck3.Size = new System.Drawing.Size(115, 20);
            this.txtCheck3.TabIndex = 153;
            this.txtCheck3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(260, 182);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 17);
            this.label18.TabIndex = 166;
            this.label18.Text = "(Real / A) * A";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRdividedbyA
            // 
            this.txtRdividedbyA.Location = new System.Drawing.Point(376, 155);
            this.txtRdividedbyA.Name = "txtRdividedbyA";
            this.txtRdividedbyA.ReadOnly = true;
            this.txtRdividedbyA.Size = new System.Drawing.Size(115, 20);
            this.txtRdividedbyA.TabIndex = 152;
            this.txtRdividedbyA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(260, 156);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 17);
            this.label19.TabIndex = 165;
            this.label19.Text = "Real / A";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCheck2
            // 
            this.txtCheck2.Location = new System.Drawing.Point(376, 129);
            this.txtCheck2.Name = "txtCheck2";
            this.txtCheck2.ReadOnly = true;
            this.txtCheck2.Size = new System.Drawing.Size(115, 20);
            this.txtCheck2.TabIndex = 151;
            this.txtCheck2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(260, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 17);
            this.label16.TabIndex = 164;
            this.label16.Text = "(A / Real) * Real";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAdividedbyR
            // 
            this.txtAdividedbyR.Location = new System.Drawing.Point(376, 103);
            this.txtAdividedbyR.Name = "txtAdividedbyR";
            this.txtAdividedbyR.ReadOnly = true;
            this.txtAdividedbyR.Size = new System.Drawing.Size(115, 20);
            this.txtAdividedbyR.TabIndex = 150;
            this.txtAdividedbyR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(260, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(110, 17);
            this.label17.TabIndex = 163;
            this.label17.Text = "A / Real";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRminusA
            // 
            this.txtRminusA.Location = new System.Drawing.Point(90, 233);
            this.txtRminusA.Name = "txtRminusA";
            this.txtRminusA.ReadOnly = true;
            this.txtRminusA.Size = new System.Drawing.Size(115, 20);
            this.txtRminusA.TabIndex = 149;
            this.txtRminusA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 162;
            this.label10.Text = "Real - A";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAminusR
            // 
            this.txtAminusR.Location = new System.Drawing.Point(90, 207);
            this.txtAminusR.Name = "txtAminusR";
            this.txtAminusR.ReadOnly = true;
            this.txtAminusR.Size = new System.Drawing.Size(115, 20);
            this.txtAminusR.TabIndex = 148;
            this.txtAminusR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 17);
            this.label11.TabIndex = 161;
            this.label11.Text = "A - Real";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAplusR
            // 
            this.txtAplusR.Location = new System.Drawing.Point(90, 103);
            this.txtAplusR.Name = "txtAplusR";
            this.txtAplusR.ReadOnly = true;
            this.txtAplusR.Size = new System.Drawing.Size(115, 20);
            this.txtAplusR.TabIndex = 144;
            this.txtAplusR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 160;
            this.label12.Text = "A + Real";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRtimesA
            // 
            this.txtRtimesA.Location = new System.Drawing.Point(90, 181);
            this.txtRtimesA.Name = "txtRtimesA";
            this.txtRtimesA.ReadOnly = true;
            this.txtRtimesA.Size = new System.Drawing.Size(115, 20);
            this.txtRtimesA.TabIndex = 147;
            this.txtRtimesA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 182);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 159;
            this.label13.Text = "Real * A";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAtimesR
            // 
            this.txtAtimesR.Location = new System.Drawing.Point(90, 155);
            this.txtAtimesR.Name = "txtAtimesR";
            this.txtAtimesR.ReadOnly = true;
            this.txtAtimesR.Size = new System.Drawing.Size(115, 20);
            this.txtAtimesR.TabIndex = 146;
            this.txtAtimesR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 158;
            this.label14.Text = "A * Real";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRplusA
            // 
            this.txtRplusA.Location = new System.Drawing.Point(90, 129);
            this.txtRplusA.Name = "txtRplusA";
            this.txtRplusA.ReadOnly = true;
            this.txtRplusA.Size = new System.Drawing.Size(115, 20);
            this.txtRplusA.TabIndex = 145;
            this.txtRplusA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 157;
            this.label15.Text = "Real + A";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 156;
            this.label9.Text = "Real:";
            // 
            // txtReal
            // 
            this.txtReal.Location = new System.Drawing.Point(52, 65);
            this.txtReal.Name = "txtReal";
            this.txtReal.Size = new System.Drawing.Size(64, 20);
            this.txtReal.TabIndex = 142;
            this.txtReal.Text = "3";
            this.txtReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 155;
            this.label4.Text = "B:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 154;
            this.label2.Text = "A:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(136, 23);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(59, 24);
            this.btnGo.TabIndex = 143;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(52, 39);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(64, 20);
            this.txtB.TabIndex = 141;
            this.txtB.Text = "21 + 10i";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(52, 13);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(64, 20);
            this.txtA.TabIndex = 140;
            this.txtA.Text = "4 + 5i";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // howto_complex_number_class4_Form1
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 267);
            this.Controls.Add(this.txtCast);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtCheck3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtRdividedbyA);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtCheck2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtAdividedbyR);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtRminusA);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAminusR);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAplusR);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtRtimesA);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAtimesR);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRplusA);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Name = "howto_complex_number_class4_Form1";
            this.Text = "howto_complex_number_class4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCast;
        internal System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCheck3;
        internal System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtRdividedbyA;
        internal System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCheck2;
        internal System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtAdividedbyR;
        internal System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtRminusA;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAminusR;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAplusR;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRtimesA;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAtimesR;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRplusA;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtReal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnGo;
        internal System.Windows.Forms.TextBox txtB;
        internal System.Windows.Forms.TextBox txtA;
    }
}

