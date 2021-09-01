using FluentValidation;

namespace DevCA.Business.Model.Validations
{
    public class ReserveValidation : AbstractValidator<Reserve>
    {
        public ReserveValidation()
        {
            RuleFor(r => r.Returned)
                .NotEmpty().WithMessage("Well... the reserve needs to return...");
        }
    }
}