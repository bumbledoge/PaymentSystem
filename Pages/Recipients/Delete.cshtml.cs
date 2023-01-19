using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PayementSystem.Data;
using PayementSystem.Models;

namespace PayementSystem.Pages.Recipients
{
    public class DeleteModel : PageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public DeleteModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Recipient Recipient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recipient == null)
            {
                return NotFound();
            }

            var recipient = await _context.Recipient.FirstOrDefaultAsync(m => m.ID == id);

            if (recipient == null)
            {
                return NotFound();
            }
            else 
            {
                Recipient = recipient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Recipient == null)
            {
                return NotFound();
            }
            var recipient = await _context.Recipient.FindAsync(id);

            if (recipient != null)
            {
                Recipient = recipient;
                _context.Recipient.Remove(Recipient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
