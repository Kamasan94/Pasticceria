using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pasticceria.Models
{
  public class TabellaTest
  {
    [Key]
    public int TestId { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public string? Nome { get; set; }


  }
}
