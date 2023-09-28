
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

  namespace  howto_add_items_to_combobox

 { 

class RegistryTools
    {
        // Save a value.
        public static void SaveSetting(string app_name, string section, string name, object value)
        {
            RegistryKey reg_key = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey app_key = reg_key.CreateSubKey(app_name);
            RegistryKey section_key = app_key.CreateSubKey(section);
            section_key.SetValue(name, value);
        }

        // Get a value.
        public static object GetSetting(string app_name, string section, string name, object default_value)
        {
            RegistryKey reg_key = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey app_key = reg_key.CreateSubKey(app_name);
            RegistryKey section_key = app_key.CreateSubKey(section);
            return section_key.GetValue(name, default_value);
        }

        // Delete a setting.
        public static void DeleteSetting(string app_name, string section, string name)
        {
            RegistryKey reg_key = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey app_key = reg_key.CreateSubKey(app_name);
            RegistryKey section_key = app_key.CreateSubKey(section);
            section_key.DeleteValue(name, false);
        }

        // Delete all settings in a section.
        public static void DeleteSettings(string app_name, string section)
        {
            RegistryKey reg_key = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey app_key = reg_key.CreateSubKey(app_name);
            app_key.DeleteSubKeyTree(section);
        }
    }

}