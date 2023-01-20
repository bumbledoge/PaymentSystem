using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PayementSystem.Data;
using PayementSystem.Models;

namespace PayementSystem.Pages.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly PayementSystem.Data.PayementSystemContext _context;

        public IndexModel(PayementSystem.Data.PayementSystemContext context)
        {
            _context = context;
        }

        public IList<Job> Job { get;set; } = default!;

        public JobData JobD { get; set; }
        public int JobID { get; set; }
        public int TagID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            JobD = new JobData();

            JobD.Jobs = await _context.Job
                                                .Include(b => b.JobTags)
                                                .ThenInclude(b => b.Tag)
                                                .AsNoTracking()
                                                .OrderBy(b => b.Title)
                                                .ToListAsync();
            if (id != null)
            {
                JobID = id.Value;
                Job job = JobD.Jobs
                .Where(i => i.ID == id.Value).Single();
                JobD.Tags = job.JobTags.Select(s => s.Tag);
            }
        }
    }
}
