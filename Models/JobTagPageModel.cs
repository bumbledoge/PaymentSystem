using Microsoft.AspNetCore.Mvc.RazorPages;
using PayementSystem.Data;

namespace PayementSystem.Models
{
    public class JobTagPageModel : PageModel
    {
        public List<AssignedTagData> AssignedTagDataList;
        public void PopulateAssignedTagData(PayementSystemContext context,
        Job job)
        {
            var allTags = context.Tag;
            var jobTags = new HashSet<int>(
            job.JobTags.Select(c => c.TagID));
            AssignedTagDataList = new List<AssignedTagData>();
            foreach (var cat in allTags)
            {
                AssignedTagDataList.Add(new AssignedTagData
                {
                    TagID = cat.ID,
                    Name = cat.TagName,
                    Assigned = jobTags.Contains(cat.ID)
                });
            }
        }
        public void UpdateJobTags(PayementSystemContext context,
        string[] selectedTags, Job jobToUpdate)
        {
            if (selectedTags == null)
            {
                jobToUpdate.JobTags = new List<JobTag>();
                return;
            }
            var selectedTagsHS = new HashSet<string>(selectedTags);
            var jobTags = new HashSet<int>
            (jobToUpdate.JobTags.Select(c => c.Tag.ID));
            foreach (var cat in context.Tag)
            {
                if (selectedTagsHS.Contains(cat.ID.ToString()))
                {
                    if (!jobTags.Contains(cat.ID))
                    {
                        jobToUpdate.JobTags.Add(
                        new JobTag
                        {
                            JobID = jobToUpdate.ID,
                            TagID = cat.ID
                        });
                    }
                }
                else
                {
                    if (jobTags.Contains(cat.ID))
                    {
                        JobTag courseToRemove = jobToUpdate
                                                        .JobTags
                                                        .SingleOrDefault(i => i.TagID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
