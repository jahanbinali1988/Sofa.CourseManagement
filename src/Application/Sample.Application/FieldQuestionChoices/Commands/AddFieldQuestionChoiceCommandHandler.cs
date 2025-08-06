using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Commands;
using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Dtos;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using Sofa.SharedKernel.Generators;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.FieldQuestionChoices.Commands
{
	public class AddFieldQuestionChoiceCommandHandler : ICommandHandler<AddFieldQuestionChoiceCommand, FieldQuestionChoiceDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddFieldQuestionChoiceCommandHandler(IIdGenerator idGenerator, ICourseManagementUnitOfWork unitOfWork)
		{
			_idGenerator = idGenerator;
			_unitOfWork = unitOfWork;
		}
		public async Task<FieldQuestionChoiceDto> Handle(AddFieldQuestionChoiceCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var question = field.Questions.SingleOrDefault(c => c.Id == request.FieldQuestionId);
			if (question == null)
				throw new EntityNotFoundException($"Could not find Field Question entity with Id {request.FieldQuestionId}");

			var choice = FieldQuestionChoice.CreateInstance(_idGenerator.GetNewId(), request.Content, request.IsAnswer, request.FieldQuestionId, request.FieldId, request.InstituteId);
			question.AddChoice(choice);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new FieldQuestionChoiceDto()
			{
				Id = choice.Id,
				IsAnswer = choice.IsAnswer,
				Content = choice.Content.Value
			};
		}
	}
}
