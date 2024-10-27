using System;

namespace Sofa.CourseManagement.SharedKernel.Generators
{
	public class IdGenerator : IIdGenerator
	{
		public Guid GetNewId()
		{
			return Guid.NewGuid();
		}
	}
}
