using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pasticceria.Models
{
  public class Vetrina
  {
    [Key]
    public int VetrinaId { get; set; }

    [Column(TypeName = "int")]
    public int DolceId { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal Prezzo { get; set; }

    [Column(TypeName = "int")]
    public int Quantita { get; set; }

    [Column(TypeName = "date")]
    public DateTime MessaInVendita { get; set; }
    
  }
}
