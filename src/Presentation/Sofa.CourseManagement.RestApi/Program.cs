using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.RestApi.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
		};
	});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy(AuthorizationPolicies.AdminPolicy, policy =>
			policy.RequireRole(UserRoleEnum.Supervisor.ToString(), UserRoleEnum.Admin.ToString())
		);
	options.AddPolicy(AuthorizationPolicies.TeacherPolicy, policy =>
			policy.RequireRole(UserRoleEnum.Supervisor.ToString(), UserRoleEnum.Teacher.ToString(), UserRoleEnum.Admin.ToString())
		);
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
