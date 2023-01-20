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

namespace PayementSystem.Pages.Jobs
{
    public class EditModel : JobTagPageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public EditModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Job == null)
            {
                return NotFound();
            }

            Job = await _context.Job
             .Include(b => b.JobTags).ThenInclude(b => b.Tag)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            var job =  await _context.Job.FirstOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }

            PopulateAssignedTagData(_context, Job);

            Job = job;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTags)
        {
            if (id == null)
            {
                return NotFound();
            }
            var jobToUpdate = await _context.Job
            .Include(i => i.JobTags)
            .ThenInclude(i => i.Tag)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (jobToUpdate == null)
            {
                return NotFound();
            }


            await TryUpdateModelAsync<Job>(jobToUpdate, "Job", i => i.Title);

            UpdateJobTags(_context, selectedTags, jobToUpdate);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");


            //Apelam UpdateJobTags pentru a aplica informatiile din checkboxuri la entitatea Jobs care 
            //este editata 
            UpdateJobTags(_context, selectedTags, jobToUpdate);
            PopulateAssignedTagData(_context, jobToUpdate);
            return Page();
        }
    }
}
