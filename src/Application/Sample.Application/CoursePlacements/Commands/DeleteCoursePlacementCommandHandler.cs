using MediatR;
using Sofa.CourseManagement.Application.Contract.CoursePlacements.Commands;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CoursePlacements.Commands
{
	public class DeleteCoursePlacementCommandHandler : ICommandHandler<DeleteCoursePlacementCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteCoursePlacementCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteCoursePlacementCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (course == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {request.CourseId}");

			var coursePlacement = course.Placements.SingleOrDefault(c => c.Id == request.Id);
			if (coursePlacement == null)
				throw new EntityNotFoundException($"Could not find Course Placement entity with Id {request.Id}");

			coursePlacement.Delete();

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
