using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.Commands
{
	internal class UpdateLessonPlanCommandHandler : ICommandHandler<UpdateLessonPlanCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public UpdateLessonPlanCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(UpdateLessonPlanCommand request, CancellationToken cancellationToken)
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

			var term = course.Terms.SingleOrDefault(c => c.Id == request.TermId);
			if (term == null)
				throw new EntityNotFoundException($"Could not find Term entity with Id {request.TermId}");

			var session = term.Sessions.SingleOrDefault(c => c.Id == request.SessionId);
			if (session == null)
				throw new EntityNotFoundException($"Could not find Session entity with Id {request.SessionId}");

			LessonPlan? lessonplan = session.LessonPlan.Id == request.LessonplanId ? session.LessonPlan : null;
			if (lessonplan == null)
				throw new EntityNotFoundException($"Could not find LessonPlan entity with Id {request.LessonplanId}");

			lessonplan.Update(request.Title, request.Level);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
