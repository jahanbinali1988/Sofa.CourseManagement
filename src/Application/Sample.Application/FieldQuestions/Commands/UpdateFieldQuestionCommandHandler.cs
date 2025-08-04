using MediatR;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.FieldQuestions.Commands;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.FieldQuestions.Commands
{
	public class UpdateFieldQuestionCommandHandler : ICommandHandler<UpdateFieldQuestionCommand>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		public UpdateFieldQuestionCommandHandler(ICourseManagementUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(UpdateFieldQuestionCommand request, CancellationToken cancellationToken)
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

			question.Update(request.Title, request.Content, request.Level, request.Type, request.FieldId);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
