using MediatR;
using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Commands
{
	internal class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
	{
		private readonly ILessonPlanRepository _lessonPlanRepository;
		private readonly IUnitOfWork _unitOfWork;
		public DeletePostCommandHandler(ILessonPlanRepository lessonPlanRepository, IUnitOfWork unitOfWork)
		{
			_lessonPlanRepository = lessonPlanRepository;
			_unitOfWork = unitOfWork;
		}

		public Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
