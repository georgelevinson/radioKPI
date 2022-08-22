using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using radioKPI_C_domain.Enums;

namespace radioKPI_D_infrastructure.Entities
{
    public class ProdProcess : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public StatusesEnum StatusEnum => Status.Description.ToEnum<StatusesEnum>();

        [Required]
        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        public ProcessStatus Status { get; set; }

        [Required]
        [ForeignKey("GuestInfoId")]
        public int GuestInfoId { get; set; }
        public GuestInfo GuestInfo { get; set; }

        [ForeignKey("ProposalId")]
        public int? ProposalId { get; set; }
        public Proposal? Proposal { get; set; }

        [ForeignKey("SufflereId")]
        public int? SufflereId { get; set; }
        public Sufflere? Sufflere { get; set; }

        [ForeignKey("SessionId")]
        public int? SessionId { get; set; }
        public Session? Session { get; set; }

        [ForeignKey("SessionReportId")]
        public int? SessionReportId { get; set; }
        public SessionReport? SessionReport { get; set; }
    }
}
