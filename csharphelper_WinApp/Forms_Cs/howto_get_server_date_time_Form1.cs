using System;
using System.Windows.Forms;

using System.Net.Sockets;
using System.IO;
using System.Text;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_get_server_date_time_Form1:Form
  { 


        public howto_get_server_date_time_Form1()
        {
            InitializeComponent();
        }

        public string sNISTDateTimeFull; //the string holding the full date time output from NIST in ASCII format
        public string subStringNISTDateTimeShort; //the string holding the full date time output without reference to NIST in ASCII format
        public DateTime dtNISTDateTime; //the DateTime value of the NIST date and time used for calculating the span between NIST and the systme clock
        public DateTime dtSystemDateTime; //the DateTime value of the system date and time used for calculating the span between NIST and the systme clock 

        //Server addresses and information from //http://tf.nist.gov/tf-cgi/servers.cgi
        public const string server = "time.nist.gov"; //URL to connect to the server
        public const Int32 port = 13; //port to get date time data from the server

        //**************************************************************************
        //NAME:      howto_get_server_date_time_Form1_Load
        //PURPOSE:   When the form loads, get the date and time from NIST
        //**************************************************************************
        private void howto_get_server_date_time_Form1_Load(object sender, EventArgs e)
        {
            //Call the method to 
            RunGetDateReport();
        }

        //**************************************************************************
        //NAME:      btnGetServerDateAndTime_Click
        //PURPOSE:   When the user click the button to get the lates date and time 
        //from NIST, disable the button so as not to     //harass    // the server and be
        //banned from acessing it in the future.
        //**************************************************************************
        private void btnGetServerDateAndTime_Click(object sender, EventArgs e)
        {
            btnGetServerDateAndTime.Enabled = false;
            TimerAntiPing.Enabled = true;
            RunGetDateReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //**************************************************************************
        //NAME:      RunGetDateReport
        //PURPOSE:   Display the information from NIST and state if the system clock
        //and the date and time from NIST are within 24 hours of eachother.
        //**************************************************************************
        public void RunGetDateReport()
        {
            GetNISTDateTime();

            dtSystemDateTime = DateTime.Now;

            string subStringNISTDateTimeLong = sNISTDateTimeFull.Substring(7, 40);
            dtNISTDateTime = DateTime.Parse("20" + subStringNISTDateTimeShort);
            long lNISTDateTime = dtNISTDateTime.Ticks;
            long lLocalDateTime = dtSystemDateTime.Ticks;

            string sMessage = "";
            sMessage = "NIST Date Time (string long): \t" + subStringNISTDateTimeLong + Environment.NewLine
                + "NIST Date Time (string short): \t" + subStringNISTDateTimeShort + Environment.NewLine
                + "NIST Date Time (date time): \t" + dtNISTDateTime.ToString() + Environment.NewLine
                + "NIST Date Time (ticks): \t" + lNISTDateTime.ToString() + Environment.NewLine
                + "System Date Time (local): \t" + dtSystemDateTime.ToString() + Environment.NewLine
                + "System Date Time (ticks): \t" + dtSystemDateTime.Ticks + Environment.NewLine
                + "System Date Time (UTC): \t" + dtSystemDateTime.ToUniversalTime() + Environment.NewLine;

            //See what the difference is between UTC and the system clock
            TimeSpan elapsedTime = dtNISTDateTime.Subtract(dtSystemDateTime);

            //Evaluate the difference to see if the system clock is within 24 hours of UTC
            if (elapsedTime.TotalHours < 24)
                sMessage = sMessage + "++++++ The clock is in order +++++";
            else
                sMessage = sMessage + "----- The clock is out of order -----";

            txtMessageBox.Text = sMessage; //Show the message on the form.

            this.Refresh();
        }

        //**************************************************************************
        //NAME:      GetNISTDateTime
        //PURPOSE:   Crates a TCP client to connect to the NIST server, get the 
        //data from the server, and parse that data into a string that can be used 
        //for display or calculation.
        //**************************************************************************
        public void GetNISTDateTime()
        {
            bool bGoodConnection = false;

            //Create and instance of a TCP client that will connect to the server 
            //and get the information it offers
            System.Net.Sockets.TcpClient tcpClientConnection = new System.Net.Sockets.TcpClient();

            //Attempt to connect to the NIST server. If it succeeds, the flag is set 
            //to collect the information from the server If it fails, try again
            try
            {
                tcpClientConnection.Connect(server, port);
                bGoodConnection = true;
            }
            catch
            {
                btnGetServerDateAndTime.PerformClick();
            }

            //Don't continue if you haven't got a good connection
            if (bGoodConnection == true)
            {
                //Attempt to get the data streaming from the NIST server
                try
                {
                    NetworkStream netStream = tcpClientConnection.GetStream();

                    //Check the flag the states if you can read the stream or not
                    if (netStream.CanRead)
                    {
                        //Get the size of the buffer
                        byte[] bytes = new byte[tcpClientConnection.ReceiveBufferSize];

                        //Read in the stream to the length of the buffer
                        netStream.Read(bytes, 0, tcpClientConnection.ReceiveBufferSize);

                        //Read the Bytes as ASCII values and build the stream of charaters that are the date and time from NIST. 
                        sNISTDateTimeFull = Encoding.ASCII.GetString(bytes).Substring(0, 50);

                        //Convert the string to a date time value
                        try
                        {
                            subStringNISTDateTimeShort = sNISTDateTimeFull.Substring(7, 17);
                            dtNISTDateTime = DateTime.Parse("20" + subStringNISTDateTimeShort);
                        }
                        catch
                        {
                            btnGetServerDateAndTime.PerformClick(); //try running the sub again if you didn't get anything worth while
                        }
                    }
                    else //If the data stream was unreadable, do the following
                    {
                        MessageBox.Show("You cannot read data from this stream."); //Advise the user of the situation
                        tcpClientConnection.Close(); //close the client stream
                        netStream.Close(); //close the network stream
                    }

                    tcpClientConnection.Close(); //Uses the Close public method to close the network stream and socket.
                }
                //Provide the user feedback if the TCP client couldn't even get the stream of data from the server.
                catch (ArgumentNullException e)
                {
                    MessageBox.Show("ArgumentNullException: {0}", e.ToString()); // show error messages when appropriate
                }
                catch (SocketException e)
                {
                    MessageBox.Show("SocketException: {0}", e.ToString()); // show error messages when appropriate
                }
            }
        }

        //**************************************************************************
        //NAME:      TimerAntiPing_Tick
        //PURPOSE:   This time is set to wait five seconds before sending another 
        //request to NIST for the date and time
        //**************************************************************************
        private void TimerAntiPing_Tick(object sender, EventArgs e)
        {
            btnGetServerDateAndTime.Enabled = true;
            TimerAntiPing.Enabled = false;
            this.Refresh();
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
            this.btnClose = new System.Windows.Forms.Button();
            this.TimerAntiPing = new System.Windows.Forms.Timer(this.components);
            this.txtMessageBox = new System.Windows.Forms.TextBox();
            this.btnGetServerDateAndTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(11, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(573, 30);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TimerAntiPing
            // 
            this.TimerAntiPing.Interval = 5000;
            this.TimerAntiPing.Tick += new System.EventHandler(this.TimerAntiPing_Tick);
            // 
            // txtMessageBox
            // 
            this.txtMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageBox.Location = new System.Drawing.Point(11, 46);
            this.txtMessageBox.Multiline = true;
            this.txtMessageBox.Name = "txtMessageBox";
            this.txtMessageBox.ReadOnly = true;
            this.txtMessageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessageBox.Size = new System.Drawing.Size(573, 201);
            this.txtMessageBox.TabIndex = 4;
            // 
            // btnGetServerDateAndTime
            // 
            this.btnGetServerDateAndTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetServerDateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetServerDateAndTime.Location = new System.Drawing.Point(11, 10);
            this.btnGetServerDateAndTime.Name = "btnGetServerDateAndTime";
            this.btnGetServerDateAndTime.Size = new System.Drawing.Size(573, 30);
            this.btnGetServerDateAndTime.TabIndex = 3;
            this.btnGetServerDateAndTime.Text = "Get Date and Time";
            this.btnGetServerDateAndTime.UseVisualStyleBackColor = true;
            this.btnGetServerDateAndTime.Click += new System.EventHandler(this.btnGetServerDateAndTime_Click);
            // 
            // howto_get_server_date_time_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 292);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtMessageBox);
            this.Controls.Add(this.btnGetServerDateAndTime);
            this.Name = "howto_get_server_date_time_Form1";
            this.Text = "howto_get_server_date_time";
            this.Load += new System.EventHandler(this.howto_get_server_date_time_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Timer TimerAntiPing;
        internal System.Windows.Forms.TextBox txtMessageBox;
        internal System.Windows.Forms.Button btnGetServerDateAndTime;
    }
}

