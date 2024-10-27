using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Courses.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.Queries
{
	internal class GetAllCoursesQueryHandler : IQueryHandler<GetAllCoursesQuery, Pagination<CourseDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllCoursesQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}

		public Task<Pagination<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
