using AlbaflexMvc.IoC;
using FluentMigrator.Runner;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddBusinessServices();
builder.Services.AddDatabaseConfiguration();
builder.Services.AddRazorPages()
    .AddMvcOptions(options =>
    {
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
            _ => "O campo não pode ser nulo.");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
runner.MigrateUp();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
