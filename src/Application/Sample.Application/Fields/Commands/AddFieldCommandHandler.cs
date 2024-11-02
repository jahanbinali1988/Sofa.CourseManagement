using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Fields.Commands;
using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Fields.Commands
{
	internal class AddFieldCommandHandler : ICommandHandler<AddFieldCommand, FieldDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddFieldCommandHandler(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_instituteRepository = instituteRepository;
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<FieldDto> Handle(AddFieldCommand request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);

			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var fieldId = _idGenerator.GetNewId();
			var field = Field.CreateInstance(fieldId, request.Title, request.InstituteId);
			institute.AssignField(field);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new FieldDto() { Id = field.Id, InstituteId = field.InstituteId, Title = field.Title.Value, InstituteTitle = institute.Title.Value };
		}
	}
}
