using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Commands
{
	public class UpdateInstituteAddressCommand
	{
        public Guid Id { get; set; }
        public String Street { get; set; }
		public String City { get; set; }
		public String State { get; set; }
		public String Country { get; set; }
		public String ZipCode { get; set; }
	}
}
