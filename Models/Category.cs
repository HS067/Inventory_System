using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_System.Models
{
    public class Category
    {

        //Product category primary key
        public int Id { get; set; }

        //Category name
        public string Name { get; set; }

        //Category code
        [NotMapped]
        public string CategoryCode
        {
            get { return "C000" + Id; }
        }

        //Category display name
        [NotMapped]
        public string CategoryDisplayName
        {
            get { return "C000" + Id + "-" + Name; }
        }

        //Category description.
        public string Description { get; set; }
    }
}
