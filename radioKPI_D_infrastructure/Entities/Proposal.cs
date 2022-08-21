using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class Proposal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string? OrgNotes { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Foreign Keys and Navigation Properties

        [Required]
        [ForeignKey("GuestId")]
        public int GuestId { get; set; }
        public GuestInfo Guest { get; set; }

        [ForeignKey("SessionId")]
        public int? SessionId { get; set; }
        public Session? Session { get; set; }

        #endregion
    }
}
