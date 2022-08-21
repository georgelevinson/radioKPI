using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime RecordingDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Foreign Keys and Navigation Properties

        [Required]
        [ForeignKey("ProposalId")]
        public int ProposalId { get; set; }
        public Proposal Proposal { get; set; }

        [Required]
        [ForeignKey("SufflereId")]
        public int SufflereId { get; set; }
        public Sufflere Sufflere { get; set; }

        [ForeignKey("ReportId")]
        public int? ReportId { get; set; }
        public SessionReport? Report { get; set; }

        //[Required]
        //public int RecEngineerUserId { get; set; }
        //public ApplicationUser RecEngineer { get; set; }

        //[Required]
        //public int RecEngineerUserId { get; set; }
        //public ApplicationUser Videograph { get; set; }

        public ICollection<PartialReport>? PartialReports { get; set; }

        #endregion
    }
}
