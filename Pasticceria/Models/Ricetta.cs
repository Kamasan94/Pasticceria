using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pasticceria.Models
{
  public class Ricetta
  {
    [Key]
    public int RicettaId { get; set; }

    [Column(TypeName = "int")]
    public int DolceId { get; set; }

    [Column(TypeName = "int")]
    public int IngredienteId { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal Quantita { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public string UM { get; set; }
  }
}
