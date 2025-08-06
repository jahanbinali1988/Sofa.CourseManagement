using Sofa.CourseManagement.Application.Contract.CourseLanguages.Commands;
using Sofa.CourseManagement.Application.Contract.CourseLanguages.Dtos;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using Sofa.SharedKernel.Generators;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CourseLanguages.Commands
{
	public class AddCourseLanguageCommandHandler : ICommandHandler<AddCourseLanguageCommand, CourseLanguageDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddCourseLanguageCommandHandler(IIdGenerator idGenerator, ICourseManagementUnitOfWork unitOfWork)
		{
			_idGenerator = idGenerator;
			_unitOfWork = unitOfWork;
		}
		public async Task<CourseLanguageDto> Handle(AddCourseLanguageCommand request, CancellationToken cancellationToken)
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

			var courseLanguage = CourseLanguage.CreateInstance(_idGenerator.GetNewId(), request.Language, request.CourseId, request.FieldId, request.InstituteId);
			course.AddLanguage(courseLanguage);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new CourseLanguageDto()
			{
				FieldId = course.FieldId,
				InstituteId = request.InstituteId,
				Id = course.Id,
				CourseId = course.Id,
				Language = courseLanguage.Language.Value,
				CourseTitle = course.Title.Value
			};
		}
	}
}
