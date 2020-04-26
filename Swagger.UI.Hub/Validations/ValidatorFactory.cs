using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger.UI.Hub.Validations
{
    public class ValidatorFactory: IValidatorFactory
    {
        private readonly IServiceProvider container;

        public ValidatorFactory(IServiceProvider container)
        {
            this.container = container;
        }

        public IValidator<T> GetValidator<T>()
        {
            return container.GetService(typeof(IValidator<T>)) as IValidator<T>;
        }

        public IValidator GetValidator(Type type)
        {
            var genericType = typeof(IValidator<>).MakeGenericType(type);
            return container.GetService(genericType) as IValidator;
        }
    }
}
