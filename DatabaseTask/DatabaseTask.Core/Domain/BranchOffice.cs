using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace DatabaseTask.Core.Domain
{
    public class BranchOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchOfficeId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Address { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? ContactPerson { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Comment { get; set; }

        public int FirmId { get; set; }
        [ForeignKey("FirmId")]
        public virtual Firm Firm { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
