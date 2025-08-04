using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Dtos;
using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.FieldQuestionChoices.Queries
{
	public class GetFieldQuestionChoiceByIdQueryHandler : IQueryHandler<GetFieldQuestionChoiceByIdQuery, FieldQuestionChoiceDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetFieldQuestionChoiceByIdQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}
		public async Task<FieldQuestionChoiceDto> Handle(GetFieldQuestionChoiceByIdQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);

			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var question = field.Questions.SingleOrDefault(c => c.Id == request.FieldQuestionId);
			if (question == null)
				throw new EntityNotFoundException($"Could not find Question entity with Id {request.FieldQuestionId}");

			var choice = question.QuestionChoices.SingleOrDefault(c => c.Id == request.Id);
			if(choice == null)
				throw new EntityNotFoundException($"Could not find Choice entity with Id {request.Id}");

			return new FieldQuestionChoiceDto()
			{
				Id = choice.Id,
				Content = choice.Content.Value,
				IsAnswer = choice.IsAnswer
			};
		}
	}
}
