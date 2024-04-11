using Server.Core.Mapping;
using Server.Core.Repositories;
using Server.Core.Services;
using Server.Data;
using Server.Data.Repositories;
using Server.Mapping;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var policy = "policy";
builder.Services.AddCors(option => option.AddPolicy(name: policy, policy =>
{
    policy.AllowAnyOrigin(); policy.AllowAnyHeader(); policy.AllowAnyMethod();
}));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddScoped<IEmployeeRepositories, EmployeeRepositories>();
builder.Services.AddScoped<IEmployeeInRoleRepositories, EmployeeInRoleRepositories>();
builder.Services.AddScoped<IRoleRepositories, RoleRepositories>();

builder.Services.AddScoped<IEmployeeInRoleServices, EmployeeInRoleServices>();
builder.Services.AddScoped<IEmployeeServices, EmployeeService>();
builder.Services.AddScoped<IRoleServices, RoleServices>();

builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(PostModelsMappingProfile));
builder.Services.AddDbContext<DataContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(policy);
app.MapControllers();

app.Run();
