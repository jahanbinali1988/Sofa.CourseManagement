using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Commands;
using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Dtos;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using Sofa.SharedKernel.Generators;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CoursePlacementQuestions.Commands
{
	public class AddCoursePlacementQuestionCommandHandler : ICommandHandler<AddCoursePlacementQuestionCommand, CoursePlacementQuestionDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddCoursePlacementQuestionCommandHandler(IIdGenerator idGenerator, ICourseManagementUnitOfWork unitOfWork)
		{
			_idGenerator = idGenerator;
			_unitOfWork = unitOfWork;
		}
		public async Task<CoursePlacementQuestionDto> Handle(AddCoursePlacementQuestionCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var fieldQuestion = field.Questions.SingleOrDefault(c => c.Id == request.QuestionId);
			if (fieldQuestion == null)
				throw new EntityNotFoundException($"Could not find Field Question entity with Id {request.QuestionId}");

			var course = field.Courses.SingleOrDefault(c => c.Id == request.CourseId);
			if (course == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {request.CourseId}");

			var placement = course.Placements.SingleOrDefault(c => c.Id == request.PlacementId);
			if (placement == null)
				throw new EntityNotFoundException($"Could not find Placement entity with Id {request.PlacementId}");

			var question = CoursePlacementQuestion.CreateInstance(_idGenerator.GetNewId(), request.Order, request.PlacementId, request.QuestionId, request.CourseId, request.FieldId, request.InstituteId);
			placement.AddQuestion(question);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new CoursePlacementQuestionDto()
			{
				Id = course.Id,
				Order = question.Order.Value,
				QuestionId = question.QuestionId,
				QuestionTitle = fieldQuestion.Title.Value
			};
		}
	}
}
