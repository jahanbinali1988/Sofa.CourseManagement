using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sofa.CourseManagement.Infrastructure.Persistence;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;
using Sofa.CourseManagement.Infrastructure.EventProcessing;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Infrastructure.Domains.Institutes;
using Sofa.CourseManagement.Infrastructure.Domains.Users;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.ServiceBus;
using Microsoft.Identity.Client;

namespace Sofa.CourseManagement.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, string mssqlConnection)
        {
            services.AddDbContextPool<CourseManagementDbContext>(options =>
            {
                options.UseSqlServer(mssqlConnection);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                options.EnableSensitiveDataLogging(true);
                options.UseLazyLoadingProxies(false);
            }, 1024);

			services.AddScoped<IInstituteRepository, InstituteRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<ICourseManagementUnitOfWork, UnitOfWork>();

			return services;
        }

        public static IServiceCollection AddRabbitMq(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
			RabbitMQSetting rabbitSetting = new RabbitMQSetting();
			configuration.GetSection("RabbitMQ").Bind(rabbitSetting);
			
			// then apply a configuration function
			serviceCollection.Configure<RabbitMQSetting>(options =>
			{
				// overwrite previous values
				options.UserName = rabbitSetting.UserName;
				options.Password = rabbitSetting.Password;
				options.HostName = rabbitSetting.HostName;
                options.Port = rabbitSetting.Port;
			});

			serviceCollection.AddScoped(typeof(IRabbitMQPublisher<>), typeof(RabbitMQPublisher<>));

            return serviceCollection;
        }

        public static IServiceCollection AddConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnection = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

            services.AddRepository(sqlConnection);
            services.AddRabbitMq(configuration);

            return services;
        }
    }
}
