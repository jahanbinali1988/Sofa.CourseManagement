using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Models.Posts
{
	public class PostBaseViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public short Order { get; set; }
		public string Content { get; set; }
		public ContentTypeEnum ContentType { get; set; }
		public string LessonPlanId { get; set; }

		internal static PostBaseViewModel Create(PostBaseDto post)
		{
			switch (post.ContentType)
			{
				case ContentTypeEnum.Text:
					return new TextPostViewModel(post);
				case ContentTypeEnum.Image:
					return new ImagePostViewModel(post);
				case ContentTypeEnum.Sound:
					return new SoundPostViewModel(post);
				case ContentTypeEnum.Video:
					return new VideoPostViewModel(post);
			}
			throw new NotImplementedException();
		}
	}
	public static class PostBaseMapper
	{
		public static Pagination<PostBaseViewModel> Map(this Pagination<PostBaseDto> dto)
		{
			return new Pagination<PostBaseViewModel>
			{
				TotalItems = dto.TotalItems,
				Items = dto.Items.Select(s => PostBaseViewModel.Create(s))
			};
		}
	}
}
