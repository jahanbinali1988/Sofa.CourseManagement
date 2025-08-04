using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Dtos;
using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.SharedKernel.Application;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.FieldQuestionChoices.Queries
{
	public class GetAllFieldQuestionChoicesQueryHandler : IQueryHandler<GetAllFieldQuestionChoicesQuery, Pagination<FieldQuestionChoiceDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllFieldQuestionChoicesQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}
		public async Task<Pagination<FieldQuestionChoiceDto>> Handle(GetAllFieldQuestionChoicesQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				return null;

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				return null;

			var question = field.Questions.SingleOrDefault(c => c.Id == request.FieldQuestionId);
			if (question == null)
				return null;

			var choiceCount = question.QuestionChoices.Count();
			var choices = question.QuestionChoices.Where(c => string.IsNullOrEmpty(request.Keyword) || request.Keyword.ToLower().Contains(c.Content.Value.ToLower()));
			var choiceDtos = choices
				.Skip(request.Offset * request.Count)
				.Take(request.Count)
				.Select(s => new FieldQuestionChoiceDto()
				{
					Id = s.Id,
					IsAnswer = s.IsAnswer,
					Content = s.Content.Value
				});

			return new Pagination<FieldQuestionChoiceDto>()
			{
				Items = choiceDtos,
				TotalItems = choiceCount
			};
		}
	}
}
