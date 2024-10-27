﻿using MediatR;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.LessonPlans.Commands
{
	internal class DeleteLessonPlanCommandHandler : ICommandHandler<DeleteLessonPlanCommand>
	{
		private readonly ILessonPlanRepository _lessonPlanRepository;
		private readonly IUnitOfWork _unitOfWork;
		public DeleteLessonPlanCommandHandler(ILessonPlanRepository lessonPlanRepository, IUnitOfWork unitOfWork)
		{
			_lessonPlanRepository = lessonPlanRepository;
			_unitOfWork = unitOfWork;
		}

		public Task<Unit> Handle(DeleteLessonPlanCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}