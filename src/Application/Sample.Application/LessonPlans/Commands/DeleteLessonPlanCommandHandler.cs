using MediatR;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.Commands
{
	internal class DeleteLessonPlanCommandHandler : ICommandHandler<DeleteLessonPlanCommand>
	{

		private readonly IInstituteRepository _repository;
		private readonly IUnitOfWork _unitOfWork;
		public DeleteLessonPlanCommandHandler(IInstituteRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public Task<Unit> Handle(DeleteLessonPlanCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
