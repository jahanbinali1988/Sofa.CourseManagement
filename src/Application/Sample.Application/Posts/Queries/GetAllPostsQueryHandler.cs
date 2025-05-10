using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Posts.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Queries
{
	internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, Pagination<PostDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		public GetAllPostsQueryHandler(IInstituteRepository repository, IUnitOfWork unitOfWork)
		{
			_instituteRepository = repository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Pagination<PostDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				return null;

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				return null;

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (course == null)
				return null;

			var session = course.Sessions.SingleOrDefault(c => c.Id == request.SessionId);
			if (session == null)
				return null;

			var lessonplan = session.LessonPlans.SingleOrDefault(c=> c.Id == request.LessonPlanId);
			if (lessonplan == null)
				return null;

			var posts = lessonplan.Posts.Where(c => string.IsNullOrEmpty(request.Keyword) || c.Title.Value.ToLower().Contains(request.Keyword));
			var postDtos = posts
				.Skip(request.Offset * request.Count)
				.Take(request.Count)
				.Select(s => new PostDto()
				{
					Id = s.Id,
					Title = s.Title.Value,
					InstituteTitle = institute.Title.Value,
					InstituteId = request.InstituteId,
					FieldId = field.Id,
					FieldTitle = field.Title.Value,
					CourseId = course.Id,
					CourseTitle = course.Title.Value,
					LessonPlanId = lessonplan.Id,
					lessonPlanTitle = lessonplan.Title.Value,
					Content = s.Content.Value,
					ContentType = s.ContentType.Value,
					Order = s.Order.Value
				});

			return new Pagination<PostDto>()
			{
				Items = postDtos,
				TotalItems = posts.Count()
			};
		}
	}
}
