using Microsoft.AspNetCore.Authentication.JwtBearer;
using SimpleRestApi.Middleware;
using SimpleRestApi.Options;

namespace SimpleRestApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureServices(builder.Configuration);

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<BasicGlobalErrorHandling>();

            app.MapControllers();

            app.Run();
        }
    }
}
