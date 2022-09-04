using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSampleSystem.Models;

[Table("Order")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // OrderId

    [Column("Quantity", TypeName = "INT")]
    [MaxLength(999)]
    [MinLength(1)]
    [Required]
    public int Quantity { get; set; }

    // FK's and Navigation Properties
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }


    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
    public ProductBudget Product { get; set; }
}
