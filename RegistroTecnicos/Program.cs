using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Components;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// obtenemos el ConStr para usarlo en el contexto
var conStr = builder.Configuration.GetConnectionString("NpgsqlConStr");

// agregamos el contexto al builder con el ConStr
builder.Services.AddDbContextFactory<Contexto>(o => o.UseNpgsql(conStr));

//Inyeccion del service
builder.Services.AddScoped<TecnicosServices>();
builder.Services.AddScoped<ClientesServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
