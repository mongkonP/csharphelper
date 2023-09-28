
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_datagridview_display_objects

 { 

public class OrderItem
    {
        public string Description;
        public int Quantity;
        public decimal UnitPrice, TotalCost;
        public OrderItem(string new_description, decimal new_unitprice, int new_quantity)
        {
            Description = new_description;
            UnitPrice = new_unitprice;
            Quantity = new_quantity;

            // Calculate total.
            TotalCost = UnitPrice * Quantity;
        }
    }

}