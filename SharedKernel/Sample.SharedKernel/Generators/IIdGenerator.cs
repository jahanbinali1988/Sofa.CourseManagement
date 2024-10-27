using System;

namespace Sofa.CourseManagement.SharedKernel.Generators
{
	public interface IIdGenerator
	{
		Guid GetNewId();
	}
}
