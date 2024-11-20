using MediatR;
using Microsoft.OpenApi.Models;
using Sofa.CourseManagement.Application;
using Sofa.CourseManagement.Infrastructure;
using Sofa.CourseManagement.SharedKernel.Generators;
using System.Reflection;
using System.Reflection.Emit;

namespace Sofa.CourseManagement.RestApi.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IIdGenerator, IdGenerator>();
			//Infrastructure
			services.AddConnection(configuration);

			//services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssembelyRecognizer).GetTypeInfo().Assembly));

			services.AddMediatR(typeof(Bootstraper).Assembly, typeof(AssembelyRecognizer).Assembly);

			//Endpoint
			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.MaxDepth = 64;
				options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
			});
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sofa Admin panel", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				  {
					{
					  new OpenApiSecurityScheme
					  {
						Reference = new OpenApiReference
						  {
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						  },
						  Scheme = "oauth2",
						  Name = "Bearer",
						  In = ParameterLocation.Header,

						},
						new List<string>()
					  }
					});
			});

			return services;
		}
	}
}
