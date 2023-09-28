
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

  namespace  howto_drag_inside_listbox

 { 

public class DragItem
    {
        public ListBox Client;
        public int Index;
        public object Item;

        public DragItem(ListBox client, int index, object item)
        {
            Client = client;
            Index = index;
            Item = item;
        }
    }











    public static class Extensions
    {
        // Return the index of the item that is
        // under the point in screen coordinates.
        public static int IndexFromScreenPoint(this ListBox lst, Point point)
        {
            // Convert the location to the ListBox's coordinates.
            point = lst.PointToClient(point);

            // Return the index of the item at that position.
            return lst.IndexFromPoint(point);
        }
    }

}