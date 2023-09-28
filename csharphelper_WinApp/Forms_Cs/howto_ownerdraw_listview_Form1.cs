using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_ownerdraw_listview;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_ownerdraw_listview_Form1:Form
  { 


        public howto_ownerdraw_listview_Form1()
        {
            InitializeComponent();
        }

        // Make some data.
        private void howto_ownerdraw_listview_Form1_Load(object sender, EventArgs e)
        {
            ListView[] listViews = new ListView[] { lvwList, lvwSmallIcon, lvwLargeIcon, lvwTile, lvwDetails };
            foreach (ListView lvw in listViews)
            {
                AddItem(lvw, "Butterfly", Properties.Resources.Butterfly, Color.Green);
                AddItem(lvw, "Guppy", Properties.Resources.Fish, Color.Red);
                AddItem(lvw, "Peggy", Properties.Resources.Peggy, Color.Yellow);
            }
        }

        // Make a server status item.
        private void AddItem(ListView lvw, string server, Image logo, Color status)
        {
            // Make the item.
            ListViewItem item = new ListViewItem(server);

            // Save the ServeStatus item in the Tag property.
            ServerStatus server_status = new ServerStatus(server, logo, status);
            item.Tag = server_status;
            item.SubItems[0].Name = "Server";

            // Add subitems so they can draw.
            item.SubItems.Add("Logo");
            item.SubItems.Add("Status");

            // Add the item to the ListView.
            lvw.Items.Add(item);
        }

        // Just draw the column's text.
        private void lvwServers_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;

                string text = lvwList.Columns[e.ColumnIndex].Text;
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Graphics.DrawString(text, lvwList.Font, Brushes.Black, e.Bounds);
                        break;
                    case 1:
                        e.Graphics.DrawString(text, lvwList.Font, Brushes.Blue, e.Bounds);
                        break;
                    case 2:
                        e.Graphics.DrawString(text, lvwList.Font, Brushes.Green, e.Bounds);
                        break;
                }
            }
        }

        // Draw the item. In this case, the server's logo.
        private void lvwServers_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // Draw Details view items in the DrawSubItem event handler.
            ListView lvw = e.Item.ListView;
            if (lvw.View == View.Details) return;

            // Get the ListView item and the ServerStatus object.
            ListViewItem item = e.Item;
            ServerStatus server_status = item.Tag as ServerStatus;

            // Clear.
            e.DrawBackground();

            // Draw a status indicator.
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(
                e.Bounds.Left + 1, e.Bounds.Top + 1,
                e.Bounds.Height - 2, e.Bounds.Height - 2);
            using (SolidBrush br = new SolidBrush(server_status.StatusColor))
            {
                e.Graphics.FillEllipse(br, rect);
            }
            e.Graphics.DrawEllipse(Pens.Black, rect);
            int left = rect.Right + 2;

            // See how much we must scale it.
            float scale;
            scale = e.Bounds.Height / (float)server_status.Logo.Height;

            // Scale and position the image.
            e.Graphics.ScaleTransform(scale, scale);
            e.Graphics.TranslateTransform(
                left,
                e.Bounds.Top + (e.Bounds.Height - server_status.Logo.Height * scale) / 2,
                System.Drawing.Drawing2D.MatrixOrder.Append);

            // Draw the image.
            e.Graphics.DrawImage(server_status.Logo, 0, 0);

            // Draw the focus rectangle if appropriate.
            e.Graphics.ResetTransform();
            e.DrawFocusRectangle();
        }

        // Draw subitems for Detail view.
        private void lvwServers_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Get the ListView item and the ServerStatus object.
            ListViewItem item = e.Item;
            ServerStatus server_status = item.Tag as ServerStatus;

            // Draw.
            switch (e.ColumnIndex)
            {
                case 0:
                    // Draw the server's name.
                    e.Graphics.DrawString(server_status.ServerName,
                        lvwList.Font, Brushes.Black, e.Bounds);
                    break;
                case 1:
                    // Draw the server's logo.
                    float scale = e.Bounds.Height / (float)server_status.Logo.Height;
                    e.Graphics.ScaleTransform(scale, scale);
                    e.Graphics.TranslateTransform(
                        e.Bounds.Left,
                        e.Bounds.Top + (e.Bounds.Height - server_status.Logo.Height * scale) / 2,
                        System.Drawing.Drawing2D.MatrixOrder.Append);
                    e.Graphics.DrawImage(server_status.Logo, 0, 0);
                    break;
                case 2:
                    // Draw the server's status.
                    Rectangle rect = new Rectangle(
                        e.Bounds.Left + 1, e.Bounds.Top + 1,
                        e.Bounds.Width - 2, e.Bounds.Height - 2);
                    using (SolidBrush br = new SolidBrush(server_status.StatusColor))
                    {
                        e.Graphics.FillRectangle(br, rect);
                    }
                    Color pen_color = Color.FromArgb(255,
                        255 - server_status.StatusColor.R,
                        255 - server_status.StatusColor.G,
                        255 - server_status.StatusColor.B);
                    using (SolidBrush br = new SolidBrush(pen_color))
                    {
                        using (StringFormat string_format = new StringFormat())
                        {
                            string_format.Alignment = StringAlignment.Center;
                            string_format.LineAlignment = StringAlignment.Center;
                            using (Font font = new Font(lvwList.Font, FontStyle.Bold))
                            {
                                e.Graphics.DrawString(server_status.StatusColor.Name,
                                    font, br, e.Bounds, string_format);
                            }
                        }
                    }
                    break;
            }

            // Draw the focus rectangle if appropriate.
            e.Graphics.ResetTransform();
            ListView lvw = e.Item.ListView;
            if (lvw.FullRowSelect)
            {
                e.DrawFocusRectangle(e.Item.Bounds);
            }
            else if (e.SubItem.Name == "Server")
            {
                e.DrawFocusRectangle(e.Bounds);
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvwDetails = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwTile = new System.Windows.Forms.ListView();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.lvwSmallIcon = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.lvwList = new System.Windows.Forms.ListView();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.lvwLargeIcon = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(215, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "Details";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 22);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tile";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwDetails
            // 
            this.lvwDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvwDetails.FullRowSelect = true;
            this.lvwDetails.Location = new System.Drawing.Point(215, 34);
            this.lvwDetails.Name = "lvwDetails";
            this.lvwDetails.OwnerDraw = true;
            this.lvwDetails.Size = new System.Drawing.Size(197, 109);
            this.lvwDetails.TabIndex = 18;
            this.lvwDetails.UseCompatibleStateImageBehavior = false;
            this.lvwDetails.View = System.Windows.Forms.View.Details;
            this.lvwDetails.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwServers_DrawColumnHeader);
            this.lvwDetails.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvwServers_DrawItem);
            this.lvwDetails.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvwServers_DrawSubItem);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Server";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Logo";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Status";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(215, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 22);
            this.label2.TabIndex = 23;
            this.label2.Text = "Small Icon";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(115, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Large Icon";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwTile
            // 
            this.lvwTile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lvwTile.Location = new System.Drawing.Point(12, 34);
            this.lvwTile.Name = "lvwTile";
            this.lvwTile.OwnerDraw = true;
            this.lvwTile.Size = new System.Drawing.Size(197, 109);
            this.lvwTile.TabIndex = 17;
            this.lvwTile.UseCompatibleStateImageBehavior = false;
            this.lvwTile.View = System.Windows.Forms.View.Tile;
            this.lvwTile.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwServers_DrawColumnHeader);
            this.lvwTile.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvwServers_DrawItem);
            this.lvwTile.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvwServers_DrawSubItem);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Server";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Logo";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Status";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Status";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Logo";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Logo";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Server";
            // 
            // lvwSmallIcon
            // 
            this.lvwSmallIcon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvwSmallIcon.Location = new System.Drawing.Point(215, 184);
            this.lvwSmallIcon.Name = "lvwSmallIcon";
            this.lvwSmallIcon.OwnerDraw = true;
            this.lvwSmallIcon.Size = new System.Drawing.Size(197, 56);
            this.lvwSmallIcon.TabIndex = 20;
            this.lvwSmallIcon.UseCompatibleStateImageBehavior = false;
            this.lvwSmallIcon.View = System.Windows.Forms.View.SmallIcon;
            this.lvwSmallIcon.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwServers_DrawColumnHeader);
            this.lvwSmallIcon.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvwServers_DrawItem);
            this.lvwSmallIcon.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvwServers_DrawSubItem);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Server";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Logo";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Status";
            // 
            // lvwList
            // 
            this.lvwList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwList.Location = new System.Drawing.Point(12, 184);
            this.lvwList.Name = "lvwList";
            this.lvwList.OwnerDraw = true;
            this.lvwList.Size = new System.Drawing.Size(197, 56);
            this.lvwList.TabIndex = 19;
            this.lvwList.UseCompatibleStateImageBehavior = false;
            this.lvwList.View = System.Windows.Forms.View.List;
            this.lvwList.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwServers_DrawColumnHeader);
            this.lvwList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvwServers_DrawItem);
            this.lvwList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvwServers_DrawSubItem);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Server";
            // 
            // lvwLargeIcon
            // 
            this.lvwLargeIcon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.lvwLargeIcon.Location = new System.Drawing.Point(115, 285);
            this.lvwLargeIcon.Name = "lvwLargeIcon";
            this.lvwLargeIcon.OwnerDraw = true;
            this.lvwLargeIcon.Size = new System.Drawing.Size(197, 42);
            this.lvwLargeIcon.TabIndex = 21;
            this.lvwLargeIcon.UseCompatibleStateImageBehavior = false;
            this.lvwLargeIcon.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwServers_DrawColumnHeader);
            this.lvwLargeIcon.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvwServers_DrawItem);
            this.lvwLargeIcon.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvwServers_DrawSubItem);
            // 
            // howto_ownerdraw_listview_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 337);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lvwDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwTile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwSmallIcon);
            this.Controls.Add(this.lvwList);
            this.Controls.Add(this.lvwLargeIcon);
            this.Name = "howto_ownerdraw_listview_Form1";
            this.Text = "howto_ownerdraw_listview";
            this.Load += new System.EventHandler(this.howto_ownerdraw_listview_Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvwDetails;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvwTile;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvwSmallIcon;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lvwList;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ListView lvwLargeIcon;
    }
}

