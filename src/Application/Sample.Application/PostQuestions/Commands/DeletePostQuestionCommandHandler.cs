using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.PostQuestions.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.PostQuestions.Commands
{
	public class DeletePostQuestionCommandHandler : ICommandHandler<DeletePostQuestionCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeletePostQuestionCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeletePostQuestionCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var question = field.Questions.SingleOrDefault(c => c.Id == request.QuestionId);
			if (question == null)
				throw new EntityNotFoundException($"Could not find Question entity with Id {request.QuestionId}");

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (course == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {request.CourseId}");

			var session = course.Sessions.SingleOrDefault(c => c.Id == request.SessionId);
			if (session == null)
				throw new EntityNotFoundException($"Could not find Session entity with Id {request.SessionId}");

			var lessonplan = session.LessonPlans.SingleOrDefault(c => c.Id == request.LessonplanId);
			if (lessonplan == null)
				throw new EntityNotFoundException($"Could not find LessonPlan entity with Id {request.LessonplanId}");

			var post = lessonplan.Posts.SingleOrDefault(c => c.Id == request.PostId);
			if (lessonplan == null)
				throw new EntityNotFoundException($"Could not find Post entity with Id {request.PostId}");

			if (post.Question == null)
				throw new EntityNotFoundException($"Could not find Post Question entity with Id {request.QuestionId}");

			post.Question.Delete();

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
