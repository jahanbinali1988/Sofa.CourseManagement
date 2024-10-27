using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Posts.Queries;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.SharedKernel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Queries
{
	internal class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, PostBaseDto>
	{
		private readonly ILessonPlanRepository _lessonPlanRepository;
		public GetPostByIdQueryHandler(ILessonPlanRepository lessonPlanRepository)
		{
			_lessonPlanRepository = lessonPlanRepository;
		}

		public Task<PostBaseDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
