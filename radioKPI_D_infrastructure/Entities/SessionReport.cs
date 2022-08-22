using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class SessionReport : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ReportText { get; set; }

        [Required]
        [ForeignKey("SessionId")]
        public int SessionId { get; set; }
        public Session Session { get; set; }

        public ICollection<PartialReport> PartialReports { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }
    }
}
