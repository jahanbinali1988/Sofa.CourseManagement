using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.PostQuestions.Dtos;
using Sofa.SharedBusinessEntities;

namespace Sofa.CourseManagement.RestApi.Models.Posts
{
	public class PostQuestionViewModel : ViewModelBase
	{
		public PriorityEnum Priority { get; set; }
		public string QuestionId { get; set; }
		public string QuestionTitle { get; set; }
		public string PostId { get; set; }
		public string PostTitle { get; set; }

		internal static PostQuestionViewModel Create(PostQuestionDto postQuestion)
		{
			return new PostQuestionViewModel()
			{
				Id = postQuestion.Id,
				PostId = postQuestion.PostId,
				PostTitle = postQuestion.PostTitle,
				Priority = postQuestion.Priority,
				QuestionId = postQuestion.QuestionId,
				QuestionTitle = postQuestion.QuestionTitle
			};
		}
	}
}
