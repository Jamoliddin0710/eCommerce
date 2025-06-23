using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APILayer.Filters;

public class ValidationFilter<T> : IAsyncActionFilter where T : class
{
    private readonly IValidator<T> _validator;

    public ValidationFilter(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var model = context.ActionArguments.Values.OfType<T>().FirstOrDefault();
        if (model == null)
        {
            context.Result = new BadRequestObjectResult("Model not found");
            return;
        }

        var result = await _validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            context.Result = new BadRequestObjectResult(result.Errors);
            return;
        }

        await next();
    }
}
