using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PayementSystem.Data;
using PayementSystem.Models;

namespace PayementSystem.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public IndexModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        public IList<Payment> Payment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Payment = await _context.Payment.Include(b => b.Recipient).ToListAsync();
            
        }
    }
}
