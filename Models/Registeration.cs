using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class Registeration
    { //Primary key
        public int Id { get; set; }

        //Reference to Product.
        public Product Product { get; set; }

        //Reference to Retailer.
        public Retailer Retailer { get; set; }

        //Product Id foriegn key
        public int ProductId { get; set; }

        //Retailer Id foriegn key
        public int RetailerId { get; set; }


        //Delivery status 
        public string DeliveryStatus { get; set; }


    }
}


