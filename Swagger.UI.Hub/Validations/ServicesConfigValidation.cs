using FluentValidation;
using Swagger.UI.Hub.Models;
using System;
using System.Linq;

namespace Swagger.UI.Hub.Validations
{
    public class ServicesConfigValidation : AbstractValidator<ServicesConfig>
    {
        public ServicesConfigValidation()
        {
            RuleFor(m => m).NotNull().OnFailure(_ => throw new ArgumentException("No services configuration present"));
            RuleFor(m => m.Services).NotNull().NotEmpty().OnFailure(_ => throw new ArgumentException("No services defined"));
            When(m => m.Services != null, () =>
               {
                   RuleFor(m => m.Services).Must(s => s.GroupBy(s => s.Name).Count() == s.Count()).OnFailure(_ => throw new ArgumentException("Service configuration names must be unique"));
                   RuleFor(m => m.Services).Must(s => s.Count(s => s.Default) <= 1).OnFailure(_ => throw new ArgumentException("Only one service can be configured as default"));
               });
        }
    }
}
