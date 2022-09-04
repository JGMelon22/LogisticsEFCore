using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSampleSystem.Models;

[Table("ProductBudget")]
public class ProductBudget
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // ProductId

    [Column("Country", TypeName = "NVARCHAR")]
    [MaxLength(100)]
    [MinLength(4)]
    [Required]
    public string Country { get; set; }

    [Column("Budget", TypeName = "FLOAT")]
    [Range(float.Epsilon, float.MaxValue)]
    [Required]
    public float Budget { get; set; }
}