
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

  namespace  howto_custom_component

 { 

class Frowner : System.ComponentModel.Component
    {

    }






    [System.Drawing.ToolboxBitmap(typeof(MyComponent), "Small Smiley.png")]
    public class MyComponent : Component
    {
        public void SayHello()
        {
            MessageBox.Show("Hello", "MyComponent", MessageBoxButtons.OK);
        }
    }

}