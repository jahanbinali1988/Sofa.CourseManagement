using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Fields.Commands;
using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Fields.Commands
{
	internal class AddFieldCommandHandler : ICommandHandler<AddFieldCommand, FieldDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddFieldCommandHandler(
			ICourseManagementUnitOfWork unitOfWork
			, IIdGenerator idGenerator
			)
		{
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<FieldDto> Handle(AddFieldCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var fieldId = _idGenerator.GetNewId();
			var field = Field.CreateInstance(fieldId, request.Title, institute.Id);
			institute.AddField(field);

			await _unitOfWork.CommitAsync(cancellationToken);
			
			return new FieldDto() { Id = field.Id, InstituteId = field.InstituteId, Title = field.Title.Value, InstituteTitle = institute.Title.Value };
		}
	}
}
