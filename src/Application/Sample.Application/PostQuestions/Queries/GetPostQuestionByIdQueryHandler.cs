using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.PostQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.PostQuestions.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.PostQuestions.Queries
{
	public class GetPostQuestionByIdQueryHandler : IQueryHandler<GetPostQuestionByIdQuery, PostQuestionDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetPostQuestionByIdQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}
		public async Task<PostQuestionDto> Handle(GetPostQuestionByIdQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

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

			var question = post.Question;
			if (question == null)
				throw new EntityNotFoundException($"Could not find Post Question entity");

			var fieldQuestion = field.Questions.SingleOrDefault(c => c.Id == question.Id);
			if (field == null)
				throw new EntityNotFoundException($"Could not find !uestion entity with Id {question.Id}");

			return new PostQuestionDto()
			{
				Id = course.Id,
				QuestionId = question.Id,
				QuestionTitle = fieldQuestion.Title.Value,
				PostId = post.Id,
				PostTitle = fieldQuestion.Title.Value,
				Priority = question.Priority.Value
			};
		}
	}
}
