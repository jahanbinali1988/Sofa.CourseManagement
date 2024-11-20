using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Application.Contract.Posts.Converter;
using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Commands
{
	internal class AddPostCommandHandler : ICommandHandler<AddPostCommand, PostBaseDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddPostCommandHandler(ICourseManagementUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<PostBaseDto> Handle(AddPostCommand request, CancellationToken cancellationToken)
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

			var postDto = Convert(request);
			var post = CreateEntity(postDto);
			lessonplan.AddPost(post);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new PostBaseDto()
			{
				Id = post.Id,
				LessonPlanId = lessonplan.Id,
				Content = post.Content.Value,
				ContentType = post.ContentType.Value,
				Order = post.Order,
				Title = post.Title.Value
			};
		}

		private PostBaseDto Convert(AddPostCommand request)
		{
			var post = PostFactory.Instance.SetContentType(request.ContentType).SetJson(request.Post.ToString()).CreatePost();
			
			return (PostBaseDto)post;
		}

		private PostBase? CreateEntity(PostBaseDto postBaseDto)
		{
			switch (postBaseDto.ContentType)
			{
				case Domain.Contract.Institutes.Enums.ContentTypeEnum.Text:
					return TextPost.CreateInstance(_idGenerator.GetNewId(), postBaseDto.Title, postBaseDto.Order, postBaseDto.Content, postBaseDto.LessonPlanId);
				case Domain.Contract.Institutes.Enums.ContentTypeEnum.Image:
					return ImagePost.CreateInstance(_idGenerator.GetNewId(), postBaseDto.Title, postBaseDto.Order, postBaseDto.Content, postBaseDto.LessonPlanId);
				case Domain.Contract.Institutes.Enums.ContentTypeEnum.Sound:
					return SoundPost.CreateInstance(_idGenerator.GetNewId(), postBaseDto.Title, postBaseDto.Order, postBaseDto.Content, postBaseDto.LessonPlanId);
				case Domain.Contract.Institutes.Enums.ContentTypeEnum.Video:
					return VideoPost.CreateInstance(_idGenerator.GetNewId(), postBaseDto.Title, postBaseDto.Order, postBaseDto.Content, postBaseDto.LessonPlanId);
				default:
					break;
			}

			return null;
		}
	}
}
