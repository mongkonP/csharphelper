using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace csharphelper_WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string s1 = "";string s2 = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.Directory.GetFiles(@"E:\T_MEGA\Test_Code\csharphelper\csharphelper_sln\csharphelper_WPF\Windows", "*.xaml.cs").ToList<string>()
                .ForEach(f =>
                {
                    string file = Path.GetFileNameWithoutExtension(f);
                    s1 +="\n" + "<Compile Include=\"Windows\\"+ file+".cs\">\n <DependentUpon>"+ file+".xaml</DependentUpon> \n</Compile> ";

                    s2 += "<Page Include=\"Windows\\"+ file+"\">\n <Generator> MSBuild:Compile </Generator> \n <SubType> Designer </SubType>\n</Page> ";
                });

            richTextBox1.Text = s1 + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine + s2;
        }
    }
}
