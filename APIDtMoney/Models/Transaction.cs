using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIDtMoney.Models;

[Table("Transactions")]
public class Transaction
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string? Type { get; set; }

    [Required]
    [StringLength(300)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(80)]
    public string? Category { get; set; }

    public DateTime CreatedAt { get; set; }
}
