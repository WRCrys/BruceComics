using System.Linq;
using System.Threading.Tasks;
using DevCA.Business.Interfaces;
using DevCA.Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevCa.Api.Controllers
{
    public abstract class MainController : Controller
    {
        private readonly INotificator _notificator;

        protected MainController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool ValidOperation() => !_notificator.ThereIsNotification();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificator.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyModelError(modelState);
            return CustomResponse();
        }

        protected void NotifyModelError(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMessage);

            }
        }

        protected void NotifyError(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        public virtual Task GetEntityById(long id) => null;
    }
}