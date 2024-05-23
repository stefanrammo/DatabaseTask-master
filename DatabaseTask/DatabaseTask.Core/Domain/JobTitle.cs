using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseTask.Core.Domain
{
    public class JobTitle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [StringLength(255)]
        public string? Title { get; set; } = "";

        public int Code { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [StringLength(255)]
        public string? Unit { get; set; } = "";

        [Column(TypeName = "VARCHAR(255)")]
        public string? Comment { get; set; }

        [ForeignKey("Employee")]
        public Employee? Employee { get; set; }

        public ICollection<WorkingHistory> WorkingHistories { get; set; } = new HashSet<WorkingHistory>();
        public ICollection<AccessPermission> AccessPermissions { get; set; } = new HashSet<AccessPermission>();
    }
}
