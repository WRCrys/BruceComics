using FluentValidation;

namespace DevCA.Business.Model.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Sorry, We need your email...")
                .Must(x => x.Contains("@"))
                .Length(7, 140).WithMessage("Well... Your email needs to has a length between {MinLength} and {MaxLength}");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage(
                    "Sorry, Your password is empty, tell us what you think, I will save your secret!")
                .Length(6, 20).WithMessage("Oh, your password needs has a length between {MinLength} and {MaxLength}");
        }
    }
}