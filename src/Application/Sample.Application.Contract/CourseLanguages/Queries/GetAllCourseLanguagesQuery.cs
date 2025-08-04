using Sofa.CourseManagement.Application.Contract.CourseLanguages.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

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

		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
	}
}
