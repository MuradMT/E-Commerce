using FluentValidation;
using MediatR;

namespace E_Commerce_Backend.Application.Behaviors;

public class FluentValidationBehaviour<TRequest,TResponse>
    (IEnumerable<IValidator<TRequest>> _validator):IPipelineBehavior<TRequest,TResponse>
where TRequest:IRequest<TResponse>
{

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validator
            .Select(v=>v.Validate(context))
            .SelectMany(result=>result.Errors)
            .GroupBy(x=>x.ErrorMessage)
            .Select(x=>x.First())
            .Where(f=> f is not null)
            .ToList();
        if (failures.Any()) 
            throw new FluentValidation.ValidationException(failures);
        return next();
    }
}