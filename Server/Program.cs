using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Radzen;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddSingleton(sp =>
{
    // Get the address that the app is currently running at
    var server = sp.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    string baseAddress = addressFeature.Addresses.First();
    return new HttpClient{BaseAddress = new Uri(baseAddress)};
});
builder.Services.AddScoped<VentaProducto.Server.PruebaVentasService>();
builder.Services.AddDbContext<VentaProducto.Server.Data.PruebaVentasContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaVentasConnection"));
});
builder.Services.AddControllers().AddOData(opt =>
{
    var oDataBuilderPruebaVentas = new ODataConventionModelBuilder();
    oDataBuilderPruebaVentas.EntitySet<VentaProducto.Server.Models.PruebaVentas.IiN04>("IiN04S");
    oDataBuilderPruebaVentas.EntitySet<VentaProducto.Server.Models.PruebaVentas.IN05>("IN05S");
    opt.AddRouteComponents("odata/PruebaVentas", oDataBuilderPruebaVentas.GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null).TimeZone = TimeZoneInfo.Utc;
});
builder.Services.AddScoped<VentaProducto.Client.PruebaVentasService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToPage("/_Host");
app.Run();