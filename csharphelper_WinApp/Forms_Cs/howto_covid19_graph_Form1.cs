using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Excel = Microsoft.Office.Interop.Excel;

// Data from https://data.humdata.org/dataset/novel-coronavirus-2019-ncov-cases

 

using howto_covid19_graph;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_covid19_graph_Form1:Form
  { 


        public howto_covid19_graph_Form1()
        {
            InitializeComponent();
        }

        // The data.
        private List<CountryData> CountryList = null;
        private List<CountryData> SelectedCountries = null;

        private Matrix Transform = null;
        private Matrix InverseTransform = null;
        private RectangleF WorldBounds;
        private PointF ClosePoint = new PointF(-1, -1);
        private CountryDataComparer Comparer =
            new CountryDataComparer(CountryDataComparer.CompareTypes.ByMaxCases);

        // Used to prevent redraws while checking or unchecking all countries.
        private bool IgnoreItemCheck = false;

        private void howto_covid19_graph_Form1_Load(object sender, EventArgs e)
        {
            // Load the data.
            LoadData();

            // Display the countries in the checked list box.
            clbCountries.DataSource = CountryList;
            clbCountries.CheckOnClick = true;
        }

        // Load and prepare the data.
        private void LoadData()
        {
            // Compose the local data file name.
            string filename = "data" + DateTime.Now.ToString("yyyy_MM_dd") + ".csv";

            // Download today's data.
            DownloadFile(filename);

            // Read the file.
            object[,] fields = LoadCsv(filename);

            // Create the country data.
            CreateCountryData(fields);
        }

        // Create the country data.
        private void CreateCountryData(object[,] fields)
        {
            // Load the dates.
            Dictionary<string, CountryData> country_dict =
                new Dictionary<string, CountryData>();
            const int first_date_col = 5;
            int max_row = fields.GetUpperBound(0);
            int max_col = fields.GetUpperBound(1);
            int num_dates = max_col - first_date_col + 1;
            CountryData.Dates = new DateTime[num_dates];
            for (int col = 1; col <= num_dates; col++)
            {
                // Convert the date into a double and then into a date.
                double double_value = (double)fields[1, col + first_date_col - 1];
                CountryData.Dates[col - 1] =
                    DateTime.FromOADate(double_value);
            }

            // Load the country data.
            const int country_col = 2;
            for (int country_num = 2; country_num <= max_row; country_num++)
            {
                // Get the country's name.
                string country_name = fields[country_num, country_col].ToString();

                // Get or create the country's CountryData object.
                CountryData country_data;
                if (country_dict.ContainsKey(country_name))
                {
                    country_data = country_dict[country_name];
                }
                else
                {
                    country_data = new CountryData();
                    country_data.Name = country_name;
                    country_data.Cases = new int[num_dates];
                    country_dict.Add(country_name, country_data);
                }

                // Add to the country's data.
                for (int col = 1; col <= num_dates; col++)
                {
                    // Add the value to the country's total.
                    country_data.Cases[col - 1] +=
                        (int)(double)fields[country_num, col + first_date_col - 1];
                }
            }

            // Convert CountryDict into CountryList.
            CountryList = country_dict.Values.ToList();

            // Set MaxCases values.
            foreach (CountryData country in CountryList)
            {
                country.SetMax();
            }

            // Sort.
            CountryList.Sort(Comparer);

            // Number the countries and set MaxCases values.
            for (int i = 0; i < CountryList.Count; i++)
            {
                CountryList[i].CountryNumber = i;
            }
        }

        // Download today's data.
        private void DownloadFile(string filename)
        {
            // See if we have today's file.
            if (!File.Exists(filename))
            {
                // Download the file.
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                try
                {
                    // Make a WebClient.
                    WebClient web_client = new WebClient();

                    // Download the file.
                    const string url = "https://data.humdata.org/hxlproxy/api/data-preview.csv?url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_confirmed_global.csv&filename=time_series_covid19_confirmed_global.csv";
                    web_client.DownloadFile(url, filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Download Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        // Load a CSV file into a 1-based array.
        private object[,] LoadCsv(string filename)
        {
            // Get the Excel application object.
            Excel.Application excel_app = new Excel.ApplicationClass();

            // Make Excel visible (optional).
            //excel_app.Visible = true;

            // Open the workbook read-only.
            filename = Application.StartupPath + "\\" + filename;
            Excel.Workbook workbook = excel_app.Workbooks.Open(
                filename,
                Type.Missing, true, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);

            // Get the first worksheet.
            Excel.Worksheet sheet = (Excel.Worksheet)workbook.Sheets[1];

            // Get the used range.
            Excel.Range used_range = sheet.UsedRange;
    
            // Get the sheet's values.
            object[,] values = (object[,])used_range.Value2;

            // Close the workbook without saving changes.
            workbook.Close(false, Type.Missing, Type.Missing);

            // Close the Excel server.
            excel_app.Quit();

            return values;
        }

        // An item has been checked or unchecked.
        private void clbCountries_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Do nothing if the user clicked All or None.
            if (IgnoreItemCheck) return;

            // Get the current list of checked items.
            CountryData checked_country =
                clbCountries.Items[e.Index] as CountryData;
            SelectedCountries = GetCountryList(checked_country, e.NewValue);

            // Graph the results.
            GraphCountries();

            // Redisplay the tooltip if appropriate.
            SetTooltip(ClosePoint);
        }

        // Get the list of checked items,
        // adding or removing a checked item.
        private List<CountryData> GetCountryList(
            CountryData checked_country, CheckState checked_state)
        {
            // Get the current list of checked items.
            List<CountryData> country_list;
            if (clbCountries.CheckedItems.Count == 0)
            {
                // Create a new list.
                country_list = new List<CountryData>();
            }
            else
            {
                // Convert the selected objects into CountryData objects.
                country_list =
                    clbCountries.CheckedItems.Cast<CountryData>().ToList();
            }

            if (checked_country != null)
            {
                // See if the clicked country is being checked or unchecked.
                if (checked_state == CheckState.Checked)
                {
                    // Add the item to the list.
                    country_list.Add(checked_country);
                }
                else
                {
                    // Remove the item from the list.
                    country_list.Remove(checked_country);
                }
            }

            return country_list;
        }

        // Draw the graph.
        private void GraphCountries()
        {
            ClosePoint = new PointF(-1, -1);
            if (SelectedCountries.Count == 0)
            {
                picGraph.Image = null;
                return;
            }

            // Get the maximum value.
            float y_max = SelectedCountries.Max(country => country.Cases.Max());
            if (y_max < 10) y_max = 10;

            // Create a transformation to make the data fit the PictureBox.
            DefineTransform(SelectedCountries, y_max);

            // Create a bitmap.
            Bitmap bm = new Bitmap(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.TextRenderingHint = TextRenderingHint.AntiAlias;
                gr.Transform = Transform;

                // Draw the axes.
                DrawAxes(gr);

                // Draw the curves.
                Color[] colors =
                {
                    Color.Red, Color.Green, Color.Blue, Color.Black,
                    Color.Cyan, Color.Orange,
                };
                int num_colors = colors.Length;
                using (Pen pen = new Pen(Color.Black, 0))
                {
                    foreach (CountryData country in SelectedCountries)
                    {
                        pen.Color = colors[country.CountryNumber % num_colors];
                        country.Draw(gr, pen, Transform);
                    }
                }
            }

            // Display the result.
            picGraph.Image = bm;
        }

        private void DefineTransform(List<CountryData> country_list, float y_max)
        {
            int num_cases = country_list[0].Cases.Length;
            WorldBounds = new RectangleF(0, 0, num_cases, y_max);
            int wid = picGraph.ClientSize.Width;
            int hgt = picGraph.ClientSize.Height - 1;
            const int margin = 4;
            PointF[] dest_points =
            {
                new PointF(margin, hgt - margin),
                new PointF(wid - margin, hgt - margin),
                new PointF(margin, margin),
            };
            Transform = new Matrix(WorldBounds, dest_points);
            InverseTransform = Transform.Clone();
            InverseTransform.Invert();
        }

        private void DrawAxes(Graphics gr)
        {
            using (Pen pen = new Pen(Color.Red, 0))
            {
                // Calculate the Y step value.
                // Find the largest power of 10 less than y_max.
                float y_max = WorldBounds.Bottom;
                int power = (int)Math.Log10(y_max);
                // If this is more than 1/2 of y_max, use the next smaller power.
                if (Math.Pow(10, power) > y_max / 2) power--;
                int y_step = (int)Math.Pow(10, power);
                if (y_step < 1) y_step = 1;

                // Draw the Y axis.
                gr.DrawLine(pen, 0, 0, 0, y_max);

                pen.Color = Color.Silver;
                float num_cases = WorldBounds.Right;
                for (int y = y_step; y < y_max; y += y_step)
                {
                    gr.DrawLine(pen, 0, y, num_cases, y);
                }

                GraphicsState state = gr.Save();
                gr.ResetTransform();
                using (Font font = new Font("Arial", 12, FontStyle.Regular))
                {
                    for (int y = y_step; y < y_max; y += y_step)
                    {
                        Point[] p = { new Point(0, y) };
                        Transform.TransformPoints(p);

                        gr.DrawString(y.ToString("n0"), font, Brushes.Black, p[0]);
                    }
                }
                gr.Restore(state);

                // Draw the X axis.
                pen.Color = Color.Red;
                gr.DrawLine(pen, 0, 0, num_cases, 0);

                // Calculate the tick mark size.
                const int tick_y_pixels = 5;
                PointF[] tick_points = { new PointF(0, tick_y_pixels) };
                InverseTransform.TransformVectors(tick_points);
                float tick_y = -tick_points[0].Y;

                // Draw tick marks.
                for (int i = 0; i < num_cases; i++)
                {
                    gr.DrawLine(pen, i, -tick_y, i, tick_y);
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            IgnoreItemCheck = true;
            for (int i = 0; i < clbCountries.Items.Count; i++)
                clbCountries.SetItemChecked(i, true);
            IgnoreItemCheck = false;
            RedrawGraph();
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            IgnoreItemCheck = true;
            for (int i = 0; i < clbCountries.Items.Count; i++)
                clbCountries.SetItemChecked(i, false);
            IgnoreItemCheck = false;
            RedrawGraph();
        }

        private void RedrawGraph()
        {
            // Get the current list of checked items.
            SelectedCountries = GetCountryList(null, CheckState.Indeterminate);

            // Graph the results.
            GraphCountries();

            // Redisplay the tooltip if appropriate.
            SetTooltip(ClosePoint);
        }

        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            SetTooltip(e.Location);
        }

        private void SetTooltip(PointF point)
        {
            if (picGraph.Image == null) return;
            if (SelectedCountries == null) return;

            string new_tip = "";
            int day_num;
            int num_cases;
            foreach (CountryData country in SelectedCountries)
            {
                if (country.PointIsAt(point, out day_num,
                    out num_cases, out ClosePoint))
                {
                    new_tip = country.Name + "\n" +
                        CountryData.Dates[day_num].ToShortDateString() + "\n" +
                        num_cases.ToString("n0") + " cases";
                    break;
                }
            }

            if (tipGraph.GetToolTip(picGraph) != new_tip)
                tipGraph.SetToolTip(picGraph, new_tip);
            picGraph.Refresh();
        }

        private void picGraph_Paint(object sender, PaintEventArgs e)
        {
            if (ClosePoint.X < 0) return;

            const int radius = 3;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float x = ClosePoint.X - radius;
            float y = ClosePoint.Y - radius;
            e.Graphics.FillEllipse(Brushes.White, x, y, 2 * radius, 2 * radius);
            e.Graphics.DrawEllipse(Pens.Red, x, y, 2 * radius, 2 * radius);
        }

        private void radSortByName_Click(object sender, EventArgs e)
        {
            if (CountryList == null) return;
            Comparer = new CountryDataComparer(CountryDataComparer.CompareTypes.ByName);
            clbCountries.DataSource = null;
            CountryList.Sort(Comparer);
            clbCountries.DataSource = CountryList;
            RedrawGraph();
        }

        private void radSortByMaxCases_Click(object sender, EventArgs e)
        {
            if (CountryList == null) return;
            Comparer = new CountryDataComparer(CountryDataComparer.CompareTypes.ByMaxCases);
            clbCountries.DataSource = null;
            CountryList.Sort(Comparer);
            clbCountries.DataSource = CountryList;
            RedrawGraph();
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
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.clbCountries = new System.Windows.Forms.CheckedListBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.tipGraph = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.radSortByName = new System.Windows.Forms.RadioButton();
            this.radSortByMaxCases = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.SystemColors.Control;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(184, 35);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(365, 347);
            this.picGraph.TabIndex = 3;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // clbCountries
            // 
            this.clbCountries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.clbCountries.FormattingEnabled = true;
            this.clbCountries.IntegralHeight = false;
            this.clbCountries.Location = new System.Drawing.Point(12, 35);
            this.clbCountries.Name = "clbCountries";
            this.clbCountries.Size = new System.Drawing.Size(166, 318);
            this.clbCountries.TabIndex = 4;
            this.clbCountries.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCountries_ItemCheck);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(12, 359);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 5;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNone
            // 
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNone.Location = new System.Drawing.Point(103, 359);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(75, 23);
            this.btnNone.TabIndex = 6;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sort By:";
            // 
            // radSortByName
            // 
            this.radSortByName.AutoSize = true;
            this.radSortByName.Location = new System.Drawing.Point(62, 12);
            this.radSortByName.Name = "radSortByName";
            this.radSortByName.Size = new System.Drawing.Size(53, 17);
            this.radSortByName.TabIndex = 8;
            this.radSortByName.TabStop = true;
            this.radSortByName.Text = "Name";
            this.radSortByName.UseVisualStyleBackColor = true;
            this.radSortByName.Click += new System.EventHandler(this.radSortByName_Click);
            // 
            // radSortByMaxCases
            // 
            this.radSortByMaxCases.AutoSize = true;
            this.radSortByMaxCases.Checked = true;
            this.radSortByMaxCases.Location = new System.Drawing.Point(121, 12);
            this.radSortByMaxCases.Name = "radSortByMaxCases";
            this.radSortByMaxCases.Size = new System.Drawing.Size(77, 17);
            this.radSortByMaxCases.TabIndex = 9;
            this.radSortByMaxCases.TabStop = true;
            this.radSortByMaxCases.Text = "Max Cases";
            this.radSortByMaxCases.UseVisualStyleBackColor = true;
            this.radSortByMaxCases.Click += new System.EventHandler(this.radSortByMaxCases_Click);
            // 
            // howto_covid19_graph_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 394);
            this.Controls.Add(this.radSortByMaxCases);
            this.Controls.Add(this.radSortByName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.clbCountries);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_covid19_graph_Form1";
            this.Text = "howto_covid19_graph";
            this.Load += new System.EventHandler(this.howto_covid19_graph_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.CheckedListBox clbCountries;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.ToolTip tipGraph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radSortByName;
        private System.Windows.Forms.RadioButton radSortByMaxCases;
    }
}

