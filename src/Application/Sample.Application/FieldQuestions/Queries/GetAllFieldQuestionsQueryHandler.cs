using Sofa.CourseManagement.Application.Contract.FieldQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.FieldQuestions.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.SharedKernel.Application;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.FieldQuestions.Queries
{
	public class GetAllFieldQuestionsQueryHandler : IQueryHandler<GetAllFieldQuestionsQuery, Pagination<FieldQuestionDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllFieldQuestionsQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}
		public async Task<Pagination<FieldQuestionDto>> Handle(GetAllFieldQuestionsQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				return null;

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				return null;

			var questionCount = field.Questions.Count();
			var questions = field.Questions.Where(c => string.IsNullOrEmpty(request.Keyword) || request.Keyword.ToLower().Contains(c.Title.Value.ToLower()));
			var questionDtos = questions
				.Skip(request.Offset * request.Count)
				.Take(request.Count)
				.Select(s => new FieldQuestionDto()
				{
					Id = s.Id,
					Title = s.Title.Value,
					Content = s.Content.Value,
					Level = s.Level.Value,
					Type = s.Type.Value
				});

			return new Pagination<FieldQuestionDto>()
			{
				Items = questionDtos,
				TotalItems = questionCount
			};
		}
	}
}
