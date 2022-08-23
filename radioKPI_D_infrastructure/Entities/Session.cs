using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class Session : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime RecordingDate { get; set; }

        #region Foreign Keys and Navigation Properties

        //[Required]
        //[ForeignKey("CreatedById")]
        //public int CreatedById { get; set; }
        //public User CreatedById { get; set; }

        //[Required]
        //[ForeignKey("UpdatedById")]
        //public int UpdatedById { get; set; }
        //public User UpdatedById { get; set; }

        //[Required]
        //public int RecEngineerUserId { get; set; }
        //public ApplicationUser RecEngineer { get; set; }

        //[Required]
        //public int RecEngineerUserId { get; set; }
        //public ApplicationUser Videograph { get; set; }

        public SessionReport? Report { get; set; }

        public ICollection<PartialReport>? PartialReports { get; set; }

        public ICollection<Recording> Recordings { get; set; }

        public ICollection<Sufflere> Suffleres { get; set; }

        #endregion

        #region Database-Generated

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        #endregion
    }
}
