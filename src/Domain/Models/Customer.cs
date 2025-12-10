namespace Domain.Models;

public class Customer : BaseEntity
{    
    public string Name { get; set; }
    public string Email { get; set; }
    public Region? Region { get; set; }
    public string Code { get; set; }
    public DateTime? Birthday { get; set; }
    public decimal Salary { get; set; }
    public bool IsArchived { get; set; }
}
