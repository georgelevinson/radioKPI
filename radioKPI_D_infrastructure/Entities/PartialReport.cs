using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class PartialReport : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ReportText { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        #region Foreign Keys and Navigation Properties

        [Required]
        [ForeignKey("SessionId")]
        public int SessionId { get; set; }
        public Session Session { get; set; }

        //[Required]
        //[ForeignKey("SubmitterId")]
        //public int SubmitterId { get; set; }
        //public ApplicationUser Submitter { get; set; }

        #endregion
        #region Foreign Keys and Navigation Properties
        #endregion
    }
}
