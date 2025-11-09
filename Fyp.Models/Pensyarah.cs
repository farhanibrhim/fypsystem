using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Fyp.Models
{
    public class Pensyarah
    {
        public int Id { get; set; }
        public bool IsCommitteeMember { get; set; }

        public int? DomainId { get; set; } // Foreign key for Domain

        [ForeignKey("DomainId")]
        public Domain Domain { get; set; } // Navigation property for Domain

        [ForeignKey("LecturerId")]
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<LecturerProgram> LecturerPrograms { get; set; }
    }
}
