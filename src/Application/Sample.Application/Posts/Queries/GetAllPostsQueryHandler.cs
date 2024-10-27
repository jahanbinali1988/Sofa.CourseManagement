using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Posts.Queries;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Queries
{
	internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, Pagination<PostBaseDto>>
	{
		private readonly ILessonPlanRepository _lessonPlanRepository;
		public GetAllPostsQueryHandler(ILessonPlanRepository lessonPlanRepository)
		{
			_lessonPlanRepository = lessonPlanRepository;
		}

		public Task<Pagination<PostBaseDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
