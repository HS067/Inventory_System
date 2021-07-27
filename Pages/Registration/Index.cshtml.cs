using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inventory_System.Data;
using Inventory_System.Models;

namespace Inventory_System.Pages.Registration
{
    public class IndexModel : PageModel
    {
        private readonly Inventory_System.Data.Inventory_SystemContext _context;

        public IndexModel(Inventory_System.Data.Inventory_SystemContext context)
        {
            _context = context;
        }

        public IList<Registeration> Registeration { get;set; }

        public async Task OnGetAsync()
        {
            Registeration = await _context.Registeration
                .Include(r => r.Product)
                .Include(r => r.Retailer).ToListAsync();
        }
    }
}
