using FluentValidation;
using MediatR;

namespace ControleFinanceiro.Application.Common.Behaviors
{
    public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellation)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var result = await Task.WhenAll(_validators.Select(v => 
                v.ValidateAsync(context, cancellation)));

                var failures = result.SelectMany(r => r.Errors)
                    .Where(f => f != null);

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
