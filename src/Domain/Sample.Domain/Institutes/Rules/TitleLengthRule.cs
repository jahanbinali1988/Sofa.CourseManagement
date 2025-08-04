using Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans;
using Sofa.CourseManagement.Domain.Institutes.Services;
using Sofa.SharedKernel.SeedWork;
using Sofa.SharedKernel.Shared;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Domain.Institutes.Rules
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

        public Task<bool> IsBroken() => Task.FromResult(_titleLengthService.IsValid(_title));
    }
}
