using MediatR;
using Sofa.CourseManagement.Application.Contract.CourseUsers.Commands;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CourseUsers.Commands
{
	internal class DeleteCourseUserCommandHandler : ICommandHandler<DeleteCourseUserCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteCourseUserCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteCourseUserCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId.Value, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (course == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {request.CourseId}");

			var courseUser = course.CourseUsers.SingleOrDefault(c => c.UserId == request.UserId);
			if (courseUser == null)
				throw new EntityNotFoundException($"Could not find courseUser entity with User Id {request.UserId}");

			courseUser.Delete();
			course.DeleteUser(courseUser);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
