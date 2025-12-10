using FluentValidation;

namespace Domain.Models.Validators;

// dotnet add package FluentValidation
public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Name).NotEmpty().Length(3, 10);
        RuleFor(p => p.Email).EmailAddress();
        RuleFor(p => p.Code).Matches(@"^\d{3}-[a-z|A-Z]{3}$").WithMessage("Podaj w formacie NNN-XXX");
        RuleFor(p => p.Salary).InclusiveBetween(100, 500);
        RuleFor(p => p.ConfirmPassword).Equal(p => p.Password);
    }
}
