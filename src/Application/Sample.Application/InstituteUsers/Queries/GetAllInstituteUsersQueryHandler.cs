using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.InstituteUsers.Queries
{
	internal class GetAllInstituteUsersQueryHandler : IQueryHandler<GetAllInstituteUsersQuery, Pagination<InstituteUserDto>>
	{
		private readonly IUserRepository _userRepository;
		private readonly IInstituteRepository _instituteRepository;
		public GetAllInstituteUsersQueryHandler(IUserRepository userRepository, IInstituteRepository instituteRepository)
		{
			_userRepository = userRepository;
			_instituteRepository = instituteRepository;
		}

		public async Task<Pagination<InstituteUserDto>> Handle(GetAllInstituteUsersQuery request, CancellationToken cancellationToken)
		{
			List<InstituteUserDto> instituteUsers = new List<InstituteUserDto>();
			if (request.UserId == null)
				instituteUsers = await GetInstituteUsersByUserIdAsync(request.UserId.Value, cancellationToken);
			else
				instituteUsers = await GetInstituteUsersByInstituteIdAsync(request.InstituteId.Value, cancellationToken);

			return new Pagination<InstituteUserDto>()
			{
				TotalItems = instituteUsers.Count,
				Items = instituteUsers.Skip(request.Count * request.Offset - 1).Take(request.Count)
			};
		}

		private async Task<List<InstituteUserDto>> GetInstituteUsersByInstituteIdAsync(Guid instituteId, CancellationToken cancellationToken)
		{
			var institute = await _instituteRepository.GetAsync(instituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {instituteId}");

			return institute.InstituteUsers.Select(s => new InstituteUserDto()
			{
				Id = s.Id,
				UserId = s.UserId,
				InstituteId = s.InstituteId,
				FirstName = s.User.FirstName.Value,
				InstituteTitle = s.Institute.Title.Value,
				LastName = s.User.LastName.Value,
				UserName = s.User.UserName.Value,
				UserPhoneNumber = s.User.PhoneNumber.Value
			}).ToList();
		}

		private async Task<List<InstituteUserDto>> GetInstituteUsersByUserIdAsync(Guid userId, CancellationToken cancellationToken)
		{

			var user = await _userRepository.GetAsync(userId, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Unable to find user with Id {userId}");

			return user.InstituteUsers.Select(s => new InstituteUserDto()
			{
				Id = s.Id,
				UserId = s.UserId,
				InstituteId = s.InstituteId,
				FirstName = s.User.FirstName.Value,
				InstituteTitle = s.Institute.Title.Value,
				LastName = s.User.LastName.Value,
				UserName = s.User.UserName.Value,
				UserPhoneNumber = s.User.PhoneNumber.Value
			}).ToList();
		}
	}
}
