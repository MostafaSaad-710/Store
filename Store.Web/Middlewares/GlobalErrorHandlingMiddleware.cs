using Store.Shared.ErrorModels;

namespace Store.Web.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next) // Address of next middleware
        {
            _next = next;
        }

        //functions for (logic of Response or request)
        public async Task InvokeAsync(HttpContext context) /*context represent Request and response*/
        {
            try
            {
                await _next.Invoke(context);
                if(context.Response.StatusCode == 404) // routing middleware
                {
                    context.Response.ContentType = "application/json";
                    var response = new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        ErrorMessage = $"endpoint {context.Request.Path} was not found !!"
                    };
                    await context.Response.WriteAsJsonAsync(response);

                }

            }
            catch( Exception ex )
            {
                // Logic

                // 1. Set Stutas Code Of Response
                context.Response.StatusCode = ex switch
                {
                    DirectoryNotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                // 2. Set Contant Type Of Response
                context.Response.ContentType = "application/json";

                // 3. Set Body Of Response

                var response = new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = ex.Message
                };

                // return response

                await context.Response.WriteAsJsonAsync(response);  
            }

        }

    }
}
