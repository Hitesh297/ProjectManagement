using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

namespace ProjectManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Appointments { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<TimeSheet> Timesheets { get; set; }
    }
}