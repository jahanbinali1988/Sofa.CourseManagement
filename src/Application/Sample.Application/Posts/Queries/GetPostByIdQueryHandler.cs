using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Posts.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Queries
{
	internal class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, PostBaseDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		public GetPostByIdQueryHandler(IInstituteRepository repository, IUnitOfWork unitOfWork)
		{
			_instituteRepository = repository;
			_unitOfWork = unitOfWork;
		}

		public async Task<PostBaseDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
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

			LessonPlan? lessonplan = session.LessonPlans.SingleOrDefault(c=> c.Id == request.LessonPlanId);
			if (lessonplan == null)
				throw new EntityNotFoundException($"Could not find LessonPlan entity with Id {request.LessonPlanId}");

			var post = lessonplan.Posts.SingleOrDefault(c => c.Id == request.Id);
			if (post == null)
				throw new EntityNotFoundException($"Could not find Post entity with Id {request.Id}");

			return new PostBaseDto()
			{
				Id = post.Id,
				Content = post.Content.Value,
				ContentType = post.ContentType.Value,
				Order = post.Order.Value,
				Title = post.Title.Value,
				LessonPlanId = post.LessonPlanId,
				lessonPlanTitle = lessonplan.Title.Value,
				FieldId = field.Id,
				FieldTitle = field.Title.Value,
				CourseId = course.Id,
				CourseTitle = course.Title.Value,
				InstituteId = institute.Id,
				InstituteTitle = institute.Title.Value,
			};
		}
	}
}
