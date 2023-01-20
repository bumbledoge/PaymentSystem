using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PayementSystem.Data;
using PayementSystem.Models;

namespace PayementSystem.Pages.Payments
{
    public class CreateModel : PaymentTagsPageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public CreateModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RecipientID"] = new SelectList(_context.Set<Recipient>(), "ID", "Name");

            var payment = new Payment();
            payment.PaymentTags = new List<PaymentTag>();
            PopulateAssignedTagData(_context, payment);

            return Page();
        }

        [BindProperty]
        public Payment Payment { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedTags)
        {
            var newPayment = new Payment();
            if (selectedTags != null)
            {
                newPayment.PaymentTags = new List<PaymentTag>();
                foreach (var cat in selectedTags)
                {
                    var catToAdd = new PaymentTag
                    {
                        TagID = int.Parse(cat)
                    };
                    newPayment.PaymentTags.Add(catToAdd);
                }
            }
            //if (!(await TryUpdateModelAsync<Payment>(newPayment, "Payment",
            //        i => i.Title, i => i.Author, i => i.Price, i => i.PublishingDate, i => i.PublisherID)))
            await TryUpdateModelAsync<Payment>(newPayment, "Payment", i => i.Value, i => i.Description, i => i.PaymentDate, i => i.Recipient);
            _context.Payment.Add(newPayment);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedTagData(_context, newPayment);
            return Page();
        }
    }
}
