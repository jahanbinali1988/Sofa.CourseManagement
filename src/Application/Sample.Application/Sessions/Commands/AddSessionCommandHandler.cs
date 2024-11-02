using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Sessions.Commands;
using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Sessions.Commands
{
	internal class AddSessionCommandHandler : ICommandHandler<AddSessionCommand, SessionDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddSessionCommandHandler(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_instituteRepository = instituteRepository;
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<SessionDto> Handle(AddSessionCommand request, CancellationToken cancellationToken)
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

			var term = course.Terms.SingleOrDefault(c => c.Id == request.TermId);
			if (term == null)
				throw new EntityNotFoundException($"Could not find Term entity with Id {request.TermId}");

			var session = Session.CreateInstance(_idGenerator.GetNewId(), request.Title, request.TermId, request.OccurredDate);

			term.AddSession(session);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new SessionDto()
			{
				Title = session.Title.Value,
				Id = session.Id,
				InstituteId = institute.Id,
				InstituteTitle = institute.Title.Value,
				FieldId = field.Id,
				FieldTitle = field.Title.Value,
				CourseId = course.Id,
				CourseTitle = course.Title.Value,
				TermId = term.Id,
				TermTitle = term.Title.Value,
			};
		}
	}
}
