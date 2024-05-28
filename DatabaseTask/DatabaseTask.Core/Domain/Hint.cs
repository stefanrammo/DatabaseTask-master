using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTask.Core.Domain
{
    public class Hint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HintId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? HintText { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string? Comment { get; set; }

        public int FirmId { get; set; }
        [ForeignKey("FirmId")]
        public virtual Firm Firm { get; set; }
    }
}
