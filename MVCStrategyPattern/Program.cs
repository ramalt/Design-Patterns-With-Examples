using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCBaseProject.Models;
using MVCStrategyPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppDbContext>();

// repositories
ServiceRegistrationExtension.RegisterRepositories(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var sp = scope.ServiceProvider;

    var appDbContext = sp.GetRequiredService<AppDbContext>();
    var userManager = sp.GetRequiredService<UserManager<AppUser>>();

    appDbContext.Database.Migrate();

    if (!userManager.Users.Any())
    {
        var newUser = new AppUser
        {
            UserName = "doejohn",
            Email = "johndoe@mail.com",
        };
        userManager.CreateAsync(new AppUser { UserName = "doejohn", Email = "johndoe@mail.com" }, "Johndoe1234!").Wait();
        userManager.CreateAsync(new AppUser { UserName = "doejane", Email = "janedoe@mail.com" }, "Janedoe1234!").Wait();
        userManager.CreateAsync(new AppUser { UserName = "dohplay", Email = "playdoh@mail.com" }, "Playdoh1234!").Wait();
        userManager.CreateAsync(new AppUser { UserName = "captainprice", Email = "captainprice@mail.com" }, "Captainprice1234!").Wait();
        userManager.CreateAsync(new AppUser { UserName = "ramalt", Email = "ramazanalltuntepe@gmail.com" }, "Ramalt1234!").Wait();

    }

}
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
