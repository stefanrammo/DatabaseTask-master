using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseTask.Core.Domain
{
    public class AccessPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccessPermissionId { get; set; }

        public int PermissionNumber { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public DateTime ValidSince { get; set; }
        public DateTime ValidUntil { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [StringLength(255)]
        public string? Comment { get; set; }

        public virtual ICollection<JobTitle> JobTitles { get; set; }
    }
}
