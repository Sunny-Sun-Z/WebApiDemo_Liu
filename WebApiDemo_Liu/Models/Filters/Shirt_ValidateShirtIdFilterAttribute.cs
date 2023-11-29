using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo_Liu.Models.Repositories;

namespace WebApiDemo_Liu.Models.Filters
{
    public class Shirt_ValidateShirtIdFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var shirtId = context.ActionArguments["id"] as int?;
            if (shirtId.HasValue)
            {
                if (shirtId.Value <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId is invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    // Below actually not needed but nice to know.
                    {
                        Status = StatusCodes.Status400BadRequest
                    }
                    ;
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
                else if (!ShirtRepository.ShirtsExists(shirtId.Value))
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt not exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    // Below actually not needed but nice to know.
                    {
                        Status = StatusCodes.Status404NotFound
                    };

                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
