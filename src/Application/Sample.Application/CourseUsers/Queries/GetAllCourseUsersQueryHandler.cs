using Sofa.CourseManagement.Application.Contract.CourseUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.CourseUsers.Queries;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.CourseUsers.Queries
{
	internal class GetAllCourseUsersQueryHandler : IQueryHandler<GetAllCourseUsersQuery, Pagination<CourseUserDto>>
	{
		private readonly IUserRepository _userRepository;
		private readonly IInstituteRepository _instituteRepository;
		public GetAllCourseUsersQueryHandler(IUserRepository userRepository, IInstituteRepository instituteRepository)
		{
			_userRepository = userRepository;
			_instituteRepository = instituteRepository;
		}

		public async Task<Pagination<CourseUserDto>> Handle(GetAllCourseUsersQuery request, CancellationToken cancellationToken)
		{
			List<CourseUserDto> courseUsers = new List<CourseUserDto>();
			if (request.UserId == null)
				courseUsers = await GetCourseUserByUserIdAsync(request.UserId.Value, request.InstituteId.Value, request.FieldId, request.CourseId, cancellationToken);
			else
				courseUsers = await GetCourseUserByCourseIdAsync(request.InstituteId.Value, request.FieldId, request.CourseId, cancellationToken);

			return new Pagination<CourseUserDto>()
			{
				TotalItems = courseUsers.Count,
				Items = courseUsers.Skip(request.Count * request.Offset - 1).Take(request.Count)
			};
		}

		private async Task<List<CourseUserDto>> GetCourseUserByCourseIdAsync(Guid instituteId, Guid fieldId, Guid courseId, CancellationToken cancellationToken)
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

			return course.CourseUsers.Select(s => new CourseUserDto()
			{
				FirstName = s.User.FirstName.Value,
				LastName = s.User.LastName.Value,
				Id = s.Id,
				CourseId = s.CourseId,
				CourseTitle = course.Title.Value,
				UserId = s.UserId,
				UserName = s.User.UserName.Value,
				UserPhoneNumber = s.User.PhoneNumber.Value,
			}).ToList();
		}

		private async Task<List<CourseUserDto>> GetCourseUserByUserIdAsync(Guid userId, Guid instituteId, Guid fieldId, Guid courseId, CancellationToken cancellationToken)
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

			var user = await _userRepository.GetAsync(userId, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Unable to find user with Id {userId}");

			return user.CourseUsers.Select(s => new CourseUserDto()
			{
				FirstName = s.User.FirstName.Value,
				LastName = s.User.LastName.Value,
				Id = s.Id,
				CourseId = s.CourseId,
				CourseTitle = course.Title.Value,
				UserId = s.UserId,
				UserName = s.User.UserName.Value,
				UserPhoneNumber = s.User.PhoneNumber.Value,
			}).ToList();
		}
	}
}
