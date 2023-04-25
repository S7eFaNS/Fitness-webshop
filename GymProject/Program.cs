using ClassLibrary.Classes.User;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(40);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/SignIn");
    options.AccessDeniedPath = new PathString("/Error");
}
);

builder.Services.AddAuthorization(options =>
{
    Dictionary<UserType, string> roleMappings = new Dictionary<UserType, string>
{
    { UserType.Admin, "Admin" },
    { UserType.Customer, "Customer" },
};
    options.AddPolicy("AdminAccess", policy => policy.RequireRole(roleMappings[UserType.Admin]));
    options.AddPolicy("CustomerAccess", policy => policy.RequireRole(roleMappings[UserType.Customer]));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
