using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using Sofa.CourseManagement.SharedKernel.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.Commands
{
	internal class AddLessonPlanCommandHandler : ICommandHandler<AddLessonPlanCommand, LessonPlanDto>
	{
		private readonly IInstituteRepository _repository;
		private readonly IUnitOfWork _unitOfWork;
		public AddLessonPlanCommandHandler(IInstituteRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public Task<LessonPlanDto> Handle(AddLessonPlanCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
