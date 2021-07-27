using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventory_System.Data;
using Inventory_System.Models;

namespace Inventory_System.Pages.Retailers
{
    public class DetailsModel : PageModel
    {
        private readonly Inventory_System.Data.Inventory_SystemContext _context;

        public DetailsModel(Inventory_System.Data.Inventory_SystemContext context)
        {
            _context = context;
        }

        public Retailer Retailer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Retailer = await _context.Retailer.FirstOrDefaultAsync(m => m.Id == id);

            if (Retailer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
