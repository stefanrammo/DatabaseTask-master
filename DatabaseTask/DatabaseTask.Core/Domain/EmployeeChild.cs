﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class EmployeeChild
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Employee")]
        public Employee? Employee { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Surname { get; set; }

        public int PID { get; set; }

        public int Age { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Comment { get; set; }
    }
}
