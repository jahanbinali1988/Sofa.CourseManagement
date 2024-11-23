using System;

namespace Sofa.CourseManagement.Application.Contract.Shared
{
	public abstract class GetByIdQueryBase
	{
		protected GetByIdQueryBase(Guid id)
		{
			Id = id;
		}
		protected GetByIdQueryBase(string id)
		{
			Id = id;
		}
		public Id Id { get; set; }
	}
}
