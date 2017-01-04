using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MvvmLightTest.Database
{
    public class DbContext : IDisposable
    {
        public DbContext()
        {
            this.Products = new List<Product>();

            List<Product> products = new List<Product>()
            {
                new Product { Name = "Apple" },
                new Product { Name = "Banana" },
                new Product { Name = "Orange" },
                new Product { Name = "Kiwi" },
                new Product { Name = "Pomegranate" },
                new Product { Name = "Cantalope" },
                new Product { Name = "Fig" },
                new Product { Name = "Peach" },
                new Product { Name = "Pear" },
            };
            
            this.Products.AddRange(products);

        }

        public List<Product> Products { get; set; }

        public void Dispose()
        {

        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public int? VirtualMachineID { get; private set; }
        public string Name { get; set; }
        public string Selection { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public double PriceWithTax { get; set; }
        public double Fee { get; set; }


    }
}
