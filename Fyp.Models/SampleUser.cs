using Fyp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FYPsystem.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            // Seed Roles
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Student", NormalizedName = "STUDENT" },
                new IdentityRole { Name = "Lecturer", NormalizedName = "LECTURER" },
                new IdentityRole { Name = "Supervisor", NormalizedName = "SUPERVISOR" },
                new IdentityRole { Name = "Evaluator", NormalizedName = "EVALUATOR" }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Users
            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser { UserName = "student1@gmail.com", NormalizedUserName = "STUDENT1@GMAIL.COM", Email = "student1@gmail.com", NormalizedEmail = "STUDENT1@GMAIL.COM", Name = "John Doe", StreetAddress = "123 Main St", Nationality = "Malaysia", IcNumber = "001234567890", Gender = "Male", StudentId = 1 },
                new ApplicationUser { UserName = "student2@gmail.com", NormalizedUserName = "STUDENT2@GMAIL.COM", Email = "student2@gmail.com", NormalizedEmail = "STUDENT2@GMAIL.COM", Name = "Jane Smith", StreetAddress = "456 Elm St", Nationality = "Malaysia", IcNumber = "987654321012", Gender = "Female", StudentId = 2  },
                new ApplicationUser { UserName = "student3@gmail.com", NormalizedUserName = "STUDENT3@GMAIL.COM", Email = "student3@gmail.com", NormalizedEmail = "STUDENT3@GMAIL.COM", Name = "Michael Johnson", StreetAddress = "789 Oak St", Nationality = "Malaysia", IcNumber = "123456789012", Gender = "Male", StudentId = 3 },
                new ApplicationUser { UserName = "lecturer1@gmail.com", NormalizedUserName = "LECTURER1@GMAIL.COM", Email = "lecturer1@gmail.com", NormalizedEmail = "LECTURER1@GMAIL.COM", Name = "Dr. Emily Brown", StreetAddress = "321 Pine St", Nationality = "Malaysia", IcNumber = "098765432101", Gender = "Female", LecturerId = 1 },
                new ApplicationUser { UserName = "lecturer2@gmail.com", NormalizedUserName = "LECTURER2@GMAIL.COM", Email = "lecturer2@gmail.com", NormalizedEmail = "LECTURER2@GMAIL.COM", Name = "Dr. David Lee", StreetAddress = "654 Cedar St", Nationality = "Malaysia", IcNumber = "456789012345", Gender = "Male", LecturerId = 2 },
                new ApplicationUser { UserName = "lecturer3@gmail.com", NormalizedUserName = "LECTURER3@GMAIL.COM", Email = "lecturer3@gmail.com", NormalizedEmail = "LECTURER3@GMAIL.COM", Name = "Dr. Sophia Miller", StreetAddress = "987 Birch St", Nationality = "France", IcNumber = "876543210987", Gender = "Female", LecturerId = 3  },
                new ApplicationUser { UserName = "admin1@gmail.com", NormalizedUserName = "ADMIN1@GMAIL.COM", Email = "admin1@gmail.com", NormalizedEmail = "ADMIN1@GMAIL.COM", Name = "Admin One", StreetAddress = "123 Admin St", Nationality = "Malaysia", IcNumber = "000", Gender = "Male" },
                new ApplicationUser { UserName = "admin2@gmail.com", NormalizedUserName = "ADMIN2@GMAIL.COM", Email = "admin2@gmail.com", NormalizedEmail = "ADMIN2@GMAIL.COM", Name = "Admin Two", StreetAddress = "124 Admin St", Nationality = "Malaysia", IcNumber = "000", Gender = "Female" },
                new ApplicationUser { UserName = "admin3@gmail.com", NormalizedUserName = "ADMIN3@GMAIL.COM", Email = "admin3@gmail.com", NormalizedEmail = "ADMIN3@GMAIL.COM", Name = "Admin Three", StreetAddress = "125 Admin St", Nationality = "Malaysia", IcNumber = "000", Gender = "Male" },
                new ApplicationUser { UserName = "supervisor1@gmail.com", NormalizedUserName = "SUPERVISOR1@GMAIL.COM", Email = "supervisor1@gmail.com", NormalizedEmail = "SUPERVISOR1@GMAIL.COM", Name = "Prof. Isabella Brown", StreetAddress = "159 Elmwood St", Nationality = "India", IcNumber = "654321098765", Gender = "Female", SupervisorId = 1 },
                new ApplicationUser { UserName = "supervisor2@gmail.com", NormalizedUserName = "SUPERVISOR2@GMAIL.COM", Email = "supervisor2@gmail.com", NormalizedEmail = "SUPERVISOR2@GMAIL.COM", Name = "Ts. Noah Taylor", StreetAddress = "951 Pinecrest St", Nationality = "China", IcNumber = "567890123456", Gender = "Male", SupervisorId = 2  },
                new ApplicationUser { UserName = "supervisor3@gmail.com", NormalizedUserName = "SUPERVISOR3@GMAIL.COM", Email = "supervisor3@gmail.com", NormalizedEmail = "SUPERVISOR3@GMAIL.COM", Name = "Dr. Sophia Rodriguez", StreetAddress = "753 Birchwood St", Nationality = "Malaysia", IcNumber = "210987654321", Gender = "Female", SupervisorId = 3 },
                new ApplicationUser { UserName = "evaluator1@gmail.com", NormalizedUserName = "EVALUATOR1@GMAIL.COM", Email = "evaluator1@gmail.com", NormalizedEmail = "EVALUATOR1@GMAIL.COM", Name = "Mr. Ethan Harris", StreetAddress = "852 Cedarwood St", Nationality = "South Korea", IcNumber = "234567890123", Gender = "Male", EvaluatorId = 1  },
                new ApplicationUser { UserName = "evaluator2@gmail.com", NormalizedUserName = "EVALUATOR2@GMAIL.COM", Email = "evaluator2@gmail.com", NormalizedEmail = "EVALUATOR2@GMAIL.COM", Name = "Prof. Emma Young", StreetAddress = "753 Pine Lane", Nationality = "Malaysia", IcNumber = "765432109876", Gender = "Female", EvaluatorId = 2 },
                new ApplicationUser { UserName = "evaluator3@gmail.com", NormalizedUserName = "EVALUATOR3@GMAIL.COM", Email = "evaluator3@gmail.com", NormalizedEmail = "EVALUATOR3@GMAIL.COM", Name = "Ts. Mason Green", StreetAddress = "951 Oak Lane", Nationality = "Malaysia", IcNumber = "345678901234", Gender = "Male", EvaluatorId = 3  },
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "Test123*");
            }

            builder.Entity<ApplicationUser>().HasData(users);

            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            for (int i = 0; i < 3; i++)
            {
                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = users[i].Id,
                    RoleId = roles.First(r => r.Name == "Student").Id
                });

                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = users[i + 3].Id,
                    RoleId = roles.First(r => r.Name == "Lecturer").Id
                });

                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = users[i + 6].Id,
                    RoleId = roles.First(r => r.Name == "Admin").Id
                });

                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = users[i + 9].Id,
                    RoleId = roles.First(r => r.Name == "Supervisor").Id
                });

                userRoles.Add(new IdentityUserRole<string>
                {
                    UserId = users[i + 12].Id,
                    RoleId = roles.First(r => r.Name == "Evaluator").Id
                });
            }

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            // Seed Students, Lecturers, Supervisors, and Evaluators tables
            var students = new List<Murid>()
            {
                new Murid { StudentId = users[0].StudentId ?? 0},
                new Murid { StudentId = users[1].StudentId ?? 0},
                new Murid { StudentId = users[2].StudentId ?? 0}
            };

            var lecturers = new List<Pensyarah>()
            {
                new Pensyarah { Id = users[3].LecturerId ?? 0},
                new Pensyarah { Id = users[4].LecturerId ?? 0},
                new Pensyarah { Id = users[5].LecturerId ?? 0}
            };

            var supervisors = new List<Penyelia>()
            {
                new Penyelia { Id = users[9].SupervisorId ?? 0},
                new Penyelia { Id = users[10].SupervisorId ?? 0},
                new Penyelia { Id = users[11].SupervisorId ?? 0}
            };

            var evaluators = new List<Penilai>()
            {
                new Penilai { Id = users[12].EvaluatorId ?? 0},
                new Penilai { Id = users[13].EvaluatorId ?? 0},
                new Penilai { Id = users[14].EvaluatorId ?? 0}
            };

            builder.Entity<Murid>().HasData(students);
            builder.Entity<Pensyarah>().HasData(lecturers);
            builder.Entity<Penyelia>().HasData(supervisors);
            builder.Entity<Penilai>().HasData(evaluators);
        }
    }
}
