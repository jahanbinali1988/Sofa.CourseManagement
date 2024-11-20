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

        public static IServiceCollection AddConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlConnection = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

            services.AddRepository(sqlConnection);

            return services;
        }
    }
}
