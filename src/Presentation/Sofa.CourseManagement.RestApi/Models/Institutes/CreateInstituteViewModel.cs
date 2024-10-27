using Sofa.CourseManagement.Application.Contract.Institutes.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Institutes
{
	public class CreateInstituteViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public string WebsiteUrl { get; set; }
		public string Code { get; set; }

		internal AddInstituteCommand ToCommand()
		{
			return new AddInstituteCommand()
			{
				Title = this.Title,
				WebsiteUrl = this.WebsiteUrl,
				Code = this.Code
			};
		}
		internal UpdateInstituteCommand ToCommand(Guid id)
		{
			return new UpdateInstituteCommand()
			{
				Id = id,
				Title = this.Title,
				WebsiteUrl = this.WebsiteUrl,
				Code = this.Code
			};
		}
	}
}
