using EduHome.Business.Abstractions.Exceptions;

namespace EduHome.Presentation.Extensions;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            string message = "Xəta baş verdi";

            if (e is IBaseException)
            {
                message = e.Message;
            }

            string errorPath = $"/Home/Error?message={message}";

            context.Response.Redirect(errorPath);
        }
    }
}
