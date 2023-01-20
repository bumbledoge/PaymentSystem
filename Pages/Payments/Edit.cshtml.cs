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
    public class EditModel : PaymentTagsPageModel
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

            Payment = await _context.Payment
             .Include(b => b.Recipient)
             .Include(b => b.PaymentTags).ThenInclude(b => b.Tag)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            var payment =  await _context.Payment.FirstOrDefaultAsync(m => m.ID == id);
            if (payment == null)
            {
                return NotFound();
            }
            PopulateAssignedTagData(_context, Payment);

            ViewData["RecipientID"] = new SelectList(_context.Set<Recipient>(), "ID", "Name");

            Payment = payment;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTags)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paymentToUpdate = await _context.Payment
                .Include(i => i.Recipient)
                .Include(i => i.PaymentTags)
                .ThenInclude(i => i.Tag)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (paymentToUpdate == null)
            {
                return NotFound();
            }


            await TryUpdateModelAsync<Payment>(paymentToUpdate, "Payment", i => i.Value, i => i.Description, i => i.PaymentDate, i => i.Recipient);

            UpdatePaymentTags(_context, selectedTags, paymentToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");


            //Apelam UpdatePaymentTags pentru a aplica informatiile din checkboxuri la entitatea Payments care 
            //este editata 
            UpdatePaymentTags(_context, selectedTags, paymentToUpdate);
            PopulateAssignedTagData(_context, paymentToUpdate);
            return Page();
        }
    }
}
