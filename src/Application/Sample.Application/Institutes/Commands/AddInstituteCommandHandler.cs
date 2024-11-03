using MediatR;
using Sofa.CourseManagement.Application.Contract.Institutes.Commands;
using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Institutes.Commands
{
	internal class AddInstituteCommandHandler : ICommandHandler<AddInstituteCommand, InstituteDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddInstituteCommandHandler(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_instituteRepository = instituteRepository;
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<InstituteDto> Handle(AddInstituteCommand request, CancellationToken cancellationToken)
		{
			var institute = Institute.CreateInstance(_idGenerator.GetNewId(), request.Title, request.Code, request.WebsiteUrl);
			
			await _instituteRepository.AddAsync(institute, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			return InstituteDto.CreateDto(institute);
		}
	}
}
