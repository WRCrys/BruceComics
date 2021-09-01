using System.ComponentModel.DataAnnotations;
using DevCA.Business.Interfaces;
using DevCA.Business.Model;
using DevCA.Business.Notifications;
using FluentValidation;

namespace DevCA.Business.Services
{
    public class BaseService
    {
        private readonly INotificator _notificator;

        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notify(ValidationResult validationResult)
        {
            Notify(validationResult.ErrorMessage);
        }

        protected void Notify(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            foreach (var error in validator.Errors)
            {
                Notify(error.ErrorMessage);
            }

            return false;
        }
    }
}