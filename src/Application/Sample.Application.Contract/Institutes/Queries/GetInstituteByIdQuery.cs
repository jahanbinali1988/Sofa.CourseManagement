using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Queries
{
	public class GetInstituteByIdQuery : GetByIdQueryBase, IQuery<InstituteDto>
	{
		public GetInstituteByIdQuery(string id) : base(id)
		{
		}
	}
}
