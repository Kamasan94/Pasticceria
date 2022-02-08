using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pasticceria.Models
{
    public class Dolce
    {
        [Key]
        public int DolceId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Nome { get; set; }
        
        public virtual ICollection<Ricetta>? Ricetta { get; set; }
        public virtual ICollection<Vetrina>? Vetrina { get; set; }

  }
}
