using Sofa.CourseManagement.Application.Contract.CourseLanguages.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CourseLanguages.Queries
{
	public class GetAllCourseLanguagesQuery : GetListQueryBase, IQuery<Pagination<CourseLanguageDto>>
	{
		public GetAllCourseLanguagesQuery(string instituteId, string fieldId, string courseId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
		}

		public string InstituteId { get; }
		public string FieldId { get; }
		public string CourseId { get; }
	}
}
