using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.FieldQuestions.Commands;
using Sofa.CourseManagement.Application.Contract.FieldQuestions.Dtos;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.SharedKernel.Application;
using Sofa.SharedKernel.Generators;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.FieldQuestions.Commands
{
	public class AddFieldQuestionCommandHandler : ICommandHandler<AddFieldQuestionCommand, FieldQuestionDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddFieldQuestionCommandHandler(IIdGenerator idGenerator, ICourseManagementUnitOfWork unitOfWork)
		{
			_idGenerator = idGenerator;
			_unitOfWork = unitOfWork;
		}
		public async Task<FieldQuestionDto> Handle(AddFieldQuestionCommand request, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {request.FieldId}");

			var question = FieldQuestion.CreateInstance(_idGenerator.GetNewId(), request.Title, request.Content, request.Level, request.Type, request.FieldId, request.InstituteId);
			field.AddQuestion(question);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new FieldQuestionDto()
			{
				Title = question.Title.Value,
				Id = question.Id,
				Type = question.Type.Value,
				Level = question.Level.Value,
				Content = question.Content.Value
			};
		}
	}
}
