using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inventory_System.Data;
using Inventory_System.Models;

namespace Inventory_System.Pages.Registration
{
    public class CreateModel : PageModel
    {
        private readonly Inventory_System.Data.Inventory_SystemContext _context;

        public CreateModel(Inventory_System.Data.Inventory_SystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
        ViewData["RetailerId"] = new SelectList(_context.Retailer, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Registeration Registeration { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Registeration.Add(Registeration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
