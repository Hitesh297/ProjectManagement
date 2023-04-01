using Microsoft.AspNetCore.Identity;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Seed Roles
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name.ToUpper();

            var employeeRole = new IdentityRole("Employee");
            employeeRole.NormalizedName = employeeRole.Name.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>() {
            adminRole,
            employeeRole
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var adminUser = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "password");

            var employeeUser = new IdentityUser
            {
                UserName = "employee@gmail.com",
                Email = "employee@gmail.com",
                EmailConfirmed = true,
            };
            employeeUser.NormalizedUserName = employeeUser.UserName.ToUpper();
            employeeUser.NormalizedEmail = employeeUser.Email.ToUpper();
            employeeUser.PasswordHash = passwordHasher.HashPassword(employeeUser, "password");

            List<IdentityUser> users = new List<IdentityUser>() {
                adminUser,
                employeeUser,
            };

            modelBuilder.Entity<IdentityUser>().HasData(users);

            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "Employee").Id
            });


            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            base.OnModelCreating(modelBuilder);
        }
    }


}