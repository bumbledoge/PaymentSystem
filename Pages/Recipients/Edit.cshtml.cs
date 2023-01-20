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

namespace PayementSystem.Pages.Recipients
{
    public class EditModel : PageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public EditModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipient Recipient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipient == null)
            {
                return NotFound();
            }

            var recipient =  await _context.Recipient.FirstOrDefaultAsync(m => m.ID == id);
            if (recipient == null)
            {
                return NotFound();
            }
            Recipient = recipient;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

            _context.Attach(Recipient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipientExists(Recipient.ID))
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

        private bool RecipientExists(int id)
        {
          return _context.Recipient.Any(e => e.ID == id);
        }
    }
}
