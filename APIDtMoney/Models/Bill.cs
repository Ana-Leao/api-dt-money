using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIDtMoney.Models;

[Table("Bills")]
public class Bill
{
    [Key]
    public int BillId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Type { get; set; }

    [Required]
    [StringLength(300)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Value { get; set; }

    [Required]
    [StringLength(80)]
    public string? Category { get; set; }

    public DateTime Date { get; set; }
}
