using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Customer : BaseEntity
{
    [Required, StringLength(maximumLength: 10, MinimumLength = 3)]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public Region? Region { get; set; }
    [RegularExpression(@"^\d{3}-[a-z|A-Z]{3}$", ErrorMessage = "Podaj w formacie NNN-XXX")]
    public string Code { get; set; }
    public DateTime? Birthday { get; set; }
    [Range(minimum: 100, maximum: 500)]
    public decimal Salary { get; set; }
    public bool IsArchived { get; set; }
}
