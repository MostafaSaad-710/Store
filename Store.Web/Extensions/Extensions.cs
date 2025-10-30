using Microsoft.AspNetCore.Mvc;
using Store.Domain.Contracts;
using Store.Persistence;
using Store.Services;
using Store.Shared.ErrorModels;
using Store.Web.Middlewares;

namespace Store.Web.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddWebServices();


            services.AddInfrastructureServices(configuration);


            services.AddApplicationServices(configuration);


            services.Configure<ApiBehaviorOptions>(config =>
            {
                config.InvalidModelStateResponseFactory = (actionContext) =>
                {

                    var errors = actionContext.ModelState.Where(m => m.Value.Errors.Any())
                                                         .Select(m => new ValidationError()
                                                         {
                                                             Field = m.Key,
                                                             Errors = m.Value.Errors.Select(E => E.ErrorMessage)
                                                         }).ToList();


                    var response = new ValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(response);
                };
            });


            return services;
        }

        private static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }





        public static async Task<WebApplication> ConfigureMiddlewaresAsync(this WebApplication app)
        {
            // ASK From CLR

            #region Inisialize Db
            // We Call 'InitializeAsync' every time i run app so i call it in program
            using var scope = app.Services.CreateScope(); // This function creates an object from IServiceScope, which allows me to access any scoped service at runtime.
            var dbInitialize = scope.ServiceProvider.GetRequiredService<IDbInitializer>(); // Ask CLR To Create Object From IDbInitializer
            await dbInitialize.InitializeAsync();

            #endregion

            app.UseMiddleware<GlobalErrorHandlingMiddleware>();

            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }

    }
}
