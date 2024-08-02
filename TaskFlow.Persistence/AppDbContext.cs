using Microsoft.EntityFrameworkCore;
using System;
using TaskFlow.Domain;

namespace TaskFlow.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Note> Notes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}
