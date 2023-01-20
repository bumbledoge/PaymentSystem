using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayementSystem.Models;

namespace PayementSystem.Data
{
    public class PayementSystemContext : DbContext
    {
        public PayementSystemContext (DbContextOptions<PayementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<PayementSystem.Models.Payment> Payment { get; set; } = default!;

        public DbSet<PayementSystem.Models.Recipient> Recipient { get; set; }

        public DbSet<PayementSystem.Models.Tag> Tag { get; set; }

        public DbSet<PayementSystem.Models.Job> Job { get; set; }
    }
}
