using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.Queries
{
	internal class GetAllLessonPlansQueryHandler : IQueryHandler<GetAllLessonPlansQuery, Pagination<LessonPlanDto>>
	{
		private readonly IInstituteRepository _repository;
		private readonly IUnitOfWork _unitOfWork;
		public GetAllLessonPlansQueryHandler(IInstituteRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public Task<Pagination<LessonPlanDto>> Handle(GetAllLessonPlansQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
