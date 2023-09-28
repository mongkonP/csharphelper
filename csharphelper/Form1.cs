using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharphelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /* string fcs = @"D:\2020-05-27\2020-05-27\howto_3d_pie_slices\howto_3d_pie_slices\howto_3d_pie_slices\Geometry.cs";
            Class.classGenerate cg = new Class.classGenerate(fcs);*/

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = cg.Methods[comboBox1.Text];


            }
            catch { }
        }
        _Class.classGenerate cg;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text))
            {  cg = new _Class.classGenerate(textBox1.Text);
                if (cg.Methods.Count > 0)
                {
                    comboBox1.Items.Clear();
                    cg.Methods.Keys.ToList<string>()
                        .ForEach(c => comboBox1.Items.Add(c));

                    comboBox1.SelectedIndex = 0;
                }
            
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog f = new OpenFileDialog())
            {
                f.Filter = "cs files (*.cs)|*.cs|All files (*.*)|*.*";
                if (f.ShowDialog() == DialogResult.OK)
                    textBox1.Text = f.FileName;
            }
        }
    }
}
