using FluentValidation;

namespace Domain.Models.Validators;

// dotnet add package FluentValidation
public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Name).NotEmpty().Length(3, 10).WithName("Nazwa");



        RuleFor(p => p.Code).Matches(@"^\d{3}-[a-z|A-Z]{3}$").WithMessage("Podaj w formacie NNN-XXX");
        RuleFor(p => p.Salary).InclusiveBetween(100, 500);
        RuleFor(p => p.ConfirmPassword).Equal(p => p.Password);

        //  RuleFor(p => p.Newsletter).Equal(true).When(p => !string.IsNullOrEmpty(p.Email));

        RuleFor(p => p.Email).NotEmpty().EmailAddress().When(p => p.Newsletter)
            .WithMessage("Adres email jest wymagany przy zgodzie na newsletter");
    }
}
