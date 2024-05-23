using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseTask.Core.Domain
{
    public class WorkingHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid JobTitleId { get; set; }
        [ForeignKey(nameof(JobTitleId))]
        public JobTitle? JobTitle { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("Employee")]
        public Employee? Employee { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Comment { get; set; }

        public ICollection<JobTitle> JobTitles { get; set; } = new HashSet<JobTitle>();
    }
}