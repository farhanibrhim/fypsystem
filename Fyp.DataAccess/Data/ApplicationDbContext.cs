using Fyp.Models;
using FYPsystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyp.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AcademicProgram> AcademicPrograms { get; set; }

        public DbSet<Pensyarah> Lecturers { get; set; }
        public DbSet<Murid> Students { get; set; }
        public DbSet<Penyelia> Supervisors { get; set; }
        public DbSet<Penilai> Evaluators { get; set; }
        public DbSet<LecturerProgram>  LecturerPrograms { get; set; }
        public DbSet<Domain> Domains { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<ProjectType> ProjectTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LecturerProgram>()
            .HasKey(lp => new { lp.LecturerId, lp.AcademicProgramId });

            modelBuilder.Entity<AcademicProgram>()
                .HasData(
                new AcademicProgram { Id = 1, Name = "Software Engineering" },
                new AcademicProgram { Id = 2, Name = "Data Engineering" }
                );

            modelBuilder.Entity<Domain>()
                .HasData(
                new Domain { Id = 1, Name = "Research" },
                new Domain { Id = 2, Name = "Development" }
                );

            modelBuilder.Entity<ProjectType>()
                .HasData(
                new ProjectType { Id = 1, Name = "Research" },
                new ProjectType { Id = 2, Name = "Development" }
                );

            modelBuilder.Entity<Murid>()
            .HasOne(m => m.Proposal)
            .WithOne(p => p.Murid)
            .HasForeignKey<Proposal>(p => p.MuridId);
        }
    }
}
