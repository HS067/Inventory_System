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

namespace Inventory_System.Pages.Registration
{
    public class EditModel : PageModel
    {
        private readonly Inventory_System.Data.Inventory_SystemContext _context;

        public EditModel(Inventory_System.Data.Inventory_SystemContext context)
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
           ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
           ViewData["RetailerId"] = new SelectList(_context.Retailer, "Id", "Id");
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

            _context.Attach(Registeration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterationExists(Registeration.Id))
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

        private bool RegisterationExists(int id)
        {
            return _context.Registeration.Any(e => e.Id == id);
        }
    }
}
