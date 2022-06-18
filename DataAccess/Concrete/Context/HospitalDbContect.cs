using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class HospitalDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database= HospitalDb; integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Email = "admin@admin.com", FirstName = "Admin", LastName = "Admin", Password = "Test123!", PasswordRepeat = "Test123!", RoleId = 1 },
                new User { UserId = 2, Email = "personnel@personnel.com", FirstName = "Personnel", LastName = "Personnel", Password = "Test123!", PasswordRepeat = "Test123!", RoleId = 2 });
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Personnel" });
            modelBuilder.Entity<Hospital>().HasData(
                new Hospital { HospitalId = 1, HospitalName = "Şişli Etfal" },
                new Hospital { HospitalId = 2, HospitalName = "Okmeydanı Eğitim Araştırma" });
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, DoctorFullName = "Ahmet Yılmaz" },
                new Doctor { DoctorId = 2, DoctorFullName = "Ayşe Demir" });
            modelBuilder.Entity<Branch>().HasData(
                new Branch { BranchId = 1, BranchName = "Ortopedi" },
                new Branch { BranchId = 2, BranchName = "Genel Cerrahi" });
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<TaskModel> TaskModels { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
