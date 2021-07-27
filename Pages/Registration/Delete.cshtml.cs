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
    public class DeleteModel : PageModel
    {
        private readonly Inventory_System.Data.Inventory_SystemContext _context;

        public DeleteModel(Inventory_System.Data.Inventory_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Registeration Registeration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Registeration = await _context.Registeration
                .Include(r => r.Product)
                .Include(r => r.Retailer).FirstOrDefaultAsync(m => m.Id == id);

            if (Registeration == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Registeration = await _context.Registeration.FindAsync(id);

            if (Registeration != null)
            {
                _context.Registeration.Remove(Registeration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
