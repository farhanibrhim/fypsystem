using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fyp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        [Display(Name = "IC Number")]
        public string IcNumber { get; set; }

        [Required]
        public string Gender { get; set; }

        // Navigation properties for associated roles

        public Pensyarah Lecturer { get; set; }

        public Penilai Evaluator { get; set; }

        public Penyelia Supervisor { get; set; }

        public Murid Student { get; set; }

        // Foreign key properties for associated roles

        [ForeignKey("Lecturer")]
        public int? LecturerId { get; set; }

        [ForeignKey("Evaluator")]
        public int? EvaluatorId { get; set; }

        [ForeignKey("Supervisor")]
        public int? SupervisorId { get; set; }

        [ForeignKey("Student")]
        public int? StudentId { get; set; }

        // Additional property for role (not stored in database)

        [NotMapped]
        public string Role { get; set; }
    }
}
