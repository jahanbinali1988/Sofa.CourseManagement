using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Posts.Queries;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Queries
{
	internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, Pagination<PostBaseDto>>
	{
		private readonly IInstituteRepository _repository;
		private readonly IUnitOfWork _unitOfWork;
		public GetAllPostsQueryHandler(IInstituteRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public Task<Pagination<PostBaseDto>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
