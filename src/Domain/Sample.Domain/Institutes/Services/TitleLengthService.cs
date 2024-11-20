using Sofa.CourseManagement.Domain.Shared.Constants;

namespace Sofa.CourseManagement.Domain.Institutes.Services
{
	public interface ITitleLengthService
    {
        bool IsValid(string value);
    }
    public class TitleLengthService : ITitleLengthService
    {
        public bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length > ConstantValues.MaxStringTitleLength)
                return false;

            return true;
        }
    }
}
