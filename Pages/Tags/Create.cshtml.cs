﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PayementSystem.Data;
using PayementSystem.Models;

namespace PayementSystem.Pages.Tags
{
    public class CreateModel : PageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public CreateModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tag Tag { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tag.Add(Tag);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
