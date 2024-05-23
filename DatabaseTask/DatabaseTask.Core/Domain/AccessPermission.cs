using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseTask.Core.Domain
{
    public class AccessPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int PermissionNumber { get; set; }

        [ForeignKey("Employee")]
        public Employee? Employee { get; set; }

        [ForeignKey("JobTitle")]
        public JobTitle? JobTitle { get; set; }

        public DateTime ValidSince { get; set; }
        public DateTime ValidUntil { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Comment { get; set; }
    }
}
