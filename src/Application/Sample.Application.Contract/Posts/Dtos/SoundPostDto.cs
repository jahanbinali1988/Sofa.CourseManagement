using Sofa.CourseManagement.Application.Contract.Posts.Converter;
using System.ComponentModel;

namespace Sofa.CourseManagement.Application.Contract.Posts.Dtos
{
	[TypeConverter(typeof(PostConverter<SoundPostDto>))]
	public class SoundPostDto : PostBaseDto
	{
	}
}
