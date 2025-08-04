using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Queries;
using Sofa.CourseManagement.Application.Contract.CoursePlacements.Dtos;
using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CoursePlacementQuestions.Queries
{
	public class GetAllCoursePlacementQuestionsQueryHandler : IQueryHandler<GetAllCoursePlacementQuestionsQuery, Pagination<CoursePlacementQuestionDto>>
	{
		private readonly IInstituteRepository _instituteRepository;
		public GetAllCoursePlacementQuestionsQueryHandler(IInstituteRepository instituteRepository)
		{
			_instituteRepository = instituteRepository;
		}
		public async Task<Pagination<CoursePlacementQuestionDto>> Handle(GetAllCoursePlacementQuestionsQuery request, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				return null;

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				return null;

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (course == null)
				return null;

			var placement = course.Placements.SingleOrDefault(c => c.Id == request.PlacementId);
			if (placement == null)
				return null;

			var questionCount = placement.Questions.Count();
			var questions = placement.Questions;
			var questionDtos = questions
				.Skip(request.Offset * request.Count)
				.Take(request.Count)
				.Select(s => new CoursePlacementQuestionDto()
				{
					Id = s.Id,
					QuestionId = s.Question.Id,
					Order = s.Order.Value,
					QuestionTitle = s.Question.Title.Value
				});

			return new Pagination<CoursePlacementQuestionDto>()
			{
				Items = questionDtos,
				TotalItems = questionCount
			};
		}
	}
}
