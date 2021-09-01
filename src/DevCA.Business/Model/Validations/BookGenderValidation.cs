using FluentValidation;

namespace DevCA.Business.Model.Validations
{
    public class BookGenderValidation : AbstractValidator<BookGender>
    {
        public BookGenderValidation()
        {
            RuleFor(bg => bg.Name)
                .NotEmpty().WithMessage("Sorry, the field {PropertyName} must be provided")
                .Length(2, 200).WithMessage("Sorry, the field {PropertyName} must be between {MinLength} and MaxLength");
        }
    }
}