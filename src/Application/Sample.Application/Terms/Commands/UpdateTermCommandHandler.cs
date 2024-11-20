using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.Terms.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Terms.Commands
{
	internal class UpdateTermCommandHandler : ICommandHandler<UpdateTermCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public UpdateTermCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(UpdateTermCommand request, CancellationToken cancellationToken)
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

			var term = course.Terms.SingleOrDefault(c=> c.Id == request.Id);
			if (term == null)
				throw new EntityNotFoundException($"Could not find Term entity with Id {request.Id}");

			term.Update(request.Title);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
