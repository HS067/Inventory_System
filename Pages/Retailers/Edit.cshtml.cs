using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventory_System.Data;
using Inventory_System.Models;

namespace Inventory_System.Pages.Retailers
{
    public class EditModel : PageModel
    {
        private readonly Inventory_System.Data.Inventory_SystemContext _context;

        public EditModel(Inventory_System.Data.Inventory_SystemContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Retailer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetailerExists(Retailer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RetailerExists(int id)
        {
            return _context.Retailer.Any(e => e.Id == id);
        }
    }
}
