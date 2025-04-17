using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.Application.Contract.CourseLanguages.Dtos
{
	public class CourseLanguageDto : EntityBaseDto
	{
		public Id InstituteId { set; get; }
		public Id FieldId { set; get; }
		public Id CourseId { set; get; }
		public LanguageEnum Language { set; get; }
		public string CourseTitle { set; get; }
	}
}
