using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using radioKPI_C_domain.Enums;

namespace radioKPI_D_infrastructure.Entities
{
    [Table("Episodes")]
    public class Episode : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public string? ReleaseNotes { get; set; }

        [NotMapped]
        public StatusesEnum StatusEnum => Status.Description.ToEnum<StatusesEnum>();

        [Required]
        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        public ProcessStatus Status { get; set; }

        [ForeignKey("PostProdProcessId")]
        public int PostProdProcessId { get; set; }
        public PostProdProcess PostProdProcess { get; set; }

        public ICollection<ProdProcess> ProductionProcesses { get; set; }
    }
}
