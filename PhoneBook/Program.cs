using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneBook.BLL.Abstracts;
using PhoneBook.BLL.Concretes;
using PhoneBook.CORE.Entities.Concretes;
using PhoneBook.CORE.IRepositories;
using PhoneBook.DAL;
using PhoneBook.DAL.Repositories;
using PhoneBook.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(@"Server=marketanalysis.yorumingo.com\MSSQLSERVER2019; Database=PhoneBook; User Id=phone; Password=O72_sz10a; MultipleActiveResultSets=true;"));
builder.Services.AddIdentity<AppUser, IdentityRole>(config =>
{
    config.Password.RequiredLength = 4;
    config.Password.RequireDigit = false;
    config.Password.RequireNonAlphanumeric = false;
    config.Password.RequireUppercase = false;
    config.SignIn.RequireConfirmedEmail = false;

    config.User.RequireUniqueEmail = true;  // benzersiz mail zorunluluðu
    config.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
}).AddEntityFrameworkStores<AppDbContext>()
           .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)
           .AddErrorDescriber<CustomIdentityErrorDescriber>()
           .AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IAppUserRepository, AppUserRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IPhoneInfoRepository, PhoneInfoRepository>();
builder.Services.AddScoped<IAppUserService, AppUserService>(); 
builder.Services.AddScoped<IBookService, BookService>(); 
builder.Services.AddScoped<IPhoneInfoService, PhoneInfoService>(); 

builder.Services.ConfigureApplicationCookie(option =>
{
    option.Cookie.Name = "Identity";
    option.ExpireTimeSpan = TimeSpan.FromDays(1);
    option.SlidingExpiration = true;    // iþlem yaptýkca süreyi uzatacak
    option.LoginPath = "/Home/Login";
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Configure Hero notification
builder.Services.AddNotyf(options =>
{
    options.IsDismissable = true;
    options.Position = NotyfPosition.BottomRight;
    options.HasRippleEffect = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews(); 
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

app.UseAuthentication();
app.UseAuthorization();

app.UseNotyf();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
