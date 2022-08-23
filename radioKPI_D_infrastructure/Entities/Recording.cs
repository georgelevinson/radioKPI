using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class Recording
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string? TechNotes { get; set; }

        [Required]
        [ForeignKey("SessionId")]
        public int SessionId { get; set; }
        public Session Session { get; set; }

        [Required]
        [ForeignKey("SufflereId")]
        public int SufflereId { get; set; }
        public Sufflere Sufflere { get; set; }

        [ForeignKey("EpisodeId")]
        public int? EpisodeId { get; set; }
        public Episode? Episode { get; set; }
    }
}
