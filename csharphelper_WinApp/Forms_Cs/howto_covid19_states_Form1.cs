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

// Data from https://covidtracking.com/api

 

using howto_covid19_states;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_covid19_states_Form1:Form
  {

        private void LoadPopulationData()
        {
            Dictionary<string, long> population_dict =
                new Dictionary<string, long>();

            // Population data from https://en.wikipedia.org/wiki/List_of_states_and_territories_of_the_United_States_by_population.
            population_dict.Add("AK", 731545);
            population_dict.Add("AL", 4903185);
            population_dict.Add("AR", 3017825);
            population_dict.Add("AS", 55641);
            population_dict.Add("AZ", 7278717);
            population_dict.Add("CA", 39512223);
            population_dict.Add("CO", 5758736);
            population_dict.Add("CT", 3565287);
            population_dict.Add("DC", 705749);
            population_dict.Add("DE", 973764);
            population_dict.Add("FL", 21477737);
            population_dict.Add("GA", 10617423);
            population_dict.Add("GU", 165718);
            population_dict.Add("HI", 1415872);
            population_dict.Add("IA", 3155070);
            population_dict.Add("ID", 1787065);
            population_dict.Add("IL", 12671821);
            population_dict.Add("IN", 6732219);
            population_dict.Add("KS", 2913314);
            population_dict.Add("KY", 4467673);
            population_dict.Add("LA", 4648794);
            population_dict.Add("MA", 6949503);
            population_dict.Add("MD", 6045680);
            population_dict.Add("ME", 1344212);
            population_dict.Add("MI", 9986857);
            population_dict.Add("MN", 5639632);
            population_dict.Add("MO", 6137428);
            population_dict.Add("MP", 55194);
            population_dict.Add("MS", 2976149);
            population_dict.Add("MT", 1068778);
            population_dict.Add("NC", 10488084);
            population_dict.Add("ND", 762062);
            population_dict.Add("NE", 1934408);
            population_dict.Add("NH", 1359711);
            population_dict.Add("NJ", 8882190);
            population_dict.Add("NM", 2096829);
            population_dict.Add("NV", 3080156);
            population_dict.Add("NY", 19453561);
            population_dict.Add("OH", 11689100);
            population_dict.Add("OK", 3956971);
            population_dict.Add("OR", 4217737);
            population_dict.Add("PA", 12801989);
            population_dict.Add("PR", 3193694);
            population_dict.Add("RI", 1059361);
            population_dict.Add("SC", 5148714);
            population_dict.Add("SD", 884659);
            population_dict.Add("TN", 6833174);
            population_dict.Add("TX", 28995881);
            population_dict.Add("UT", 3205958);
            population_dict.Add("VA", 8535519);
            population_dict.Add("VI", 104914);
            population_dict.Add("VT", 623989);
            population_dict.Add("WA", 7614893);
            population_dict.Add("WI", 5822434);
            population_dict.Add("WV", 1792147);
            population_dict.Add("WY", 578759);

            // Get the state population.
            long all_pop = 0;
            foreach (int value in population_dict.Values)
            {
                all_pop += value;
            }
            population_dict.Add("ALL STATES", all_pop);

            // Add the population data to the state data.
            Console.WriteLine("No population data for these states:");
            foreach (StateData state in StateList)
            {
                if (population_dict.ContainsKey(state.Name))
                    state.Population = population_dict[state.Name];
                else
                    Console.WriteLine(state.Name);
            }
        }
        public howto_covid19_states_Form1()
        {
            InitializeComponent();
        }

        // The data.
        private int NumDates = 0;
        private List<StateData> StateList = null;
        private List<StateData> SelectedStates =
            new List<StateData>();

        private Dictionary<string, StateData> StateDict =
            new Dictionary<string, StateData>();

        private Matrix Transform = null;
        private Matrix InverseTransform = null;
        private RectangleF WorldBounds;
        private PointF ClosePoint = new PointF(-1, -1);
        private StateDataComparer Comparer =
            new StateDataComparer(StateDataComparer.CompareTypes.ByMaxCases);

        // Used to prevent redraws while checking or unchecking all countries.
        private bool IgnoreItemCheck = false;

        // Make an array of CheckBoxes for the All and None buttons.
        private CheckBox[] CheckBoxes;

        // Used to prevent redraws while checking or unchecking all data sets.
        private bool IgnoreCheckedChanged = false;

        private void howto_covid19_states_Form1_Load(object sender, EventArgs e)
        {
            // Allow TLS 1.1 and TLS 1.2 protocols for file download.
            ServicePointManager.SecurityProtocol =
                Protocols.protocol_Tls11 | Protocols.protocol_Tls12;

            // Initialize the CheckBoxes array.
            CheckBoxes = new CheckBox[]
            {
                chkTotalPositive,
                chkTotalNegative,
                chkPending,
                chkHospitalizedNow,
                chkHospitalizedTotal,
                chkIcuNow,
                chkIcuTotal,
                chkVentNow,
                chkVentTotal,
                chkRecovered,
                chkDeaths,
            };

            Show();

            // Load the data.
            lblLoading.Text = "Loading data...";
            lblLoading.Refresh();
            LoadData();

            // Make StateList.
            StateList = StateDict.Values.ToList();

            // Number the states.
            for (int i = 0; i < StateList.Count; i++)
            {
                StateList[i].StateNumber = i;
            }

            // Load the population data.
            LoadPopulationData();

            // Display the states in sorted order.
            SortStates();

            lblLoading.Text = "";
            lblLoading.Refresh();
        }

        // Load and prepare the data.
        private void LoadData()
        {
            // Compose the local data file name.
            string filename = "state_data" + DateTime.Now.ToString("yyyy_MM_dd") + ".csv";

            // Download today's data.
            const string url = "https://covidtracking.com/api/v1/states/daily.csv";
            DownloadFile(url, filename);

            // Read the file.
            object[,] fields = LoadCsv(filename);

            // Create the state data.
            CreateStateData(fields);
        }

        // Get or create a StateData object.
        private StateData GetOrCreateStateData(string state_name)
        {
            if (StateDict.ContainsKey(state_name))
                return StateDict[state_name];

            StateData state_data = new StateData();
            state_data.Name = state_name;
            state_data.Positive = new float[NumDates];
            state_data.Negative = new float[NumDates];
            state_data.Pending = new float[NumDates];
            state_data.HospitalizedNow = new float[NumDates];
            state_data.HospitalizedTotal = new float[NumDates];
            state_data.IcuNow = new float[NumDates];
            state_data.IcuTotal = new float[NumDates];
            state_data.VentNow = new float[NumDates];
            state_data.VentTotal = new float[NumDates];
            state_data.Recovered = new float[NumDates];
            state_data.Deaths = new float[NumDates];
            state_data.DeathsPerResolution = new float[NumDates];

            StateDict.Add(state_name, state_data);
            return state_data;
        }

        // Create the state data.
        private void CreateStateData(object[,] fields)
        {
            const int colDate = 1;
            const int colState = 2;
            const int colPositive = 3;
            const int colNegative = 4;
            const int colPending = 5;
            const int colHospitalizedNow = 6;
            const int colHospitalizedTotal = 7;
            const int colIcuNow = 8;
            const int colIcuTotal = 9;
            const int colVentNow = 10;
            const int colVentTotal = 11;
            const int colRecovered = 12;
            const int colDeaths = 17;

            // Get the first and last dates.
            int max_row = fields.GetUpperBound(0);
            DateTime last_date = ParseDate(fields[2, colDate].ToString());
            DateTime first_date = ParseDate(fields[max_row, colDate].ToString());
            TimeSpan time_span = last_date - first_date;
            NumDates = (int)time_span.TotalDays + 1;

            StateData.Dates = new DateTime[NumDates + 1];
            for (int day_num = 0; day_num <= NumDates; day_num++)
            {
                StateData.Dates[day_num] = first_date.AddDays(day_num);
            }

            // Create the state's StateData object.
            StateData all_data =
                GetOrCreateStateData("ALL STATES");

            // Load the state data.
            for (int row = 2; row < max_row; row++)
            {
                // Get the state's name.
                string state_name = fields[row, colState].ToString();

                // Get or create the state's StateData object.
                StateData state_data =
                    GetOrCreateStateData(state_name);

                // Find the date number.
                DateTime cur_date = ParseDate(fields[row, colDate].ToString());
                int date_num = (int)(cur_date - first_date).TotalDays;

                state_data.Positive[date_num] = ParseValue(fields[row, colPositive]);
                state_data.Negative[date_num] = ParseValue(fields[row, colNegative]);
                state_data.Pending[date_num] = ParseValue(fields[row, colPending]);
                state_data.HospitalizedNow[date_num] = ParseValue(fields[row, colHospitalizedNow]);
                state_data.HospitalizedTotal[date_num] = ParseValue(fields[row, colHospitalizedTotal]);
                state_data.IcuNow[date_num] = ParseValue(fields[row, colIcuNow]);
                state_data.IcuTotal[date_num] = ParseValue(fields[row, colIcuTotal]);
                state_data.VentNow[date_num] = ParseValue(fields[row, colVentNow]);
                state_data.VentTotal[date_num] = ParseValue(fields[row, colVentTotal]);
                state_data.Recovered[date_num] = ParseValue(fields[row, colRecovered]);
                state_data.Deaths[date_num] = ParseValue(fields[row, colDeaths]);

                if ((state_data.Deaths[date_num] == 0) ||
                    (state_data.Recovered[date_num] == 0))
                {
                    state_data.DeathsPerResolution[date_num] = 0;
                }
                else
                {
                    state_data.DeathsPerResolution[date_num] =
                        state_data.Deaths[date_num] / (
                            state_data.Deaths[date_num] + state_data.Recovered[date_num]);
                }

                // Add to the national totals.
                all_data.Positive[date_num] += state_data.Positive[date_num];
                all_data.Positive[date_num] += state_data.Positive[date_num];
                all_data.Negative[date_num] += state_data.Negative[date_num];
                all_data.Pending[date_num] += state_data.Pending[date_num];
                all_data.HospitalizedNow[date_num] += state_data.HospitalizedNow[date_num];
                all_data.HospitalizedTotal[date_num] += state_data.HospitalizedTotal[date_num];
                all_data.IcuNow[date_num] += state_data.IcuNow[date_num];
                all_data.IcuTotal[date_num] += state_data.IcuTotal[date_num];
                all_data.VentNow[date_num] += state_data.VentNow[date_num];
                all_data.VentTotal[date_num] += state_data.VentTotal[date_num];
                all_data.Recovered[date_num] += state_data.Recovered[date_num];
                all_data.Deaths[date_num] += state_data.Deaths[date_num];
            }

            for (int date_num = 0;
                date_num < all_data.DeathsPerResolution.Length;
                date_num++)
            {
                if ((all_data.Deaths[date_num] == 0) ||
                    (all_data.Recovered[date_num] == 0))
                {
                    all_data.DeathsPerResolution[date_num] = 0;
                }
                else
                {
                    all_data.DeathsPerResolution[date_num] =
                        all_data.Deaths[date_num] / (
                            all_data.Deaths[date_num] + all_data.Recovered[date_num]);
                }
            }

            // Set maximum values.
            foreach (StateData state_data in StateDict.Values)
                state_data.SetMaxDataValues();
        }

        // Parse a dater with format 20200517.
        private DateTime ParseDate(string date_text)
        {
            int year = int.Parse(date_text.Substring(0, 4));
            int month = int.Parse(date_text.Substring(4, 2));
            int day = int.Parse(date_text.Substring(6));
            return new DateTime(year, month, day);
        }

        // Return a value from the CSV file.
        private int ParseValue(object value)
        {
            if (value == null) return 0;
 
            int result;
            if (int.TryParse(value.ToString(), out result)) return result;
            return 0;
        }

        // Download today's data.
        private void DownloadFile(string url, string filename)
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
            StateData checked_state =
                clbStates.Items[e.Index] as StateData;
            SelectedStates = GetStateList(checked_state, e.NewValue);

            // Graph the results.
            GraphStates();

            // Redisplay the tooltip if appropriate.
            SetTooltip(ClosePoint);
        }

        // Get the list of checked items,
        // adding or removing a checked item.
        private List<StateData> GetStateList(
            StateData checked_state, CheckState checked_status)
        {
            // Get the current list of checked items.
            List<StateData> state_list;
            if (clbStates.CheckedItems.Count == 0)
            {
                // Create a new list.
                state_list = new List<StateData>();
            }
            else
            {
                // Convert the selected objects into StateData objects.
                state_list =
                    clbStates.CheckedItems.Cast<StateData>().ToList();
            }

            if (checked_state != null)
            {
                // See if the clicked state is being checked or unchecked.
                if (checked_status == CheckState.Checked)
                {
                    // Add the item to the list.
                    state_list.Add(checked_state);
                }
                else
                {
                    // Remove the item from the list.
                    state_list.Remove(checked_state);
                }
            }

            return state_list;
        }

        // Draw the graph.
        private void GraphStates()
        {
            ClosePoint = new PointF(-1, -1);

            // Do nothing if no states are selected or
            // if no datasets are selected.
            if ((SelectedStates.Count == 0) ||
                (!SelectedDataSets.DataSetsAreSelected))
            {
                picGraph.Image = null;
                return;
            }

            // Get the maximum value.
            foreach (StateData state in SelectedStates)
                state.SetMaxDataValue();
            float y_max = SelectedStates.Max(state => state.MaxDataValue);
            if (y_max < 1) y_max = 1;

            // Create a transformation to make the data fit the PictureBox.
            DefineTransform(SelectedStates, y_max);

            // Get the number of cases where we should align countries.
            int align_cases = 0;
            int.TryParse(txtAlignCases.Text, out align_cases);

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
                    Color.Orange,
                };
                int num_colors = colors.Length;
                using (Pen pen = new Pen(Color.Black, 0))
                {
                    foreach (StateData state in SelectedStates)
                    {
                        pen.Color = colors[state.StateNumber % num_colors];
                        state.Draw(align_cases, gr, pen, Transform, state.Name);
                    }
                }
            }

            // Display the result.
            picGraph.Image = bm;
        }

        private void DefineTransform(List<StateData> state_list, float y_max)
        {
            WorldBounds = new RectangleF(0, 0, NumDates, y_max);
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
                float y_step = (float)Math.Pow(10, power);
                //if (y_step < 1) y_step = 1;

                // Draw the Y axis.
                gr.DrawLine(pen, 0, 0, 0, y_max);

                pen.Color = Color.Silver;
                float num_cases = WorldBounds.Right;
                for (float y = y_step; y < y_max; y += y_step)
                {
                    gr.DrawLine(pen, 0, y, num_cases, y);
                }

                GraphicsState state = gr.Save();
                gr.ResetTransform();
                using (Font font = new Font("Arial", 12, FontStyle.Regular))
                {
                    for (float y = y_step; y < y_max; y += y_step)
                    {
                        PointF[] p = { new PointF(0, y) };
                        Transform.TransformPoints(p);

                        if (y < 1)
                            gr.DrawString(y.ToString("n"), font, Brushes.Black, p[0]);
                        else
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
            for (int i = 0; i < clbStates.Items.Count; i++)
                clbStates.SetItemChecked(i, true);
            IgnoreItemCheck = false;
            RedrawGraph();
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            IgnoreItemCheck = true;
            for (int i = 0; i < clbStates.Items.Count; i++)
                clbStates.SetItemChecked(i, false);
            IgnoreItemCheck = false;
            RedrawGraph();
        }

        private void RedrawGraph()
        {
            if (IgnoreCheckedChanged) return;

            // Get the current list of checked items.
            SelectedStates = GetStateList(null, CheckState.Indeterminate);

            // Get the checked data items.
            SelectedDataSets.SetSelectedDataSets(this);

            // Graph the results.
            GraphStates();

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
            if (SelectedStates == null) return;

            string new_tip = "";
            int day_num;
            string descr;

            foreach (StateData state in SelectedStates)
            {
                if (state.PointIsAt(point, out day_num,
                    out descr, out ClosePoint))
                {
                    new_tip = state.Name + "\n" +
                        StateData.Dates[day_num].ToShortDateString() + "\n" +
                        descr;
                    if (chkPerMillion.Checked)
                        new_tip += " per million";
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

        // Redraw the graph aligned on the left.
        private void txtAlignCases_TextChanged(object sender, EventArgs e)
        {
            GraphStates();
        }

        // A sorting radio button has been clicked. Update the display.
        private void radSort_Click(object sender, EventArgs e)
        {
            SortStates();
        }

        // Sort the countries by the selected data.
        private void SortStates()
        {
            if (StateList == null) return;

            // Make the appropriate comparer.
            if (radSortByName.Checked)
                Comparer = new StateDataComparer(StateDataComparer.CompareTypes.ByName);
            else if (radSortByMaxCases.Checked)
                Comparer = new StateDataComparer(StateDataComparer.CompareTypes.ByMaxCases);

            // Redisplay the state list in the new order.
            clbStates.DataSource = null;
            StateList.Sort(Comparer);
            clbStates.DataSource = StateList;

            // Check the currently selected countries.
            foreach (StateData state in SelectedStates)
            {
                int index = clbStates.Items.IndexOf(state);
                if (index >= 0) clbStates.SetItemChecked(index, true);
            }
        }

        private void chkDataSet_CheckedChanged(object sender, EventArgs e)
        {
            RedrawGraph();
        }

        private void btnAllDataSets_Click(object sender, EventArgs e)
        {
            IgnoreCheckedChanged = true;
            foreach (CheckBox chk in CheckBoxes)
                chk.Checked = true;
            IgnoreCheckedChanged = false;
            RedrawGraph();
        }

        private void btnNoDataSets_Click(object sender, EventArgs e)
        {
            IgnoreCheckedChanged = true;
            foreach (CheckBox chk in CheckBoxes)
                chk.Checked = false;
            IgnoreCheckedChanged = false;
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
            this.clbStates = new System.Windows.Forms.CheckedListBox();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.tipGraph = new System.Windows.Forms.ToolTip(this.components);
            this.radSortByName = new System.Windows.Forms.RadioButton();
            this.radSortByMaxCases = new System.Windows.Forms.RadioButton();
            this.txtAlignCases = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNoDataSets = new System.Windows.Forms.Button();
            this.btnAllDataSets = new System.Windows.Forms.Button();
            this.chkDeathsPerResolution = new System.Windows.Forms.CheckBox();
            this.chkDeaths = new System.Windows.Forms.CheckBox();
            this.chkRecovered = new System.Windows.Forms.CheckBox();
            this.chkVentTotal = new System.Windows.Forms.CheckBox();
            this.chkVentNow = new System.Windows.Forms.CheckBox();
            this.chkIcuTotal = new System.Windows.Forms.CheckBox();
            this.chkIcuNow = new System.Windows.Forms.CheckBox();
            this.chkHospitalizedTotal = new System.Windows.Forms.CheckBox();
            this.chkPerMillion = new System.Windows.Forms.CheckBox();
            this.chkHospitalizedNow = new System.Windows.Forms.CheckBox();
            this.chkPending = new System.Windows.Forms.CheckBox();
            this.chkTotalNegative = new System.Windows.Forms.CheckBox();
            this.chkTotalPositive = new System.Windows.Forms.CheckBox();
            this.lblLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.BackColor = System.Drawing.SystemColors.Control;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picGraph.Location = new System.Drawing.Point(355, 65);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(458, 364);
            this.picGraph.TabIndex = 3;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // clbStates
            // 
            this.clbStates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.clbStates.CheckOnClick = true;
            this.clbStates.FormattingEnabled = true;
            this.clbStates.IntegralHeight = false;
            this.clbStates.Location = new System.Drawing.Point(266, 65);
            this.clbStates.Name = "clbStates";
            this.clbStates.Size = new System.Drawing.Size(83, 306);
            this.clbStates.TabIndex = 4;
            this.clbStates.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCountries_ItemCheck);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(266, 377);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(83, 23);
            this.btnAll.TabIndex = 5;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNone
            // 
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNone.Location = new System.Drawing.Point(266, 406);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(83, 23);
            this.btnNone.TabIndex = 6;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // radSortByName
            // 
            this.radSortByName.AutoSize = true;
            this.radSortByName.Location = new System.Drawing.Point(20, 19);
            this.radSortByName.Name = "radSortByName";
            this.radSortByName.Size = new System.Drawing.Size(53, 17);
            this.radSortByName.TabIndex = 8;
            this.radSortByName.TabStop = true;
            this.radSortByName.Text = "Name";
            this.radSortByName.UseVisualStyleBackColor = true;
            this.radSortByName.Click += new System.EventHandler(this.radSort_Click);
            // 
            // radSortByMaxCases
            // 
            this.radSortByMaxCases.AutoSize = true;
            this.radSortByMaxCases.Checked = true;
            this.radSortByMaxCases.Location = new System.Drawing.Point(79, 19);
            this.radSortByMaxCases.Name = "radSortByMaxCases";
            this.radSortByMaxCases.Size = new System.Drawing.Size(77, 17);
            this.radSortByMaxCases.TabIndex = 9;
            this.radSortByMaxCases.TabStop = true;
            this.radSortByMaxCases.Text = "Max Cases";
            this.radSortByMaxCases.UseVisualStyleBackColor = true;
            this.radSortByMaxCases.Click += new System.EventHandler(this.radSort_Click);
            // 
            // txtAlignCases
            // 
            this.txtAlignCases.Location = new System.Drawing.Point(20, 18);
            this.txtAlignCases.Name = "txtAlignCases";
            this.txtAlignCases.Size = new System.Drawing.Size(53, 20);
            this.txtAlignCases.TabIndex = 11;
            this.txtAlignCases.Text = "0";
            this.txtAlignCases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAlignCases.TextChanged += new System.EventHandler(this.txtAlignCases_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "cases";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radSortByName);
            this.groupBox1.Controls.Add(this.radSortByMaxCases);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 47);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort By";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAlignCases);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(184, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 47);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Align At";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNoDataSets);
            this.groupBox3.Controls.Add(this.btnAllDataSets);
            this.groupBox3.Controls.Add(this.chkDeathsPerResolution);
            this.groupBox3.Controls.Add(this.chkDeaths);
            this.groupBox3.Controls.Add(this.chkRecovered);
            this.groupBox3.Controls.Add(this.chkVentTotal);
            this.groupBox3.Controls.Add(this.chkVentNow);
            this.groupBox3.Controls.Add(this.chkIcuTotal);
            this.groupBox3.Controls.Add(this.chkIcuNow);
            this.groupBox3.Controls.Add(this.chkHospitalizedTotal);
            this.groupBox3.Controls.Add(this.chkPerMillion);
            this.groupBox3.Controls.Add(this.chkHospitalizedNow);
            this.groupBox3.Controls.Add(this.chkPending);
            this.groupBox3.Controls.Add(this.chkTotalNegative);
            this.groupBox3.Controls.Add(this.chkTotalPositive);
            this.groupBox3.Location = new System.Drawing.Point(13, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 365);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display";
            // 
            // btnNoDataSets
            // 
            this.btnNoDataSets.Location = new System.Drawing.Point(166, 90);
            this.btnNoDataSets.Name = "btnNoDataSets";
            this.btnNoDataSets.Size = new System.Drawing.Size(75, 23);
            this.btnNoDataSets.TabIndex = 16;
            this.btnNoDataSets.Text = "None";
            this.btnNoDataSets.UseVisualStyleBackColor = true;
            this.btnNoDataSets.Click += new System.EventHandler(this.btnNoDataSets_Click);
            // 
            // btnAllDataSets
            // 
            this.btnAllDataSets.Location = new System.Drawing.Point(166, 61);
            this.btnAllDataSets.Name = "btnAllDataSets";
            this.btnAllDataSets.Size = new System.Drawing.Size(75, 23);
            this.btnAllDataSets.TabIndex = 16;
            this.btnAllDataSets.Text = "All";
            this.btnAllDataSets.UseVisualStyleBackColor = true;
            this.btnAllDataSets.Click += new System.EventHandler(this.btnAllDataSets_Click);
            // 
            // chkDeathsPerResolution
            // 
            this.chkDeathsPerResolution.AutoSize = true;
            this.chkDeathsPerResolution.Location = new System.Drawing.Point(19, 341);
            this.chkDeathsPerResolution.Name = "chkDeathsPerResolution";
            this.chkDeathsPerResolution.Size = new System.Drawing.Size(132, 17);
            this.chkDeathsPerResolution.TabIndex = 21;
            this.chkDeathsPerResolution.Text = "Deaths Per Resolution";
            this.chkDeathsPerResolution.UseVisualStyleBackColor = true;
            this.chkDeathsPerResolution.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkDeaths
            // 
            this.chkDeaths.AutoSize = true;
            this.chkDeaths.Location = new System.Drawing.Point(20, 295);
            this.chkDeaths.Name = "chkDeaths";
            this.chkDeaths.Size = new System.Drawing.Size(60, 17);
            this.chkDeaths.TabIndex = 18;
            this.chkDeaths.Text = "Deaths";
            this.chkDeaths.UseVisualStyleBackColor = true;
            this.chkDeaths.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkRecovered
            // 
            this.chkRecovered.AutoSize = true;
            this.chkRecovered.Location = new System.Drawing.Point(20, 272);
            this.chkRecovered.Name = "chkRecovered";
            this.chkRecovered.Size = new System.Drawing.Size(79, 17);
            this.chkRecovered.TabIndex = 17;
            this.chkRecovered.Text = "Recovered";
            this.chkRecovered.UseVisualStyleBackColor = true;
            this.chkRecovered.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkVentTotal
            // 
            this.chkVentTotal.AutoSize = true;
            this.chkVentTotal.Location = new System.Drawing.Point(20, 249);
            this.chkVentTotal.Name = "chkVentTotal";
            this.chkVentTotal.Size = new System.Drawing.Size(75, 17);
            this.chkVentTotal.TabIndex = 16;
            this.chkVentTotal.Text = "Vent Total";
            this.chkVentTotal.UseVisualStyleBackColor = true;
            this.chkVentTotal.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkVentNow
            // 
            this.chkVentNow.AutoSize = true;
            this.chkVentNow.Location = new System.Drawing.Point(20, 226);
            this.chkVentNow.Name = "chkVentNow";
            this.chkVentNow.Size = new System.Drawing.Size(73, 17);
            this.chkVentNow.TabIndex = 15;
            this.chkVentNow.Text = "Vent Now";
            this.chkVentNow.UseVisualStyleBackColor = true;
            this.chkVentNow.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkIcuTotal
            // 
            this.chkIcuTotal.AutoSize = true;
            this.chkIcuTotal.Location = new System.Drawing.Point(20, 203);
            this.chkIcuTotal.Name = "chkIcuTotal";
            this.chkIcuTotal.Size = new System.Drawing.Size(71, 17);
            this.chkIcuTotal.TabIndex = 14;
            this.chkIcuTotal.Text = "ICU Total";
            this.chkIcuTotal.UseVisualStyleBackColor = true;
            this.chkIcuTotal.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkIcuNow
            // 
            this.chkIcuNow.AutoSize = true;
            this.chkIcuNow.Location = new System.Drawing.Point(20, 180);
            this.chkIcuNow.Name = "chkIcuNow";
            this.chkIcuNow.Size = new System.Drawing.Size(69, 17);
            this.chkIcuNow.TabIndex = 13;
            this.chkIcuNow.Text = "ICU Now";
            this.chkIcuNow.UseVisualStyleBackColor = true;
            this.chkIcuNow.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkHospitalizedTotal
            // 
            this.chkHospitalizedTotal.AutoSize = true;
            this.chkHospitalizedTotal.Location = new System.Drawing.Point(20, 157);
            this.chkHospitalizedTotal.Name = "chkHospitalizedTotal";
            this.chkHospitalizedTotal.Size = new System.Drawing.Size(110, 17);
            this.chkHospitalizedTotal.TabIndex = 12;
            this.chkHospitalizedTotal.Text = "Hospitalized Total";
            this.chkHospitalizedTotal.UseVisualStyleBackColor = true;
            this.chkHospitalizedTotal.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkPerMillion
            // 
            this.chkPerMillion.AutoSize = true;
            this.chkPerMillion.Location = new System.Drawing.Point(20, 19);
            this.chkPerMillion.Name = "chkPerMillion";
            this.chkPerMillion.Size = new System.Drawing.Size(74, 17);
            this.chkPerMillion.TabIndex = 11;
            this.chkPerMillion.Text = "Per Million";
            this.chkPerMillion.UseVisualStyleBackColor = true;
            this.chkPerMillion.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkHospitalizedNow
            // 
            this.chkHospitalizedNow.AutoSize = true;
            this.chkHospitalizedNow.Location = new System.Drawing.Point(20, 134);
            this.chkHospitalizedNow.Name = "chkHospitalizedNow";
            this.chkHospitalizedNow.Size = new System.Drawing.Size(108, 17);
            this.chkHospitalizedNow.TabIndex = 10;
            this.chkHospitalizedNow.Text = "Hospitalized Now";
            this.chkHospitalizedNow.UseVisualStyleBackColor = true;
            this.chkHospitalizedNow.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkPending
            // 
            this.chkPending.AutoSize = true;
            this.chkPending.Location = new System.Drawing.Point(20, 111);
            this.chkPending.Name = "chkPending";
            this.chkPending.Size = new System.Drawing.Size(65, 17);
            this.chkPending.TabIndex = 9;
            this.chkPending.Text = "Pending";
            this.chkPending.UseVisualStyleBackColor = true;
            this.chkPending.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkTotalNegative
            // 
            this.chkTotalNegative.AutoSize = true;
            this.chkTotalNegative.Location = new System.Drawing.Point(20, 88);
            this.chkTotalNegative.Name = "chkTotalNegative";
            this.chkTotalNegative.Size = new System.Drawing.Size(96, 17);
            this.chkTotalNegative.TabIndex = 8;
            this.chkTotalNegative.Text = "Total Negative";
            this.chkTotalNegative.UseVisualStyleBackColor = true;
            this.chkTotalNegative.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // chkTotalPositive
            // 
            this.chkTotalPositive.AutoSize = true;
            this.chkTotalPositive.Location = new System.Drawing.Point(20, 65);
            this.chkTotalPositive.Name = "chkTotalPositive";
            this.chkTotalPositive.Size = new System.Drawing.Size(90, 17);
            this.chkTotalPositive.TabIndex = 7;
            this.chkTotalPositive.Text = "Total Positive";
            this.chkTotalPositive.UseVisualStyleBackColor = true;
            this.chkTotalPositive.CheckedChanged += new System.EventHandler(this.chkDataSet_CheckedChanged);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.Color.Red;
            this.lblLoading.Location = new System.Drawing.Point(324, 28);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(70, 20);
            this.lblLoading.TabIndex = 15;
            this.lblLoading.Text = "Loading:";
            // 
            // howto_covid19_states_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 441);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.clbStates);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_covid19_states_Form1";
            this.Text = "howto_covid19_states";
            this.Load += new System.EventHandler(this.howto_covid19_states_Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.CheckedListBox clbStates;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.ToolTip tipGraph;
        private System.Windows.Forms.RadioButton radSortByName;
        private System.Windows.Forms.RadioButton radSortByMaxCases;
        private System.Windows.Forms.TextBox txtAlignCases;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblLoading;
        public System.Windows.Forms.CheckBox chkDeathsPerResolution;
        public System.Windows.Forms.CheckBox chkDeaths;
        public System.Windows.Forms.CheckBox chkRecovered;
        public System.Windows.Forms.CheckBox chkVentTotal;
        public System.Windows.Forms.CheckBox chkVentNow;
        public System.Windows.Forms.CheckBox chkIcuTotal;
        public System.Windows.Forms.CheckBox chkIcuNow;
        public System.Windows.Forms.CheckBox chkHospitalizedTotal;
        public System.Windows.Forms.CheckBox chkPerMillion;
        public System.Windows.Forms.CheckBox chkHospitalizedNow;
        public System.Windows.Forms.CheckBox chkPending;
        public System.Windows.Forms.CheckBox chkTotalNegative;
        public System.Windows.Forms.CheckBox chkTotalPositive;
        private System.Windows.Forms.Button btnNoDataSets;
        private System.Windows.Forms.Button btnAllDataSets;
    }
}

