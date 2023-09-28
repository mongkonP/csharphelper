
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

  namespace  howto_eula_once

 { 

class RegistryTools
    {
        // Save a value.
        public static void SaveSetting(string app_name, string name, object value)
        {
            RegistryKey reg_key = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey sub_key = reg_key.CreateSubKey(app_name);
            sub_key.SetValue(name, value);
        }

        // Get a value.
        public static object GetSetting(string app_name, string name, object default_value)
        {
            RegistryKey reg_key = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey sub_key = reg_key.CreateSubKey(app_name);
            return sub_key.GetValue(name, default_value);
        }
    }

}