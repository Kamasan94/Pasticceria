using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pasticceria.Models
{
  public class Ingrediente
  {
    [Key]
    public int IngredienteId { get; set; } 

    [Column(TypeName = "nvarchar(100)")]
    public string? Nome { get; set; }

   //public virtual ICollection<Ricetta>? Ricetta { get; set; }
  }
}
