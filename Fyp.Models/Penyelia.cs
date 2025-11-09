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
    public class Penyelia
    {
        public int Id { get; set; }

        [ForeignKey("SupervisorId")]
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Murid> Students { get; set; }

    }
}
