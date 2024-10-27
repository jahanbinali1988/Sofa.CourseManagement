using Sofa.CourseManagement.Domain.LessonPlans.Services;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using Sofa.CourseManagement.SharedKernel.Shared;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Domain.LessonPlans.Rules
{
	public class TitleLengthRule : IBusinessRule
    {
        private readonly ITitleLengthService _titleLengthService;
        private readonly string _title;
        public TitleLengthRule(ITitleLengthService titleLengthService, string title)
        {
			_titleLengthService = titleLengthService;
            _title = title;
        }

        public string Message => $"Unable to set value {_title}";

        public string[] Properties => new[] { nameof(LessonPlan.Title) };

        public string ErrorType => BusinessRuleType.IdValidity.ToString("G");

        public Task<bool> IsBroken() => Task.FromResult<bool>(_titleLengthService.IsValid(_title));
    }
}
