using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.UserTerms.Dtos;
using Sofa.CourseManagement.Application.Contract.UserTerms.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.UserTerms.Queries
{
	internal class GetAllUserTermsQueryHandler : IQueryHandler<GetAllUserTermsQuery, Pagination<UserTermDto>>
	{
		private readonly IUserRepository _userRepository;
		private readonly IInstituteRepository _instituteRepository;
		public GetAllUserTermsQueryHandler(IUserRepository userRepository, IInstituteRepository instituteRepository)
		{
			_userRepository = userRepository;
			_instituteRepository = instituteRepository;
		}

		public async Task<Pagination<UserTermDto>> Handle(GetAllUserTermsQuery request, CancellationToken cancellationToken)
		{
			List<UserTermDto> userTerms = new List<UserTermDto>();
			if (request.UserId == null)
				userTerms = await GetUserTermByUserIdAsync(request.UserId.Value, cancellationToken);
			else
				userTerms = await GetUserTermByTermIdAsync(request.InstituteId.Value, request.FieldId, request.CourseId, request.TermId, cancellationToken);

			return new Pagination<UserTermDto>()
			{
				TotalItems = userTerms.Count,
				Items = userTerms.Skip(request.Count * request.Offset - 1).Take(request.Count)
			};
		}

		private async Task<List<UserTermDto>> GetUserTermByTermIdAsync(Guid instituteId, Guid fieldId, Guid courseId, Guid? termId, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(instituteId, cancellationToken);
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

			return term.UserTerms.Select(s=> new UserTermDto()
			{
				FirstName = s.User.FirstName.Value,
				LastName = s.User.LastName.Value,
				Id = s.Id,
				TermId = s.TermId,
				TermTitle = s.Term.Title.Value,
				UserId = s.UserId,
				UserName = s.User.UserName.Value,
				UserPhoneNumber = s.User.PhoneNumber.Value,
			}).ToList();
		}

		private async Task<List<UserTermDto>> GetUserTermByUserIdAsync(Guid userId, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetAsync(userId, cancellationToken);
			if(user == null)
				throw new EntityNotFoundException($"Unable to find user with Id {userId}");

			return user.UserTerms.Select(s => new UserTermDto()
			{
				FirstName = s.User.FirstName.Value,
				LastName = s.User.LastName.Value,
				Id = s.Id,
				TermId = s.TermId,
				TermTitle = s.Term.Title.Value,
				UserId = s.UserId,
				UserName = s.User.UserName.Value,
				UserPhoneNumber = s.User.PhoneNumber.Value,
			}).ToList();
		}
	}
}
