using radioKPI_C_domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Entities
{
    public class GuestInfo : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string PlacesOfWorkOrStudy { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string JobTitlesOrSpecializations { get; set; }

        public string? GuestDetails { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Foreign Keys and Navigation Properties

        //[Required]
        //[ForeignKey("GuestId")]
        //public int GuestId { get; set; }
        //public User Guest { get; set; }

        //[Required]
        //[ForeignKey("ManagerId")]
        //public int ManagerId { get; set; }
        //public User Manager { get; set; }

        //[Required]
        //[ForeignKey("CreatedById")]
        //public int CreatedById { get; set; }
        //public User CreatedById { get; set; }

        //[Required]
        //[ForeignKey("UpdatedById")]
        //public int UpdatedById { get; set; }
        //public User UpdatedById { get; set; }

        public Proposal? Proposal { get; set; }

        public ProdProcess? MyProperty { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        #endregion
    }
}
