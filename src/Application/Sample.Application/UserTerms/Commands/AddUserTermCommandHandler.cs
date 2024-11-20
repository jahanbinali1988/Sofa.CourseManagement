using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.UserTerms.Commands;
using Sofa.CourseManagement.Application.Contract.UserTerms.Dtos;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.UserTerms.Commands
{
	internal class AddUserTermCommandHandler : ICommandHandler<AddUserTermCommand, UserTermDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddUserTermCommandHandler(IIdGenerator idGenerator, ICourseManagementUnitOfWork unitOfWork)
		{
			_idGenerator = idGenerator;
			_unitOfWork = unitOfWork;
		}

		public async Task<UserTermDto> Handle(AddUserTermCommand request, CancellationToken cancellationToken)
		{
			if (request.InstituteId == null)
				return await AddByUserAsync(request.UserId.Value, request.TermId.Value, cancellationToken);
			else
				return await AddByTermAsync(request.InstituteId.Value, request.FieldId.Value, request.CourseId.Value, request.TermId.Value, request.UserId.Value, cancellationToken);
		}

		private async Task<UserTermDto> AddByTermAsync(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid userId, CancellationToken cancellationToken)
		{
			var institute = await _unitOfWork.InstituteRepository.GetAsync(instituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {instituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == fieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find Field entity with Id {fieldId}");

			var course = field.Courses.SingleOrDefault(c => c.Id == courseId);
			if (course == null)
				throw new EntityNotFoundException($"Could not find Course entity with Id {courseId}");

			var term = course.Terms.SingleOrDefault(c => c.Id == termId);
			if (term == null)
				throw new EntityNotFoundException($"Could not find Term entity with Id {termId}");

			var user = await _unitOfWork.UserRepository.GetAsync(userId, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Could not find User entity with Id {userId}");

			var userTerm = UserTerm.CreateInstance(_idGenerator.GetNewId(), userId, termId);
			term.AddUser(userTerm);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new UserTermDto()
			{
				FirstName = user.FirstName.Value,
				Id = userTerm.Id,
				LastName = user.LastName.Value,
				TermId = userTerm.TermId,
				TermTitle = userTerm.Term.Title.Value,
				UserId = user.Id,
				UserName = user.UserName.Value,
				UserPhoneNumber = user.PhoneNumber.Value,
			};
		}

		private async Task<UserTermDto> AddByUserAsync(Guid userId, Guid termId, CancellationToken cancellationToken)
		{
			var user = await _unitOfWork.UserRepository.GetAsync(userId, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Could not find User entity with Id {userId}");

			var userTerm = UserTerm.CreateInstance(_idGenerator.GetNewId(), userId, termId);
			user.AddTerm(userTerm);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new UserTermDto()
			{
				FirstName = user.FirstName.Value,
				Id = userTerm.Id,
				LastName = user.LastName.Value,
				TermId = userTerm.TermId,
				TermTitle = userTerm.Term.Title.Value,
				UserId = user.Id,
				UserName = user.UserName.Value,
				UserPhoneNumber = user.PhoneNumber.Value,
			};
		}
	}
}
