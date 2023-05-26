using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using RectangleONEHSN.Authentication;
using RectangleONEHSN.Data;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RectangleDBConnectionString"));
});

//Register IAppDbContext interface
builder.Services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

//Register IUserService interface
builder.Services.AddScoped<IUserService, UserService>();

// Register DataSeeder as a service
builder.Services.AddScoped<DataSeeder>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//enable authentication
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


var app = builder.Build();

// Create a scope to retrieve the services
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Retrieve the AppDbContext and DataSeeder instances
    var dbContext = services.GetRequiredService<AppDbContext>();
    var dataSeeder = services.GetRequiredService<DataSeeder>();

    // Seed the data
    dataSeeder.SeedData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Enable authentication
app.UseAuthorization();
app.MapControllers();
app.Run();
