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

        public PaymentData PaymentD { get; set; }
        public int PaymentID { get; set; }
        public int TagID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            PaymentD = new PaymentData();

            PaymentD.Payments = await _context.Payment
                                                .Include(b => b.Recipient)
                                                .Include(b => b.PaymentTags)
                                                .ThenInclude(b => b.Tag)
                                                .AsNoTracking()
                                                .OrderBy(b => b.Value)
                                                .ToListAsync();
            if (id != null)
            {
                PaymentID = id.Value;
                Payment book = PaymentD.Payments
                .Where(i => i.ID == id.Value).Single();
                PaymentD.Tags = book.PaymentTags.Select(s => s.Tag);
            }
        }
    }
}
