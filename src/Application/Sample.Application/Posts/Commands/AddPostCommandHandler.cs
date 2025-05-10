using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans;
using Sofa.CourseManagement.Domain.Institutes.Entities.Posts;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Commands
{
	internal class AddPostCommandHandler : ICommandHandler<AddPostCommand, PostDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddPostCommandHandler(ICourseManagementUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<PostDto> Handle(AddPostCommand request, CancellationToken cancellationToken)
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

			var session = course.Sessions.SingleOrDefault(c => c.Id == request.SessionId);
			if (session == null)
				throw new EntityNotFoundException($"Could not find Session entity with Id {request.SessionId}");

			LessonPlan? lessonplan = session.LessonPlans.SingleOrDefault(c=> c.Id == request.LessonPlanId);
			if (lessonplan == null)
				throw new EntityNotFoundException($"Could not find LessonPlan entity with Id {request.LessonPlanId}");

			var post = Post.CreateInstance(_idGenerator.GetNewId(), request.Title, request.Order, request.Content, request.ContentType, request.LessonPlanId);
			lessonplan.AddPost(post);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new PostDto()
			{
				Id = post.Id,
				LessonPlanId = lessonplan.Id,
				Content = post.Content.Value,
				ContentType = post.ContentType.Value,
				Order = post.Order.Value,
				Title = post.Title.Value
			};
		}
	}
}
