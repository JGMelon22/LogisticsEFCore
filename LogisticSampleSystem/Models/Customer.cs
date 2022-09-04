using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticSampleSystem.Models;

[Table("Customer")]
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } // CustomerId

    [Column("Country", TypeName = "NVARCHAR")]
    [MaxLength(100)]
    [MinLength(4)]
    [Required]
    public string Country { get; set; }

    [Column("CustomerName", TypeName = "NVARCHAR")]
    [MaxLength(100)]
    [MinLength(3)]
    [Required]
    public string CustomerName { get; set; }
}
