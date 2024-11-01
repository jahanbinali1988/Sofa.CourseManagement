using MediatR;
using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Application.Contract.Posts.Converter;
using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Commands
{
	internal class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommand>
	{
		private readonly IInstituteRepository _repository;
		private readonly IUnitOfWork _unitOfWork;
		public UpdatePostCommandHandler(IInstituteRepository repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
		{
			var post = Convert(request);
			throw new NotImplementedException();
		}

		private PostBaseDto Convert(UpdatePostCommand request)
		{
			var post = PostFactory.Instance.SetContentType(request.ContentType).SetJson(request.Post.ToString()).CreatePost();

			return post;
		}
	}
}
