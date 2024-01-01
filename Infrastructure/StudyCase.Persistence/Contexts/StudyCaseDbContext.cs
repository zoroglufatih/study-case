using Microsoft.EntityFrameworkCore;
using StudyCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Persistence.Contexts
{
    public class StudyCaseDbContext : DbContext
    {
        public StudyCaseDbContext(DbContextOptions<StudyCaseDbContext> options) : base(options)
        { }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().HasData(
                new Developer() { Id = 1, Name = "Developer 1", Difficulty = 1, Duration = 1, TotalWorkDone = 0 },
                new Developer() { Id = 2, Name = "Developer 2", Difficulty = 2, Duration = 1, TotalWorkDone = 0 },
                new Developer() { Id = 3, Name = "Developer 3", Difficulty = 3, Duration = 1, TotalWorkDone = 0 },
                new Developer() { Id = 4, Name = "Developer 4", Difficulty = 4, Duration = 1, TotalWorkDone = 0 },
                new Developer() { Id = 5, Name = "Developer 5", Difficulty = 5, Duration = 1, TotalWorkDone = 0 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
