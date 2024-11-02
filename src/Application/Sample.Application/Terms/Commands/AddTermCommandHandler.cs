using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Terms.Commands;
using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Terms.Commands
{
	internal class AddTermCommandHandler : ICommandHandler<AddTermCommand, TermDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddTermCommandHandler(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_instituteRepository = instituteRepository;
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<TermDto> Handle(AddTermCommand request, CancellationToken cancellationToken)
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

			var term = Term.CreateInstance(_idGenerator.GetNewId(), request.Title, request.CourseId);
			course.AddTerm(term);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new TermDto()
			{
				CourseId = request.CourseId,
				FieldId = request.FieldId,
				Title = term.Title.Value,
				InstituteId = request.InstituteId,
				Id = term.Id,
				CourseTitle = course.Title.Value,
				InstituteTitle = institute.Title.Value,
			};
		}
	}
}
