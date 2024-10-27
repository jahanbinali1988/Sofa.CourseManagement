using Sofa.CourseManagement.Application.Contract.Posts.Converter;
using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using System.ComponentModel;

namespace Sofa.CourseManagement.Application.Contract.Posts.Dtos
{
	[TypeConverter(typeof(PostConverter<VideoPostDto>))]
	public class VideoPostDto : PostBaseDto
	{
	}
}
