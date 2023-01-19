using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayementSystem.Data;
using PayementSystem.Models;

namespace PayementSystem.Pages.Payments
{
    public class EditModel : PageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public EditModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }

            var payment =  await _context.Payment.FirstOrDefaultAsync(m => m.ID == id);
            if (payment == null)
            {
                return NotFound();
            }
            Payment = payment;

            ViewData["RecipientID"] = new SelectList(_context.Set<Recipient>(), "ID", "Name");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Payment).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool PaymentExists(int id)
        {
          return _context.Payment.Any(e => e.ID == id);
        }
    }
}
