
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

  namespace  howto_listview_print_multipage_data

 { 

public static class ExtensionProperties
    {
        // Storage for the properties.
        private static Dictionary<object, Dictionary<string, object>> PropertyValues =
                   new Dictionary<object, Dictionary<string, object>>();

        // Set a property value for the item.
        public static void SetValue(this object item, string name, object value)
        {
            // If we don't have a dictionary for this item yet, make one.
            if (!PropertyValues.ContainsKey(item))
                PropertyValues[item] = new Dictionary<string, object>();

            // Set the value in the item's dictionary.
            PropertyValues[item][name] = value;
        }

        // Return a property value for the item.
        public static object GetValue(this object item, string name, object default_value)
        {
            // If we don't have a dictionary for
            // this item yet, return the default value.
            if (!PropertyValues.ContainsKey(item)) return default_value;

            // If the value isn't in the dictionary,
            // return the default value.
            if (!PropertyValues[item].ContainsKey(name)) return default_value;

            // Return the saved value.
            return PropertyValues[item][name];
        }

        // Remove the property.
        public static void RemoveValue(this object item, string name)
        {
            // If we don't have a dictionary for this item, do nothing.
            if (!PropertyValues.ContainsKey(item)) return;

            // If the value isn't in the dictionary, do nothing.
            if (!PropertyValues[item].ContainsKey(name)) return;

            // Remove the value.
            PropertyValues[item].Remove(name);
        }
    }












    public static class ListViewExtensions
    {
        // Make a ListView row.
        public static void AddRow(this ListView lvw, params string[] values)
        {
            // Make the item.
            ListViewItem new_item = lvw.Items.Add(values[0]);

            // Make the sub-items.
            for (int i = 1; i < values.Length; i++)
            {
                new_item.SubItems.Add(values[i]);
            }
        }

        // Make the ListView's column headers.
        // The params entries should alternate between
        // strings and HorizontalAlignment values.
        public static void SetColumnHeaders(this ListView lvw, params object[] header_info)
        {
            // Remove any existing headers.
            lvw.Columns.Clear();

            // Make the column headers.
            for (int i = header_info.GetLowerBound(0); i <= header_info.GetUpperBound(0); i += 2)
            {
                lvw.Columns.Add(
                    (string)header_info[i],
                    -1,
                    (HorizontalAlignment)header_info[i + 1]);
            }
        }

        // Set the ListView's column sizes to the same value.
        public static void SetColumnSizes(this ListView lvw, int width)
        {
            foreach (ColumnHeader col in lvw.Columns)
            {
                col.Width = width;
            }
        }

        // Size the columns to fit their data.
        public static void SizeColumnsToFitData(this ListView lvw)
        {
            SetColumnSizes(lvw, -1);
        }

        // Size the columns to fit their data and headers.
        public static void SizeColumnsToFitDataAndHeaders(this ListView lvw)
        {
            SetColumnSizes(lvw, -2);
        }

        // Prepare the ListView for column sorting.
        public enum SortMode
        {
            SortNone,
            SortOnClickedColumn,
            SortOnAllColumns
        }
        public static void SetSortMode(this ListView lvw, SortMode sort_mode)
        {
            // Get the current sort mode.
            SortMode old_sort_mode =
                (SortMode)lvw.GetValue("ListViewSortMode", SortMode.SortNone);

            // If the sort mode isn't changing, do nothing.
            if (sort_mode == old_sort_mode) return;

            // See what the current sorting mode is.
            if (old_sort_mode == SortMode.SortOnClickedColumn)
            {
                // Stop sorting on clicked columns.
                ListViewSortManager SortManager =
                    (ListViewSortManager)lvw.GetValue("ListViewSortManager", null);
                SortManager.Disable();
                lvw.RemoveValue("ListViewSortManager");
                lvw.ListViewItemSorter = null;
            }
            else if (old_sort_mode == SortMode.SortOnAllColumns)
            {
                // Stop sorting on all columns.
                lvw.ListViewItemSorter = null;
            }

            // Start the new sort mode.
            if (sort_mode == SortMode.SortNone)
            {
                lvw.RemoveValue("ListViewSortMode");
                return;
            }

            if (sort_mode == SortMode.SortOnClickedColumn)
            {
                // Sort on clicked columns.
                lvw.SetValue("ListViewSortManager", new ListViewSortManager(lvw));
            }
            else if (sort_mode == SortMode.SortOnAllColumns)
            {
                // Sort on all columns.
                lvw.ListViewItemSorter = new ListViewAllColumnComparer(SortOrder.Ascending);
                lvw.Sort();
            }

            // Save the new sort mode.
            lvw.SetValue("ListViewSortMode", sort_mode);
        }

        // A class to manage sorting for a ListView.
        private class ListViewSortManager
        {
            // The ListView we are sorting.
            private ListView MyListView;

            // The column we are currently using for sorting.
            private ColumnHeader SortingColumn;

            // Constructor.
            public ListViewSortManager(ListView lvw)
            {
                // Save the control.
                MyListView = lvw;

                // Initially no column is selected for sorting.
                SortingColumn = null;

                // Install the column click event handler.
                MyListView.ColumnClick += MyListView_ColumnClick;
            }

            // No longer sort on columns clicked.
            // Note that this ListViewSortManager can no longer be used
            // after this because it no longer has a reference to a ListView.
            public void Disable()
            {
                // Remove the old sort indicator, if there is one.
                if (SortingColumn != null)
                    SortingColumn.Text = SortingColumn.Text.Substring(2);

                MyListView.ColumnClick -= MyListView_ColumnClick;
                MyListView = null;
            }

            // Sort on the clicked column.
            private void MyListView_ColumnClick(object sender, ColumnClickEventArgs e)
            {
                // Get the new sorting column.
                ColumnHeader new_sorting_column = MyListView.Columns[e.Column];

                // Figure out the new sorting order.
                System.Windows.Forms.SortOrder sort_order;
                if (SortingColumn == null)
                {
                    // New column. Sort ascending.
                    sort_order = SortOrder.Ascending;
                }
                else
                {
                    // See if this is the same column.
                    if (new_sorting_column == SortingColumn)
                    {
                        // Same column. Switch the sort order.
                        if (SortingColumn.Text.StartsWith("> "))
                        {
                            sort_order = SortOrder.Descending;
                        }
                        else
                        {
                            sort_order = SortOrder.Ascending;
                        }
                    }
                    else
                    {
                        // New column. Sort ascending.
                        sort_order = SortOrder.Ascending;
                    }

                    // Remove the old sort indicator.
                    SortingColumn.Text = SortingColumn.Text.Substring(2);
                }

                // Display the new sort order.
                SortingColumn = new_sorting_column;
                if (sort_order == SortOrder.Ascending)
                {
                    SortingColumn.Text = "> " + SortingColumn.Text;
                }
                else
                {
                    SortingColumn.Text = "< " + SortingColumn.Text;
                }

                // Create a comparer.
                MyListView.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);

                // Sort.
                MyListView.Sort();
            }
        }

        // Compares two ListView items based on a selected column.
        private class ListViewComparer : System.Collections.IComparer
        {
            private int ColumnNumber;
            private SortOrder SortOrder;

            public ListViewComparer(int column_number, SortOrder sort_order)
            {
                ColumnNumber = column_number;
                SortOrder = sort_order;
            }

            // Compare two ListViewItems.
            public int Compare(object object_x, object object_y)
            {
                // Get the objects as ListViewItems.
                ListViewItem item_x = object_x as ListViewItem;
                ListViewItem item_y = object_y as ListViewItem;

                // Get the corresponding sub-item values.
                string string_x;
                if (item_x.SubItems.Count <= ColumnNumber)
                {
                    string_x = "";
                }
                else
                {
                    string_x = item_x.SubItems[ColumnNumber].Text;
                }

                string string_y;
                if (item_y.SubItems.Count <= ColumnNumber)
                {
                    string_y = "";
                }
                else
                {
                    string_y = item_y.SubItems[ColumnNumber].Text;
                }

                // Compare them.
                int result;
                double double_x, double_y;
                DateTime date_x, date_y;
                if (double.TryParse(string_x, out double_x) &&
                    double.TryParse(string_y, out double_y))
                {
                    // Treat as a number.
                    result = double_x.CompareTo(double_y);
                }
                else if (DateTime.TryParse(string_x, out date_x) &&
                         DateTime.TryParse(string_y, out date_y))
                {
                    // Treat as a date.
                    result = date_x.CompareTo(date_y);
                }
                else
                {
                    // Treat as a string.
                    result = string_x.CompareTo(string_y);
                }

                // Return the correct result depending on whether
                // we're sorting ascending or descending.
                if (SortOrder == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }

        // Compares two ListView items using all of their columns.
        private class ListViewAllColumnComparer : System.Collections.IComparer
        {
            private SortOrder SortOrder;

            public ListViewAllColumnComparer(SortOrder sort_order)
            {
                SortOrder = sort_order;
            }

            // Compare two ListViewItems.
            public int Compare(object object_x, object object_y)
            {
                // Get the objects as ListViewItems.
                ListViewItem item_x = object_x as ListViewItem;
                ListViewItem item_y = object_y as ListViewItem;

                // Loop through the sub-items.
                for (int i = 0; i < item_x.SubItems.Count; i++)
                {
                    // If item_y is out of sub-items,
                    // then it comes first.
                    if (item_y.SubItems.Count <= i) return 1;

                    // Get the sub-items.
                    string string_x = item_x.SubItems[i].Text;
                    string string_y = item_y.SubItems[i].Text;

                    // Compare them.
                    int result = CompareValues(string_x, string_y);

                    if (result != 0) return result;
                }

                // If we get here, we have an exact match.
                return 0;
            }

            // Compare two items. If they look like
            // numbers or dates, compare them as such.
            private int CompareValues(string string_x, string string_y)
            {
                // Compare them.
                int result;
                double double_x, double_y;
                if (double.TryParse(string_x, out double_x) &&
                    double.TryParse(string_y, out double_y))
                {
                    // Treat as a number.
                    result = double_x.CompareTo(double_y);
                }
                else
                {
                    DateTime date_x, date_y;
                    if (DateTime.TryParse(string_x, out date_x) &&
                        DateTime.TryParse(string_y, out date_y))
                    {
                        // Treat as a date.
                        result = date_x.CompareTo(date_y);
                    }
                    else
                    {
                        // Treat as a string.
                        result = string_x.CompareTo(string_y);
                    }
                }

                // Return the correct result depending on whether
                // we're sorting ascending or descending.
                if (SortOrder == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }

        // Print the ListView's data at the indicated location
        // assuming everything will fit within the column widths.
        public static void PrintData(this ListView lvw, Point location, Graphics gr,
            Brush header_brush, Brush data_brush, Pen grid_pen)
        {
            const int x_margin = 5;
            const int y_margin = 3;
            float x = location.X;
            float y = location.Y;

            // See how tall rows should be.
            SizeF row_size = gr.MeasureString(lvw.Columns[0].Text, lvw.Font);
            int row_height = (int)row_size.Height + 2 * y_margin;

            // Get the screen's horizontal resolution.
            float screen_res_x;
            using (Graphics screen_gr = lvw.CreateGraphics())
            {
                screen_res_x = screen_gr.DpiX;
            }

            // Scale factor to convert from screen pixels
            // to printer units (100ths of inches).
            float screen_to_printer = 100 / screen_res_x;

            // Get the column widths in printer units.
            float[] col_wids = new float[lvw.Columns.Count];
            for (int i = 0; i < lvw.Columns.Count; i++)
                col_wids[i] = (lvw.Columns[i].Width + 4 * x_margin) * screen_to_printer;

            int num_columns = lvw.Columns.Count;
            using (StringFormat string_format = new StringFormat())
            {
                // Draw the column headers.
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                for (int i = 0; i < num_columns; i++)
                {
                    RectangleF rect = new RectangleF(
                        x, y, col_wids[i], row_height);
                    gr.DrawString(lvw.Columns[i].Text,
                        lvw.Font, header_brush, rect, string_format);
                    gr.DrawRectangle(grid_pen, rect);
                    x += col_wids[i];
                }
                y += row_height;

                // Draw the data.
                foreach (ListViewItem item in lvw.Items)
                {
                    x = location.X;
                    for (int i = 0; i < num_columns; i++)
                    {
                        RectangleF rect = new RectangleF(
                            x + x_margin, y,
                            col_wids[i] - x_margin, row_height);

                        switch (lvw.Columns[i].TextAlign)
                        {
                            case HorizontalAlignment.Left:
                                string_format.Alignment = StringAlignment.Near;
                                break;
                            case HorizontalAlignment.Center:
                                string_format.Alignment = StringAlignment.Center;
                                break;
                            case HorizontalAlignment.Right:
                                string_format.Alignment = StringAlignment.Far;
                                break;
                        }

                        gr.DrawString(item.SubItems[i].Text,
                            lvw.Font, header_brush, rect, string_format);
                        rect = new RectangleF(x, y, col_wids[i], row_height);
                        gr.DrawRectangle(grid_pen, rect);
                        x += col_wids[i];
                    }
                    y += row_height;
                }
            }
        }

        // The index of the next ListView row to be drawn.
        private static int NextListViewRow = 0;

        // Print the ListView's data at the indicated location
        // allowing data to span multiple lines.
        // Return true if the row fits.
        // If the row won't fit, don't draw anything and return false.
        public static bool PrintMultiLineData(this ListView lvw, Point location,
            float max_y, Graphics gr, Brush header_brush, Brush data_brush, Pen grid_pen)
        {
            const int x_margin = 5;
            const int y_margin = 3;
            float x = location.X;
            float y = location.Y;

            // Get the screen's horizontal resolution.
            float screen_res_x;
            using (Graphics screen_gr = lvw.CreateGraphics())
            {
                screen_res_x = screen_gr.DpiX;
            }

            // Scale factor to convert from screen pixels
            // to printer units (100ths of inches).
            float screen_to_printer = 100 / screen_res_x;

            // Get the column widths in printer units.
            float[] col_wids = new float[lvw.Columns.Count];
            for (int i = 0; i < lvw.Columns.Count; i++)
                col_wids[i] = (lvw.Columns[i].Width + 2 * x_margin) * screen_to_printer;

            int num_columns = lvw.Columns.Count;
            using (StringFormat string_format = new StringFormat())
            {
                // Draw the column headers.
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                var header_query =
                    from ColumnHeader column in lvw.Columns
                    select column.Text;
                DrawMultiLineItems(header_query.ToArray(),
                    gr, lvw.Font, header_brush, grid_pen,
                    max_y, x_margin, y_margin,
                    x, ref y, col_wids, num_columns, string_format);

                // Draw the data.
                string_format.Alignment = StringAlignment.Near;
                while (NextListViewRow < lvw.Items.Count)
                {
                    ListViewItem item = lvw.Items[NextListViewRow];
                    var subitems_query =
                        from ListViewItem.ListViewSubItem subitem
                        in item.SubItems
                        select subitem.Text;
                    if (!DrawMultiLineItems(subitems_query.ToArray(),
                        gr, lvw.Font, data_brush, grid_pen,
                        max_y, x_margin, y_margin,
                        x, ref y, col_wids, num_columns, string_format)) return false;
                    NextListViewRow++;
                }
            }
            NextListViewRow = 0;
            return true;
        }

        // Draw the items in a row. Return true if the row fits.
        // If the row won't fit, don't draw anything and return false.
        private static bool DrawMultiLineItems(string[] items, Graphics gr, Font lvw_font,
            Brush header_brush, Pen grid_pen, float max_y, float x_margin, float y_margin,
            float x0, ref float y0, float[] col_wids, int num_columns, StringFormat string_format)
        {
            float row_height = 0;
            float x = x0;

            // Measure the size needed by the text.
            for (int i = 0; i < num_columns; i++)
            {
                SizeF layout_area = new SizeF(col_wids[i], 1000);
                SizeF row_size = gr.MeasureString(items[i], lvw_font, layout_area);
                if (row_height < row_size.Height) row_height = row_size.Height;
            }

            // See if we have enough room for the row.
            if (y0 + row_height > max_y) return false;

            // Draw the text.
            for (int i = 0; i < num_columns; i++)
            {
                // Measure the size needed by the text.
                float text_width = col_wids[i] - 2 * x_margin;
                SizeF layout_area = new SizeF(col_wids[i], 1000);
                SizeF row_size = gr.MeasureString(items[i], lvw_font, layout_area);

                // Draw the text.
                RectangleF rect = new RectangleF(
                    x + x_margin, y0 + y_margin,
                    text_width, row_size.Height);
                gr.DrawString(items[i], lvw_font,
                    header_brush, rect, string_format);

                // Draw the next column.
                x += col_wids[i];
            }

            // Add extra room for the vertical margin.
            row_height += 2 * y_margin;

            // Draw boxes around the column headers.
            x = x0;
            for (int i = 0; i < num_columns; i++)
            {
                // Draw the box.
                RectangleF rect = new RectangleF(
                    x, y0, col_wids[i], row_height);
                gr.DrawRectangle(grid_pen, rect);

                // Draw the next column.
                x += col_wids[i];
            }

            // Get ready for the next row.
            y0 += row_height;

            return true;
        }

        // Draw a RectangleF.
        public static void DrawRectangle(this Graphics gr, Pen pen, RectangleF rectf)
        {
            gr.DrawRectangle(pen, rectf.Left, rectf.Top, rectf.Width, rectf.Height);
        }
    }

}