
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

  namespace  howto_duplicate_console

 { 

// Represent a list of TextWriter objects.
    public class ListTextWriter : TextWriter
    {
        private List<TextWriter> Writers = new List<TextWriter>();

        // Add a new textWriter to the list.
        public void Add(TextWriter writer)
        {
            Writers.Add(writer);
        }

        public override void Write(char value)
        {
            foreach (var writer in Writers)
                writer.Write(value);
        }

        public override void Write(string value)
        {
            foreach (var writer in Writers)
                writer.Write(value);
        }

        public override void Flush()
        {
            foreach (var writer in Writers)
                writer.Flush();
        }

        public override void Close()
        {
            foreach (var writer in Writers)
                writer.Close();
        }

        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }
    }











    public class TextBoxWriter : TextWriter
    {
        // The control where we will write text.
        private Control MyControl;
        public TextBoxWriter(Control control)
        {
            MyControl = control;
        }

        public override void Write(char value)
        {
            MyControl.Text += value;
        }

        public override void Write(string value)
        {
            MyControl.Text += value;
        }

        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }
    }

}