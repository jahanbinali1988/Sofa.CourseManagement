using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;

namespace Sofa.CourseManagement.RestApi.Models.Sessions
{
	public class SessionViewModel : ViewModelBase
	{
        public string Title { get; set; }
		public string CourseId { get; set; }
		public string CourseTitle { get; set; }
		public string FieldId { get; set; }
		public string FieldTitle { get; set; }
		public string InstituteId { get; set; }
		public string InstituteTitle { get; set; }

		internal static SessionViewModel Create(SessionDto session)
		{
			return new SessionViewModel 
			{ 
				Id = session.Id, 
				Title = session.Title, 
				CourseId = session.CourseId,
				CourseTitle = session.CourseTitle,
				FieldId = session.FieldId,
				FieldTitle = session.FieldTitle,
				InstituteId = session.InstituteId,
				InstituteTitle = session.InstituteTitle,
			};
		}
	}
}
