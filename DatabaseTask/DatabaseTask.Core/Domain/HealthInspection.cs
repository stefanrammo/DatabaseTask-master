﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class HealthInspection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Employee")]
        public Employee? Employee { get; set; }

        public DateTime LastInspection { get; set; }
        public DateTime NewInspectionDate { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Comment { get; set; }
    }
}
