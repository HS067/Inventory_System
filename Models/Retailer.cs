using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class Retailer
    {
        //Retailer Id primary key
        public int Id { get; set; }

        //Retailer name.
        public string Name { get; set; }

        //Retailer contact number
        public string ContactNumber { get; set; }

        //Retailer code 
        [NotMapped]
        public string RetailerCode
        {
            get { return "R000" + Id; }
        }

        //Retailer display name.
        [NotMapped]
        public string RetailerDisplayName
        {
            get { return "RET0000" + Id + "-" + Name; }
        }
    }
}
