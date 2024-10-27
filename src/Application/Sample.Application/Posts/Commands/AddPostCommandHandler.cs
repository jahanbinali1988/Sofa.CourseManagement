using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Application.Contract.Posts.Converter;
using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Posts.Commands
{
	internal class AddPostCommandHandler : ICommandHandler<AddPostCommand, PostBaseDto>
	{
		private readonly ILessonPlanRepository _lessonPlanRepository;
		private readonly IUnitOfWork _unitOfWork;
		public AddPostCommandHandler(ILessonPlanRepository lessonPlanRepository, IUnitOfWork unitOfWork)
		{
			_lessonPlanRepository = lessonPlanRepository;
			_unitOfWork = unitOfWork;
		}

		public Task<PostBaseDto> Handle(AddPostCommand request, CancellationToken cancellationToken)
		{
			var post = Convert(request);

			throw new NotImplementedException();
		}

		private PostBaseDto Convert(AddPostCommand request)
		{
			var post = PostFactory.Instance.SetContentType(request.ContentType).SetJson(request.Post.ToString()).CreatePost();

			return post;
		}
	}
}
