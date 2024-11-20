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
	internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, Pagination<PostBaseDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		public GetAllPostsQueryHandler(IInstituteRepository repository, IUnitOfWork unitOfWork)
		{
			_instituteRepository = repository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Pagination<PostBaseDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
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

			var term = course.Terms.SingleOrDefault(c => c.Id == request.TermId);
			if (term == null)
				return null;

			var session = term.Sessions.SingleOrDefault(c => c.Id == request.SessionId);
			if (session == null)
				return null;

			var lessonplan = session.LessonPlan;
			if (lessonplan == null)
				return null;

			var posts = lessonplan.Posts.Where(c => c.Title.Value.ToLower().Contains(request.Keyword));
			var postDtos = posts
				.Skip(request.Offset - 1 * request.Count)
				.Take(request.Count)
				.Select(s => new PostBaseDto()
				{
					Id = s.Id,
					Title = s.Title.Value,
					InstituteTitle = institute.Title.Value,
					InstituteId = request.InstituteId,
					FieldId = field.Id,
					FieldTitle = field.Title.Value,
					CourseId = course.Id,
					CourseTitle = course.Title.Value,
					TermId = term.Id,
					TermTitle = term.Title.Value,
					LessonPlanId = lessonplan.Id,
					lessonPlanTitle = lessonplan.Title.Value,
					Content = s.Content.Value,
					ContentType = s.ContentType.Value,
					Order = s.Order
				});

			return new Pagination<PostBaseDto>()
			{
				Items = postDtos,
				TotalItems = posts.Count()
			};
		}
	}
}
