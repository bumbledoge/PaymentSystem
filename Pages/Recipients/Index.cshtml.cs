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
    public class IndexModel : PageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public IndexModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        public IList<Recipient> Recipient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Recipient = await _context.Recipient.Include(b => b.Job).ToListAsync();
            
        }
    }
}
