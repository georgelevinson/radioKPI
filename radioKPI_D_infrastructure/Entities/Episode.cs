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

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string? ReleaseNotes { get; set; }

        public DateTime? ReleaseDate { get; set; }

        #region Foreign Keys and Navigation Properties

        [Required]
        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        public EpisodeStatus EpisodeStatus { get; set; }

        public ICollection<Recording>? Recordings { get; set; }

        #endregion

        #region Utility
        [NotMapped]
        public EpisodeStatusesEnum StatusEnum => EpisodeStatus.Description.ToEnum<EpisodeStatusesEnum>();
        #endregion
    }
}
