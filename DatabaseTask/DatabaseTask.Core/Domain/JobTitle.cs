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
        public int JobTitleId { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [StringLength(255)]
        public string? Title { get; set; } = "";

        public int Code { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        [StringLength(255)]
        public string? Unit { get; set; } = "";

        [Column(TypeName = "VARCHAR(255)")]
        public string? Comment { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public int AccessPermissionId { get; set; }
        [ForeignKey("AccessPermissionId")]
        public virtual AccessPermission AccessPermission { get; set; }

        public virtual ICollection<WorkingHistory> WorkingHistories { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } // Add this line
    }
}
