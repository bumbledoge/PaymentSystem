using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PayementSystem.Data;
using PayementSystem.Models;

namespace PayementSystem.Pages.Jobs
{
    public class CreateModel : JobTagPageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public CreateModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var job = new Job();
            job.JobTags = new List<JobTag>();
            PopulateAssignedTagData(_context, job);

            return Page();
        }

        [BindProperty]
        public Job Job { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedTags)
        {
            var newJob = new Job();
            if (selectedTags != null)
            {
                newJob.JobTags = new List<JobTag>();
                foreach (var cat in selectedTags)
                {
                    var catToAdd = new JobTag
                    {
                        TagID = int.Parse(cat)
                    };
                    newJob.JobTags.Add(catToAdd);
                }
            }

            await TryUpdateModelAsync<Job>(newJob, "Job", i => i.Title);
            _context.Job.Add(newJob);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedTagData(_context, newJob);
            return Page();
        }
    }
}
