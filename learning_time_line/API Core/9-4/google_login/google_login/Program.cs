using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

 builder.Services.AddControllers();

 builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

 builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 

 builder.Services.AddAuthentication(options =>
{
     options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;   
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;   
})
.AddCookie()   
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "add yours";
    googleOptions.ClientSecret = "add yours";
    googleOptions.CallbackPath = "/Account/GoogleResponse";  
    googleOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;   
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
