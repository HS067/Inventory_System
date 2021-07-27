using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class Product
    {

        //Product primary key.
        public int Id { get; set; }

        //Product Name
        public string ProductName { get; set; }

        //Product Price
        public decimal Price { get; set; }

        //Returns product Code
        [NotMapped]
        public string ProductCode
        {
            get { return "P000" + Id; }
        }

        //Product display name
        [NotMapped]
        public string ProductDisplayName
        {
            get { return "P000" + Id + "-" + ProductName; }
        }

        //Product category Link
        public Category Category { get; set; }

        //Product category foriegn key.
        public int CategoryId { get; set; }
    }
}
