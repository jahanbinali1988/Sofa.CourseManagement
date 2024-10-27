using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using System;
using System.ComponentModel;

namespace Sofa.CourseManagement.Application.Contract.Posts.Converter
{
	public class PostFactory
	{
		public static PostFactory Instance
		{
			get
			{
				var result = new PostFactory();

				return result;
			}
		}

		private dynamic _json;
		private ContentTypeEnum _contentType;

		public PostFactory SetContentType(ContentTypeEnum activityType)
		{
			_contentType = activityType;
			return this;
		}
		public PostFactory SetJson(dynamic json)
		{
			_json = json;
			return this;
		}

		public PostBaseDto CreatePost()
		{
			if (string.IsNullOrEmpty(_json))
				throw new ArgumentException($"Unable to cast the given input json {_json}");

			switch (_contentType)
			{
				case ContentTypeEnum.Text:
					return (TextPostDto)TypeDescriptor.GetConverter(typeof(TextPostDto)).ConvertTo(_json, typeof(TextPostDto))!;
				case ContentTypeEnum.Sound:
					return (SoundPostDto)TypeDescriptor.GetConverter(typeof(SoundPostDto)).ConvertTo(_json, typeof(SoundPostDto))!;
				case ContentTypeEnum.Video:
					return (VideoPostDto)TypeDescriptor.GetConverter(typeof(VideoPostDto)).ConvertTo(_json, typeof(VideoPostDto))!;
				case ContentTypeEnum.Image:
					return (ImagePostDto)TypeDescriptor.GetConverter(typeof(ImagePostDto)).ConvertTo(_json, typeof(ImagePostDto))!;
				default:
					throw new ArgumentException();
			}
		}
	}
}
