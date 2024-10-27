using System;

namespace Sofa.CourseManagement.Application.Contract.Shared
{
	public abstract class GetByIdQueryBase
	{
		protected GetByIdQueryBase(Guid id)
		{
			Id = id;
		}
		public Guid Id { get; set; }
	}
}
