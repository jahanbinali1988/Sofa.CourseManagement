﻿using Sofa.CourseManagement.Application.Contract.Courses.Commands;
using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Exceptions;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.Generators;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Courses.Commands
{
	internal class AddCourseCommandHandler : ICommandHandler<AddCourseCommand, CourseDto>
	{
		private readonly IInstituteRepository _instituteRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public AddCourseCommandHandler(IInstituteRepository instituteRepository, IUnitOfWork unitOfWork, IIdGenerator idGenerator)
		{
			_instituteRepository = instituteRepository;
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<CourseDto> Handle(AddCourseCommand request, CancellationToken cancellationToken)
		{

			var institute = await _instituteRepository.GetAsync(request.InstituteId, cancellationToken);
			if (institute == null)
				throw new EntityNotFoundException($"Could not find Institute entity with Id {request.InstituteId}");

			var field = institute.Fields.SingleOrDefault(c => c.Id == request.FieldId);
			if (field == null)
				throw new EntityNotFoundException($"Could not find field entity with Id {request.FieldId}");

			var course = Course.CreateInstance(_idGenerator.GetNewId(), request.Title, request.AgeRange, request.FieldId);
			field.AddCourse(course);

			await _unitOfWork.CommitAsync(cancellationToken);

			return new CourseDto()
			{
				FieldId = course.FieldId,
				AgeRange = course.AgeRange.Value,
				Title = course.Title.Value,
				InstituteId = request.InstituteId,
				Id = course.Id
			};
		}
	}
}