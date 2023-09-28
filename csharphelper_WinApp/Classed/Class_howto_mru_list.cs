
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

  namespace  howto_mru_list

 { 

public class MruList
    {
        // The application's name.
        private string ApplicationName;

        // A list of the files.
        private int NumFiles;
        private List<FileInfo> FileInfos;

        // The File menu.
        private ToolStripMenuItem MyMenu;

        // The menu items we use to display files.
        private ToolStripSeparator Separator;
        private ToolStripMenuItem[] MenuItems;

        // Raised when the user selects a file from the MRU list.
        public delegate void FileSelectedEventHandler(string file_name);
        public event FileSelectedEventHandler FileSelected;

        // Constructor.
        public MruList(string application_name, ToolStripMenuItem menu, int num_files)
        {
            ApplicationName = application_name;
            MyMenu = menu;
            NumFiles = num_files;
            FileInfos = new List<FileInfo>();

            // Make a separator.
            Separator = new ToolStripSeparator();
            Separator.Visible = false;
            MyMenu.DropDownItems.Add(Separator);

            // Make the menu items we may later need.
            MenuItems = new ToolStripMenuItem[NumFiles + 1];
            for (int i = 0; i < NumFiles; i++)
            {
                MenuItems[i] = new ToolStripMenuItem();
                MenuItems[i].Visible = false;
                MyMenu.DropDownItems.Add(MenuItems[i]);
            }

            // Reload items from the registry.
            LoadFiles();

            // Display the items.
            ShowFiles();
        }

        // Load saved items from the Registry.
        private void LoadFiles()
        {
            // Reload items from the registry.
            for (int i = 0; i < NumFiles; i++)
            {
                string file_name = (string)RegistryTools.GetSetting(
                    ApplicationName, "FilePath" + i.ToString(), "");
                if (file_name != "")
                {
                    FileInfos.Add(new FileInfo(file_name));
                }
            }
        }

        // Save the current items in the Registry.
        private void SaveFiles()
        {
            // Delete the saved entries.
            for (int i = 0; i < NumFiles; i++)
            {
                RegistryTools.DeleteSetting(ApplicationName, "FilePath" + i.ToString());
            }

            // Save the current entries.
            int index = 0;
            foreach (FileInfo file_info in FileInfos)
            {
                RegistryTools.SaveSetting(ApplicationName,
                    "FilePath" + index.ToString(), file_info.FullName);
                index++;
            }
        }

        // Remove a file's info from the list.
        private void RemoveFileInfo(string file_name)
        {
            // Remove occurrences of the file's information from the list.
            for (int i = FileInfos.Count - 1; i >= 0; i--)
            {
                if (FileInfos[i].FullName == file_name) FileInfos.RemoveAt(i);
            }
        }

        // Add a file to the list, rearranging if necessary.
        public void AddFile(string file_name)
        {
            // Remove the file from the list.
            RemoveFileInfo(file_name);

            // Add the file to the beginning of the list.
            FileInfos.Insert(0, new FileInfo(file_name));

            // If we have too many items, remove the last one.
            if (FileInfos.Count > NumFiles) FileInfos.RemoveAt(NumFiles);

            // Display the files.
            ShowFiles();

            // Update the Registry.
            SaveFiles();
        }

        // Remove a file from the list, rearranging if necessary.
        public void RemoveFile(string file_name)
        {
            // Remove the file from the list.
            RemoveFileInfo(file_name);

            // Display the files.
            ShowFiles();

            // Update the Registry.
            SaveFiles();
        }

        // Display the files in the menu items.
        private void ShowFiles()
        {
            Separator.Visible = (FileInfos.Count > 0);
            for (int i = 0; i < FileInfos.Count; i++)
            {
                MenuItems[i].Text = string.Format("&{0} {1}", i + 1, FileInfos[i].Name);
                MenuItems[i].Visible = true;
                MenuItems[i].Tag = FileInfos[i];
                MenuItems[i].Click -= File_Click;
                MenuItems[i].Click += File_Click;
            }
            for (int i = FileInfos.Count; i < NumFiles; i++)
            {
                MenuItems[i].Visible = false;
                MenuItems[i].Click -= File_Click;
            }
        }

        // The user selected a file from the menu.
        private void File_Click(object sender, EventArgs e)
        {
            // Don't bother if no one wants to catch the event.
            if (FileSelected != null)
            {
                // Get the corresponding FileInfo object.
                ToolStripMenuItem menu_item = sender as ToolStripMenuItem;
                FileInfo file_info = menu_item.Tag as FileInfo;

                // Raise the event.
                FileSelected(file_info.FullName);
            }
        }
    }











    public class RegistryTools
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

        // Load all of the saved settings.
        public static void LoadAllSettings(string app_name, Form frm)
        {
            // Load form settings.
            frm.SetBounds(
                (int)GetSetting(app_name, "FormLeft", frm.Left),
                (int)GetSetting(app_name, "FormTop", frm.Top),
                (int)GetSetting(app_name, "FormWidth", frm.Width),
                (int)GetSetting(app_name, "FormHeight", frm.Height));
            frm.WindowState = (FormWindowState)GetSetting(app_name,
                "FormWindowState", frm.WindowState);

            // Load the controls' values.
            LoadChildSettings(app_name, frm);
        }

        // Load all child control settings.
        public static void LoadChildSettings(string app_name, Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                // Restore the child's value.
                switch (child.GetType().Name)
                {
                    case "TextBox":
                    case "ListBox":
                    case "ComboBox":
                        child.Text = GetSetting(app_name, child.Name, child.Text).ToString();
                        break;
                    case "CheckBox":
                        CheckBox chk = child as CheckBox;
                        chk.Checked = bool.Parse(GetSetting(app_name,
                            child.Name, chk.Checked.ToString()).ToString());
                        break;
                    case "RadioButton":
                        RadioButton rad = child as RadioButton;
                        rad.Checked = bool.Parse(GetSetting(app_name,
                            child.Name, rad.Checked.ToString()).ToString());
                        break;
                    case "VScrollBar":
                        VScrollBar vscr = child as VScrollBar;
                        vscr.Value = (int)GetSetting(app_name, child.Name, vscr.Value);
                        break;
                    case "HScrollBar":
                        HScrollBar hscr = child as HScrollBar;
                        hscr.Value = (int)GetSetting(app_name, child.Name, hscr.Value);
                        break;
                    case "NumericUpDown":
                        NumericUpDown nud = child as NumericUpDown;
                        nud.Value = decimal.Parse(GetSetting(app_name, child.Name, nud.Value).ToString());
                        break;
                    // Add other control types here.
                }

                // Recursively restore the child's children.
                LoadChildSettings(app_name, child);
            }
        }

        // Save all of the form's settings.
        public static void SaveAllSettings(string app_name, Form frm)
        {
            // Save form settings.
            SaveSetting(app_name, "FormWindowState", (int)frm.WindowState);
            if (frm.WindowState == FormWindowState.Normal)
            {
                // Save current bounds.
                SaveSetting(app_name, "FormLeft", frm.Left);
                SaveSetting(app_name, "FormTop", frm.Top);
                SaveSetting(app_name, "FormWidth", frm.Width);
                SaveSetting(app_name, "FormHeight", frm.Height);
            }
            else
            {
                // Save bounds when we're restored.
                SaveSetting(app_name, "FormLeft", frm.RestoreBounds.Left);
                SaveSetting(app_name, "FormTop", frm.RestoreBounds.Top);
                SaveSetting(app_name, "FormWidth", frm.RestoreBounds.Width);
                SaveSetting(app_name, "FormHeight", frm.RestoreBounds.Height);
            }

            // Save the controls' values.
            SaveChildSettings(app_name, frm);
        }

        // Save all child control settings.
        public static void SaveChildSettings(string app_name, Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                // Save the child's value.
                switch (child.GetType().Name)
                {
                    case "TextBox":
                    case "ListBox":
                    case "ComboBox":
                        SaveSetting(app_name, child.Name, child.Text);
                        break;
                    case "CheckBox":
                        CheckBox chk = child as CheckBox;
                        SaveSetting(app_name, child.Name, chk.Checked.ToString());
                        break;
                    case "RadioButton":
                        RadioButton rad = child as RadioButton;
                        SaveSetting(app_name, child.Name, rad.Checked.ToString());
                        break;
                    case "VScrollBar":
                        VScrollBar vscr = child as VScrollBar;
                        SaveSetting(app_name, child.Name, vscr.Value);
                        break;
                    case "HScrollBar":
                        HScrollBar hscr = child as HScrollBar;
                        SaveSetting(app_name, child.Name, hscr.Value);
                        break;
                    case "NumericUpDown":
                        NumericUpDown nud = child as NumericUpDown;
                        SaveSetting(app_name, child.Name, nud.Value);
                        break;
                    // Add other control types here.
                }

                // Recursively save the child's children.
                SaveChildSettings(app_name, child);
            }
        }

        // Delete a value.
        public static void DeleteSetting(string app_name, string name)
        {
            RegistryKey reg_key = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey sub_key = reg_key.CreateSubKey(app_name);
            try
            {
                sub_key.DeleteValue(name);
            }
            catch
            {
            }
        }
    }

}