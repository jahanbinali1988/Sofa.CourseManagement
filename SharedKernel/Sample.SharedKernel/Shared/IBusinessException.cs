namespace Sofa.CourseManagement.SharedKernel.Shared
{
	public interface IBusinessException
	{
		string? GetCode();

		string GetMessage();
	}
}
