using MediatR;
using Sofa.CourseManagement.Application.Contract.Courses.Commands;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.Commands
{
	internal class DeleteCourseCommandHandler : ICommandHandler<DeleteCourseCommand>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		public DeleteCourseCommandHandler(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork)
		{
			_instituteRepository = instituteRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.Id}");

			var course = field.Courses.SingleOrDefault(c => c.Id == request.Id);
			if (course == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {request.Id}");

			field.Delete(course);
			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
