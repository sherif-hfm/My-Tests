using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace SqlDAL
{
    [Table("Attachments")]
    public partial class Attachments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AttachmentID { get; set; }
       
        public long MomraLicenseId { get; set; }

        public long RequestNumber { get; set; }

        public int RequestYear { get; set; }

        [Required]
        [StringLength(500)]
        public string AtachmentURL { get; set; }

        public bool IsSaved { get; set; }
    }
}
