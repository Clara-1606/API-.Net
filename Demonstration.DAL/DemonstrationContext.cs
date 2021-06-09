using Demonstration.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demonstration.DAL
{
    public class DemonstrationContext : DbContext
    {
        public DemonstrationContext(DbContextOptions<DemonstrationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TaskModel> Tasks { get; set; }
    }
}
