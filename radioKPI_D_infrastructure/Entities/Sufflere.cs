using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class Sufflere : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DataJson { get; set; }

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
        [ForeignKey("ProposalId")]
        public int ProposalId { get; set; }
        public Proposal Proposal { get; set; }

        public Session? Session { get; set; }

        public Recording? Recording { get; set; }

        #endregion

        #region Database-Generated

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        #endregion
    }
}
