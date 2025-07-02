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

app.UseCors("PermitirTudo"); // Aplica o CORS
app.UseAuthorization();
app.MapControllers();        // Mapeia os controllers

app.Run();