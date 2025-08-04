using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.PostQuestions.Commands;
using Sofa.CourseManagement.Application.Contract.PostQuestions.Dtos;
using Sofa.CourseManagement.Domain.Institutes.Entities.Posts;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using Sofa.SharedKernel.Generators;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.PostQuestions.Commands
{
	public class AddPostQuestionCommandHandler : ICommandHandler<AddPostQuestionCommand, PostQuestionDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddPostQuestionCommandHandler(IIdGenerator idGenerator, ICourseManagementUnitOfWork unitOfWork)
		{
			_idGenerator = idGenerator;
			_unitOfWork = unitOfWork;
		}
		public async Task<PostQuestionDto> Handle(AddPostQuestionCommand request, CancellationToken cancellationToken)
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

			var posQuestion = PostQuestion.CreateInstance(_idGenerator.GetNewId(), request.Priority, request.QuestionId, request.PostId);
			post.AddQuestion(posQuestion);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new PostQuestionDto()
			{
				Id = posQuestion.Id,
				QuestionId = posQuestion.QuestionId,
				PostId = post.Id,
				PostTitle = post.Title.Value,
				Priority = posQuestion.Priority.Value,
				QuestionTitle = question.Title.Value
			};
		}
	}
}
