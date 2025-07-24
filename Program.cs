var builder = WebApplication.CreateBuilder(args);

// Ativa os controladores e CORS
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("PermitirTudo");
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers(); 
app.MapFallbackToFile("index.html");
app.Run();