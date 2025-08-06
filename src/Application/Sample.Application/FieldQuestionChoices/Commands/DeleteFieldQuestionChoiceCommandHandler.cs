using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.FieldQuestionChoices.Commands
{
	public class DeleteFieldQuestionChoiceCommandHandler : ICommandHandler<DeleteFieldQuestionChoiceCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public DeleteFieldQuestionChoiceCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteFieldQuestionChoiceCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var question = field.Questions.SingleOrDefault(c => c.Id == request.FieldQuestionId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field Question entity with Id {request.FieldQuestionId}");

			var choice = question.QuestionChoices.SingleOrDefault(c => c.Id == request.FieldQuestionChoiceId);
			if (choice == null)
				throw new EntityNotFoundException($"Could not find Choice entity with Id {request.FieldQuestionChoiceId}");

			choice.Delete(question.Id, request.FieldId, request.InstituteId);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
