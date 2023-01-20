using Microsoft.AspNetCore.Mvc.RazorPages;
using PayementSystem.Data;

namespace PayementSystem.Models
{
    public class PaymentTagsPageModel : PageModel
    {
        public List<AssignedTagData> AssignedTagDataList;
        public void PopulateAssignedTagData(PayementSystemContext context,
        Payment payment)
        {
            var allTags = context.Tag;
            var paymentTags = new HashSet<int>(
            payment.PaymentTags.Select(c => c.TagID));
            AssignedTagDataList = new List<AssignedTagData>();
            foreach (var cat in allTags)
            {
                AssignedTagDataList.Add(new AssignedTagData
                {
                    TagID = cat.ID,
                    Name = cat.TagName,
                    Assigned = paymentTags.Contains(cat.ID)
                });
            }
        }
        public void UpdatePaymentTags(PayementSystemContext context,
        string[] selectedTags, Payment paymentToUpdate)
        {
            if (selectedTags == null)
            {
                paymentToUpdate.PaymentTags = new List<PaymentTag>();
                return;
            }
            var selectedTagsHS = new HashSet<string>(selectedTags);
            var paymentTags = new HashSet<int>
            (paymentToUpdate.PaymentTags.Select(c => c.Tag.ID));
            foreach (var cat in context.Tag)
            {
                if (selectedTagsHS.Contains(cat.ID.ToString()))
                {
                    if (!paymentTags.Contains(cat.ID))
                    {
                        paymentToUpdate.PaymentTags.Add(
                        new PaymentTag
                        {
                            PaymentID = paymentToUpdate.ID,
                            TagID = cat.ID
                        });
                    }
                }
                else
                {
                    if (paymentTags.Contains(cat.ID))
                    {
                        PaymentTag courseToRemove = paymentToUpdate
                                                        .PaymentTags
                                                        .SingleOrDefault(i => i.TagID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
