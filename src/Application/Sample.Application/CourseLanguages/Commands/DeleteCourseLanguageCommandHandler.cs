using MediatR;
using Sofa.CourseManagement.Application.Contract.CourseLanguages.Commands;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CourseLanguages.Commands
{
	public class DeleteCourseLanguageCommandHandler : ICommandHandler<DeleteCourseLanguageCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteCourseLanguageCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteCourseLanguageCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {request.CourseId}");

			var courseLanguage = course.CourseLanguages.SingleOrDefault(c => c.Id == request.LanguageId);
			if (courseLanguage == null)
				throw new EntityNotFoundException($"Could not find Course Language entity with Id {request.LanguageId}");

			courseLanguage.Delete(request.FieldId, request.InstituteId);
			//field.DeleteCourse(course);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
