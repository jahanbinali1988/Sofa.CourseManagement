﻿using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Commands
{
	public class UpdateInstituteAddressCommand : CommandBase
	{
        public Id UserId { get; set; }
        public String Street { get; set; }
		public String City { get; set; }
		public String State { get; set; }
		public String Country { get; set; }
		public String ZipCode { get; set; }
	}
}
