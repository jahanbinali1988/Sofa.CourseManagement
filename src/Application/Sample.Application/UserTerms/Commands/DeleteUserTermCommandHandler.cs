using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.UserTerms.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.UserTerms.Commands
{
	internal class DeleteUserTermCommandHandler : ICommandHandler<DeleteUserTermCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteUserTermCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteUserTermCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId.Value, cancellationToken);
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

			var userTerm = term.UserTerms.SingleOrDefault(c=> c.UserId ==  request.UserId);
			if (userTerm == null)
				throw new EntityNotFoundException($"Could not find UserTerm entity with User Id {request.UserId}");

			userTerm.Delete();
			term.DeleteUser(userTerm);

			 await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
