using FluentValidation;
using Microsoft.Extensions.Options;
using Swagger.UI.Hub.Models;
using System.Linq;


namespace Swagger.UI.Hub.Validations
{
    public class ServicesConfigValidation : AbstractValidator<ServicesConfig>
    {
        public ServicesConfigValidation()
        {
            RuleFor(m => m).NotNull().WithMessage("No services configuration present");
            RuleFor(m => m.Services).NotNull().NotEmpty().WithMessage("No services defined");
            When(m => m.Services != null, () =>
               {
                   RuleFor(m => m.Services).Must(s => s.GroupBy(s => s.Name).Count() == s.Count()).WithMessage("Service configuration names must be unique");
                   RuleFor(m => m.Services).Must(s => s.Count(s => s.Default) <= 1).WithMessage("Only one service can be configured as default");
               });
        }
    }
}
