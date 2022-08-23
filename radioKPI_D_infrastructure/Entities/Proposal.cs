using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class Proposal : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string? OrgNotes { get; set; }

        #region Foreign Keys and Navigation Properties

        //[Required]
        //[ForeignKey("CreatedById")]
        //public int CreatedById { get; set; }
        //public User CreatedById { get; set; }

        //[Required]
        //[ForeignKey("UpdatedById")]
        //public int UpdatedById { get; set; }
        //public User UpdatedById { get; set; }

        [Required]
        [ForeignKey("GuestId")]
        public int GuestId { get; set; }
        public GuestInfo Guest { get; set; }

        public Session? Session { get; set; }

        public Sufflere? Sufflere { get; set; }

        #endregion

        #region Database-Generated

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        #endregion
    }
}
