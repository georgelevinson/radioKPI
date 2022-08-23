using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class GuestSubject
    {
        [Required]
        [ForeignKey("GuestId")]
        public int GuestId { get; set; }
        public GuestInfo Guest { get; set; }

        [Required]
        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
