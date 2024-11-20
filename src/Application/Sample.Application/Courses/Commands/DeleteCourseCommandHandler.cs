using MediatR;
using Sofa.CourseManagement.Application.Contract.Courses.Commands;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.Commands
{
	internal class DeleteCourseCommandHandler : ICommandHandler<DeleteCourseCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteCourseCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var course = field.Courses.SingleOrDefault(c => c.Id == request.Id);
			if (course == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {request.Id}");

			course.Delete();
			field.DeleteCourse(course);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
