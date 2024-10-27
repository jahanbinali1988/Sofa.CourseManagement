using Sofa.CourseManagement.Application.Contract.Posts.Dtos;

namespace Sofa.CourseManagement.RestApi.Models.Posts
{
	public class ImagePostViewModel : PostBaseViewModel
	{
        public ImagePostViewModel()
        {
            
        }
        public ImagePostViewModel(PostBaseDto post)
		{
			base.Id = post.Id;
			base.Order = post.Order;
			base.Content = post.Content;
			base.ContentType = post.ContentType;
			base.Title = post.Title;
			base.LessonPlanId = post.LessonPlanId;
		}
	}
}
