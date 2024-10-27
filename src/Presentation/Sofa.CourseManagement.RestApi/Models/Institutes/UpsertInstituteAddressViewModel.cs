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

		internal UpdateInstituteAddressCommand ToCommand(Guid id)
		{
			return new UpdateInstituteAddressCommand()
			{
				Id = id,
				City = City,
				Country	= Country,
				ZipCode = ZipCode,
				State = State,
				Street = Street
			};
		}
	}
}
