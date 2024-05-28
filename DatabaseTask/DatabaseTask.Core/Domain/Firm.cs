using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Firm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FirmId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? RegistryType { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? ContactPerson { get; set; }

        [MaxLength(15)]
        public string? ContactPhone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Comment { get; set; }

        public virtual ICollection<BranchOffice> BranchOffices { get; set; }
        public virtual ICollection<Hint> Hints { get; set; }
    }
}
