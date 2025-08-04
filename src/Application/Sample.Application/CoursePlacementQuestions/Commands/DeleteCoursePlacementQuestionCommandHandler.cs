using MediatR;
using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Commands;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CoursePlacementQuestions.Commands
{
	public class DeleteCoursePlacementQuestionCommandHandler : ICommandHandler<DeleteCoursePlacementQuestionCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteCoursePlacementQuestionCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteCoursePlacementQuestionCommand request, CancellationToken cancellationToken)
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

			var coursePlacement = course.Placements.SingleOrDefault(c => c.Id == request.PlacementId);
			if (coursePlacement == null)
				throw new EntityNotFoundException($"Could not find Course Placement entity with Id {request.PlacementId}");

			var coursePlacementQuestion = coursePlacement.Questions.SingleOrDefault(c => c.Id == request.QuestionId);
			if (coursePlacementQuestion == null)
				throw new EntityNotFoundException($"Could not find Course Placement Question entity with Id {request.QuestionId}");

			course.Delete();

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
