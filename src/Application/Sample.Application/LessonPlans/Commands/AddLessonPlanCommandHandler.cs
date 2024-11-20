using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.Commands
{
	internal class AddLessonPlanCommandHandler : ICommandHandler<AddLessonPlanCommand, LessonPlanDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddLessonPlanCommandHandler(IInstituteRepository repository, ICourseManagementUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<LessonPlanDto> Handle(AddLessonPlanCommand request, CancellationToken cancellationToken)
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

			var lessonplan = LessonPlan.CreateInstance(_idGenerator.GetNewId(), request.Title, request.Level, request.SessionId);
			session.AddLessonPlan(lessonplan);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new LessonPlanDto()
			{
				Id = lessonplan.Id,
				Title = lessonplan.Title.Value,
				Level = lessonplan.Level.Value,
				InstituteId = institute.Id,
				InstituteTitle = institute.Title.Value,
				FieldId = field.Id,
				FieldTitle = field.Title.Value,
				CourseId = course.Id,
				CourseTitle = course.Title.Value,
				TermId = term.Id,
				TermTitle = term.Title.Value,
				SessionId = session.Id,
				SessionTitle = session.Title.Value,
			};
		}
	}
}
