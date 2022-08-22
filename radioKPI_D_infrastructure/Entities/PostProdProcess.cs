﻿using radioKPI_C_domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace radioKPI_D_infrastructure.Entities
{
    public class PostProdProcess : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        public ProcessStatus Status { get; set; }

        public Episode Episode { get; set; }

        //[Required]
        //[ForeignKey("AudioEngineerId")]
        //public int AudioEngineerId { get; set; }
        //public ApplicationUser AudioEngineer { get; set; }

        //[Required]
        //[ForeignKey("VideoEditorId")]
        //public int VideoEditorId { get; set; }
        //public ApplicationUser VideoEditorId { get; set; }

        public ICollection<Session> Sessions { get; set; }

        #region Utility
        [NotMapped]
        public ProcessStatusesEnum StatusEnum => Status.Description.ToEnum<ProcessStatusesEnum>();
        #endregion
    }
}