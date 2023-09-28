using csharphelper.Class;
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
using TorServices;

namespace csharphelper
{
    public partial class frm_test : Form
    {
        public frm_test()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //  Set_File_Form(fcs);
            string ClassName, ClassType, file_cs, code = "", f_Designer = @"D:\csharphelper\2020-05-27\LangtonsAntSimulator_RichardMoss\LangtonsAntSimulator_RichardMoss\DelayDialog.Designer.cs";
            string f_Form = f_Designer.ToLower().Replace(".designer.cs", ".cs");


            if (File.Exists(f_Form))
            {
                using (FileClass reader = new FileClass(f_Form))
                {

                    ClassName = new Regex(@".*?partial class(.*?):.*?", RegexOptions.None).Matches(reader.code)[0].Groups[1].Value.Trim();
                    try
                    { ClassType = new Regex(@"class.*?:\s{0,}(.*?)[\n\s]{1,}", RegexOptions.None).Matches(reader.code)[0].Groups[1].Value.Trim().Replace(" ", "_"); }
                    catch { ClassType = ""; }


                    /* if (ClassType.Trim() == "Form")
                     {*/
                    using (FileClass r = new FileClass(f_Designer))
                    {
                        r.code = new Regex(@"(namespace.*?[\n\s{]{2,}partial class.*?[\s\n{]{3,})", RegexOptions.None).Replace(r.code, "");
                        code = r.code;
                        r.Dispose();
                    }


                    //  }
                    reader.code = (reader.code.Trim().TrimEnd('}').Trim().TrimEnd('}') + "\n\n" + code);


                    file_cs = FilePath.RenameFileDup(Program.folForms + @"\" + (Path.GetFileName(Path.GetDirectoryName(f_Form)).Replace(" ", "_") + "_" + ClassName).Replace(" ", "_").Replace(",", "_") + ".cs");
                    reader.code = reader.code.Replace(ClassName, Path.GetFileNameWithoutExtension(file_cs));

                    reader.code = new Regex(@"(namespace.*?[\n\s]{0,}\{[\n\s]{0,}public\s{1,}partial class.*?:.*?[\n\s]{0,}\{)", RegexOptions.None)
                .Replace(reader.code, " \n\nnamespace csharphelper_WinApp.Forms_Cs \n    {\n     public partial class "
                + Path.GetFileNameWithoutExtension(file_cs) + ":" + ClassType
                + Environment.NewLine +
                "  { \n\n"
                );

                    reader.code = new Regex(@"(global::.*?.Properties.Resources.)", RegexOptions.None).Replace(reader.code, "Properties.Resources.");
                    richTextBox1.Text = reader.code;
                    reader.Dispose();


                }



            }







        }




    }
}
