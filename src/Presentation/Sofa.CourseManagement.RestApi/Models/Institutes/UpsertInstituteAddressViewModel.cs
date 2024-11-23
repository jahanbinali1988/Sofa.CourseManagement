using Sofa.CourseManagement.Application.Contract.Institutes.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Institutes
{
	public class UpsertInstituteAddressViewModel : ViewModelBase
	{
		public String Street { get; set; }
		public String City { get; set; }
		public String State { get; set; }
		public String Country { get; set; }
		public String ZipCode { get; set; }
        public Id UserId { get; set; }

        internal UpdateInstituteAddressCommand ToCommand(string id)
		{
			return new UpdateInstituteAddressCommand()
			{
				UserId = id,
				City = City,
				Country	= Country,
				ZipCode = ZipCode,
				State = State,
				Street = Street
			};
		}
	}
}
