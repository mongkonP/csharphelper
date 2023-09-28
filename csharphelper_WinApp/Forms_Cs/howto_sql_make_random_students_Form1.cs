using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_sql_make_random_students_Form1:Form
  { 


        public howto_sql_make_random_students_Form1()
        {
            InitializeComponent();
        }

        // The database connection.
        private OleDbConnection Conn;

        // Names.
        private string[] LastNames = { "Ballard", "Horton", "Jordan", "King", "Peters", "Jensen", "Richardson", "Vargas", "Romero", "Carter", "Hammond", "Stokes", "Crawford", "Barnett", "Harmon", "Park", "Aguilar", "Turner", "Barker", "Mullins", "Tran", "Daniel", "Farmer", "Watson", "Ingram", "Byrd", "Ellis", "Silva", "Henry", "Rice", "Caldwell", "Poole", "Walters", "Morris", "Williams", "Flores", "Bush", "Owen", "Williamson", "Shelton", "Diaz", "Mason", "Perez", "Daniels", "Wagner", "Walsh", "Fitzgerald", "Franklin", "Huff", "Hernandez" };
        private string[] FirstNames = { "Tasha", "Erma", "Maryann", "Jorge", "Violet", "Darryl", "Elisa", "Bradley", "Teri", "Blake", "Hugh", "Benny", "Alexis", "Rosie", "Rhonda", "Isaac", "Melvin", "Jan", "Marty", "Gene", "Chad", "Alicia", "Lorenzo", "Nicholas", "Arturo", "Dana", "June", "Alex", "Ernestine", "Jaime", "Pat", "Lewis", "Moses", "Shannon", "Marcia", "Adrian", "Shari", "Noah", "Gayle", "Delbert", "Walter", "Hazel", "Ricky", "Ebony", "Dwayne", "Muriel", "Reginald", "Audrey", "Jonathan", "Noel" };
        private string[] StreetNames = { "Amber", "Auburn", "Bent", "Big", "Birch", "Blue", "Bright", "Broad", "Burning", "Calm", "Cinder", "Clear", "Cold", "Colonial", "Cool", "Cotton", "Cozy", "Crimson", "Crystal", "Dewy", "Dusty", "Easy", "Emerald", "Fallen", "Foggy", "Gentle", "Golden", "Grand", "Green", "Happy", "Harvest", "Hazy", "Heather", "Hidden", "High", "Honey", "Hush", "Indian", "Iron", "Ivory", "Jagged", "Lazy", "Little", "Lone", "Lonely", "Long", "Lost", "Merry", "Middle", "Misty", "Noble", "Old", "Orange", "Pearl", "Pied", "Pleasant", "Pretty", "Quaint", "Quaking", "Quiet", "Red", "Rocky", "Rose", "Rough", "Round", "Rustic", "Sandy", "Shady", "Silent", "Silver", "Sleepy", "Small", "Square", "Still", "Stony", "Strong", "Sunny", "Sweet", "Tawny", "Tender", "Thunder", "Turning", "Twin", "Umber", "Velvet", "White", "Windy" };
        private string[] StreetTypes = { "Acres", "Alcove", "Arbor", "Avenue", "Bank", "Bayou", "Bend", "Bluff", "Byway", "Canyon", "Chase", "Circle", "Corner", "Court", "Cove", "Crest", "Cut", "Dale", "Dell", "Drive", "Edge", "Estates", "Falls", "Farms", "Field", "Flats", "Gardens", "Gate", "Glade", "Glen", "Grove", "Haven", "Heights", "Highlands", "Hollow", "Isle", "Jetty", "Journey", "Knoll", "Lace", "Lagoon", "Landing", "Lane", "Ledge", "Manor", "Meadow", "Mews", "Niche", "Nook", "Orchard", "Pace", "Park", "Pass", "Path", "Pike", "Place", "Point", "Promenade", "Quay", "Race", "Ramble", "Ridge", "Road", "Round", "Rove", "Run", "Saunter", "Shoal", "Stead", "Street", "Stroll", "Summit", "Swale", "Terrace", "Trace", "Trail", "Trek", "Turn", "Twist", "Vale", "Valley", "View", "Villa", "Vista", "Wander", "Way", "Woods" };
        private string[] CityNames = { "Sitka", "Juneau", "Wrangell", "Anchorage", "Jacksonville", "Anaconda", "Butte", "Oklahoma City", "Houston", "Phoenix", "Nashville", "Los Angeles", "San Antonio", "Suffolk", "Buckeye", "Indianapolis", "Chesapeake", "Dallas", "Fort Worth", "Louisville", "San Diego", "Memphis", "Kansas City", "New York City", "Augusta", "Austin", "Charlotte", "Lexington", "El Paso", "Virginia Beach", "Cusseta", "Chicago", "Tucson", "Columbus", "Columbus", "Valdez", "Preston", "Huntsville", "Boulder City", "California City", "Tulsa", "Colorado Springs", "Goodyear", "Albuquerque", "Scottsdale", "Hibbing", "Norman", "San Jose", "Peoria", "New Orleans", "Corpus Christi", "Montgomery", "Wichita", "Aurora", "Denver", "Sierra Vista", "Georgetown", "Birmingham", "Fayetteville", "Carson City", "Raleigh", "Bakersfield", "Mobile", "Detroit", "Bunnell", "Mesa", "Las Vegas", "Chattanooga", "Philadelphia", "Portland", "Atlanta", "Winston-Salem", "Brownsville", "Columbia", "Lynchburg", "Athens", "Little Rock", "Omaha", "Lubbock", "Tampa", "Unalaska", "Orlando", "Salt Lake City", "Columbia", "Yuma", "Babbitt", "Cape Coral", "Abilene", "Palmdale", "Jackson", "Greensboro", "Fresno", "Shreveport", "St. Marys", "Sacramento", "Charleston", "Nightmute", "Plymouth", "Milwaukee", "Arlington", "Tallahassee", "Clarksville", "Durham", "Palm Springs", "Lancaster", "Knoxville", "Amarillo", "Dothan", "Oak Ridge", "Edmond", "Beaumont", "Waco", "Seattle", "Port Arthur", "Baltimore", "Toledo", "Kansas City", "El Reno", "Henderson", "Jonesboro", "Ellsworth", "Caribou", "Laredo", "Fort Wayne", "North Las Vegas", "Independence", "Riverside", "Cincinnati", "Las Cruces", "Cleveland", "Baton Rouge", "Fremont", "Presque Isle", "Des Moines", "Port St. Lucie", "Lawton", "Rome", "North Port", "Savannah", "Lincoln", "Enid", "Rio Rancho", "Apple Valley", "Springfield", "Victorville", "Marana", "Eloy", "Plano", "Grand Prairie", "Wichita Falls" };
        private string[] StateNames = { "AL", "MT", "AK", "NE", "AZ", "NV", "AR", "NH", "CA", "NJ", "CO", "NM", "CT", "NY", "DE", "NC", "FL", "ND", "GA", "OH", "HI", "OK", "ID", "OR", "IL", "PA", "IN", "RI", "IA", "SC", "KS", "SD", "KY", "TN", "LA", "TX", "ME", "UT", "MD", "VT", "MA", "VA", "MI", "WA", "MN", "WV", "MS", "WI", "MO", "WY" };

        // Set up the connection.
        private void howto_sql_make_random_students_Form1_Load(object sender, EventArgs e)
        {
            string connect_string =
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=Students.mdb;" +
                "Mode=Share Deny None";
            Conn = new OleDbConnection(connect_string);
        }

        // Create random students.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Conn.Open();

            // Empty the tables.
            using (OleDbCommand scores_cmd =
                new OleDbCommand("DELETE FROM TestScores", Conn))
            {
                int num_scores_deleted = scores_cmd.ExecuteNonQuery();
                Console.WriteLine("Deleted " + num_scores_deleted +
                    " TestScores records");
            }

            using (OleDbCommand delete_addr_cmd =
                new OleDbCommand("DELETE FROM Addresses", Conn))
            {
                int num_addresses_deleted = delete_addr_cmd.ExecuteNonQuery();
                Console.WriteLine("Deleted " + num_addresses_deleted +
                    " Addresses records");
            }

            int num_students = int.Parse(txtNumStudents.Text);
            int num_tests = int.Parse(txtNumTestScores.Text);

            // Make OleDbCommand objects to create students and test scores.
            string create_student_sql = "INSERT INTO Addresses " +
                    "(FirstName, LastName, Street, City, State, Zip) " +
                    " VALUES (?, ?, ?, ?, ?, ?)";
            using (OleDbCommand create_student_cmd =
                new OleDbCommand(create_student_sql, Conn))
            {
                string create_score_sql = "INSERT INTO TestScores " +
                    "(StudentId, TestNumber, Score) VALUES (?, ?, ?)";
                using (OleDbCommand create_score_cmd =
                    new OleDbCommand(create_score_sql, Conn))
                {
                    // Create students.
                    Random rand = new Random();
                    List<string> names = new List<string>();
                    for (int i = 0; i < num_students; i++)
                    {
                        // Pick the i-th random name.
                        string first_name, last_name;
                        do
                        {
                            first_name = FirstNames[rand.Next(0, FirstNames.Length)];
                            last_name = LastNames[rand.Next(0, LastNames.Length)];
                            if (!names.Contains(last_name + ", " + first_name))
                                names.Add(last_name + ", " + first_name);
                        }
                        while (names.Count <= i);

                        // Set the command's name parameters.
                        create_student_cmd.Parameters.Clear();
                        create_student_cmd.Parameters.AddWithValue(
                            "FirstName", first_name);
                        create_student_cmd.Parameters.AddWithValue(
                            "LastName", last_name);

                        // Set the other parameter values.
                        create_student_cmd.Parameters.AddWithValue(
                            "Street",
                            rand.Next(100, 99999).ToString() +
                            " " + StreetNames[rand.Next(0, StreetNames.Length)] +
                            " " + StreetTypes[rand.Next(0, StreetTypes.Length)]);
                        create_student_cmd.Parameters.AddWithValue(
                            "City",
                            CityNames[rand.Next(0, CityNames.Length)]);
                        create_student_cmd.Parameters.AddWithValue(
                            "State",
                            StateNames[rand.Next(0, StateNames.Length)]);
                        create_student_cmd.Parameters.AddWithValue(
                            "Zip",
                            rand.Next(10000, 99999).ToString());

                        // Create the student.
                        create_student_cmd.ExecuteNonQuery();

                        // Get the new student's auto-generated ID.
                        OleDbCommand get_id_cmd =
                            new OleDbCommand("SELECT @@IDENTITY", Conn);
                        int student_id;
                        using (OleDbDataReader reader = get_id_cmd.ExecuteReader())
                        {
                            reader.Read();
                            student_id = (int)reader.GetValue(0);
                        }

                        // Create the new student's test scores.
                        for (int test_number = 0; test_number < num_tests; test_number++)
                        {
                            // Set the new test score command parameters.
                            create_score_cmd.Parameters.Clear();
                            create_score_cmd.Parameters.AddWithValue(
                                "StudentId", student_id);
                            create_score_cmd.Parameters.AddWithValue(
                                "TestNumber", test_number);
                            create_score_cmd.Parameters.AddWithValue(
                                "Score", rand.Next(50, 101));

                            // Execute the command.
                            create_score_cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            // Close the connection.
            Conn.Close();

            MessageBox.Show("Created " + num_students + " students and " +
                num_students * num_tests + " test score records.");
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumStudents = new System.Windows.Forms.TextBox();
            this.txtNumTestScores = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "# Students:";
            // 
            // txtNumStudents
            // 
            this.txtNumStudents.Location = new System.Drawing.Point(154, 12);
            this.txtNumStudents.Name = "txtNumStudents";
            this.txtNumStudents.Size = new System.Drawing.Size(42, 20);
            this.txtNumStudents.TabIndex = 1;
            this.txtNumStudents.Text = "10";
            this.txtNumStudents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumTestScores
            // 
            this.txtNumTestScores.Location = new System.Drawing.Point(154, 38);
            this.txtNumTestScores.Name = "txtNumTestScores";
            this.txtNumTestScores.Size = new System.Drawing.Size(42, 20);
            this.txtNumTestScores.TabIndex = 3;
            this.txtNumTestScores.Text = "10";
            this.txtNumTestScores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Test Scores Per Student:";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(213, 22);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // howto_sql_make_random_students_Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 70);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtNumTestScores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumStudents);
            this.Controls.Add(this.label1);
            this.Name = "howto_sql_make_random_students_Form1";
            this.Text = "howto_sql_make_random_students";
            this.Load += new System.EventHandler(this.howto_sql_make_random_students_Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumStudents;
        private System.Windows.Forms.TextBox txtNumTestScores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreate;
    }
}

