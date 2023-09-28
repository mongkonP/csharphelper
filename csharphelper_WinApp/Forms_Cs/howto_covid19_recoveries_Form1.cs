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
// Case data:       https://data.humdata.org/hxlproxy/api/data-preview.csv?url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_confirmed_global.csv&filename=time_series_covid19_confirmed_global.csv
// Death data:      https://data.humdata.org/hxlproxy/api/data-preview.csv?url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_deaths_global.csv&filename=time_series_covid19_deaths_global.csv
// Recovery data:   https://data.humdata.org/hxlproxy/api/data-preview.csv?url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_recovered_global.csv&filename=time_series_covid19_recovered_global.csv

 

using howto_covid19_recoveries;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_covid19_recoveries_Form1:Form
  {

        private void LoadPopulationData()
        {
            Dictionary<string, int> population_dict =
                new Dictionary<string, int>();

            // Population data from https://www.worldometers.info/world-population/population-by-country/.
            population_dict.Add("China", 1439323776);
            population_dict.Add("India", 1380004385);
            population_dict.Add("US", 331002651);    // United States
            population_dict.Add("Indonesia", 273523615);
            population_dict.Add("Pakistan", 220892340);
            population_dict.Add("Brazil", 212559417);
            population_dict.Add("Nigeria", 206139589);
            population_dict.Add("Bangladesh", 164689383);
            population_dict.Add("Russia", 145934462);
            population_dict.Add("Mexico", 128932753);
            population_dict.Add("Japan", 126476461);
            population_dict.Add("Ethiopia", 114963588);
            population_dict.Add("Philippines", 109581078);
            population_dict.Add("Egypt", 102334404);
            population_dict.Add("Vietnam", 97338579);
            population_dict.Add("DR Congo", 89561403);
            population_dict.Add("Turkey", 84339067);
            population_dict.Add("Iran", 83992949);
            population_dict.Add("Germany", 83783942);
            population_dict.Add("Thailand", 69799978);
            population_dict.Add("United Kingdom", 67886011);
            population_dict.Add("France", 65273511);
            population_dict.Add("Italy", 60461826);
            population_dict.Add("Tanzania", 59734218);
            population_dict.Add("South Africa", 59308690);
            population_dict.Add("Burma", 54409800);  // Myanmar
            population_dict.Add("Kenya", 53771296);
            population_dict.Add("Korea, South", 51269185);   // South Korea
            population_dict.Add("Colombia", 50882891);
            population_dict.Add("Spain", 46754778);
            population_dict.Add("Uganda", 45741007);
            population_dict.Add("Argentina", 45195774);
            population_dict.Add("Algeria", 43851044);
            population_dict.Add("Sudan", 43849260);
            population_dict.Add("Ukraine", 43733762);
            population_dict.Add("Iraq", 40222493);
            population_dict.Add("Afghanistan", 38928346);
            population_dict.Add("Poland", 37846611);
            population_dict.Add("Canada", 37742154);
            population_dict.Add("Morocco", 36910560);
            population_dict.Add("Saudi Arabia", 34813871);
            population_dict.Add("Uzbekistan", 33469203);
            population_dict.Add("Peru", 32971854);
            population_dict.Add("Angola", 32866272);
            population_dict.Add("Malaysia", 32365999);
            population_dict.Add("Mozambique", 31255435);
            population_dict.Add("Ghana", 31072940);
            population_dict.Add("Yemen", 29825964);
            population_dict.Add("Nepal", 29136808);
            population_dict.Add("Venezuela", 28435940);
            population_dict.Add("Madagascar", 27691018);
            population_dict.Add("Cameroon", 26545863);
            population_dict.Add("Cote d'Ivoire", 26378274);  // Côte d'Ivoire
            population_dict.Add("North Korea", 25778816);
            population_dict.Add("Australia", 25499884);
            population_dict.Add("Niger", 24206644);
            population_dict.Add("Taiwan*", 23816775);    // Taiwan
            population_dict.Add("Sri Lanka", 21413249);
            population_dict.Add("Burkina Faso", 20903273);
            population_dict.Add("Mali", 20250833);
            population_dict.Add("Romania", 19237691);
            population_dict.Add("Malawi", 19129952);
            population_dict.Add("Chile", 19116201);
            population_dict.Add("Kazakhstan", 18776707);
            population_dict.Add("Zambia", 18383955);
            population_dict.Add("Guatemala", 17915568);
            population_dict.Add("Ecuador", 17643054);
            population_dict.Add("Syria", 17500658);
            population_dict.Add("Netherlands", 17134872);
            population_dict.Add("Senegal", 16743927);
            population_dict.Add("Cambodia", 16718965);
            population_dict.Add("Chad", 16425864);
            population_dict.Add("Somalia", 15893222);
            population_dict.Add("Zimbabwe", 14862924);
            population_dict.Add("Guinea", 13132795);
            population_dict.Add("Rwanda", 12952218);
            population_dict.Add("Benin", 12123200);
            population_dict.Add("Burundi", 11890784);
            population_dict.Add("Tunisia", 11818619);
            population_dict.Add("Bolivia", 11673021);
            population_dict.Add("Belgium", 11589623);
            population_dict.Add("Haiti", 11402528);
            population_dict.Add("Cuba", 11326616);
            population_dict.Add("South Sudan", 11193725);
            population_dict.Add("Dominican Republic", 10847910);
            population_dict.Add("Czechia", 10708981);    // Czech Republic (Czechia)
            population_dict.Add("Greece", 10423054);
            population_dict.Add("Jordan", 10203134);
            population_dict.Add("Portugal", 10196709);
            population_dict.Add("Azerbaijan", 10139177);
            population_dict.Add("Sweden", 10099265);
            population_dict.Add("Honduras", 9904607);
            population_dict.Add("United Arab Emirates", 9890402);
            population_dict.Add("Hungary", 9660351);
            population_dict.Add("Tajikistan", 9537645);
            population_dict.Add("Belarus", 9449323);
            population_dict.Add("Austria", 9006398);
            population_dict.Add("Papua New Guinea", 8947024);
            population_dict.Add("Serbia", 8737371);
            population_dict.Add("Israel", 8655535);
            population_dict.Add("Switzerland", 8654622);
            population_dict.Add("Togo", 8278724);
            population_dict.Add("Sierra Leone", 7976983);
            population_dict.Add("Hong Kong", 7496981);
            population_dict.Add("Laos", 7275560);
            population_dict.Add("Paraguay", 7132538);
            population_dict.Add("Bulgaria", 6948445);
            population_dict.Add("Libya", 6871292);
            population_dict.Add("Lebanon", 6825445);
            population_dict.Add("Nicaragua", 6624554);
            population_dict.Add("Kyrgyzstan", 6524195);
            population_dict.Add("El Salvador", 6486205);
            population_dict.Add("Turkmenistan", 6031200);
            population_dict.Add("Singapore", 5850342);
            population_dict.Add("Denmark", 5792202);
            population_dict.Add("Finland", 5540720);
            population_dict.Add("Congo", 5518087);
            population_dict.Add("Slovakia", 5459642);
            population_dict.Add("Norway", 5421241);
            population_dict.Add("Oman", 5106626);
            population_dict.Add("West Bank and Gaza", 5101414);  // State of Palestine
            population_dict.Add("Costa Rica", 5094118);
            population_dict.Add("Liberia", 5057681);
            population_dict.Add("Ireland", 4937786);
            population_dict.Add("Central African Republic", 4829767);
            population_dict.Add("New Zealand", 4822233);
            population_dict.Add("Mauritania", 4649658);
            population_dict.Add("Panama", 4314767);
            population_dict.Add("Kuwait", 4270571);
            population_dict.Add("Croatia", 4105267);
            population_dict.Add("Moldova", 4033963);
            population_dict.Add("Georgia", 3989167);
            population_dict.Add("Eritrea", 3546421);
            population_dict.Add("Uruguay", 3473730);
            population_dict.Add("Bosnia and Herzegovina", 3280819);
            population_dict.Add("Mongolia", 3278290);
            population_dict.Add("Armenia", 2963243);
            population_dict.Add("Jamaica", 2961167);
            population_dict.Add("Qatar", 2881053);
            population_dict.Add("Albania", 2877797);
            population_dict.Add("Puerto Rico", 2860853);
            population_dict.Add("Lithuania", 2722289);
            population_dict.Add("Namibia", 2540905);
            population_dict.Add("Gambia", 2416668);
            population_dict.Add("Botswana", 2351627);
            population_dict.Add("Gabon", 2225734);
            population_dict.Add("Lesotho", 2142249);
            population_dict.Add("North Macedonia", 2083374);
            population_dict.Add("Slovenia", 2078938);
            population_dict.Add("Guinea-Bissau", 1968001);
            population_dict.Add("Latvia", 1886198);
            population_dict.Add("Bahrain", 1701575);
            population_dict.Add("Equatorial Guinea", 1402985);
            population_dict.Add("Trinidad and Tobago", 1399488);
            population_dict.Add("Estonia", 1326535);
            population_dict.Add("Timor-Leste", 1318445);
            population_dict.Add("Mauritius", 1271768);
            population_dict.Add("Cyprus", 1207359);
            population_dict.Add("Eswatini", 1160164);
            population_dict.Add("Djibouti", 988000);
            population_dict.Add("Fiji", 896445);
            population_dict.Add("Réunion", 895312);
            population_dict.Add("Comoros", 869601);
            population_dict.Add("Guyana", 786552);
            population_dict.Add("Bhutan", 771608);
            population_dict.Add("Solomon Islands", 686884);
            population_dict.Add("Macao", 649335);
            population_dict.Add("Montenegro", 628066);
            population_dict.Add("Luxembourg", 625978);
            population_dict.Add("Western Sahara", 597339);
            population_dict.Add("Suriname", 586632);
            population_dict.Add("Cabo Verde", 555987);
            population_dict.Add("Maldives", 540544);
            population_dict.Add("Malta", 441543);
            population_dict.Add("Brunei", 437479);
            population_dict.Add("Guadeloupe", 400124);
            population_dict.Add("Belize", 397628);
            population_dict.Add("Bahamas", 393244);
            population_dict.Add("Martinique", 375265);
            population_dict.Add("Iceland", 341243);
            population_dict.Add("Vanuatu", 307145);
            population_dict.Add("French Guiana", 298682);
            population_dict.Add("Barbados", 287375);
            population_dict.Add("New Caledonia", 285498);
            population_dict.Add("French Polynesia", 280908);
            population_dict.Add("Mayotte", 272815);
            population_dict.Add("Sao Tome & Principe", 219159);
            population_dict.Add("Samoa", 198414);
            population_dict.Add("Saint Lucia", 183627);
            population_dict.Add("Channel Islands", 173863);
            population_dict.Add("Guam", 168775);
            population_dict.Add("Curaçao", 164093);
            population_dict.Add("Kiribati", 119449);
            population_dict.Add("Micronesia", 115023);
            population_dict.Add("Grenada", 112523);
            population_dict.Add("Saint Vincent and the Grenadines", 110940); // St. Vincent & Grenadines
            population_dict.Add("Aruba", 106766);
            population_dict.Add("Tonga", 105695);
            population_dict.Add("U.S. Virgin Islands", 104425);
            population_dict.Add("Seychelles", 98347);
            population_dict.Add("Antigua and Barbuda", 97929);
            population_dict.Add("Isle of Man", 85033);
            population_dict.Add("Andorra", 77265);
            population_dict.Add("Dominica", 71986);
            population_dict.Add("Cayman Islands", 65722);
            population_dict.Add("Bermuda", 62278);
            population_dict.Add("Marshall Islands", 59190);
            population_dict.Add("Northern Mariana Islands", 57559);
            population_dict.Add("Greenland", 56770);
            population_dict.Add("American Samoa", 55191);
            population_dict.Add("Saint Kitts and Nevis", 53199); // Saint Kitts & Nevis
            population_dict.Add("Faeroe Islands", 48863);
            population_dict.Add("Sint Maarten", 42876);
            population_dict.Add("Monaco", 39242);
            population_dict.Add("Turks and Caicos", 38717);
            population_dict.Add("Saint Martin", 38666);
            population_dict.Add("Liechtenstein", 38128);
            population_dict.Add("San Marino", 33931);
            population_dict.Add("Gibraltar", 33691);
            population_dict.Add("British Virgin Islands", 30231);
            population_dict.Add("Caribbean Netherlands", 26223);
            population_dict.Add("Palau", 18094);
            population_dict.Add("Cook Islands", 17564);
            population_dict.Add("Anguilla", 15003);
            population_dict.Add("Tuvalu", 11792);
            population_dict.Add("Wallis & Futuna", 11239);
            population_dict.Add("Nauru", 10824);
            population_dict.Add("Saint Barthelemy", 9877);
            population_dict.Add("Saint Helena", 6077);
            population_dict.Add("Saint Pierre & Miquelon", 5794);
            population_dict.Add("Montserrat", 4992);
            population_dict.Add("Falkland Islands", 3480);
            population_dict.Add("Niue", 1626);
            population_dict.Add("Tokelau", 1357);
            population_dict.Add("Holy See", 801);

            // Add the population data to the country data.
            Console.WriteLine("No population data for these countries:");
            foreach (CountryData country in CountryList)
            {
                if (population_dict.ContainsKey(country.Name))
                    country.Population = population_dict[country.Name];
                else
                    Console.WriteLine(country.Name);
            }

            // Calculate cases per million.
            // You could do this only when needed.
            // I'm using extra memory so we don't need
            // to do it later.
            foreach (CountryData country in CountryList)
            {
                country.CalculateCasesPerMillion();
                country.CalculateDeathsPerMillion();
                country.CalculateRecoveriesPerMillion();
                country.CalculateDeathsPerResolution();
            }
        }
        public howto_covid19_recoveries_Form1()
        {
            InitializeComponent();
        }

        // The data.
        private List<CountryData> CountryList = null;
        private List<CountryData> SelectedCountries =
            new List<CountryData>();

        private Dictionary<string, CountryData> CountryDict =
            new Dictionary<string, CountryData>();

        private Matrix Transform = null;
        private Matrix InverseTransform = null;
        private RectangleF WorldBounds;
        private PointF ClosePoint = new PointF(-1, -1);
        private CountryDataComparer Comparer =
            new CountryDataComparer(CountryDataComparer.CompareTypes.ByMaxCases);

        // Used to prevent redraws while checking or unchecking all countries.
        private bool IgnoreItemCheck = false;

        private void howto_covid19_recoveries_Form1_Load(object sender, EventArgs e)
        {
            Show();

            // Load the case data.
            lblLoading.Text = "Loading case data...";
            lblLoading.Refresh();
            LoadCaseData();

            // Load the deaths data.
            lblLoading.Text = "Loading death data...";
            lblLoading.Refresh();
            LoadDeathData();

            // Load the recovery data.
            lblLoading.Text = "Loading recovery data...";
            lblLoading.Refresh();
            LoadRecoveryData();

            // Make CountryList.
            CountryList = CountryDict.Values.ToList();

            // Number the countries.
            for (int i = 0; i < CountryList.Count; i++)
            {
                CountryList[i].CountryNumber = i;
            }

            // Load the population data.
            LoadPopulationData();

            // Initially display number of cases.
            SetSelectedData();

            // Display the countries in sorted order.
            SortCountries();

            lblLoading.Text = "";
            lblLoading.Refresh();
        }

        // Load and prepare the case data.
        private void LoadCaseData()
        {
            // Compose the local data file name.
            string filename = "cases" + DateTime.Now.ToString("yyyy_MM_dd") + ".csv";

            // Download today's data.
            const string url = "https://data.humdata.org/hxlproxy/api/data-preview.csv?url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_confirmed_global.csv&filename=time_series_covid19_confirmed_global.csv";
            DownloadFile(url, filename);

            // Read the file.
            object[,] fields = LoadCsv(filename);

            // Create the country data.
            CreateCountryCaseData(fields);
        }

        // Get or create a CountryData object.
        private CountryData GetOrCreateCountryData(
            string country_name, int num_dates)
        {
            if (CountryDict.ContainsKey(country_name))
                return CountryDict[country_name];

            CountryData country_data = new CountryData();
            country_data.Name = country_name;
            country_data.Cases = new float[num_dates];
            country_data.CasesPerMillion = new float[num_dates];
            country_data.Deaths = new float[num_dates];
            country_data.DeathsPerMillion = new float[num_dates];
            country_data.Recoveries = new float[num_dates];
            country_data.RecoveriesPerMillion = new float[num_dates];
            country_data.DeathsPerResolution = new float[num_dates];

            CountryDict.Add(country_name, country_data);
            return country_data;
        }

        // Create the country data.
        private void CreateCountryCaseData(object[,] fields)
        {
            // Load the dates.
            const int first_date_col = 5;
            int max_row = fields.GetUpperBound(0);
            int max_col = fields.GetUpperBound(1);
            int num_dates = max_col - first_date_col + 1;
            CountryData.Dates = new DateTime[num_dates];
            for (int col = 1; col <= num_dates; col++)
            {
                // BUG: Problem sometimes loading in UK.
                // Possibly a newer version of Excel library is
                // loading the dates as dates instead of doubles.
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
                CountryData country_data =
                    GetOrCreateCountryData(country_name, num_dates);

                // Add to the country's data.
                for (int col = 1; col <= num_dates; col++)
                {
                    // Add the value to the country's total.
                    country_data.Cases[col - 1] +=
                        (int)(double)fields[country_num, col + first_date_col - 1];
                }
            }
        }

        // Load and prepare the death data.
        private void LoadDeathData()
        {
            // Compose the local data file name.
            string filename = "deaths" + DateTime.Now.ToString("yyyy_MM_dd") + ".csv";

            // Download today's data.
            const string url = "https://data.humdata.org/hxlproxy/api/data-preview.csv?url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_deaths_global.csv&filename=time_series_covid19_deaths_global.csv";
            DownloadFile(url, filename);

            // Read the file.
            object[,] fields = LoadCsv(filename);

            // Create the country data.
            CreateCountryDeathData(fields);
        }

        // Create the country data.
        private void CreateCountryDeathData(object[,] fields)
        {
            const int first_date_col = 5;
            int max_row = fields.GetUpperBound(0);
            int max_col = fields.GetUpperBound(1);
            int num_dates = max_col - first_date_col + 1;

            // Load the death data.
            const int country_col = 2;
            for (int country_num = 2; country_num <= max_row; country_num++)
            {
                // Get the country's name.
                string country_name = fields[country_num, country_col].ToString();

                // Get or create the country's CountryData object.
                CountryData country_data =
                    GetOrCreateCountryData(country_name, num_dates);

                // Add to the country's data.
                for (int col = 1; col <= num_dates; col++)
                {
                    // Add the value to the country's total.
                    country_data.Deaths[col - 1] +=
                        (int)(double)fields[country_num, col + first_date_col - 1];
                }
            }
        }

        // Load and prepare the recovery data.
        private void LoadRecoveryData()
        {
            // Compose the local data file name.
            string filename = "recoveries" + DateTime.Now.ToString("yyyy_MM_dd") + ".csv";

            // Download today's data.
            const string url = "https://data.humdata.org/hxlproxy/api/data-preview.csv?url=https%3A%2F%2Fraw.githubusercontent.com%2FCSSEGISandData%2FCOVID-19%2Fmaster%2Fcsse_covid_19_data%2Fcsse_covid_19_time_series%2Ftime_series_covid19_recovered_global.csv&filename=time_series_covid19_recovered_global.csv";
            DownloadFile(url, filename);

            // Read the file.
            object[,] fields = LoadCsv(filename);

            // Create the country data.
            CreateCountryRecoveryData(fields);
        }

        // Create the country data.
        private void CreateCountryRecoveryData(object[,] fields)
        {
            const int first_date_col = 5;
            int max_row = fields.GetUpperBound(0);
            int max_col = fields.GetUpperBound(1);
            int num_dates = max_col - first_date_col + 1;

            // Load the Recovery data.
            const int country_col = 2;
            for (int country_num = 2; country_num <= max_row; country_num++)
            {
                // Get the country's name.
                string country_name = fields[country_num, country_col].ToString();

                // Get or create the country's CountryData object.
                CountryData country_data =
                    GetOrCreateCountryData(country_name, num_dates);

                // Add to the country's data.
                for (int col = 1; col <= num_dates; col++)
                {
                    // Add the value to the country's total.
                    country_data.Recoveries[col - 1] +=
                        (int)(double)fields[country_num, col + first_date_col - 1];
                }
            }
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

            // Do nothing if no countries are selected.
            if (SelectedCountries.Count == 0)
            {
                picGraph.Image = null;
                return;
            }

            // Get the maximum value.
            float y_max = SelectedCountries.Max(country => country.MaxDataValue);
            if (y_max < 1) y_max = 1;

            // Create a transformation to make the data fit the PictureBox.
            DefineTransform(SelectedCountries, y_max);

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
                    foreach (CountryData country in SelectedCountries)
                    {
                        pen.Color = colors[country.CountryNumber % num_colors];
                        country.Draw(align_cases, gr, pen, Transform);
                    }
                }
            }

            // Display the result.
            picGraph.Image = bm;
        }

        private void DefineTransform(List<CountryData> country_list, float y_max)
        {
            int num_cases = country_list[0].SelectedData.Length;
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
            float data_value;
            foreach (CountryData country in SelectedCountries)
            {
                if (country.PointIsAt(point, out day_num,
                    out data_value, out ClosePoint))
                {
                    new_tip = country.Name + "\n" +
                        CountryData.Dates[day_num].ToShortDateString() + "\n";

                    if (radCases.Checked)
                        new_tip += data_value.ToString("n0") + " cases";
                    else if (radCasesPerMillion.Checked)
                        new_tip += data_value.ToString("n2") + " cases per million";
                    else if (radDeaths.Checked)
                        new_tip += data_value.ToString("n0") + " deaths";
                    else if (radDeathsPerMillion.Checked)
                        new_tip += data_value.ToString("n2") + " deaths per million";
                    else if (radRecoveries.Checked)
                        new_tip += data_value.ToString("n0") + " recoveries";
                    else if (radRecoveriesPerMillion.Checked)
                        new_tip += data_value.ToString("n2") + " recoveries per million";
                    else if (radDeathsPerResolution.Checked)
                        new_tip += data_value.ToString("n2") + " deaths per resolution";

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
            GraphCountries();
        }

        // A sorting radio button has been clicked. Update the display.
        private void radSort_Click(object sender, EventArgs e)
        {
            SortCountries();
        }

        // Sort the countries by the selected data.
        private void SortCountries()
        {
            if (CountryList == null) return;

            // Make the appropriate comparer.
            if (radSortByName.Checked)
                Comparer = new CountryDataComparer(CountryDataComparer.CompareTypes.ByName);
            else if (radSortByMaxCases.Checked)
                Comparer = new CountryDataComparer(CountryDataComparer.CompareTypes.ByMaxCases);

            // Redisplay the country list in the new order.
            clbCountries.DataSource = null;
            CountryList.Sort(Comparer);
            clbCountries.DataSource = CountryList;

            // Check the currently selected countries.
            foreach (CountryData country in SelectedCountries)
            {
                int index = clbCountries.Items.IndexOf(country);
                if (index >= 0) clbCountries.SetItemChecked(index, true);
            }
        }

        // Copy the selected data into SelectedData.
        private void SetSelectedData()
        {
            // Select the appropriate data for each country.
            CountryData.DataSets data_set = CountryData.DataSets.Cases;
            if (radCasesPerMillion.Checked) data_set =
                CountryData.DataSets.CasesPerMillion;
            else if (radDeaths.Checked) data_set =
                CountryData.DataSets.Deaths;
            else if (radDeathsPerMillion.Checked) data_set =
                CountryData.DataSets.DeathsPerMillion;
            else if (radRecoveries.Checked) data_set =
                CountryData.DataSets.Recoveries;
            else if (radRecoveriesPerMillion.Checked) data_set =
                CountryData.DataSets.RecoveriesPerMillion;
            else if (radDeathsPerResolution.Checked) data_set =
                CountryData.DataSets.DeathsPerResolution;

            foreach (CountryData country in CountryList)
            {
                country.SelectData(data_set);
            }

            // Set MaxCases values.
            foreach (CountryData country in CountryList)
            {
                country.SetMax();
            }

            // Sort by the selected data.
            CountryList.Sort(Comparer);

            // Redraw the graph.
            RedrawGraph();        
        }

        // A data set radio button has been clicked. Update the graph.
        private void radDataSet_Click(object sender, EventArgs e)
        {
            // Set the selected data.
            SetSelectedData();

            // Ignore checkbox changes.
            // Sorting the data changes the items' checked state.
            IgnoreItemCheck = true;

            // Resort the countries using the selected data.
            SortCountries();
            IgnoreItemCheck = false;

            // Redisplay the graph using the selected data.
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
            this.radSortByName = new System.Windows.Forms.RadioButton();
            this.radSortByMaxCases = new System.Windows.Forms.RadioButton();
            this.txtAlignCases = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radDeathsPerResolution = new System.Windows.Forms.RadioButton();
            this.radRecoveriesPerMillion = new System.Windows.Forms.RadioButton();
            this.radRecoveries = new System.Windows.Forms.RadioButton();
            this.radDeathsPerMillion = new System.Windows.Forms.RadioButton();
            this.radDeaths = new System.Windows.Forms.RadioButton();
            this.radCasesPerMillion = new System.Windows.Forms.RadioButton();
            this.radCases = new System.Windows.Forms.RadioButton();
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
            this.picGraph.Location = new System.Drawing.Point(184, 130);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(378, 269);
            this.picGraph.TabIndex = 3;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            // 
            // clbCountries
            // 
            this.clbCountries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.clbCountries.CheckOnClick = true;
            this.clbCountries.FormattingEnabled = true;
            this.clbCountries.IntegralHeight = false;
            this.clbCountries.Location = new System.Drawing.Point(12, 130);
            this.clbCountries.Name = "clbCountries";
            this.clbCountries.Size = new System.Drawing.Size(166, 240);
            this.clbCountries.TabIndex = 4;
            this.clbCountries.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCountries_ItemCheck);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(12, 376);
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
            this.btnNone.Location = new System.Drawing.Point(103, 376);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(75, 23);
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
            this.groupBox3.Controls.Add(this.radDeathsPerResolution);
            this.groupBox3.Controls.Add(this.radRecoveriesPerMillion);
            this.groupBox3.Controls.Add(this.radRecoveries);
            this.groupBox3.Controls.Add(this.radDeathsPerMillion);
            this.groupBox3.Controls.Add(this.radDeaths);
            this.groupBox3.Controls.Add(this.radCasesPerMillion);
            this.groupBox3.Controls.Add(this.radCases);
            this.groupBox3.Location = new System.Drawing.Point(315, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 112);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Display";
            // 
            // radDeathsPerResolution
            // 
            this.radDeathsPerResolution.AutoSize = true;
            this.radDeathsPerResolution.Location = new System.Drawing.Point(20, 88);
            this.radDeathsPerResolution.Name = "radDeathsPerResolution";
            this.radDeathsPerResolution.Size = new System.Drawing.Size(131, 17);
            this.radDeathsPerResolution.TabIndex = 6;
            this.radDeathsPerResolution.Text = "Deaths Per Resolution";
            this.radDeathsPerResolution.UseVisualStyleBackColor = true;
            this.radDeathsPerResolution.Click += new System.EventHandler(this.radDataSet_Click);
            // 
            // radRecoveriesPerMillion
            // 
            this.radRecoveriesPerMillion.AutoSize = true;
            this.radRecoveriesPerMillion.Location = new System.Drawing.Point(105, 65);
            this.radRecoveriesPerMillion.Name = "radRecoveriesPerMillion";
            this.radRecoveriesPerMillion.Size = new System.Drawing.Size(130, 17);
            this.radRecoveriesPerMillion.TabIndex = 5;
            this.radRecoveriesPerMillion.Text = "Recoveries Per Million";
            this.radRecoveriesPerMillion.UseVisualStyleBackColor = true;
            this.radRecoveriesPerMillion.Click += new System.EventHandler(this.radDataSet_Click);
            // 
            // radRecoveries
            // 
            this.radRecoveries.AutoSize = true;
            this.radRecoveries.Location = new System.Drawing.Point(20, 65);
            this.radRecoveries.Name = "radRecoveries";
            this.radRecoveries.Size = new System.Drawing.Size(79, 17);
            this.radRecoveries.TabIndex = 4;
            this.radRecoveries.Text = "Recoveries";
            this.radRecoveries.UseVisualStyleBackColor = true;
            this.radRecoveries.Click += new System.EventHandler(this.radDataSet_Click);
            // 
            // radDeathsPerMillion
            // 
            this.radDeathsPerMillion.AutoSize = true;
            this.radDeathsPerMillion.Location = new System.Drawing.Point(105, 42);
            this.radDeathsPerMillion.Name = "radDeathsPerMillion";
            this.radDeathsPerMillion.Size = new System.Drawing.Size(110, 17);
            this.radDeathsPerMillion.TabIndex = 3;
            this.radDeathsPerMillion.Text = "Deaths Per Million";
            this.radDeathsPerMillion.UseVisualStyleBackColor = true;
            this.radDeathsPerMillion.Click += new System.EventHandler(this.radDataSet_Click);
            // 
            // radDeaths
            // 
            this.radDeaths.AutoSize = true;
            this.radDeaths.Location = new System.Drawing.Point(20, 42);
            this.radDeaths.Name = "radDeaths";
            this.radDeaths.Size = new System.Drawing.Size(59, 17);
            this.radDeaths.TabIndex = 2;
            this.radDeaths.Text = "Deaths";
            this.radDeaths.UseVisualStyleBackColor = true;
            this.radDeaths.Click += new System.EventHandler(this.radDataSet_Click);
            // 
            // radCasesPerMillion
            // 
            this.radCasesPerMillion.AutoSize = true;
            this.radCasesPerMillion.Location = new System.Drawing.Point(105, 19);
            this.radCasesPerMillion.Name = "radCasesPerMillion";
            this.radCasesPerMillion.Size = new System.Drawing.Size(105, 17);
            this.radCasesPerMillion.TabIndex = 1;
            this.radCasesPerMillion.Text = "Cases Per Million";
            this.radCasesPerMillion.UseVisualStyleBackColor = true;
            this.radCasesPerMillion.Click += new System.EventHandler(this.radDataSet_Click);
            // 
            // radCases
            // 
            this.radCases.AutoSize = true;
            this.radCases.Checked = true;
            this.radCases.Location = new System.Drawing.Point(20, 19);
            this.radCases.Name = "radCases";
            this.radCases.Size = new System.Drawing.Size(54, 17);
            this.radCases.TabIndex = 0;
            this.radCases.TabStop = true;
            this.radCases.Text = "Cases";
            this.radCases.UseVisualStyleBackColor = true;
            this.radCases.Click += new System.EventHandler(this.radDataSet_Click);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.Color.Red;
            this.lblLoading.Location = new System.Drawing.Point(12, 79);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(70, 20);
            this.lblLoading.TabIndex = 15;
            this.lblLoading.Text = "Loading:";
            // 
            // howto_covid19_recoveries_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 411);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.clbCountries);
            this.Controls.Add(this.picGraph);
            this.Name = "howto_covid19_recoveries_Form1";
            this.Text = "howto_covid19_recoveries";
            this.Load += new System.EventHandler(this.howto_covid19_recoveries_Form1_Load);
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
        private System.Windows.Forms.CheckedListBox clbCountries;
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
        private System.Windows.Forms.RadioButton radCasesPerMillion;
        private System.Windows.Forms.RadioButton radCases;
        private System.Windows.Forms.RadioButton radDeathsPerMillion;
        private System.Windows.Forms.RadioButton radDeaths;
        private System.Windows.Forms.RadioButton radDeathsPerResolution;
        private System.Windows.Forms.RadioButton radRecoveriesPerMillion;
        private System.Windows.Forms.RadioButton radRecoveries;
        private System.Windows.Forms.Label lblLoading;
    }
}

