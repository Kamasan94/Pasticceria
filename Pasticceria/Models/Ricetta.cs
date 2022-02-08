using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pasticceria.Models
{
  public class Ricetta
  {
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "int")]
    public int DolceId { get; set; }

    [Column(TypeName = "int")]
    public int IngredienteId { get; set; }

    [Column(TypeName = "int")]
    public int Quantita { get; set; }

    [Column(TypeName = "nvarchar(10)")]
    public int UM { get; set; }
  }
}
