using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.FieldQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.FieldQuestions.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.FieldQuestions.Queries
{
	public class GetFieldQuestionByIdQueryHandler : IQueryHandler<GetFieldQuestionByIdQuery, FieldQuestionDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetFieldQuestionByIdQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}
		public async Task<FieldQuestionDto> Handle(GetFieldQuestionByIdQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);

			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var question = field.Questions.SingleOrDefault(c => c.Id == request.Id);
			if (question == null)
				throw new EntityNotFoundException($"Could not find Question entity with Id {request.Id}");

			return new FieldQuestionDto()
			{
				Id = question.Id,
				Title = question.Title.Value,
				Type = question.Type.Value,
				Level = question.Level.Value,
				Content = question.Content.Value
			};
		}
	}
}
