using MediatR;
using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Commands
{
	internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
	{
		private readonly IInstituteRepository _repository;
		private readonly IUnitOfWork _unitOfWork;
		public DeletePostCommandHandler(IInstituteRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
