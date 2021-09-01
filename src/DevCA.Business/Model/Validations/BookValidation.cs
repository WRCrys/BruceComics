using FluentValidation;

namespace DevCA.Business.Model.Validations
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Sorry, the field {PropertyName} must be provided")
                .Length(2, 200).WithMessage("Sorry, the field {PropertyName} must be between {MinLength} and MaxLength");

            RuleFor(b => b.Synopsis)
                .NotEmpty().WithMessage("Sorry, the field {PropertyName} must be provided")
                .MinimumLength(2).WithMessage("Well, the minimum length for the field {PropertyName} is {MinLength}");
        }
    }
}