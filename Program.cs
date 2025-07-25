var builder = WebApplication.CreateBuilder(args);

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

// 👇 Isso garante que o index.html funcione na raiz
app.MapFallbackToFile("index.html");

app.Run();