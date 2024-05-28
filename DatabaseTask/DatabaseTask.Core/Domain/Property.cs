using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Property
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyId { get; set; }

        public int ObjectId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? ObjectLocation { get; set; }

        public DateTime PurchasingDate { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? History { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Comment { get; set; }

        public virtual ICollection<Renting> Rentings { get; set; }
    }
}
