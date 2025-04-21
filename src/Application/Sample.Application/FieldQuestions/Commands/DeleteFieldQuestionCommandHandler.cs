using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.FieldQuestions.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.FieldQuestions.Commands
{
	public class DeleteFieldQuestionCommandHandler : ICommandHandler<DeleteFieldQuestionCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteFieldQuestionCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteFieldQuestionCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var question = field.Questions.SingleOrDefault(c => c.Id == request.QuestionId);
			if (question == null)
				throw new EntityNotFoundException($"Could not find Question entity with Id {request.QuestionId}");

			question.Delete();

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
