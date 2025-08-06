using Sofa.CourseManagement.Application.Contract.CoursePlacements.Commands;
using Sofa.CourseManagement.Application.Contract.CoursePlacements.Dtos;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using Sofa.SharedKernel.Generators;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CoursePlacements.Commands
{
	public class AddCoursePlacementCommandHandler : ICommandHandler<AddCoursePlacementCommand, CoursePlacementDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddCoursePlacementCommandHandler(IIdGenerator idGenerator, ICourseManagementUnitOfWork unitOfWork)
		{
			_idGenerator = idGenerator;
			_unitOfWork = unitOfWork;
		}
		public async Task<CoursePlacementDto> Handle(AddCoursePlacementCommand request, CancellationToken cancellationToken)
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

			var coursePlacement = CoursePlacement.CreateInstance(_idGenerator.GetNewId(), request.Title, request.CourseId, request.FieldId, request.InstituteId);
			course.AddPlacement(coursePlacement);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new CoursePlacementDto()
			{
				Title = course.Title.Value,
				Id = course.Id
			};
		}
	}
}
