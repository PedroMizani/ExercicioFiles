using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeFile.Entities
{
    internal class Products
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }   

        public Products() { }

        public Products(string productName, double price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public double Total()
        {
            return Price * Quantity;
        }
    }
}
