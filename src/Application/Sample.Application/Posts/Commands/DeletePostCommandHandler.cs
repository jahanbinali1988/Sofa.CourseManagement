using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Commands
{
	internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeletePostCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
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

			LessonPlan? lessonplan = session.LessonPlan.Id == request.LessonPlanId ? session.LessonPlan : null;
			if (lessonplan == null)
				throw new EntityNotFoundException($"Could not find LessonPlan entity with Id {request.LessonPlanId}");

			var post = lessonplan.Posts.SingleOrDefault(c => c.Id == request.PostId);
			if (post == null)
				throw new EntityNotFoundException($"Could not find Post entity with Id {request.PostId}");

			post.Delete();

			lessonplan.DeletePost(post);

			return Unit.Value;
		}
	}
}
