using Scalar.AspNetCore;
using SLRPBackend.Data;
using SLRPBackend.Extension;

public sealed class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        
#if DEBUG
        builder.Services.AddCors(o => o.AddPolicy("AllOrigins", builder =>
        {
            builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        }));
#endif
        
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddExtraServices();
        builder.Services.Configure<AuthServiceOptions>(builder.Configuration.GetSection("AuthServiceOptions"));
        
        WebApplication app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }
        
#if DEBUG
        app.UseCors("AllOrigins");
#endif
        
        app.UseHttpsRedirection();
        //app.UseAuthentication();
        app.MapControllers();
        app.Run();
    }
}