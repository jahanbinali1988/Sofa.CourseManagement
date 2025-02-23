using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Application.Contract.UserTerms.Commands;
using Sofa.CourseManagement.Application.Contract.UserTerms.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.UserTerms.Commands
{
	internal class AddCourseUserCommandHandler : ICommandHandler<AddCourseUserCommand, CourseUserDto>
	{
		private readonly ICourseManagementUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddCourseUserCommandHandler(IIdGenerator idGenerator, ICourseManagementUnitOfWork unitOfWork)
		{
			_idGenerator = idGenerator;
			_unitOfWork = unitOfWork;
		}

		public async Task<CourseUserDto> Handle(AddCourseUserCommand request, CancellationToken cancellationToken)
		{
			if (request.InstituteId == null)
				return await AddByUserAsync(request.UserId.Value, request.InstituteId.Value, request.FieldId.Value, request.CourseId.Value, cancellationToken);
			else
				return await AddByCourseAsync(request.InstituteId.Value, request.FieldId.Value, request.CourseId.Value, request.UserId.Value, cancellationToken);
		}

		private async Task<CourseUserDto> AddByCourseAsync(Guid instituteId, Guid fieldId, Guid courseId, Guid userId, CancellationToken cancellationToken)
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

			var user = await _unitOfWork.UserRepository.GetAsync(userId, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Could not find User entity with Id {userId}");

			var courseUser = CourseUser.CreateInstance(_idGenerator.GetNewId(), courseId, userId);
			course.AddUser(courseUser);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new CourseUserDto()
			{
				FirstName = user.FirstName.Value,
				Id = courseUser.Id,
				LastName = user.LastName.Value,
				CourseId = courseUser.CourseId,
				CourseTitle = course.Title.Value,
				UserId = user.Id,
				UserName = user.UserName.Value,
				UserPhoneNumber = user.PhoneNumber.Value,
			};
		}

		private async Task<CourseUserDto> AddByUserAsync(Guid userId, Guid instituteId, Guid fieldId, Guid courseId, CancellationToken cancellationToken)
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

			var user = await _unitOfWork.UserRepository.GetAsync(userId, cancellationToken);
			if (user == null)
				throw new EntityNotFoundException($"Could not find User entity with Id {userId}");

			var courseUser = CourseUser.CreateInstance(_idGenerator.GetNewId(), courseId, userId);
			user.AddCourse(courseUser);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new CourseUserDto()
			{
				FirstName = user.FirstName.Value,
				Id = courseUser.Id,
				LastName = user.LastName.Value,
				CourseId = course.Id,
				CourseTitle = course.Title.Value,
				UserId = user.Id,
				UserName = user.UserName.Value,
				UserPhoneNumber = user.PhoneNumber.Value,
			};
		}
	}
}
