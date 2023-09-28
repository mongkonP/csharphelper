using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_define_interface;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_define_interface_Form1:Form
  { 


        public howto_define_interface_Form1()
        {
            InitializeComponent();
        }

        // Make an object.
        private void howto_define_interface_Form1_Load(object sender, EventArgs e)
        {
            // Make a Vehicle.
            // Set NumCupholders and Mpg but not MaxSpeed.
            Car car = new Car();
            car.NumCupholders = 5;
            car.MaxSpeed = 50;              // Fails.
            car.Mpg = 10;

            // Make an IVehicle.
            // Set MaxSpeed and Mpg but not NumCupholders.
            IVehicle ivehicle = new Car();
         //   ivehicle.NumCupholders = 5;     // Fails.
            ivehicle.MaxSpeed = 50;
            ivehicle.Mpg = 10;
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
            this.SuspendLayout();
            // 
            // howto_define_interface_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Name = "howto_define_interface_Form1";
            this.Text = "howto_define_interface";
            this.Load += new System.EventHandler(this.howto_define_interface_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

